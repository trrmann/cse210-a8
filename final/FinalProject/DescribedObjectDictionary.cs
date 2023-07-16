using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonDescribedObjectDictionary<JNO> : JsonDescribedObject where JNO : JsonNamedObject
    {
        protected DescribedObjectDictionary<NamedObject> DescribedObjectDictionary { get; set; }
        [JsonInclude]
        [JsonRequired]
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
        public JsonDescribedObjectDictionary()
        {
            Init();
        }
        [JsonConstructor]
        public JsonDescribedObjectDictionary(String Name, NameType Type, String Description, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(Name, Type, Description, DescribedObjectDictionaryOfNamedObjects);
        }

        public JsonDescribedObjectDictionary(JsonNamedObject Name, String Description, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(new JsonDescribedObject(Name, Description), DescribedObjectDictionaryOfNamedObjects);
        }
        public JsonDescribedObjectDictionary(JsonDescribedObject DescribedObject, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(DescribedObject, DescribedObjectDictionaryOfNamedObjects);
        }
        public JsonDescribedObjectDictionary(JsonDescribedObjectDictionary<JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(DescribedObjectDictionaryOfNamedObjects);
        }
        public JsonDescribedObjectDictionary(DescribedObjectDictionary<NamedObject> DescribedObjectDictionaryOfNamedObjects) 
        {
            Init(DescribedObjectDictionaryOfNamedObjects);
        }
        protected override void Init()
        {
            Init("", NameType.Thing, "", new());
        }
        protected void Init(String Name, NameType Type, String Description, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(new JsonNamedObject(Name, Type), Description, DescribedObjectDictionaryOfNamedObjects);
        }
        protected void Init(JsonNamedObject Name, String Description, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(new JsonDescribedObject(Name, Description), DescribedObjectDictionaryOfNamedObjects);
        }
        protected void Init(JsonDescribedObject DescribedObject, Dictionary<String, JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            base.Init(DescribedObject);
            this.DescribedObjectDictionaryOfNamedObjects = DescribedObjectDictionaryOfNamedObjects;
        }
        protected void Init(JsonDescribedObjectDictionary<JNO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(DescribedObjectDictionaryOfNamedObjects._describedObject);
            this.DescribedObjectDictionaryOfNamedObjects = DescribedObjectDictionaryOfNamedObjects.DescribedObjectDictionaryOfNamedObjects;
        }
        protected void Init(DescribedObjectDictionary<NamedObject> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(((JsonDescribedObjectDictionary<JNO>)DescribedObjectDictionaryOfNamedObjects)._describedObject);
            this.DescribedObjectDictionaryOfNamedObjects = ((JsonDescribedObjectDictionary<JNO>)DescribedObjectDictionaryOfNamedObjects).DescribedObjectDictionaryOfNamedObjects;
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
    public class DescribedObjectDictionary<NO> : DescribedObject, IDictionary<String, NO> where NO : NamedObject
    {
        internal Dictionary<String, NO> DescribedObjectDictionaryOfNamedObjects { get; set; } = new();
        public ICollection<String> Keys => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).Keys;
        public ICollection<NO> Values => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects).Values;
        public int Count => ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).Count;
        public bool IsReadOnly => ((ICollection<KeyValuePair<String, NO>>)DescribedObjectDictionaryOfNamedObjects).IsReadOnly;
        public NO this[String key] { get => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects)[key]; set => ((IDictionary<String, NO>)DescribedObjectDictionaryOfNamedObjects)[key] = value; }
        public DescribedObjectDictionary()
        {
            Init();
        }
        public DescribedObjectDictionary(String name, NameType type, String Description, Dictionary<String, NO> DictionaryOfNamedObjects)
        {
            Init(name, type, Description, DictionaryOfNamedObjects);
        }
        public DescribedObjectDictionary(Name name, String Description, Dictionary<String, NO> DictionaryOfNamedObjects)
        {
            Init(name, Description, DictionaryOfNamedObjects);
        }
        public DescribedObjectDictionary(DescribedObject name, Dictionary<String, NO> DictionaryOfNamedObjects)
        {
            Init(name, DictionaryOfNamedObjects);
        }
        public DescribedObjectDictionary(DescribedObjectDictionary<NO> DescribedObjectDictionaryOfNamedObjects)
        {
            Init(DescribedObjectDictionaryOfNamedObjects);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", new());
        }
        protected void Init(String name, NameType type, String Description, Dictionary<String, NO> DictionaryOfNamedObjects)
        {
            Init(new Name(name, type), Description, DictionaryOfNamedObjects);
        }
        protected void Init(Name Name, String Description, Dictionary<String, NO> DictionaryOfNamedObjects)
        {
            this.Name = Name;
            this.Description = Description;
            this.DescribedObjectDictionaryOfNamedObjects = DictionaryOfNamedObjects;
        }
        protected void Init(DescribedObject Name, Dictionary<String, NO> DictionaryOfNamedObjects)
        {
            this.Name = Name.Name;
            this.Description = Name.Description;
            this.DescribedObjectDictionaryOfNamedObjects = DictionaryOfNamedObjects;
        }
        protected void Init(DescribedObjectDictionary<NO> DescribedObjectDictionaryOfNamedObjects)
        {
            this.Name = DescribedObjectDictionaryOfNamedObjects.Name;
            this.Description = DescribedObjectDictionaryOfNamedObjects.Description;
            this.DescribedObjectDictionaryOfNamedObjects = DescribedObjectDictionaryOfNamedObjects.DescribedObjectDictionaryOfNamedObjects;
        }
        public static implicit operator String(DescribedObjectDictionary<NO> describedObject)
        {
            return describedObject;
        }
        public static implicit operator DescribedObjectDictionary<NO>(String name)
        {
            return new DescribedObjectDictionary<NO>(name, new());
        }
        public static implicit operator NameType(DescribedObjectDictionary<NO> describedObject)
        {
            return describedObject;
        }
        public static implicit operator DescribedObjectDictionary<NO>(NameType type)
        {
            return new Name("", type);
        }
        public static implicit operator Name(DescribedObjectDictionary<NO> describedObject)
        {
            return describedObject.Name;
        }
        public static implicit operator DescribedObjectDictionary<NO>(Name name)
        {
            return new DescribedObjectDictionary<NO>(name);
        }
        protected override void DisplayRequestNameMessage()
        {
            base.DisplayRequestNameMessage();
            Console.WriteLine("\nPlease enter the collection name.");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            base.DisplayRequestDescriptionMessage();
            Console.WriteLine("\nPlease enter the collection description.");
        }
        protected override void DisplaySetNameMessage()
        {
            base.DisplaySetNameMessage();
            Console.WriteLine("\nSet collection name.");
        }
        protected override void DisplaySetDescriptionMessage()
        {
            base.DisplaySetDescriptionMessage();
            Console.WriteLine("\nSet collection description.");
        }
        protected override void DisplayRequestReSetNameMessage()
        {
            base.DisplayRequestReSetNameMessage();
            Console.WriteLine("\nrename collection?");
        }
        protected override void DisplayRequestReSetDescriptionMessage()
        {
            base.DisplayRequestReSetDescriptionMessage();
            Console.WriteLine("\nredescribe collection?");
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
        }
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            base.Display(name, description, option);
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