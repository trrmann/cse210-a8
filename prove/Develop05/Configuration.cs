using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Develop05
{
    [XmlType("KeyValue"), XmlRoot("KeyValue")]
    public class SerializableKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    internal static class SERIALIZABLE_KEY_VALUE_PAIR_EXTENSIONS
    {
        internal static SerializableKeyValuePair<TKey, TValue> TO_SERIALIZABLE_PAIR<TKey, TValue>(this KeyValuePair<TKey, TValue> pair)
        {
            return new SerializableKeyValuePair<TKey, TValue> { Key = pair.Key, Value = pair.Value };
        }
    }
    [DataContract]
    public class Configuration
    {
        [DataMember]
        [XmlIgnore]
        internal Dictionary<String, Object> Dictionary { get; set; } = new Dictionary<String, Object>();
        [IgnoreDataMember]
        [XmlArray("Dictionary")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public SerializableKeyValuePair<String, Object>[] ConfigurationArray
        {
            get
            {
                return Dictionary == null ? null : Dictionary.Select(p => p.TO_SERIALIZABLE_PAIR()).ToArray();
            }
            set
            {
                Dictionary = value == null ? null : value.ToDictionary(p => p.Key, p => p.Value);
            }
        }
    }
}