namespace FinalProject
{
    public class OrganizationName : Name
    {
        private String Name { get; set; }
        private Boolean HasName { get { return Name is not null && Name != ""; } }
        public OrganizationName()
        {
            Init();
        }
        public OrganizationName(String name)
        {
            Init(name);
        }
        protected override void Init()
        {
            base.Init(NameType.Organization);
        }
        protected override void Init(String name)
        {
            Init();
            Value = name;
        }
        protected override List<Boolean> OptionCombinationFlags(NameType type)
        {
            return new() { HasName };
        }
        protected override List<String> OptionCombination(NameType type)
        {
            List<String> result = new();
            if (HasName) result.Add(Name);
            return result;
        }
        protected override List<String> KeyOptionCombination(NameType type)
        {
            List<String> result = new();
            if (HasName) result.Add(IStringUtilities.Proper(Name));
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
            return ToNameString();
        }

        public static implicit operator OrganizationName(string name)
        {
            OrganizationName nameObject = new()
            {
                Value = name
            };
            return nameObject;
        }

        public static implicit operator string(OrganizationName name)
        {
            return name.Value;
        }
    }
}
