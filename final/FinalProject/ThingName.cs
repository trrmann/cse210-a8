namespace FinalProject
{
    public class ThingName : Name
    {
        private String Name { get; set; }
        private Boolean HasName { get { return Value is not null && Value != ""; } }

        public ThingName()
        {
            Init();
        }
        public ThingName(String name)
        {
            Init(name);
        }

        public ThingName(Boolean empty=true) : base(NameType.Thing)
        {
            Init(empty);
        }

        public ThingName(String name, Boolean empty = true) : base(NameType.Thing)
        {
            Init(name, empty);
        }

        protected override void Init()
        {
            base.Init(NameType.Thing);
        }
        protected void Init(Boolean empty = true)
        {
            base.Init(NameType.Thing);
        }
        protected override void Init(String name)
        {
            Init(true);
            Value = name;
        }
        protected void Init(String name, Boolean empty = true)
        {
            Init(empty);
            Value = name;
        }
        protected override List<Boolean> OptionCombinationFlags(NameType type)
        {
            return new() { HasName };
        }
        protected override List<String> OptionCombination(NameType type)
        {
            List<String> result = new();
            if (HasName) result.Add(Value);
            return result;
        }
        protected override List<String> KeyOptionCombination(NameType type)
        {
            List<String> result = new();
            if (HasName) result.Add(IStringUtilities.Proper(Value));
            return result;
        }
        public override void Parse(String value)
        {
            Name = value;
        }
        public override String ToNameString()
        {
            return Name;
        }
        internal override String ToKeyString()
        {
            return IStringUtilities.Proper(ToNameString());
        }

        public static implicit operator ThingName(string name)
        {
            ThingName nameObject = new()
            {
                Value = name
            };
            return nameObject;
        }

        public static implicit operator string(ThingName name)
        {
            return name.Value;
        }
    }
}
