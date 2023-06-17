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
    public static class SerializableKeyValuePairExtensions
    {
        public static SerializableKeyValuePair<TKey, TValue> ToSerializablePair<TKey, TValue>(this KeyValuePair<TKey, TValue> pair)
        {
            return new SerializableKeyValuePair<TKey, TValue> { Key = pair.Key, Value = pair.Value };
        }
    }
    [DataContract]
    public class Configuration
    {
        [DataMember]
        [XmlIgnore]
        public Dictionary<String, Object> Dictionary { get; set; } = new Dictionary<String, Object>();
        [IgnoreDataMember]
        [XmlArray("Dictionary")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public SerializableKeyValuePair<String, Object>[] ConfigurationArray
        {
            get
            {
                return Dictionary == null ? null : Dictionary.Select(p => p.ToSerializablePair()).ToArray();
            }
            set
            {
                Dictionary = value == null ? null : value.ToDictionary(p => p.Key, p => p.Value);
            }
        }
    }
}