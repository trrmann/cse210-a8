using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonRisk : JsonDescribedObject
    {
        protected Risk Risk { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject {
            get {
                return Risk;
            }
            set {
                if(value.GetType().IsInstanceOfType(typeof(Risk)))
                {
                    Risk = (Risk)value;
                }
                else
                {
                    Risk = new();
                    Risk.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return Risk.Description; } set { Risk.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Severity")]
        public String Severity { get { return Risk.Severity; } set { Risk.Severity = value; } }
        public JsonRisk()
        {
            Risk = new();
        }
        [JsonConstructor]
        public JsonRisk(JsonNamedObject NamedObject, String Description, String Severity) : base(NamedObject, Description)
        {
            this.NamedObject = NamedObject;
            this.Description=Description;
            this.Severity = Severity;
        }
        public JsonRisk(Risk Risk) : base(Risk, Risk.Description)
        {
            this.Risk = Risk;
        }
        public static implicit operator JsonRisk(Risk risk)
        {
            return new(risk);
        }
        public static implicit operator Risk(JsonRisk risk)
        {
            return risk.Risk;
        }
    }
    public class Risk : DescribedObject
    {
        internal String Severity { get; set; } = "";
        public Risk()
        {
            Init();
        }
        public Risk(Boolean interactive)
        {
            Init(interactive);
        }
        public Risk(String name, NameType type, String Description, String Severity, Boolean interactive = false)
        {
            Init(name, type, Description, Severity, interactive);
        }
        public Risk(String riskName, String riskDescription, String severity, Boolean interactive = false)
        {
            Init(riskName, riskDescription, severity, interactive);
        }
        public Risk(DescribedObject name, String Severity, Boolean interactive = false)
        {
            Init(name, Severity, interactive);
        }
        public Risk(Name name, String Description, String Severity, Boolean interactive = false)
        {
            Init(name, Description, Severity, interactive);
        }
        public Risk(Risk risk, Boolean interactive = false)
        {
            Init(risk, interactive);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", "", interactive);
        }
        protected void Init(String name, NameType type, String Description, String Severity, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, Severity, interactive);
        }
        protected void Init(DescribedObject Name, String Severity, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, Severity, interactive);
        }
        protected void Init(Name Name, String Description, String Severity, Boolean interactive = false)
        {
            base.Init(Name, Description, interactive);
            if (interactive)
            {
                this.Severity = Severity;
                RequestSeverity();
            }
            else this.Severity = Severity;
        }
        private void Init(Risk risk, Boolean interactive = false)
        {
            base.Init(risk, interactive);
            Severity = risk.Severity;
        }
        protected void Init(String riskName, String riskDescription, String severity, Boolean interactive = false)
        {
            switch (riskName)
            {
                case "":
                    Init(interactive);
                    break;
                default:
                    base.Init(riskName, riskDescription, interactive);
                    Severity = severity;
                    break;
            }
        }
        protected override void DisplaySetNameMessage()
        {
            Console.WriteLine("\nSet risk name");
        }
        protected override void DisplaySetDescriptionMessage()
        {
            Console.WriteLine("\nSet risk Description");
        }
        protected override void DisplayRequestNameMessage()
        {
            Console.WriteLine("\nPlease enter the risk name.");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine("\nPlease enter the risk description.");
        }
        protected void DisplayRequestSeverityMessage()
        {
            Console.WriteLine("\nPlease enter the risk Severity.");
        }
        protected virtual void DisplaySetSeverityMessage()
        {
            Console.WriteLine("\nSet risk severity");
        }
        protected void DisplayRequestSeverity()
        {
            DisplayRequestSeverityMessage();
            Severity = IApplication.READ_RESPONSE();
        }
        protected Boolean HasSeverity()
        {
            return (Severity != "");
        }
        internal void RequestSeverity()
        {
            Boolean setSeverity = true;
            this.DisplaySetSeverityMessage();
            if (HasSeverity())
            {
                Display(false, true, -1);
                this.DisplayRequestSeverity();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setSeverity = false;
            }
            if (setSeverity) DisplayRequestSeverity();
        }
        internal Risk CreateCopy(String newName)
        {
            Risk result = new(this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
            if (option >= 0) Console.WriteLine(String.Format("{0}   {1}", new string(' ', option.ToString().Length), Severity));
            else Console.WriteLine(String.Format("\t{0}", Severity));
        }
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            if (name) { base.Display(option); }
            if (name && description)
            {
                if (option >= 0)
                {
                    foreach (char character in option.ToString()) { Console.Write(' '); }
                    Console.WriteLine(String.Format("   {0}", Severity));
                }
                else
                {
                    Console.WriteLine(String.Format("\t{0}", Severity));
                }
            }
            else if (description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("   {0}", Severity));
                }
                else
                {
                    Console.WriteLine(String.Format("\t{0}", Severity));
                }
            }
        }
    }
}