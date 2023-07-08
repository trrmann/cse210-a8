namespace FinalProject
{
    public class PlaceName : Name
    {
        private String LocationName { get; set; }
        private String StreetIdentifier { get; set; }
        private String StreetName { get; set; }
        private Boolean UseStreetSubIdentifier { get; set; }
        private String StreetSubIdentifier { get; set; }
        private String City { get; set; }
        private String PostalCode { get; set; }
        private Boolean UseCounty { get; set; }
        private String County { get; set; }
        private Boolean UseDistrict { get; set; }
        private String District { get; set; }
        private String State { get; set; }
        private String Country { get; set; }
        private Boolean HasLocationName { get { return LocationName is not null && LocationName != ""; } }
        private Boolean HasStreetIdentifier { get { return StreetIdentifier is not null && StreetIdentifier != ""; } }
        private Boolean HasStreetName { get { return StreetName is not null && StreetName != ""; } }
        private Boolean HasStreetSubIdentifier { get { return StreetSubIdentifier is not null && StreetSubIdentifier != ""; } }
        private Boolean HasCity { get { return City is not null && City != ""; } }
        private Boolean HasPostalCode { get { return PostalCode is not null && PostalCode != ""; } }
        private Boolean HasCounty { get { return County is not null && County != ""; } }
        private Boolean HasDistrict { get { return District is not null && District != ""; } }
        private Boolean HasState { get { return State is not null && State != ""; } }
        private Boolean HasCountry { get { return Country is not null && Country != ""; } }
        public PlaceName()
        {
            Init();
        }
        public PlaceName(String name)
        {
            Init(name);
        }
        protected override void Init()
        {
            base.Init(NameType.Person);
        }
        protected override void Init(String name)
        {
            Init();
            Value = name;
        }
        protected override List<Boolean> OptionCombinationFlags(NameType type)
        {
            return new () { HasLocationName, HasStreetIdentifier, HasStreetName, UseStreetSubIdentifier, HasStreetSubIdentifier, HasCity, HasPostalCode, UseCounty, HasCounty, UseDistrict, HasDistrict, HasState, HasCountry };
        }
        protected override List<String> OptionCombination(NameType type)
        {
            List<String> result = new();
            if (HasLocationName) result.Add(LocationName);
            if (HasStreetIdentifier) result.Add(StreetIdentifier);
            if (HasStreetName) result.Add(StreetName);
            if (UseStreetSubIdentifier && HasStreetSubIdentifier) result.Add(StreetSubIdentifier);
            if (HasCity) result.Add(City);
            if (HasPostalCode) result.Add(PostalCode);
            if (UseCounty && HasCounty) result.Add(County);
            if (UseDistrict && HasDistrict) result.Add(District);
            if (HasState) result.Add(State);
            if (HasCountry) result.Add(Country);
            return result;
        }
        protected override List<String> KeyOptionCombination(NameType type)
        {
            List<String> result = new();
            if (HasLocationName) result.Add(IStringUtilities.Proper(LocationName));
            if (HasStreetIdentifier) result.Add(IStringUtilities.Proper(StreetIdentifier));
            if (HasStreetName) result.Add(IStringUtilities.Proper(StreetName));
            if (UseStreetSubIdentifier && HasStreetSubIdentifier) result.Add(IStringUtilities.Proper(StreetSubIdentifier));
            if (HasCity) result.Add(IStringUtilities.Proper(City));
            if (HasPostalCode) result.Add(IStringUtilities.Proper(PostalCode));
            if (UseCounty && HasCounty) result.Add(IStringUtilities.Proper(County));
            if (UseDistrict && HasDistrict) result.Add(IStringUtilities.Proper(District));
            if (HasState) result.Add(IStringUtilities.Proper(State));
            if (HasCountry) result.Add(IStringUtilities.Proper(Country));
            return result;
        }
        public override void Parse(String value)
        {
            /**
            string[] parts;
            List<String> partsList;
            String subValue = value;
            Title = "";
            Suffix = "";
            MaternalSur = "";
            PaternalSur = "";
            if (UseTitle && subValue.Contains(" "))
            {
                parts = subValue.Split(" ");
                partsList = new(parts);
                Title = partsList[0];
                partsList.RemoveAt(0);
                subValue = String.Join(" ", partsList);
            }
            else
            {
                Title = subValue;
                subValue = "";
            }
            if (UseSuffix && subValue.Contains(" "))
            {
                parts = subValue.Split(" ");
                partsList = new(parts);
                Suffix = partsList[partsList.Count - 1];
                partsList.RemoveAt(partsList.Count - 1);
                subValue = String.Join(" ", partsList);
            }
            else
            {
                Suffix = subValue;
                subValue = "";
            }
            if (UseMaternalSurName && subValue.Contains(" "))
            {
                parts = subValue.Split(" ");
                partsList = new(parts);
                MaternalSur = partsList[partsList.Count - 1];
                partsList.RemoveAt(partsList.Count - 1);
                subValue = String.Join(" ", partsList);
            }
            else if (UseMaternalSurName)
            {
                MaternalSur = subValue;
                subValue = "";
            }
            parts = subValue.Split(" ");
            partsList = new(parts);
            PaternalSur = partsList[partsList.Count - 1];
            partsList.RemoveAt(partsList.Count - 1);
            subValue = String.Join(" ", partsList);
            parts = subValue.Split(" ");
            partsList = new(parts);
            Given = partsList[0];
            partsList.RemoveAt(0);
            Middle = String.Join(" ", partsList);
            /**/
        }

        public override String ToNameString()
        {
            return "";
        }
        internal override String ToKeyString()
        {
            return ToNameString();
        }

        public static implicit operator PlaceName(string name)
        {
            PlaceName nameObject = new()
            {
                Value = name
            };
            return nameObject;
        }

        public static implicit operator string(PlaceName name)
        {
            return name.Value;
        }
    }
}
