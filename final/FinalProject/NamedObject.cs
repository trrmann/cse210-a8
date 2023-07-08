using System.Collections.Generic;

namespace FinalProject
{
    public abstract class NamedObject
    {
        internal String Key { get { return ToKeyString(); } }
        protected Name Name { get; set; }
        protected virtual void Init(Boolean empty = true)
        {
            Init(NameType.Thing, empty);
        }
        protected virtual void Init(NameType type, Boolean empty = true)
        {
            if (empty) Name = IName.CreateName("", type);
            else RequestName(type);
        }
        protected virtual void Init(Name name)
        {
            Name = name;
        }
        protected virtual void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter Name.");
        }
        protected void RequestName(NameType type)
        {
            DisplayRequestname();
            Name = IName.CreateName(IApplication.READ_RESPONSE(), type);
        }
        protected Boolean IsNamed()
        {
            return (Name != null) && (Name != "");
        }
        internal virtual void Display(int option = -1)
        {
            if (option >= 0) Console.WriteLine(String.Format("{0})  {1}", option, Name.ToNameString()));
            else Console.WriteLine(String.Format("{0}", Name.ToNameString()));
        }
        protected virtual void DisplaySetName()
        {
            Console.WriteLine("\nSet Name");
        }
        protected virtual void DisplayRequestReSetName()
        {
            Console.WriteLine("\nRename?");
        }
        protected virtual void DisplayRequestSetName()
        {
            Console.WriteLine("\nWhat is the name?");
        }
        internal void SetName()
        {
            Boolean setName = true;
            this.DisplaySetName();
            if (IsNamed())
            {
                Display(-1);
                this.DisplayRequestReSetName();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setName = false;
            }
            if (setName)
            {
                this.DisplayRequestSetName();
                NameType type = Name;
                Name = IName.CreateName(IApplication.READ_RESPONSE(), type);
            }
        }
        internal String ToNameString()
        {
            return Name.ToNameString();
        }
        internal String ToKeyString()
        {
            return Name.ToKeyString();
        }
        /**
        public override String ToString()
        {
            switch(Type)
            {
                case NameType.Organization:
                    return ThingName;
                case NameType.Place:



                    if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState && 
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, District {7}, {8}, {9}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, District {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, District {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, District {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, District {6}, {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, District {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}, {3}, {4} {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}, {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}, {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, District {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4}, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3}, {4} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, District {6}, {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, District {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} {4}, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}, {3} {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3}, {4} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            City);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3}, {4} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3}, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} County, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3} County",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, District {3}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetName,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity)
                        return String.Format("{0}, {1} {2}",
                            Location,
                            StreetIdentifier,
                            StreetName);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, District {6}, {7}, {8}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, District {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, District {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5} County",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} {4}, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}, {3} {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, District {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3}, {4} County",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            StreetIdentifier,
                            StreetSubIdentifier);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, District {5}, {6}, {7}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, District {5}, {6}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, District {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {4} County, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} {3}, {4} County",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, District {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2} {3}",
                            Location,
                            StreetIdentifier,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            StreetIdentifier,
                            City,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            StreetIdentifier,
                            City,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            City,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            City,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            StreetIdentifier,
                            City);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}, {6}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}, {5}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {4}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {4}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            StreetIdentifier,
                            PostalCode);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {4}, {5}",
                            Location,
                            StreetIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {4}",
                            Location,
                            StreetIdentifier,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            Location,
                            StreetIdentifier,
                            County,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {4}",
                            Location,
                            StreetIdentifier,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            StreetIdentifier,
                            County,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            StreetIdentifier,
                            County,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            Location,
                            StreetIdentifier,
                            County);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            Location,
                            StreetIdentifier,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            StreetIdentifier,
                            District,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            StreetIdentifier,
                            District,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            Location,
                            StreetIdentifier,
                            District);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            StreetIdentifier,
                            State,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            StreetIdentifier,
                            State);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            StreetIdentifier,
                            Country);
                    else if (HasLocationName &&
                        HasStreetIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1} {2}",
                            Location,
                            StreetIdentifier,
                            StreetName);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, District {7}, {8}, {9}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, District {7}, {8}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, District {7}, {8}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, District {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, {7}, {8}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6} County",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, District {6}, {7}, {8}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {5}, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} {5}, District {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}, {3} {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}, {7}, {8}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            City);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}, {7}, {8}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, District {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3}, {5} County",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3}, District {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetName,
                            StreetSubIdentifier);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}, {8}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}, {7}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} {3}, {5} County",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, District {5}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2} {3}",
                            Location,
                            
                            StreetName,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            
                            StreetName,
                            City,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            
                            StreetName,
                            City,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            City,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            City,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetName,
                            City);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetName,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            Location,
                            
                            StreetName,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            StreetName,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            Location,
                            
                            StreetName,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            Location,
                            
                            StreetName,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            StreetName,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            StreetName,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            Location,
                            
                            StreetName,
                            County);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            Location,
                            
                            StreetName,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            StreetName,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            StreetName,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            Location,
                            
                            StreetName,
                            District);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetName,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetName,
                            State);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetName,
                            Country);
                    else if (HasLocationName &&
                        
                        HasStreetName &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            StreetName);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}, {8}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}, {7}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} {3}, {5} County",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}, {7}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, District {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2} {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetSubIdentifier,
                            City);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetSubIdentifier,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            Location,
                            
                            StreetSubIdentifier,
                            County);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            Location,
                            
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            Location,
                            
                            StreetSubIdentifier,
                            District);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetSubIdentifier,
                            State);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            StreetSubIdentifier,
                            Country);
                    else if (HasLocationName &&
                        
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            StreetSubIdentifier);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}, {6}, {7}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}, {6}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {5}, {6}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, {5}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {5}",
                            Location,
                            
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3} County",
                            Location,
                            
                            City,
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {5}, {6}",
                            Location,
                            
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, District {3}, {5}",
                            Location,
                            
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {5}",
                            Location,
                            
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, District {3}",
                            Location,
                            
                            City,
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {5}",
                            Location,
                            
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            
                            City,
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}",
                            Location,
                            
                            City,
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}",
                            Location,
                            
                            City,
                            PostalCode);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            Location,
                            
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            City,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            City,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            Location,
                            
                            City,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            Location,
                            
                            City,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            City,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            City,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            Location,
                            
                            City,
                            County);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            Location,
                            
                            City,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            City,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            City,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            Location,
                            
                            City,
                            District);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            City,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            City,
                            State);
                    else if (HasLocationName &&
                        
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            City,
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            City);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            Location,
                            
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            Location,
                            
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            Location,
                            
                            PostalCode,
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            Location,
                            
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            PostalCode,
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            Location,
                            
                            PostalCode,
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            Location,
                            
                            PostalCode,
                            County);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            Location,
                            
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            PostalCode,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            Location,
                            
                            PostalCode,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            Location,
                            
                            PostalCode,
                            District);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            Location,
                            
                            PostalCode,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            PostalCode,
                            State);
                    else if (HasLocationName &&
                        
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            PostalCode,
                            Country);
                    else if (HasLocationName &&
                        
                        HasPostalCode)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            PostalCode);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}, {5}",
                            Location,
                            
                            County,
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            Location,
                            
                            County,
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            Location,
                            
                            County,
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} County, District {2}",
                            Location,
                            
                            County,
                            District);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}, {3}",
                            Location,
                            
                            County,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} County, {2}",
                            Location,
                            
                            County,
                            State);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}",
                            Location,
                            
                            County,
                            Country);
                    else if (HasLocationName &&
                        
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} County",
                            Location,
                            
                            County);
                    else if (HasLocationName &&
                        
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            Location,
                            
                            District,
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            Location,
                            
                            District,
                            State);
                    else if (HasLocationName &&
                        
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            Location,
                            
                            District,
                            Country);
                    else if (HasLocationName &&
                        
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            Location,
                            
                            District);
                    else if (HasLocationName &&
                        
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            Location,
                            
                            State,
                            Country);
                    else if (HasLocationName &&
                        
                        HasState)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            State);
                    else if (HasLocationName &&
                        
                        HasCountry)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            Country);
                    else if (HasLocationName &&
                        
                        HasCity)
                        return String.Format("{0}, {1}",
                            Location,
                            
                            StreetName);

                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, District {7}, {8}, {9}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, District {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, District {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, District {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6} County",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, District {6}, {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} {5}, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3} {5}, District {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0} {1}, {2}, {3} {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}, {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2}, {3}, {5} County",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3}, District {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            City);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}, {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, District {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2}, {3}, {5} County",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3}, District {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2}, {3} County",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, District {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0} {1}, {2}",
                            
                            StreetIdentifier,
                            StreetName,
                            StreetSubIdentifier);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, {5} County, District {6}, {7}, {8}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2} {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2} {3}, {5} County, District {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, {5} County, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2} {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2} {3}, {5} County",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2} {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2} {3}, District {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0} {1}, {2} {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0} {1}, {2} {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2}, {3} County",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, District {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            City,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity)
                        return String.Format("{0} {1}, {2}",
                            
                            StreetIdentifier,
                            StreetName,
                            City);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, {3} County, District {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2}, {3} County",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2}, District {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasPostalCode)
                        return String.Format("{0} {1}, {2}",
                            
                            StreetIdentifier,
                            StreetName,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2} County, District {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2} County",
                            
                            StreetIdentifier,
                            StreetName,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, District {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetName,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, District {2}",
                            
                            StreetIdentifier,
                            StreetName,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetName,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasState)
                        return String.Format("{0} {1}, {2}",
                            
                            StreetIdentifier,
                            StreetName,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}",
                            
                            StreetIdentifier,
                            StreetName,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasStreetName &&
                        HasCity)
                        return String.Format("{0} {1}",
                            
                            StreetIdentifier,
                            StreetName);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}, {8}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}, {7}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, District {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5} County, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} {3}, {5} County",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, District {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2} {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            City);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            
                            StreetIdentifier,
                            StreetSubIdentifier);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}, {6}, {7}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}, {6}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} County, District {5}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {5}, {6}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {5}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3} County",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, District {3}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}",
                            
                            StreetIdentifier,
                            City,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            City,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            
                            StreetIdentifier,
                            City,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            City,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            City,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            
                            StreetIdentifier,
                            City,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            City,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            City,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            City,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            
                            StreetIdentifier,
                            City);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}, {6}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {5}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {5}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            
                            StreetIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            
                            StreetIdentifier,
                            PostalCode,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            
                            StreetIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            
                            StreetIdentifier,
                            PostalCode,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            PostalCode,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            PostalCode,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}",
                            
                            StreetIdentifier,
                            PostalCode);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}, {5}",
                            
                            StreetIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            
                            StreetIdentifier,
                            County,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            
                            StreetIdentifier,
                            County,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} County, District {2}",
                            
                            StreetIdentifier,
                            County,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}, {3}",
                            
                            StreetIdentifier,
                            County,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} County, {2}",
                            
                            StreetIdentifier,
                            County,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}",
                            
                            StreetIdentifier,
                            County,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} County",
                            
                            StreetIdentifier,
                            County);
                    else if (
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            
                            StreetIdentifier,
                            District,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            
                            StreetIdentifier,
                            District,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            
                            StreetIdentifier,
                            District,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            
                            StreetIdentifier,
                            District);
                    else if (
                        HasStreetIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            
                            StreetIdentifier,
                            State,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}",
                            
                            StreetIdentifier,
                            State);
                    else if (
                        HasStreetIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}",
                            
                            StreetIdentifier,
                            Country);
                    else if (
                        HasStreetIdentifier &&
                        HasCity)
                        return String.Format("{0} {1}",
                            
                            StreetIdentifier,
                            StreetName);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, District {7}, {8}, {9}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, District {7}, {8}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, District {7}, {8}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, District {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, {7}, {8}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {6} County, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} {3}, {6} County",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {6}, {7}, {8}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, District {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, District {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} {3}, District {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2} {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2} {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}, {7}, {8}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            County);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            City);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}, {7}, {8}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, {3} County, District {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3} County, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3} County, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2}, {3} County",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, District {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, District {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2}, District {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            PostalCode);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}, {7}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            

                            StreetName,
                            StreetSubIdentifier,
                            County);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {6}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            District);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            State);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            StreetSubIdentifier,
                            Country);
                    else if (

                        HasStreetName &&
                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            

                            StreetName,
                            StreetSubIdentifier);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}, {7}, {8}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}, {7}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}, {7}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {6}, {7}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, {6}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {6}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3} County",
                            

                            StreetName,
                            City,
                            PostalCode,
                            County);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {6}, {7}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, District {3}, {6}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {6}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, District {3}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            District);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {6}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}",
                            

                            StreetName,
                            City,
                            PostalCode,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}",
                            

                            StreetName,
                            City,
                            PostalCode);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}, {7}",
                            

                            StreetName,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetName,
                            City,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetName,
                            City,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            

                            StreetName,
                            City,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {6}",
                            

                            StreetName,
                            City,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetName,
                            City,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetName,
                            City,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            

                            StreetName,
                            City,
                            County);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {6}",
                            

                            StreetName,
                            City,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetName,
                            City,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetName,
                            City,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            

                            StreetName,
                            City,
                            District);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            City,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            City,
                            State);
                    else if (

                        HasStreetName &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            City,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            

                            StreetName,
                            City);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}, {7}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {6}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetName,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            

                            StreetName,
                            PostalCode,
                            County);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {6}",
                            

                            StreetName,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetName,
                            PostalCode,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetName,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            

                            StreetName,
                            PostalCode,
                            District);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetName,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            PostalCode,
                            State);
                    else if (

                        HasStreetName &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            PostalCode,
                            Country);
                    else if (

                        HasStreetName &&
                        HasPostalCode)
                        return String.Format("{0}, {1}",
                            

                            StreetName,
                            PostalCode);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}, {6}",
                            

                            StreetName,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            StreetName,
                            County,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            StreetName,
                            County,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} County, District {2}",
                            

                            StreetName,
                            County,
                            District);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}, {3}",
                            

                            StreetName,
                            County,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} County, {2}",
                            

                            StreetName,
                            County,
                            State);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}",
                            

                            StreetName,
                            County,
                            Country);
                    else if (

                        HasStreetName &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} County",
                            

                            StreetName,
                            County);
                    else if (

                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            

                            StreetName,
                            District,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            

                            StreetName,
                            District,
                            State);
                    else if (

                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            

                            StreetName,
                            District,
                            Country);
                    else if (

                        HasStreetName &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            

                            StreetName,
                            District);
                    else if (

                        HasStreetName &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetName,
                            State,
                            Country);
                    else if (

                        HasStreetName &&
                        HasState)
                        return String.Format("{0}, {1}",
                            

                            StreetName,
                            State);
                    else if (

                        HasStreetName &&
                        HasCountry)
                        return String.Format("{0}, {1}",
                            

                            StreetName,
                            Country);
                    else if (

                        HasStreetName &&
                        HasCity)
                        return String.Format("{0}",
                            

                            StreetName);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}, {7}, {8}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}, {7}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}, {7}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, {3} County, District {6}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {6}, {7}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3} County, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3} County, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} {2}, {3} County",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            County);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {6}, {7}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} {2}, District {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, District {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} {2}, District {3}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1} {2}, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1} {2}, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0}, {1} {2}",
                            

                            StreetSubIdentifier,
                            City,
                            PostalCode);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}, {7}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            County,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            

                            StreetSubIdentifier,
                            City,
                            County);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {6}",
                            

                            StreetSubIdentifier,
                            City,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            

                            StreetSubIdentifier,
                            City,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetSubIdentifier,
                            City,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetSubIdentifier,
                            City,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetSubIdentifier,
                            City,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}, {1}",
                            

                            StreetSubIdentifier,
                            City);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}, {7}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, District {3}, {6}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, {2} County, District {3}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}, {6}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2} County, {3}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1}, {2} County",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            County);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}, {6}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1}, District {2}, {3}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1}, District {2}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}, {3}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetSubIdentifier,
                            PostalCode,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasPostalCode)
                        return String.Format("{0}, {1}",
                            

                            StreetSubIdentifier,
                            PostalCode);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}, {6}",
                            

                            StreetSubIdentifier,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            StreetSubIdentifier,
                            County,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            StreetSubIdentifier,
                            County,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} County, District {2}",
                            

                            StreetSubIdentifier,
                            County,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}, {3}",
                            

                            StreetSubIdentifier,
                            County,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} County, {2}",
                            

                            StreetSubIdentifier,
                            County,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}",
                            

                            StreetSubIdentifier,
                            County,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} County",
                            

                            StreetSubIdentifier,
                            County);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            

                            StreetSubIdentifier,
                            District,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            

                            StreetSubIdentifier,
                            District,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            

                            StreetSubIdentifier,
                            District,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            

                            StreetSubIdentifier,
                            District);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            StreetSubIdentifier,
                            State,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasState)
                        return String.Format("{0}, {1}",
                            

                            StreetSubIdentifier,
                            State);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCountry)
                        return String.Format("{0}, {1}",
                            

                            StreetSubIdentifier,
                            Country);
                    else if (

                        UseStreetSubIdentifier &&
                        HasStreetSubIdentifier &&
                        HasCity)
                        return String.Format("{0}",
                            

                            StreetSubIdentifier);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, District {3}, {6}, {7}",
                            

                            City,
                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, {2} County, District {3}, {6}",
                            

                            City,
                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, District {3}, {6}",
                            

                            City,
                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, {2} County, District {3}",
                            

                            City,
                            PostalCode,
                            County,
                            District);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, {3}, {6}",
                            

                            City,
                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} {1}, {2} County, {3}",
                            

                            City,
                            PostalCode,
                            County,
                            State);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} {1}, {2} County, {3}",
                            

                            City,
                            PostalCode,
                            County,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} {1}, {2} County",
                            

                            City,
                            PostalCode,
                            County);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, District {2}, {3}, {6}",
                            

                            City,
                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} {1}, District {2}, {3}",
                            

                            City,
                            PostalCode,
                            District,
                            State);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} {1}, District {2}, {3}",
                            

                            City,
                            PostalCode,
                            District,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} {1}, District {2}",
                            

                            City,
                            PostalCode,
                            District);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}, {3}",
                            

                            City,
                            PostalCode,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        HasState)
                        return String.Format("{0} {1}, {2}",
                            

                            City,
                            PostalCode,
                            State);
                    else if (

                        HasCity &&
                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0} {1}, {2}",
                            

                            City,
                            PostalCode,
                            Country);
                    else if (

                        HasCity &&
                        HasPostalCode)
                        return String.Format("{0} {1}",
                            

                            City,
                            PostalCode);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}, {6}",
                            

                            City,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            City,
                            County,
                            District,
                            State);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            City,
                            County,
                            District,
                            Country);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} County, District {2}",
                            

                            City,
                            County,
                            District);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}, {3}",
                            

                            City,
                            County,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} County, {2}",
                            

                            City,
                            County,
                            State);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}",
                            

                            City,
                            County,
                            Country);
                    else if (

                        HasCity &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} County",
                            

                            City,
                            County);
                    else if (

                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            

                            City,
                            District,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            

                            City,
                            District,
                            State);
                    else if (

                        HasCity &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            

                            City,
                            District,
                            Country);
                    else if (

                        HasCity &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            

                            City,
                            District);
                    else if (

                        HasCity &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            City,
                            State,
                            Country);
                    else if (

                        HasCity &&
                        HasState)
                        return String.Format("{0}, {1}",
                            

                            City,
                            State);
                    else if (

                        HasCity &&
                        HasCountry)
                        return String.Format("{0}, {1}",
                            

                            City,
                            Country);
                    else if (

                        HasCity)
                        return String.Format("{0}",
                            

                            City);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}, {6}",
                            

                            PostalCode,
                            County,
                            District,
                            State,
                            Country);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            PostalCode,
                            County,
                            District,
                            State);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, {1} County, District {2}, {3}",
                            

                            PostalCode,
                            County,
                            District,
                            Country);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, {1} County, District {2}",
                            

                            PostalCode,
                            County,
                            District);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}, {3}",
                            

                            PostalCode,
                            County,
                            State,
                            Country);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0}, {1} County, {2}",
                            

                            PostalCode,
                            County,
                            State);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0}, {1} County, {2}",
                            

                            PostalCode,
                            County,
                            Country);
                    else if (

                        HasPostalCode &&
                        UseCounty &&
                        HasCounty)
                        return String.Format("{0}, {1} County",
                            

                            PostalCode,
                            County);
                    else if (

                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            

                            PostalCode,
                            District,
                            State,
                            Country);
                    else if (

                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            

                            PostalCode,
                            District,
                            State);
                    else if (

                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            

                            PostalCode,
                            District,
                            Country);
                    else if (

                        HasPostalCode &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            

                            PostalCode,
                            District);
                    else if (

                        HasPostalCode &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}, {2}",
                            

                            PostalCode,
                            State,
                            Country);
                    else if (

                        HasPostalCode &&
                        HasState)
                        return String.Format("{0}, {1}",
                            

                            PostalCode,
                            State);
                    else if (

                        HasPostalCode &&
                        HasCountry)
                        return String.Format("{0}, {1}",
                            

                            PostalCode,
                            Country);
                    else if (

                        HasPostalCode)
                        return String.Format("{0}",
                            

                            PostalCode);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} County, District {1}, {2}, {3}",
                            

                            County,
                            District,
                            State,
                            Country);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0} County, District {1}, {2}",
                            

                            County,
                            District,
                            State);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0} County, District {1}, {2}",
                            

                            County,
                            District,
                            Country);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0} County, District {1}",
                            

                            County,
                            District);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0} County, {1}, {2}",
                            

                            County,
                            State,
                            Country);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        HasState)
                        return String.Format("{0} County, {1}",
                            

                            County,
                            State);
                    else if (

                        UseCounty &&
                        HasCounty &&
                        HasCountry)
                        return String.Format("{0} County, {1}",
                            

                            County,
                            Country);
                    else if (

                        UseCounty &&
                        HasCounty)
                        return String.Format("{0} County",
                            

                            County);
                    else if (

                        UseDistrict &&
                        HasDistrict &&
                        HasState &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}, {3}",
                            

                            District,
                            State,
                            Country);
                    else if (

                        UseDistrict &&
                        HasDistrict &&
                        HasState)
                        return String.Format("{0}, District {1}, {2}",
                            

                            District,
                            State);
                    else if (

                        UseDistrict &&
                        HasDistrict &&
                        HasCountry)
                        return String.Format("{0}, District {1}, {2}",
                            

                            District,
                            Country);
                    else if (

                        UseDistrict &&
                        HasDistrict)
                        return String.Format("{0}, District {1}",
                            

                            District);
                    else if (

                        HasState &&
                        HasCountry)
                        return String.Format("{0}, {1}",
                            

                            State,
                            Country);
                    else if (

                        HasState)
                        return String.Format("{0}",
                            

                            State);
                    else if (

                        HasCountry)
                        return String.Format("{0}",
                            

                            Country);
                    else if (

                        HasCity)
                        return String.Format("{0}",
                            

                            StreetName);


                    break;
                case NameType.Thing:
                    return ThingName;
                default: return Name;
            }
        }
        public virtual String ToKeyString()
        {
            switch (Type)
            {
                case NameType.Person:
                    if (UseTitle && HasTitle && HasGivenName && HasMiddleName && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}{3}{4}", Proper(Title), Proper(Given), Proper(Middle), Proper(Sur), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasGivenName && HasMiddleName && HasSurName) return String.Format("{0}{1}{2}{3}", Proper(Title), Proper(Given), Proper(Middle), Proper(Sur));
                    else if (UseTitle && HasTitle && HasGivenName && HasMiddleName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}{3}", Proper(Title), Proper(Given), Proper(Middle), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasGivenName && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}{3}", Proper(Title), Proper(Given), Proper(Sur), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasMiddleName && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}{3}", Proper(Title), Proper(Middle), Proper(Sur), Proper(Suffix));
                    else if (HasGivenName && HasMiddleName && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}{3}", Proper(Given), Proper(Middle), Proper(Sur), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasGivenName && HasMiddleName) return String.Format("{0}{1}{2}", Proper(Title), Proper(Given), Proper(Middle));
                    else if (UseTitle && HasTitle && HasGivenName && HasSurName) return String.Format("{0}{1}{2}", Proper(Title), Proper(Given), Proper(Sur));
                    else if (UseTitle && HasTitle && HasGivenName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}", Proper(Title), Proper(Given), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasMiddleName && HasSurName) return String.Format("{0}{1}{2}", Proper(Title), Proper(Middle), Proper(Sur));
                    else if (UseTitle && HasTitle && HasMiddleName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}", Proper(Title), Proper(Middle), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}", Proper(Title), Proper(Sur), Proper(Suffix));
                    else if (HasGivenName && HasMiddleName && HasSurName) return String.Format("{0}{1}{2}", Proper(Given), Proper(Middle), Proper(Sur));
                    else if (HasGivenName && HasMiddleName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}", Proper(Given), Proper(Middle), Proper(Suffix));
                    else if (HasGivenName && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}", Proper(Given), Proper(Sur), Proper(Suffix));
                    else if (HasMiddleName && HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}{2}", Proper(Middle), Proper(Sur), Proper(Suffix));
                    else if (UseTitle && HasTitle && HasGivenName) return String.Format("{0}{1}", Proper(Title), Proper(Given));
                    else if (UseTitle && HasTitle && HasMiddleName) return String.Format("{0}{1}", Proper(Title), Proper(Middle));
                    else if (UseTitle && HasTitle && HasSurName) return String.Format("{0}{1}", Proper(Title), Proper(Sur));
                    else if (UseTitle && HasTitle && UseSuffix && HasSuffix) return String.Format("{0}{1}", Proper(Title), Proper(Suffix));
                    else if (HasGivenName && HasMiddleName) return String.Format("{0}{1}", Proper(Given), Proper(Middle));
                    else if (HasGivenName && HasSurName) return String.Format("{0}{1}", Proper(Given), Proper(Sur));
                    else if (HasGivenName && UseSuffix && HasSuffix) return String.Format("{0}{1}", Proper(Given), Proper(Suffix));
                    else if (HasMiddleName && HasSurName) return String.Format("{0}{1}", Proper(Middle), Proper(Sur));
                    else if (HasMiddleName && UseSuffix && HasSuffix) return String.Format("{0}{1}", Proper(Middle), Proper(Suffix));
                    else if (HasSurName && UseSuffix && HasSuffix) return String.Format("{0}{1}", Proper(Sur), Proper(Suffix));
                    else if (UseTitle && HasTitle) return Proper(Title);
                    else if (HasGivenName) return Proper(Given);
                    else if (HasMiddleName) return Proper(Middle);
                    else if (HasSurName) return Proper(Sur);
                    else if (UseSuffix && HasSuffix) return Proper(Suffix);
                    else return "";
                case NameType.Organization:
                    return Proper(ThingName);
                case NameType.Place:
                    break;
                case NameType.Thing:
                    return Proper(ThingName);
                default: return Name;
            }
        }
        /**/
    }

}