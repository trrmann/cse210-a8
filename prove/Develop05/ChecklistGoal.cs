using System.Text.Json.Serialization;

namespace Develop05
{
    public class ChecklistGoal : Goal
    {
        public ChecklistGoal(Configuration configuration, Boolean empty = false)
        {
            Init(configuration, empty);
        }
        public ChecklistGoal(Goal goal)
        {
            Init(goal);
            NumberOfTimes = ((ChecklistGoal)goal).NumberOfTimes;
            BonusPointValue = ((ChecklistGoal)goal).BonusPointValue;
            TargetNumberOfTimes = ((ChecklistGoal)goal).TargetNumberOfTimes;
        }
        protected new void Init(Configuration configuration, Boolean empty = false)
        {
            base.Init(configuration, empty);
            if(empty)
            {
                NumberOfTimes = 0;
                BonusPointValue = 0;
            } else
            {
                RequestNumberOfTimes();
                RequestBonusPoints();
            }
            NumberOfTimes = 0;
        }
        internal int TargetNumberOfTimes { get; set; }
        internal int NumberOfTimes { get; set; }
        internal int BonusPointValue { get; set; }
        public override void DisplayRequestPointValue()
        {
            Console.WriteLine(Configuration.Dictionary["RequestRepeatPointValueMessage"]);
        }
        public virtual void DisplayRequestNumberOfTimes()
        {
            Console.WriteLine(Configuration.Dictionary["RequestChecklistCompleteCountMessage"]);
        }
        public virtual void DisplayRequestBonusPoints()
        {
            Console.WriteLine(Configuration.Dictionary["RequestChecklistBonusPointValueMessage"]);
        }
        public void RequestNumberOfTimes()
        {
            DisplayRequestNumberOfTimes();
            TargetNumberOfTimes = int.Parse(IApplication.ReadResponse(Configuration));
        }
        public void RequestBonusPoints()
        {
            DisplayRequestBonusPoints();
            BonusPointValue = int.Parse(IApplication.ReadResponse(Configuration));
        }
        internal static Boolean IsCompleted(ChecklistGoal goal)
        {
            return goal.NumberOfTimes >= goal.TargetNumberOfTimes;
        }
        public override Boolean IsCompleted()
        {
            return IsCompleted(this);
        }
        internal static void DisplayGoal(ChecklistGoal goal, Configuration configuration, int index = -1)
        {
            Char check = (Char)configuration.Dictionary["IncompleteSymbol"];
            if (goal.IsCompleted()) check = (Char)configuration.Dictionary["CompleteSymbol"];
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["ChecklistGoalIndexedDisplayFormat"], index, check, goal.Name, goal.Description, goal.NumberOfTimes, goal.TargetNumberOfTimes));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["ChecklistGoalNonIndexedDisplayFormat"], check, goal.Name, goal.Description, goal.NumberOfTimes, goal.TargetNumberOfTimes));
        }
        public override void DisplayGoal(int index = -1)
        {
            DisplayGoal(this, Configuration, index);
        }
        internal static int Report(ChecklistGoal goal)
        {
            goal.NumberOfTimes++;
            if (goal.IsCompleted()) return goal.PointValue + goal.BonusPointValue;
            else return goal.PointValue;
        }
        public override int Report()
        {
            return Report(this);
        }
        public static explicit operator ChecklistGoal(JSONGoal goal)
        {
            ChecklistGoal result = null;
            if (goal.GetType() == typeof(JSONChecklistGoal))
            {
                result = new(goal.Configuration, true);
                result.Init((JSONChecklistGoal)goal);
                result.TargetNumberOfTimes = ((JSONChecklistGoal)goal).TargetNumberOfTimes;
                result.NumberOfTimes = ((JSONChecklistGoal)goal).NumberOfTimes;
                result.BonusPointValue = ((JSONChecklistGoal)goal).BonusPointValue;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONChecklistGoal : JSONGoal
    {
        [JsonConstructor]
        public JSONChecklistGoal() { }
        [JsonInclude]
        [JsonPropertyName("Target Number of Times")]
        [JsonPropertyOrder(5)]
        public int TargetNumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("Number of Times")]
        [JsonPropertyOrder(4)]
        public int NumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("Bonus Point Value")]
        [JsonPropertyOrder(3)]
        public int BonusPointValue { get; set; }
        public JSONChecklistGoal(Goal goal)
        {
            if (goal.GetType() == typeof(ChecklistGoal))
            {
                Init((ChecklistGoal)goal);
                TargetNumberOfTimes = ((ChecklistGoal)goal).TargetNumberOfTimes;
                NumberOfTimes = ((ChecklistGoal)goal).NumberOfTimes;
                BonusPointValue = ((ChecklistGoal)goal).BonusPointValue;
            }
        }
        public override void DisplayGoal(int index = -1)
        {
            ChecklistGoal.DisplayGoal((ChecklistGoal)(Goal)(JSONGoal)this, Configuration, index);
        }
        public override bool IsCompleted()
        {
            return ChecklistGoal.IsCompleted((ChecklistGoal)(Goal)(JSONGoal)this);
        }
        public override int Report()
        {
            return ChecklistGoal.Report((ChecklistGoal)(Goal)(JSONGoal)this);
        }
    }
}