using Develop05External;
using System.Text.Json.Serialization;

namespace Develop05
{
    public class ChecklistSMARTGoal : SMARTGoal
    {
        private ChecklistGoal Base { get; set; }
        internal DateTime LastUpdate { get; set; }
        internal int TargetNumberOfTimes { get; set; }
        internal int NumberOfTimes { get; set; }
        internal int BonusPointValue { get; set; }
        internal ChecklistSMARTGoal(Configuration configuration, Boolean empty = false)
        {
            Init(configuration, empty);
            if (empty)
            {
                NumberOfTimes = 0;
                BonusPointValue = 0;
            }
            else
            {
                RequestNumberOfTimes();
                RequestBonusPoints();
            }
            NumberOfTimes = 0;
        }
        internal ChecklistSMARTGoal(Goal goal)
        {
            Init(goal);
            if (goal.GetType() == typeof(ChecklistSMARTGoal))
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
            else if (goal.GetType() == typeof(JSONChecklistSMARTGoal))
            {
                NumberOfTimes = ((JSONChecklistSMARTGoal)goal).NumberOfTimes;
                BonusPointValue = ((JSONChecklistSMARTGoal)goal).BonusPointValue;
                TargetNumberOfTimes = ((JSONChecklistSMARTGoal)goal).TargetNumberOfTimes;
            }
        }
        private ChecklistSMARTGoal(SMARTGoal goal)
        {
            Init(goal);
            NumberOfTimes = ((ChecklistSMARTGoal)goal).NumberOfTimes;
            BonusPointValue = ((ChecklistSMARTGoal)goal).BonusPointValue;
            TargetNumberOfTimes = ((ChecklistSMARTGoal)goal).TargetNumberOfTimes;
        }
        protected override void Init(Configuration configuration, Boolean empty = false)
        {
            Base = new ChecklistGoal(configuration, true);
            base.Init(configuration, empty);
            LastUpdate = Created;
        }
        protected override void Init(Goal goal)
        {
            Base = new ChecklistGoal(goal);
            base.Init(goal);
            if (goal.GetType() == typeof(ChecklistGoal))
            {
                LastUpdate = Created;
            }
            else if (goal.GetType() == typeof(ChecklistSMARTGoal))
            {
                LastUpdate = ((ChecklistSMARTGoal)goal).LastUpdate;
            }
            else if (goal.GetType() == typeof(JSONChecklistSMARTGoal))
            {
                LastUpdate = ((JSONChecklistSMARTGoal)goal).LastUpdate;
                Created = ((JSONChecklistSMARTGoal)goal).Created;
                Timely = ((JSONChecklistSMARTGoal)goal).Timely;
                TimelyPointPentalty = ((JSONChecklistSMARTGoal)goal).TimelyPointPentalty;
            }
            else
            {
                LastUpdate = Created;
            }
        }
        protected override void Init(SMARTGoal goal)
        {
            Base = new ChecklistGoal(goal);
            base.Init(goal);
            LastUpdate = ((ChecklistSMARTGoal)goal).LastUpdate;
        }
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
        internal static void DISPLAY_GOAL(ChecklistSMARTGoal goal, Configuration configuration, int index = -1)
        {
            DateTime dueDate = goal.LastUpdate.AddDays(goal.Timely);
            Char check = (Char)configuration.Dictionary["IncompleteSymbol"];
            if (goal.IsCompleted()) check = (Char)configuration.Dictionary["CompleteSymbol"];
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["ChecklistSMARTGoalIndexedDisplayFormat"], index, check, goal.Name, goal.Description, goal.NumberOfTimes, goal.TargetNumberOfTimes, dueDate));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["ChecklistSMARTGoalNonIndexedDisplayFormat"], check, goal.Name, goal.Description, goal.NumberOfTimes, goal.TargetNumberOfTimes, dueDate));
        }
        internal override void DisplayGoal(int index = -1)
        {
            DISPLAY_GOAL(this, Configuration, index);
        }
        internal static Boolean IS_COMPLETED(ChecklistSMARTGoal goal)
        {
            return goal.NumberOfTimes >= goal.TargetNumberOfTimes;
        }
        internal override Boolean IsCompleted()
        {
            return IS_COMPLETED(this);
        }
        internal static int REPORT(ChecklistSMARTGoal goal)
        {
            DateTime dueDate = goal.LastUpdate.AddDays(goal.Timely);
            goal.LastUpdate = DateTime.Now;
            goal.NumberOfTimes++;
            if (goal.IsCompleted() && DateTime.Now <= dueDate) return goal.PointValue + goal.BonusPointValue;
            else if (goal.IsCompleted() && DateTime.Now > dueDate) return goal.PointValue + goal.BonusPointValue - goal.TimelyPointPentalty;
            else if (DateTime.Now > dueDate) return goal.PointValue - goal.TimelyPointPentalty;
            else return goal.PointValue;
        }
        internal override int Report()
        {
            return REPORT(this);
        }
        public static explicit operator ChecklistSMARTGoal(JSONSMARTGoal goal)
        {
            ChecklistSMARTGoal result = null;
            if (goal.GetType() == typeof(JSONChecklistSMARTGoal))
            {
                result = new(goal.Configuration, true);
                result.Init((JSONChecklistSMARTGoal)goal);
                result.LastUpdate = ((JSONChecklistSMARTGoal)goal).LastUpdate;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONChecklistSMARTGoal : JSONSMARTGoal
    {
        [JsonConstructor]
        public JSONChecklistSMARTGoal()
        {
            Init();
        }
        public override void Init()
        {
            Base = new ChecklistSMARTGoal(Configuration, true);
        }
        [JsonInclude]
        [JsonPropertyName("LastUpdate")]
        [JsonPropertyOrder(6)]
        public DateTime LastUpdate { get; set; }
        [JsonInclude]
        [JsonPropertyName("TargetNumberOfTimes")]
        [JsonPropertyOrder(7)]
        public int TargetNumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("NumberOfTimes")]
        [JsonPropertyOrder(8)]
        public int NumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("BonusPointValue")]
        [JsonPropertyOrder(9)]
        public int BonusPointValue { get; set; }
        public JSONChecklistSMARTGoal(Goal goal)
        {
            if (goal.GetType() == typeof(ChecklistSMARTGoal))
            {
                Init((ChecklistSMARTGoal)goal);
                LastUpdate = ((ChecklistSMARTGoal)goal).LastUpdate;
                TargetNumberOfTimes = ((ChecklistSMARTGoal)goal).TargetNumberOfTimes;
                NumberOfTimes = ((ChecklistSMARTGoal)goal).NumberOfTimes;
                BonusPointValue = ((ChecklistSMARTGoal)goal).BonusPointValue;
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
