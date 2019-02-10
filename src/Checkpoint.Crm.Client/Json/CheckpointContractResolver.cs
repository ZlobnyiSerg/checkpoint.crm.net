using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Checkpoint.Crm.Client.Json
{
    public class CheckpointContractResolver : FluentContractResolver
    {        
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.PropertyName = ConvertPropertyName(property.PropertyName);
            return property;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).Where(p=>!p.PropertyName.EndsWith("_specified")).ToList();
        }

        private string ConvertPropertyName(string propName)
        {
            var sb = new StringBuilder(propName.Length + 3);
            foreach (var c in propName)
            {
                if (char.IsUpper(c) && sb.Length > 0)
                {
                    sb.Append("_" + c);
                } else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToLowerInvariant();
        }
    }
}
