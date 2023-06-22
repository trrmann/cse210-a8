using Develop05External;
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
            if(goal.GetType() == typeof(ChecklistSMARTGoal))
            {
                NumberOfTimes = ((ChecklistSMARTGoal)goal).NumberOfTimes;
                BonusPointValue = ((ChecklistSMARTGoal)goal).BonusPointValue;
                TargetNumberOfTimes = ((ChecklistSMARTGoal)goal).TargetNumberOfTimes;
            }
            else if (goal.GetType() == typeof(ChecklistGoal))
            {
                NumberOfTimes = ((ChecklistGoal)goal).NumberOfTimes;
                BonusPointValue = ((ChecklistGoal)goal).BonusPointValue;
                TargetNumberOfTimes = ((ChecklistGoal)goal).TargetNumberOfTimes;
            }
        }
        internal new void Init(Configuration configuration, Boolean empty = false)
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
        internal override void DisplayRequestPointValue()
        {
            Console.WriteLine(Configuration.Dictionary["RequestRepeatPointValueMessage"]);
        }
        internal virtual void DisplayRequestNumberOfTimes()
        {
            Console.WriteLine(Configuration.Dictionary["RequestChecklistCompleteCountMessage"]);
        }
        internal virtual void DisplayRequestBonusPoints()
        {
            Console.WriteLine(Configuration.Dictionary["RequestChecklistBonusPointValueMessage"]);
        }
        internal void RequestNumberOfTimes()
        {
            DisplayRequestNumberOfTimes();
            TargetNumberOfTimes = int.Parse(IApplication.READ_RESPONSE(Configuration));
        }
        internal void RequestBonusPoints()
        {
            DisplayRequestBonusPoints();
            BonusPointValue = int.Parse(IApplication.READ_RESPONSE(Configuration));
        }
        internal static Boolean IS_COMPLETED(ChecklistGoal goal)
        {
            return goal.NumberOfTimes >= goal.TargetNumberOfTimes;
        }
        internal override Boolean IsCompleted()
        {
            return IS_COMPLETED(this);
        }
        internal static void DISPLAY_GOAL(ChecklistGoal goal, Configuration configuration, int index = -1)
        {
            Char check = (Char)configuration.Dictionary["IncompleteSymbol"];
            if (goal.IsCompleted()) check = (Char)configuration.Dictionary["CompleteSymbol"];
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["ChecklistGoalIndexedDisplayFormat"], index, check, goal.Name, goal.Description, goal.NumberOfTimes, goal.TargetNumberOfTimes));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["ChecklistGoalNonIndexedDisplayFormat"], check, goal.Name, goal.Description, goal.NumberOfTimes, goal.TargetNumberOfTimes));
        }
        internal override void DisplayGoal(int index = -1)
        {
            DISPLAY_GOAL(this, Configuration, index);
        }
        internal static int REPORT(ChecklistGoal goal)
        {
            goal.NumberOfTimes++;
            if (goal.IsCompleted()) return goal.PointValue + goal.BonusPointValue;
            else return goal.PointValue;
        }
        internal override int Report()
        {
            return REPORT(this);
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
        internal override void DisplayGoal(int index = -1)
        {
            ChecklistGoal.DISPLAY_GOAL((ChecklistGoal)(Goal)(JSONGoal)this, Configuration, index);
        }
        internal override Boolean IsCompleted()
        {
            return ChecklistGoal.IS_COMPLETED((ChecklistGoal)(Goal)(JSONGoal)this);
        }
        internal override int Report()
        {
            return ChecklistGoal.REPORT((ChecklistGoal)(Goal)(JSONGoal)this);
        }
    }
}