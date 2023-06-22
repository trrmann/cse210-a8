using System.Text.Json.Serialization;

namespace Develop05
{
    public class EternalGoal : Goal
    {
        public EternalGoal(Configuration configuration, Boolean empty = false)
        {
            Init(configuration, empty);
        }
        public EternalGoal(Goal goal)
        {
            Init(goal);
        }
        protected new void Init(Configuration configuration, Boolean empty = false)
        {
            base.Init(configuration, empty);
        }
        internal override void DisplayRequestPointValue()
        {
            Console.WriteLine(Configuration.Dictionary["RequestRepeatPointValueMessage"]);
        }
        internal static Boolean IS_COMPLETED(EternalGoal goal)
        {
            return false;
        }
        internal override Boolean IsCompleted()
        {
            return IS_COMPLETED(this);
        }
        internal static void DISPLAY_GOAL(EternalGoal goal, Configuration configuration, int index = -1)
        {
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleGoalIndexedDisplayFormat"], index, (Char)configuration.Dictionary["IncompleteSymbol"], goal.Name, goal.Description));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleGoalNonIndexedDisplayFormat"], (Char)configuration.Dictionary["IncompleteSymbol"], goal.Name, goal.Description));
        }
        internal override void DisplayGoal(int index = -1)
        {
            DISPLAY_GOAL(this, Configuration, index);
        }
        internal static int REPORT(EternalGoal goal)
        {
            return goal.PointValue;
        }
        internal override int Report()
        {
            return REPORT(this);
        }
        public static explicit operator EternalGoal(JSONGoal goal)
        {
            EternalGoal result = null;
            if (goal.GetType() == typeof(JSONEternalGoal))
            {
                result = new(goal.Configuration, true);
                result.Init((JSONEternalGoal)goal);
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONEternalGoal : JSONGoal
    {
        [JsonConstructor]
        public JSONEternalGoal() { }
        public JSONEternalGoal(Goal goal)
        {
            if (goal.GetType() == typeof(EternalGoal))
            {
                Init((EternalGoal)goal);
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
