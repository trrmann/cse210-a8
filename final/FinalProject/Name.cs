using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonName
    {
        protected Name _name { get; set; } = IName.CreateName("");
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NameType")]
        public NameType Type { get { return _name.Type; } set { _name.Type = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Name")]
        public String Name { get { return _name.Value; } set { _name.Value = value; } }
        public JsonName()
        {
            Type = NameType.Thing;
            Name = "";
        }
        [JsonConstructor]
        public JsonName(NameType Type, String Name)
        {
            this.Type = Type;
            this.Name = Name;
        }
        public JsonName(Name name)
        {
            _name = name;
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
    public abstract class Name : IName
    {
        internal NameType Type { get; set; }
        internal String Value {
            get {
                return ToNameString();
            }
            set {
                Parse(value);
            } }
        public Name()
        {
            Init();
        }
        public Name(NameType type)
        {
            Init(type);
        }
        protected virtual void Init(NameType type = NameType.Thing)
        {
            Type = type;
            Value = "";
        }
        protected virtual void Init()
        {
            Init(NameType.Thing);
        }
        protected abstract void Init(String name);
        protected abstract List<Boolean> OptionCombinationFlags(NameType type);
        protected abstract List<String> OptionCombination(NameType type);
        protected abstract List<String> KeyOptionCombination(NameType type);
        public abstract void Parse(String value);
        public abstract String ToNameString();
        internal abstract String ToKeyString();
        public static implicit operator string(Name name)
        {
            return name.Value;
        }
        public static implicit operator NameType(Name name)
        {
            return name.Type;
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