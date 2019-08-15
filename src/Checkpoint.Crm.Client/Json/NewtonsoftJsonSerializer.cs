using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Checkpoint.Crm.Client.Json
{
    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        private static readonly Lazy<NewtonsoftJsonSerializer> _default = new Lazy<NewtonsoftJsonSerializer>(LazyThreadSafetyMode.PublicationOnly);
        private readonly Newtonsoft.Json.JsonSerializer _serializer;      

        public string DateFormat { get; set; }        

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string ContentType { get; set; }

        public NewtonsoftJsonSerializer()
        {
            ContentType = "application/json";
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                Culture = new CultureInfo(string.Empty)
                {
                    NumberFormat = new NumberFormatInfo()
                    {
                        CurrencyDecimalDigits = 5
                    }
                }
            };
        }

        public NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    _serializer.Serialize(jsonTextWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(IRestResponse response)
        {
            using (var stringReader = new StringReader(response.Content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                    return _serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}