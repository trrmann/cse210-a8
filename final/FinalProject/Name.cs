using System.Text.Json.Serialization;

namespace FinalProject
{
    public class JsonName
    {
        protected Name _name { get; set; } = new();
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NameType")]
        public NameType Type {
            get {
                return _name.Type;
            } set {
                _name.Type = value;
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Name")]
        public String Name {
            get {
                return _name.Value;
            } set {
                _name.Value = value;
            }
        }
        public JsonName()
        {
            Init("", NameType.Thing);
        }
        [JsonConstructor]
        public JsonName(String Name, NameType Type)
        {
            Init(Name, Type);
        }
        public JsonName(Name name)
        {
            Init(name);
        }
        protected void Init(String Name, NameType Type)
        {
            this.Name = Name;
            this.Type = Type;
        }
        protected void Init(Name Name)
        {
            _name = Name;
        }

        public static implicit operator JsonName(Name name)
        {
            return new(name);
        }
        public static implicit operator Name(JsonName name)
        {
            return name._name;
        }
    }
    public class Name : IName
    {
        internal NameType Type { get; set; }
        internal String Value { get; set; }
        public Name()
        {
            Init();
        }
        public Name(NameType type)
        {
            Init(type);
        }
        public Name(String name, NameType type)
        {
            Init(name, type);
        }
        protected void Init(NameType type = NameType.Thing)
        {
            Init("", type);
        }
        protected void Init(String name, NameType type = NameType.Thing)
        {
            Type = type;
            Value = name;
        }
        internal virtual void Display(int option = -1)
        {
            if (option >= 0) Console.WriteLine(String.Format("{0})  {1}", option, Value));
            else Console.WriteLine(String.Format("{0}", Value));
        }
        public static implicit operator String(Name name)
        {
            return name.Value;
        }
        public static implicit operator Name(String name)
        {
            return new(name, NameType.Thing);
        }
        public static implicit operator NameType(Name name)
        {
            return name.Type;
        }
        public static implicit operator Name(NameType type)
        {
            return new("", type);
        }
    }
    public enum NameType
    {
        Person,
        Organization,
        Place,
        Thing
    }
}