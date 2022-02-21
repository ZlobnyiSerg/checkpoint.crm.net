using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Checkpoint.Crm.Core.Models.Customers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Checkpoint.Crm.Client.Json
{
    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            ContractResolver = new CheckpointContractResolver()
                .AddSettings<Customer>(c =>
                {
                    c.RuleFor(ct => ct.BirthDate).Converter(new DateFormatter());
                    c.RuleFor(ct => ct.DocIssueDate).Converter(new DateFormatter());
                    c.RuleFor(ct => ct.DocExpirationDate).Converter(new DateFormatter());
                }),
            NullValueHandling = NullValueHandling.Ignore,            
            Formatting = Formatting.Indented,
            Converters =
            {
                new StringEnumConverter(),
                new DecimalJsonConverter()
            }
        };      

        public string DateFormat { get; set; }        

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string ContentType { get; set; }

        public NewtonsoftJsonSerializer()
        {
            ContentType = "application/json";
        }

        public string Serialize(object obj)
        {
            using var stringWriter = new StringWriter();
            using var jsonTextWriter = new JsonTextWriter(stringWriter);
            Serializer.Serialize(jsonTextWriter, obj);
            return stringWriter.ToString();
        }

        public T Deserialize<T>(IRestResponse response)
        {
            using var stringReader = new StringReader(response.Content);
            using var jsonTextReader = new JsonTextReader(stringReader);
            return Serializer.Deserialize<T>(jsonTextReader);
        }
    }
}