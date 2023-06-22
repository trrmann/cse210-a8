using Develop05External;
using System.Text.Json.Serialization;

namespace Develop05
{
    public abstract class Goal
    {
        protected virtual void Init(Configuration configuration, Boolean empty = false) {
            Configuration = configuration;
            if (empty)
            {
                Name = "";
                Description = "";
                PointValue = 0;
            }
            else
            {
                RequestName();
                RequestDescription();
                RequestPointValue();
            }
        }
        protected virtual void Init(Goal goal)
        {
            Name = goal.Name;
            Description = goal.Description;
            PointValue = goal.PointValue;
            Configuration = goal.Configuration;
        }
        protected String Name { get; set; }
        protected String Description { get; set; }
        protected int PointValue { get; set; }
        internal Configuration Configuration { get; set; }
        internal abstract void DisplayGoal(int index = -1);
        internal abstract Boolean IsCompleted();
        internal virtual void DisplayRequestName()
        {
            Console.WriteLine(Configuration.Dictionary["RequestNameMessage"]);
        }
        internal virtual void DisplayRequestDescription()
        {
            Console.WriteLine(Configuration.Dictionary["RequestDescriptionMessage"]);
        }
        internal virtual void DisplayRequestPointValue()
        {
            Console.WriteLine(Configuration.Dictionary["RequestPointValueMessage"]);
        }
        internal void RequestName()
        {
            DisplayRequestName();
            Name = IApplication.READ_RESPONSE(Configuration);
        }
        internal void RequestDescription()
        {
            DisplayRequestDescription();
            Description = IApplication.READ_RESPONSE(Configuration);
        }
        internal void RequestPointValue()
        {
            DisplayRequestPointValue();
            PointValue = int.Parse(IApplication.READ_RESPONSE(Configuration));
        }
        internal abstract int Report();
    }
    [Serializable]
    [JsonDerivedType(typeof(JSONSimpleGoal), typeDiscriminator: "Simple")]
    [JsonDerivedType(typeof(JSONEternalGoal), typeDiscriminator: "Eternal")]
    [JsonDerivedType(typeof(JSONChecklistGoal), typeDiscriminator: "Checklist")]
    [JsonDerivedType(typeof(JSONSimpleSMARTGoal), typeDiscriminator: "SimpleSmartGoal")]
    [JsonDerivedType(typeof(JSONEternalSMARTGoal), typeDiscriminator: "EternalSmartGoal")]
    [JsonDerivedType(typeof(JSONChecklistSMARTGoal), typeDiscriminator: "ChecklistSmartGoal")]
    public abstract class JSONGoal : Goal
    {
        [JsonInclude]
        [JsonPropertyName("Name")]
        [JsonPropertyOrder(0)]
        public new String Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }
        [JsonInclude]
        [JsonPropertyName("Description")]
        [JsonPropertyOrder(1)]
        public new String Description {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
            }
        }
        [JsonInclude]
        [JsonPropertyName("Point Value")]
        [JsonPropertyOrder(2)]
        public new int PointValue {
            get
            {
                return base.PointValue;
            }
            set
            {
                base.PointValue = value;
            }
        }
    }
}
