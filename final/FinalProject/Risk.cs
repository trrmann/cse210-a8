using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonRisk : JsonDescribedObject
    {
        protected Risk Risk { get { return (Risk)base._namedObject; } set { base._namedObject = value; } }
        [JsonConstructor]
        public JsonRisk(JsonName name, String description) : base(name, description)
        {
        }
        public JsonRisk(Risk risk) : base((DescribedObject)risk)
        {
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
        protected String Severity { get; set; }
        public Risk(String riskName, String riskDescription, String severity)
        {
            Init(riskName, riskDescription, severity);
        }
        public Risk(Boolean empty = true)
        {
            Init(empty);
        }
        public Risk(Risk risk)
        {
            Init(risk);
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the risk name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the risk description.");
        }
        protected void Init(String riskName, String riskDescription, String severity, Boolean empty = true)
        {
            switch (riskName)
            {
                case "":
                    Init(false);
                    break;
                default:
                    Name = new ThingName(riskName);
                    Description = riskDescription;
                    Severity = severity;
                    break;
            }
        }
        private void Init(Risk risk)
        {
            Name = risk.Name;
            Description = risk.Description;
            Severity = risk.Severity;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override Risk CreateCopy(String newName)
        {
            Risk result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}