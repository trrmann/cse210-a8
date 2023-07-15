using System;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace FinalProject
{
    internal class JsonDescribedObject : JsonNamedObject
    {
        protected DescribedObject _describedObject {
            get {
                DescribedObject describedObject = new DescribedObject();
                if(base._namedObject is null) base._namedObject = describedObject;
                if (!base._namedObject.GetType().IsInstanceOfType(describedObject.GetType())) base._namedObject = describedObject;
                return (DescribedObject)base._namedObject;
            } set {
                if (base._namedObject is null) base._namedObject = new DescribedObject();
                base._namedObject = value;
            } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public String Description { get { return _describedObject.Description; } set { _describedObject.Description = value; } }
        public JsonDescribedObject() : base((JsonNamedObject)new()) 
        {
            Description = "";
        }
        [JsonConstructor]
        public JsonDescribedObject(JsonName Name, String Description) : base(Name)
        {
            this.Description = Description;
        }
        public JsonDescribedObject(DescribedObject describedObject) : base((NamedObject)describedObject)
        {
        }
        public static implicit operator JsonDescribedObject(DescribedObject describedObject)
        {
            return new(describedObject);
        }
        public static implicit operator DescribedObject(JsonDescribedObject describedObject)
        {
            return describedObject._describedObject;
        }

        internal static JsonDescribedObject Convert<DO>(DO describedObject) where DO : DescribedObject
        {
            return new JsonDescribedObject(describedObject);
        }
        internal virtual JDO Convert<JDO>() where JDO : JsonDescribedObject, new()
        {
            JDO jsonG = new();
            jsonG._describedObject = this._describedObject;
            return jsonG;
        }
    }
    public class DescribedObject : NamedObject
    {
        internal String Description { get; set; }
        protected override void Init(Boolean empty = true)
        {
            Init(NameType.Thing, empty);
        }
        protected override void Init(NameType type, Boolean empty = true)
        {
            base.Init(type, empty);
            if (empty) Description = "";
            else RequestDescription();
        }
        protected override void Init(Name name)
        {
            base.Init(name);
        }
        protected virtual void Init(Name name, String description)
        {
            base.Init(name);
            Description = description;
        }
        public DescribedObject()
        {
            Init();
        }
        public DescribedObject(Name name)
        {
            Init(name);
        }
        public DescribedObject(Name name, String description)
        {
            Init(name, description);
        }
        internal static DescribedObject CreateDescribedObject()
        {
            return new DescribedObject();
        }
        protected virtual void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the description.");
        }
        protected void RequestDescription()
        {
            DisplayRequestDescription();
            Description = IApplication.READ_RESPONSE();
        }
        protected Boolean IsDescribed()
        {
            return (Description != null) && (Description != "");
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
                else Console.WriteLine(String.Format("{0}", Description));
            }
            else if (description)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0})  {1}", option, Description));
                else Console.WriteLine(String.Format("{0}", Description));
            }
        }
        protected virtual void DisplaySetDescription()
        {
            Console.WriteLine("\nSet Description");
        }
        protected virtual void DisplayRequestReSetDescription()
        {
            Console.WriteLine("\nRedescribe?");
        }
        protected virtual void DisplayRequestSetDescription()
        {
            Console.WriteLine("\nWhat is the description?");
        }
        internal void SetDescription()
        {
            Boolean setDescription = true;
            this.DisplaySetDescription();
            if (IsDescribed())
            {
                Display(false, true, -1);
                this.DisplayRequestReSetDescription();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setDescription = false;
            }
            if (setDescription)
            {
                this.DisplayRequestSetDescription();
                Description = IApplication.READ_RESPONSE();
            }
        }
        internal virtual DescribedObject CreateCopy(String newName)
        {
            /*TODO - CreateCopy*/
            throw new NotImplementedException();
        }
    }
}