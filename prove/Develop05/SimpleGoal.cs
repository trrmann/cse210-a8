using System.Text.Json.Serialization;

namespace Develop05
{
    public class SimpleGoal : Goal
    {
        internal Boolean Completed { get; set; }
        public SimpleGoal(Boolean empty=false) {
            Init(empty);
        }
        protected new void Init(Boolean empty = false)
        {
            base.Init(empty);
            Completed = false;
        }
        internal static Boolean IsCompleted(SimpleGoal goal)
        {
            return goal.Completed;
        }
        public override Boolean IsCompleted()
        {
            return IsCompleted(this);
        }
        internal static void DisplayGoal(SimpleGoal goal, int index = -1)
        {
            String check = " ";
            if (goal.IsCompleted()) check = "X";
            if (index >= 0) Console.WriteLine($"{index})  [{check}] {goal.Name}({goal.Description})");
            else Console.WriteLine($"[{check}] {goal.Name}({goal.Description})");
        }
        public override void DisplayGoal(int index = -1)
        {
            DisplayGoal(this, index);
        }
        internal static int Report(SimpleGoal goal)
        {
            goal.Completed = true;
            return goal.PointValue;
        }
        public override int Report()
        {
            return Report(this);
        }
        public static explicit operator SimpleGoal(JSONGoal goal)
        {
            SimpleGoal result = null;
            if (goal.GetType() == typeof(JSONSimpleGoal))
            {
                result = new(true);
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
            SimpleGoal.DisplayGoal((SimpleGoal)(Goal)(JSONGoal)this, index);
        }
        public override bool IsCompleted()
        {
            return SimpleGoal.IsCompleted((SimpleGoal)(Goal)(JSONGoal)this);
        }
        public override int Report()
        {
            return SimpleGoal.Report((SimpleGoal)(Goal)(JSONGoal)this);
        }
    }
}
