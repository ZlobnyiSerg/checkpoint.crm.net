using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Checkpoint.Crm.Client.Json
{
    class DecimalJsonConverter : JsonConverter<decimal>
    {
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString("F5", CultureInfo.InvariantCulture));
        }

        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}