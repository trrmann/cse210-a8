using System;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonDescribedObject), typeDiscriminator: "DescribedObject")]
    [JsonDerivedType(typeof(JsonDescribedObjectDictionary<>), typeDiscriminator: "DescribedObjectDictionary")]
    [JsonDerivedType(typeof(JsonPlan), typeDiscriminator: "Plan")]
    [JsonDerivedType(typeof(JsonRisk), typeDiscriminator: "Risk")]
    [JsonDerivedType(typeof(JsonTask), typeDiscriminator: "Task")]
    public class JsonDescribedObject : JsonNamedObject
    {
        internal DescribedObject _describedObject
        {
            get
            {
                DescribedObject describedObject = new DescribedObject();
                if (base._namedObject is null) base._namedObject = describedObject;
                if (!base._namedObject.GetType().IsInstanceOfType(describedObject.GetType())) base._namedObject = describedObject;
                return (DescribedObject)base._namedObject;
            }
            set
            {
                if (base._namedObject is null) base._namedObject = new DescribedObject();
                base._namedObject = value;
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public String Description { get { return _describedObject.Description; } set { _describedObject.Description = value; } }

        public JsonDescribedObject()
        {
            Init();
        }
        [JsonConstructor]
        public JsonDescribedObject(String Name, NameType Type, String Description)
        {
            Init(Name, Type, Description);
        }
        public JsonDescribedObject(JsonNamedObject Name, String Description)
        {
            Init(Name, Description);
        }
        public JsonDescribedObject(DescribedObject DescribedObject)
        {
            Init(DescribedObject);
        }
        protected override void Init()
        {
            NamedObject = new();
        }
        protected void Init(String Name, NameType Type, String Description)
        {
            Init(new NamedObject(Name, Type), Description);
        }
        protected void Init(JsonNamedObject Name, String Description)
        {
            this.NamedObject = Name;
            this.Description = Description;
        }
        protected void Init(DescribedObject DescribedObject)
        {
            _describedObject = DescribedObject;
        }
        public static implicit operator JsonDescribedObject(DescribedObject DescribedObject)
        {
            return new(DescribedObject);
        }
        public static implicit operator DescribedObject(JsonDescribedObject JsonDescribedObject)
        {
            return JsonDescribedObject._describedObject;
        }
    }
    public class DescribedObject : NamedObject
    {
        internal String Description { get; set; }
        public DescribedObject()
        {
            Init();
        }
        public DescribedObject(Boolean interactive)
        {
            Init(interactive);
        }
        public DescribedObject(String name, NameType type, String Description, Boolean interactive = false)
        {
            Init(name, type, Description, interactive);
        }
        public DescribedObject(DescribedObject name, Boolean interactive = false)
        {
            Init(name, interactive);
        }
        public DescribedObject(Name name, String Description, Boolean interactive = false)
        {
            Init(name, Description, interactive);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", interactive);
        }
        protected void Init(String name, NameType type, String Description, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, interactive);
        }
        protected void Init(DescribedObject Name, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, interactive);
        }
        protected void Init(Name Name, String Description, Boolean interactive = false)
        {
            base.Init(Name, interactive);
            if (interactive)
            {
                this.Description = Description;
                RequestDescription();
            }
            else this.Description = Description;
        }
        public static implicit operator String(DescribedObject describedObject)
        {
            return describedObject;
        }
        public static implicit operator DescribedObject(String name)
        {
            return new Name(name, NameType.Thing);
        }
        public static implicit operator NameType(DescribedObject describedObject)
        {
            return describedObject;
        }
        public static implicit operator DescribedObject(NameType type)
        {
            return new Name("", type);
        }
        public static implicit operator Name(DescribedObject describedObject)
        {
            return describedObject.Name;
        }
        public static implicit operator DescribedObject(Name name)
        {
            return new DescribedObject(name);
        }
        protected override void DisplayRequestNameMessage()
        {
            base.DisplayRequestNameMessage();
        }
        protected virtual void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine("\nPlease enter description.");
        }
        protected override void DisplaySetNameMessage()
        {
            base.DisplaySetNameMessage();
        }
        protected virtual void DisplaySetDescriptionMessage()
        {
            Console.WriteLine("\nSet Description");
        }
        protected override void DisplayRequestReSetNameMessage()
        {
            base.DisplayRequestReSetNameMessage();
        }
        protected virtual void DisplayRequestReSetDescriptionMessage()
        {
            Console.WriteLine("\nRedescribe?");
        }
        protected void DisplayRequestDescription()
        {
            DisplayRequestDescriptionMessage();
            Description = IApplication.READ_RESPONSE();
        }
        internal void RequestDescription()
        {
            Boolean setDescription = true;
            this.DisplaySetDescriptionMessage();
            if (IsDescribed())
            {
                Display(false, true, -1);
                this.DisplayRequestReSetDescriptionMessage();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setDescription = false;
            }
            if (setDescription) DisplayRequestDescription();
        }
        protected Boolean IsDescribed()
        {
            return (Description != "");
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
            if (option >= 0) Console.WriteLine(String.Format("{0}   {1}", new string(' ',option.ToString().Length), Description));
            else Console.WriteLine(String.Format("\t{0}", Description));
        }
        internal virtual void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            if (name) { base.Display(option); }
            if (name && description)
            {
                if (option >= 0)
                {
                    foreach (char character in option.ToString()) { Console.Write(' '); }
                    Console.WriteLine(String.Format("   {0}", Description));
                }
                else Console.WriteLine(String.Format("\t{0}", Description));
            }
            else if (description)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0})  {1}", option, Description));
                else Console.WriteLine(String.Format("\t{0}", Description));
            }
        }
    }
}