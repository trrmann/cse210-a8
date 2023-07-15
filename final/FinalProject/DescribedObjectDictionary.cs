using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonDescribedObjectDictionary<JNO> : JsonDescribedObject where JNO : JsonNamedObject
    {
        protected DescribedObjectDictionary<NamedObject> DescribedObjectDictionary { get; set; }
        [JsonInclude]
        [JsonPropertyName("DescribedObjectDictionaryOfNamedObjects")]
        public Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects
        {
            get
            {
                Dictionary<String, JNO> dictionary = new();
                foreach (String key in DescribedObjectDictionary.Keys)
                {
                    dictionary.Add(key, (JNO)DescribedObjectDictionary[key]);
                }
                return dictionary;
            }
            set
            {
                DescribedObjectDictionary.Clear();
                foreach (String key in value.Keys)
                {
                    DescribedObjectDictionary.Add(key, value[key]);
                }
            }
        }
        [JsonConstructor]
        public JsonDescribedObjectDictionary(JsonName name, String description, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects) : base(name, description)
        {
            this.DescribedObjectDictionaryOfNamedObjects = DescribedObjectDictionaryOfNamedObjects;
        }
        public JsonDescribedObjectDictionary(DescribedObjectDictionary<NamedObject> describedObjectDictionary) : base((DescribedObject)describedObjectDictionary)
        {
        }
        public static implicit operator JsonDescribedObjectDictionary<JNO>(DescribedObjectDictionary<NamedObject> describedObjectDictionary)
        {
            return new(describedObjectDictionary);
        }
        public static implicit operator DescribedObjectDictionary<NamedObject>(JsonDescribedObjectDictionary<JNO> describedObjectDictionary)
        {
            return describedObjectDictionary.DescribedObjectDictionary;
        }
    }
    public abstract class DescribedObjectDictionary<NO> : DescribedObject, IDictionary<String, NO> where NO : NamedObject
    {
        internal Dictionary<String, NO> DescribedObjectDictionaryOfNamedObjects { get; set; } = new();
        public ICollection<String> Keys => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).Keys;
        public ICollection<NO> Values => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).Values;
        public int Count => ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).Count;
        public bool IsReadOnly => ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).IsReadOnly;
        public NO this[String key] { get => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects)[key]; set => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects)[key] = value; }
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
        protected override void Init(Name name, String description)
        {
            base.Init(name, description);
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
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the collection description.");
        }
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            base.Display(name, description, option);
        }
        protected override void DisplaySetDescription()
        {
            Console.WriteLine("\nSet collection description");
        }
        protected override void DisplayRequestReSetDescription()
        {
            Console.WriteLine("\nRedescribe collection?");
        }
        protected override void DisplayRequestSetDescription()
        {
            Console.WriteLine("\nWhat is the collection description?");
        }
        public void Add(String key, NO value)
        {
            ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).Add(key, value);
        }
        public bool ContainsKey(String key)
        {
            return ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).ContainsKey(key);
        }
        public bool Remove(String key)
        {
            return ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).Remove(key);
        }
        public bool TryGetValue(String key, [MaybeNullWhen(false)] out NO value)
        {
            return ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).TryGetValue(key, out value);
        }
        public void Add(KeyValuePair<String, NO> item)
        {
            ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).Add(item);
        }
        public void Clear()
        {
            ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).Clear();
        }
        public bool Contains(KeyValuePair<String, NO> item)
        {
            return ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).Contains(item);
        }
        public void CopyTo(KeyValuePair<String, NO>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).CopyTo(array, arrayIndex);
        }
        public bool Remove(KeyValuePair<String, NO> item)
        {
            return ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).Remove(item);
        }
        public IEnumerator<KeyValuePair<String, NO>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)DescribedObjectDictionaryOfNamedObjects).GetEnumerator();
        }
    }
}