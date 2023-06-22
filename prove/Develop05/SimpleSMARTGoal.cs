using System.Text.Json.Serialization;

namespace Develop05
{
    public class SimpleSMARTGoal : SMARTGoal
    {
        private SimpleGoal Base { get; set; }
        internal Boolean Completed {
            get
            {
                return Base.Completed;
            }
            set
            {
                Base.Completed = value;
            }
        }
        internal SimpleSMARTGoal(Configuration configuration, Boolean empty = false)
        {
            Init(configuration, empty);
        }
        internal SimpleSMARTGoal(Goal goal)
        {
            Init(goal);
        }
        private SimpleSMARTGoal(SMARTGoal goal)
        {
            Init(goal);
        }
        protected override void Init(Configuration configuration, Boolean empty = false)
        {
            Base = new SimpleGoal(configuration, true);
            base.Init(configuration, empty);
            Completed = false;
        }
        protected override void Init(Goal goal)
        {
            Base = new SimpleGoal(goal);
            base.Init(goal);
            if (goal.GetType() == typeof(SimpleGoal))
            {
                Completed = ((SimpleGoal)goal).Completed;
            }
            else if (goal.GetType() == typeof(SimpleSMARTGoal))
            {
                Completed = ((SimpleSMARTGoal)goal).Completed;
            }
            else if (goal.GetType() == typeof(JSONSimpleSMARTGoal))
            {
                Completed = ((JSONSimpleSMARTGoal)goal).Completed;
                Created = ((JSONSimpleSMARTGoal)goal).Created;
                Timely = ((JSONSimpleSMARTGoal)goal).Timely;
                TimelyPointPentalty = ((JSONSimpleSMARTGoal)goal).TimelyPointPentalty;
            }
            else
            {
                Completed = ((SimpleGoal)goal).Completed;
            }
        }
        protected override void Init(SMARTGoal goal)
        {
            Base = new SimpleGoal(goal);
            base.Init(goal);
            Completed = ((SimpleSMARTGoal)goal).Completed;
        }
        internal static void DISPLAY_GOAL(SimpleSMARTGoal goal, Configuration configuration, int index = -1)
        {
            DateTime dueDate = goal.Created.AddDays(goal.Timely);
            Char check = (Char)configuration.Dictionary["IncompleteSymbol"];
            if (goal.IsCompleted()) check = (Char)configuration.Dictionary["CompleteSymbol"];
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleSMARTGoalIndexedDisplayFormat"], index, check, goal.Name, goal.Description, dueDate));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleSMARTGoalNonIndexedDisplayFormat"], check, goal.Name, goal.Description, dueDate));
        }
        internal override void DisplayGoal(int index = -1)
        {
            DISPLAY_GOAL(this, Configuration, index);
        }
        internal override Boolean IsCompleted()
        {
            return Base.IsCompleted();
        }
        internal static int REPORT(SimpleSMARTGoal goal)
        {
            DateTime dueDate = goal.Created.AddDays(goal.Timely);
            goal.Completed = true;
            if(DateTime.Now > dueDate) return goal.PointValue - goal.TimelyPointPentalty;
            else return goal.PointValue;
        }
        internal override int Report()
        {
            return REPORT(this);
        }
        public static explicit operator SimpleSMARTGoal(JSONSMARTGoal goal)
        {
            SimpleSMARTGoal result = null;
            if (goal.GetType() == typeof(JSONSimpleSMARTGoal))
            {
                result = new(goal.Configuration, true);
                result.Init((JSONSimpleSMARTGoal)goal);
                result.Completed = ((JSONSimpleSMARTGoal)goal).Completed;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONSimpleSMARTGoal : JSONSMARTGoal
    {
        [JsonConstructor]
        public JSONSimpleSMARTGoal() {
            Init();
        }
        public override void Init()
        {
            Base = new SimpleSMARTGoal(Configuration, true);
        }
        [JsonInclude]
        [JsonPropertyName("Complete")]
        [JsonPropertyOrder(6)]
        public Boolean Completed {
            get { return ((SimpleSMARTGoal)Base).Completed; }
            set { ((SimpleSMARTGoal)Base).Completed = value; }
        }
        public JSONSimpleSMARTGoal(Goal goal)
        {
            if (goal.GetType() == typeof(SimpleSMARTGoal))
            {
                Init((SimpleSMARTGoal)goal);
                Completed = ((SimpleSMARTGoal)goal).Completed;
            }
        }
        internal override void DisplayGoal(int index = -1)
        {
            Base.DisplayGoal(index);
        }
        internal override Boolean IsCompleted()
        {
            return SimpleGoal.IS_COMPLETED((SimpleGoal)(Goal)(JSONGoal)this);
        }
        internal override int Report()
        {
            return SimpleGoal.REPORT((SimpleGoal)(Goal)(JSONGoal)this);
        }
    }
}