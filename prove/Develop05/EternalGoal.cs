using System.Text.Json.Serialization;

namespace Develop05
{
    public class EternalGoal : Goal
    {
        public EternalGoal(Boolean empty = false)
        {
            Init(empty);
        }
        protected new void Init(Boolean empty = false)
        {
            base.Init(empty);
        }
        public override void DisplayRequestPointValue()
        {
            Console.WriteLine("Please enter the point value for each completion of your goal.");
        }
        internal static Boolean IsCompleted(EternalGoal goal)
        {
            return false;
        }
        public override bool IsCompleted()
        {
            return IsCompleted(this);
        }
        internal static void DisplayGoal(EternalGoal goal, int index = -1)
        {
            if (index >= 0) Console.WriteLine($"{index})  [ ] {goal.Name}({goal.Description})");
            else Console.WriteLine($"[ ] {goal.Name}({goal.Description})");
        }
        public override void DisplayGoal(int index = -1)
        {
            DisplayGoal(this, index);
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
                result = new(true);
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
            EternalGoal.DisplayGoal((EternalGoal)(Goal)(JSONGoal)this, index);
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
