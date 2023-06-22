using System.Text.Json.Serialization;

namespace Develop05
{
    public class EternalSMARTGoal : SMARTGoal
    {
        internal EternalGoal Base { get; set; }
        internal DateTime LastUpdate { get; set; }
        public EternalSMARTGoal(Configuration configuration, Boolean empty = false)
        {
            Init(configuration, empty);
        }
        public EternalSMARTGoal(Goal goal)
        {
            Init(goal);
        }
        public EternalSMARTGoal(SMARTGoal goal)
        {
            Init(goal);
        }
        protected override void Init(Configuration configuration, Boolean empty = false)
        {
            Base = new EternalGoal(configuration, true);
            base.Init(configuration, empty);
            LastUpdate = Created;
        }
        protected override void Init(Goal goal)
        {
            Base = new EternalGoal(goal);
            base.Init(goal);
            if (goal.GetType() == typeof(EternalGoal))
            {
                LastUpdate = Created;
            }
            else if (goal.GetType() == typeof(EternalSMARTGoal))
            {
                LastUpdate = ((EternalSMARTGoal)goal).LastUpdate;
            }
            else if (goal.GetType() == typeof(JSONEternalSMARTGoal))
            {
                LastUpdate = ((JSONEternalSMARTGoal)goal).LastUpdate;
                Created = ((JSONEternalSMARTGoal)goal).Created;
                Timely = ((JSONEternalSMARTGoal)goal).Timely;
                TimelyPointPentalty = ((JSONEternalSMARTGoal)goal).TimelyPointPentalty;
            }
            else
            {
                LastUpdate = Created;
            }
        }
        protected override void Init(SMARTGoal goal)
        {
            Base = new EternalGoal(goal);
            base.Init(goal);
            LastUpdate = ((EternalSMARTGoal)goal).LastUpdate;
        }
        internal static void DISPLAY_GOAL(EternalSMARTGoal goal, Configuration configuration, int index = -1)
        {
            DateTime dueDate = goal.LastUpdate.AddDays(goal.Timely);
            Char check = (Char)configuration.Dictionary["IncompleteSymbol"];
            if (goal.IsCompleted()) check = (Char)configuration.Dictionary["CompleteSymbol"];
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleSMARTGoalIndexedDisplayFormat"], index, check, goal.Name, goal.Description, dueDate));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleSMARTGoalNonIndexedDisplayFormat"], check, goal.Name, goal.Description, dueDate));
        }
        internal override void DisplayGoal(int index = -1)
        {
            DISPLAY_GOAL(this, Configuration, index);
        }
        internal static Boolean IS_COMPLETED(EternalSMARTGoal goal)
        {
            return false;
        }
        internal override Boolean IsCompleted()
        {
            return IS_COMPLETED(this);
        }
        internal static int REPORT(EternalSMARTGoal goal)
        {
            DateTime dueDate = goal.LastUpdate.AddDays(goal.Timely);
            goal.LastUpdate = DateTime.Now;
            if (DateTime.Now > dueDate) return goal.PointValue - goal.TimelyPointPentalty;
            else return goal.PointValue;
        }
        internal override int Report()
        {
            return REPORT(this);
        }
        public static explicit operator EternalSMARTGoal(JSONSMARTGoal goal)
        {
            EternalSMARTGoal result = null;
            if (goal.GetType() == typeof(JSONEternalSMARTGoal))
            {
                result = new(goal.Configuration, true);
                result.Init((JSONEternalSMARTGoal)goal);
                result.LastUpdate = ((JSONEternalSMARTGoal)goal).LastUpdate;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONEternalSMARTGoal : JSONSMARTGoal
    {
        [JsonConstructor]
        public JSONEternalSMARTGoal()
        {
            Init();
        }
        public override void Init()
        {
            Base = new EternalSMARTGoal(Configuration, true);
        }
        [JsonInclude]
        [JsonPropertyName("LastUpdate")]
        [JsonPropertyOrder(6)]
        public DateTime LastUpdate { get; set; }
        public JSONEternalSMARTGoal(Goal goal)
        {
            if (goal.GetType() == typeof(EternalSMARTGoal))
            {
                Init((EternalSMARTGoal)goal);
                LastUpdate = ((EternalSMARTGoal)goal).LastUpdate;
            }
        }
        internal override void DisplayGoal(int index = -1)
        {
            EternalGoal.DISPLAY_GOAL((EternalGoal)(Goal)(JSONGoal)this, Configuration, index);
        }
        internal override Boolean IsCompleted()
        {
            return EternalGoal.IS_COMPLETED((EternalGoal)(Goal)(JSONGoal)this);
        }
        internal override int Report()
        {
            return EternalGoal.REPORT((EternalGoal)(Goal)(JSONGoal)this);
        }
    }
}
