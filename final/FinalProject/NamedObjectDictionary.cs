using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonNamedObjectDictionary<JNO> : JsonNamedObject where JNO : JsonNamedObject
    {
        protected NamedObjectDictionary<NamedObject> NamedObjectDictionary { get; set; }
        [JsonInclude]
        [JsonPropertyName("NODDictionary")]
        public Dictionary<String, JNO> Dictionary
        {
            get
            {
                Dictionary<String, JNO> dictionary = new();
                foreach (String key in NamedObjectDictionary.Keys)
                {
                    dictionary.Add(key, (JNO)NamedObjectDictionary[key]);
                }
                return dictionary;
            }
            set
            {
                NamedObjectDictionary.Clear();
                foreach (String key in value.Keys)
                {
                    NamedObjectDictionary.Add(key, value[key]);
                }
            }
        }
        [JsonConstructor]
        public JsonNamedObjectDictionary(JsonName name, Dictionary<String, JNO> dictionary) : base(name)
        {
            Dictionary = dictionary;
        }
        public JsonNamedObjectDictionary(NamedObjectDictionary<NamedObject> namedObjectDictionary) : base((NamedObject)namedObjectDictionary)
        {
        }
        public static implicit operator JsonNamedObjectDictionary<JNO>(NamedObjectDictionary<NamedObject> namedObjectDictionary)
        {
            return new(namedObjectDictionary);
        }
        public static implicit operator NamedObjectDictionary<NamedObject>(JsonNamedObjectDictionary<JNO> namedObjectDictionary)
        {
            return namedObjectDictionary.NamedObjectDictionary;
        }
    }
    public abstract class NamedObjectDictionary<NO> : NamedObject, IDictionary<String, NO> where NO : NamedObject
    {
        protected Dictionary<String, NO> Dictionary { get; set; }
        public ICollection<String> Keys => ((IDictionary<String, NO>)Dictionary).Keys;
        public ICollection<NO> Values => ((IDictionary<String, NO>)Dictionary).Values;
        public int Count => ((ICollection<KeyValuePair<String, NO>>)Dictionary).Count;
        public bool IsReadOnly => ((ICollection<KeyValuePair<String, NO>>)Dictionary).IsReadOnly;
        public NO this[String key] { get => ((IDictionary<String, NO>)Dictionary)[key]; set => ((IDictionary<String, NO>)Dictionary)[key] = value; }
        protected override void Init(Boolean empty = true)
        {
            base.Init(empty);
        }
        protected override void Init(NameType type, Boolean empty = true)
        {
            base.Init(type, empty);
        }
        protected override void Init(Name name)
        {
            base.Init(name);
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter collection name.");
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
        }
        protected override void DisplaySetName()
        {
            Console.WriteLine("\nSet collection name");
        }
        protected override void DisplayRequestReSetName()
        {
            Console.WriteLine("\nRename collection?");
        }
        protected override void DisplayRequestSetName()
        {
            Console.WriteLine("\nWhat is the collection name?");
        }
        public void Add(String key, NO value)
        {
            ((IDictionary<String, NO>)Dictionary).Add(key, value);
        }
        public bool ContainsKey(String key)
        {
            return ((IDictionary<String, NO>)Dictionary).ContainsKey(key);
        }
        public bool Remove(String key)
        {
            return ((IDictionary<String, NO>)Dictionary).Remove(key);
        }
        public bool TryGetValue(String key, [MaybeNullWhen(false)] out NO value)
        {
            return ((IDictionary<String, NO>)Dictionary).TryGetValue(key, out value);
        }
        public void Add(KeyValuePair<String, NO> item)
        {
            ((ICollection<KeyValuePair<String, NO>>)Dictionary).Add(item);
        }
        public void Clear()
        {
            ((ICollection<KeyValuePair<String, NO>>)Dictionary).Clear();
        }
        public bool Contains(KeyValuePair<String, NO> item)
        {
            return ((ICollection<KeyValuePair<String, NO>>)Dictionary).Contains(item);
        }
        public void CopyTo(KeyValuePair<String, NO>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<String, NO>>)Dictionary).CopyTo(array, arrayIndex);
        }
        public bool Remove(KeyValuePair<String, NO> item)
        {
            return ((ICollection<KeyValuePair<String, NO>>)Dictionary).Remove(item);
        }
        public IEnumerator<KeyValuePair<String, NO>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<String, NO>>)Dictionary).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }
    }
}