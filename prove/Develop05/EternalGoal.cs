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
        public override void DisplayRequestPointValue()
        {
            Console.WriteLine(Configuration.Dictionary["RequestRepeatPointValueMessage"]);
        }
        internal static Boolean IsCompleted(EternalGoal goal)
        {
            return false;
        }
        public override bool IsCompleted()
        {
            return IsCompleted(this);
        }
        internal static void DisplayGoal(EternalGoal goal, Configuration configuration, int index = -1)
        {
            if (index >= 0) Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleGoalIndexedDisplayFormat"], index, (Char)configuration.Dictionary["IncompleteSymbol"], goal.Name, goal.Description));
            else Console.WriteLine(String.Format((String)configuration.Dictionary["SimpleGoalNonIndexedDisplayFormat"], (Char)configuration.Dictionary["IncompleteSymbol"], goal.Name, goal.Description));
        }
        public override void DisplayGoal(int index = -1)
        {
            DisplayGoal(this, Configuration, index);
        }
        internal static int Report(EternalGoal goal)
        {
            return goal.PointValue;
        }
        public override int Report()
        {
            return Report(this);
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
        public override void DisplayGoal(int index = -1)
        {
            EternalGoal.DisplayGoal((EternalGoal)(Goal)(JSONGoal)this, Configuration, index);
        }
        public override bool IsCompleted()
        {
            return EternalGoal.IsCompleted((EternalGoal)(Goal)(JSONGoal)this);
        }
        public override int Report()
        {
            return EternalGoal.Report((EternalGoal)(Goal)(JSONGoal)this);
        }
    }
}
