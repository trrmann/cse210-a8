using System.Text.Json.Serialization;

namespace Develop05
{
    public class SimpleGoal : Goal
    {
        internal Boolean Completed { get; set; }
        public SimpleGoal(Configuration configuration, Boolean empty =false) {
            Init(configuration, empty);
        }
        public SimpleGoal(Goal goal)
        {
            Init(goal);
            Completed = ((SimpleGoal)goal).Completed;
        }
        protected new void Init(Configuration configuration, Boolean empty = false)
        {
            base.Init(configuration, empty);
            Completed = false;
        }
        internal static Boolean IS_COMPLETED(SimpleGoal goal)
        {
            return goal.Completed;
        }
        public override Boolean IsCompleted()
        {
            return IS_COMPLETED(this);
        }
        internal static void DISPLAY_GOAL(SimpleGoal goal, Configuration configuration, int index = -1)
        {
            Char check = (Char)configuration.Dictionary["IncompleteSymbol"];
            if (goal.IsCompleted()) check = (Char)configuration.Dictionary["CompleteSymbol"];
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleGoalIndexedDisplayFormat"], index, check, goal.Name, goal.Description));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleGoalNonIndexedDisplayFormat"], check, goal.Name, goal.Description));
        }
        public override void DisplayGoal(int index = -1)
        {
            DISPLAY_GOAL(this, Configuration, index);
        }
        internal static int REPORT(SimpleGoal goal)
        {
            goal.Completed = true;
            return goal.PointValue;
        }
        public override int Report()
        {
            return REPORT(this);
        }
        public static explicit operator SimpleGoal(JSONGoal goal)
        {
            SimpleGoal result = null;
            if (goal.GetType() == typeof(JSONSimpleGoal))
            {
                result = new(goal.Configuration, true);
                result.Init((JSONSimpleGoal)goal);
                result.Completed = ((JSONSimpleGoal)goal).Completed;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONSimpleGoal : JSONGoal
    {
        [JsonConstructor]
        public JSONSimpleGoal() { }
        [JsonInclude]
        [JsonPropertyName("Complete")]
        [JsonPropertyOrder(3)]
        public Boolean Completed { get; set; }
        public JSONSimpleGoal(Goal goal)
        {
            if(goal.GetType() == typeof(SimpleGoal))
            {
                Init((SimpleGoal)goal);
                Completed = ((SimpleGoal)goal).Completed;
            }
        }
        public override void DisplayGoal(int index = -1)
        {
            SimpleGoal.DISPLAY_GOAL((SimpleGoal)(Goal)(JSONGoal)this, Configuration, index);
        }
        public override Boolean IsCompleted()
        {
            return SimpleGoal.IS_COMPLETED((SimpleGoal)(Goal)(JSONGoal)this);
        }
        public override int Report()
        {
            return SimpleGoal.REPORT((SimpleGoal)(Goal)(JSONGoal)this);
        }
    }
}
