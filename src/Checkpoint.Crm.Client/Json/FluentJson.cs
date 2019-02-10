using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Checkpoint.Crm.Client.Json
{
    public abstract class Rule
    {
        private readonly Dictionary<string, object> _rule = new Dictionary<string, object>();

        protected void AddRule(string key, object value)
        {
            if (_rule.ContainsKey(key))
            {
                _rule.Add(key, value);
            }
            else
            {
                _rule[key] = value;
            }
        }

        protected IEnumerable<KeyValuePair<string, object>> RegisteredRules => _rule.AsEnumerable();
    }

    public abstract class PropertyRule : Rule
    {
        public MemberInfo PropertyInfo { get; protected set; }

        public void Update(JsonProperty contract)
        {
            var props = typeof(JsonProperty).GetProperties();
            foreach (var rule in RegisteredRules)
            {                
                var property = props.FirstOrDefault(x => x.Name == rule.Key);
                if (property != null)
                {
                    var value = rule.Value;
                    if (property.PropertyType.IsInstanceOfType(value))
                    {
                        property.SetValue(contract, value);
                    }
                }
            }
        }
    }

    public class PropertyRule<TClass, TProp> : PropertyRule
    {
        public const string ConverterKey = "Converter";
        public const string PropertyNameKey = "PropertyName";
        public const string IgnoredKey = "Ignored";

        public PropertyRule(Expression<Func<TClass, TProp>> prop)
        {
            PropertyInfo = (prop.Body as MemberExpression)?.Member;
        }

        public PropertyRule<TClass, TProp> Converter(JsonConverter converter)
        {
            AddRule(ConverterKey, converter);
            return this;
        }

        public PropertyRule<TClass, TProp> Name(string propertyName)
        {
            AddRule(PropertyNameKey, propertyName);
            return this;
        }

        public PropertyRule<TClass, TProp> Ignore()
        {
            AddRule(IgnoredKey, true);
            return this;
        }
    }

    public interface ISerializationSettings
    {
        IEnumerable<Rule> Rules { get; }
    }

    public class SerializationSettings<T> : ISerializationSettings
    {
        private readonly List<Rule> _rules = new List<Rule>();

        public IEnumerable<Rule> Rules { get; }

        public SerializationSettings()
        {
            Rules = _rules.AsEnumerable();
        }

        public PropertyRule<T, TProp> RuleFor<TProp>(Expression<Func<T, TProp>> prop)
        {
            var rule = new PropertyRule<T, TProp>(prop);
            _rules.Add(rule);
            return rule;
        }
    }

    public class FluentContractResolver : DefaultContractResolver
    {
        private readonly List<ISerializationSettings> _settings = new List<ISerializationSettings>();

        public FluentContractResolver AddSettings<T>(Action<SerializationSettings<T>> configurer) where T : new()
        {
            var settings = new SerializationSettings<T>();
            configurer(settings);
            _settings.Add(settings);
            return this;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var contract = base.CreateProperty(member, memberSerialization);

            var rule = _settings.Where(x => x.GetType().GetTypeInfo().GenericTypeArguments[0] == member.DeclaringType).SelectMany(x => x.Rules.OfType<PropertyRule>().Where(r => r.PropertyInfo.Name == member.Name)).FirstOrDefault();
            rule?.Update(contract);
            return contract;
        }
    }
}