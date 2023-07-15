using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonDescribedObjectDictionaryDescribedObjects<JDO> : JsonDescribedObject where JDO : JsonDescribedObject
    {
        protected DescribedObjectDictionaryDescribedObjects<DescribedObject> DescribedObjectDictionaryDescribedObjects { get; set; }
        [JsonInclude]
        [JsonPropertyName("NODDDDictionary")]
        public Dictionary<String, JDO> Dictionary
        {
            get
            {
                Dictionary<String, JDO> dictionary = new();
                foreach (String key in DescribedObjectDictionaryDescribedObjects.Keys)
                {
                    dictionary.Add(key, (JDO)DescribedObjectDictionaryDescribedObjects[key]);
                }
                return dictionary;
            }
            set
            {
                DescribedObjectDictionaryDescribedObjects.Clear();
                foreach (String key in value.Keys)
                {
                    DescribedObjectDictionaryDescribedObjects.Add(key, value[key]);
                }
            }
        }
        [JsonConstructor]
        public JsonDescribedObjectDictionaryDescribedObjects(JsonName name, String description, Dictionary<String, JDO> dictionary) : base(name, description)
        {
            Dictionary = dictionary;
        }
        public JsonDescribedObjectDictionaryDescribedObjects(DescribedObjectDictionaryDescribedObjects<DescribedObject> describedObjectDictionaryDescribedObjects) : base((DescribedObject)describedObjectDictionaryDescribedObjects)
        {
        }
        public static implicit operator JsonDescribedObjectDictionaryDescribedObjects<JDO>(DescribedObjectDictionaryDescribedObjects<DescribedObject> describedObjectDictionaryDescribedObjects)
        {
            return new(describedObjectDictionaryDescribedObjects);
        }
        public static implicit operator DescribedObjectDictionaryDescribedObjects<DescribedObject>(JsonDescribedObjectDictionaryDescribedObjects<JDO> describedObjectDictionaryDescribedObjects)
        {
            return describedObjectDictionaryDescribedObjects.DescribedObjectDictionaryDescribedObjects;
        }
    }
    public abstract class DescribedObjectDictionaryDescribedObjects<DO> : DescribedObject, IDictionary<String, DO> where DO : DescribedObject
    {
        protected Dictionary<String, DO> Dictionary { get; set; } = new();
        public ICollection<String> Keys => ((IDictionary<String, DO>)Dictionary).Keys;
        public ICollection<DO> Values => ((IDictionary<String, DO>)Dictionary).Values;
        public int Count => ((ICollection<KeyValuePair<String, DO>>)Dictionary).Count;
        public bool IsReadOnly => ((ICollection<KeyValuePair<String, DO>>)Dictionary).IsReadOnly;
        public DO this[String key] { get => ((IDictionary<String, DO>)Dictionary)[key]; set => ((IDictionary<String, DO>)Dictionary)[key] = value; }
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
        public void Add(String key, DO value)
        {
            ((IDictionary<String, DO>)Dictionary).Add(key, value);
        }
        public bool ContainsKey(String key)
        {
            return ((IDictionary<String, DO>)Dictionary).ContainsKey(key);
        }
        public bool Remove(String key)
        {
            return ((IDictionary<String, DO>)Dictionary).Remove(key);
        }
        public bool TryGetValue(String key, [MaybeNullWhen(false)] out DO value)
        {
            return ((IDictionary<String, DO>)Dictionary).TryGetValue(key, out value);
        }
        public void Add(KeyValuePair<String, DO> item)
        {
            ((ICollection<KeyValuePair<String, DO>>)Dictionary).Add(item);
        }
        public void Clear()
        {
            ((ICollection<KeyValuePair<String, DO>>)Dictionary).Clear();
        }
        public bool Contains(KeyValuePair<String, DO> item)
        {
            return ((ICollection<KeyValuePair<String, DO>>)Dictionary).Contains(item);
        }
        public void CopyTo(KeyValuePair<String, DO>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<String, DO>>)Dictionary).CopyTo(array, arrayIndex);
        }
        public bool Remove(KeyValuePair<String, DO> item)
        {
            return ((ICollection<KeyValuePair<String, DO>>)Dictionary).Remove(item);
        }
        public IEnumerator<KeyValuePair<String, DO>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<String, DO>>)Dictionary).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }
    }
}