namespace FinalProject
{
    public abstract class Name : IName
    {
        protected NameType Type { get; set; }
        protected String Value {
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