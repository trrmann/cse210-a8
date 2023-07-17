using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonNamedObject), typeDiscriminator: "NamedObject")]
    [JsonDerivedType(typeof(JsonDescribedObject), typeDiscriminator: "DescribedObject")]
    public class JsonNamedObject
    {
        protected NamedObject _namedObject { get; set; } = new();
        protected String Key { get { return _namedObject.Key; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Name")]
        public JsonName Name
        {
            get {
                return _namedObject.Name;
            } set {
                _namedObject.Name = value;
            }
        }
        protected JsonNamedObject NamedObject {
            get {
                return _namedObject;
            } set {
                _namedObject = value;
            }
        }
        public JsonNamedObject()
        {
            Init();
        }
        [JsonConstructor]
        public JsonNamedObject(JsonName Name)
        {
            Init(Name);
        }
        public JsonNamedObject(JsonNamedObject NamedObject)
        {
            Init(NamedObject);
        }
        public JsonNamedObject(NamedObject NamedObject)
        {
            Init(NamedObject);
        }
        public JsonNamedObject(String Name, NameType Type)
        {
            Init(Name, Type);
        }
        protected virtual void Init()
        {
            Init("", NameType.Thing);
        }
        protected void Init(String Name, NameType Type)
        {
            _namedObject.Name.Value = Name;
            _namedObject.Name.Type = Type;
        }
        protected void Init(JsonName Name)
        {
            Init(Name.Name, Name.Type);
        }
        protected void Init(JsonNamedObject NamedObject)
        {
            this.NamedObject = NamedObject;
        }
        protected void Init(NamedObject NamedObject)
        {
            _namedObject = NamedObject;
        }
        public static implicit operator JsonNamedObject(NamedObject namedObject)
        {
            return new(namedObject);
        }
        public static implicit operator NamedObject(JsonNamedObject namedObject) {
            return namedObject._namedObject;
        }
    }
    public class NamedObject
    {
        internal String Key { get { return CaculateKey(); } }
        internal Name Name { get; set; } = new();
        public NamedObject()
        {
            Init();
        }
        public NamedObject(Boolean interactive)
        {
            Init(interactive);
        }
        public NamedObject(String name, NameType type, Boolean interactive = false)
        {
            Init(name, type, interactive);
        }
        public NamedObject(NamedObject name, Boolean interactive = false)
        {
            Init(name, interactive);
        }
        public NamedObject(Name name, Boolean interactive = false)
        {
            Init(name, interactive);
        }
        protected virtual void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, interactive);
        }
        protected void Init(String name, NameType type, Boolean interactive = false)
        {
            Init(new Name(name, type), interactive);
        }
        protected void Init(NamedObject Name, Boolean interactive = false)
        {
            Init(Name.Name, interactive);
        }
        protected void Init(Name Name, Boolean interactive = false)
        {
            if (interactive)
            {
                this.Name = Name;
                RequestName();
            }
            else  this.Name = Name;
        }
        public static implicit operator String(NamedObject namedObject)
        {
            return namedObject;
        }
        public static implicit operator NamedObject(String name)
        {
            return new Name(name, NameType.Thing);
        }
        public static implicit operator NameType(NamedObject namedObject)
        {
            return namedObject;
        }
        public static implicit operator NamedObject(NameType type)
        {
            return new Name("", type);
        }
        public static implicit operator Name(NamedObject namedObject)
        {
            return namedObject.Name;
        }
        public static implicit operator NamedObject(Name name)
        {
            return new NamedObject(name);
        }
        protected virtual void DisplayRequestNameMessage()
        {
            Console.WriteLine("\nPlease enter NamedObject.");
        }
        protected virtual void DisplaySetNameMessage()
        {
            Console.WriteLine("\nSet NamedObject");
        }
        protected virtual void DisplayRequestReSetNameMessage()
        {
            Console.WriteLine("\nRename?");
        }
        protected void DisplayRequestName(NameType type)
        {
            DisplayRequestNameMessage();
            Init(IApplication.READ_RESPONSE(), type);
        }
        internal void RequestName()
        {
            Boolean setName = true;
            this.DisplaySetNameMessage();
            if (IsNamed())
            {
                Display(-1);
                this.DisplayRequestReSetNameMessage();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setName = false;
            }
            if (setName) DisplayRequestName(Name);
        }
        protected Boolean IsNamed()
        {
            return (Name != "");
        }
        internal virtual void Display(int option = -1)
        {
            Name.Display(option);
        }
        internal String ToName()
        {
            return Name.Value;
        }
        internal String ToProper()
        {
            return IStringUtilities.Proper(Name.Value);
        }
        internal virtual String CaculateKey()
        {
            if (Name is null) return ""; else return IStringUtilities.ProperKey(Name.Value);
        }
    }
}