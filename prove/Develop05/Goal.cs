using System.Text.Json.Serialization;

namespace Develop05
{
    public interface IGoal
    {
        void DisplayRequestName();
        void DisplayRequestDescription();
        void DisplayRequestPointValue();
        void RequestName();
        void RequestDescription();
        void RequestPointValue();
        String ReadResponse();
    }
    public abstract class Goal : IGoal
    {
        internal void Init(Boolean empty = false) {
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
        internal void Init(Goal goal)
        {
            Name = goal.Name;
            Description = goal.Description;
            PointValue = goal.PointValue;
        }
        protected String Name { get; set; }
        protected String Description { get; set; }
        protected int PointValue { get; set; }
        public abstract void DisplayGoal(int index = -1);
        public abstract Boolean IsCompleted();
        public virtual void DisplayRequestName()
        {
            Console.WriteLine("Please enter the name of your goal.");
        }
        public virtual void DisplayRequestDescription()
        {
            Console.WriteLine("Please enter the description of your goal.");
        }
        public virtual void DisplayRequestPointValue()
        {
            Console.WriteLine("Please enter the point value of your goal.");
        }
        public String ReadResponse()
        {
            Console.Write(">  ");
            return Console.ReadLine();
        }
        public void RequestName()
        {
            DisplayRequestName();
            Name = ReadResponse();
        }
        public void RequestDescription()
        {
            DisplayRequestDescription();
            Description = ReadResponse();
        }
        public void RequestPointValue()
        {
            DisplayRequestPointValue();
            PointValue = int.Parse(ReadResponse());
        }
        public abstract int Report();
    }
    [Serializable]
    [JsonDerivedType(typeof(JSONSimpleGoal), typeDiscriminator: "Simple")]
    [JsonDerivedType(typeof(JSONEternalGoal), typeDiscriminator: "Eternal")]
    [JsonDerivedType(typeof(JSONChecklistGoal), typeDiscriminator: "Checklist")]
    public abstract class JSONGoal : Goal, IGoal
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
