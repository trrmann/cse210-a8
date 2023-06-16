using System.Numerics;
using System.Text.Json.Serialization;

namespace Learning05
{
    public interface ISimpleGoal : IGoal
    {
    }
    public class SimpleGoal : Goal, ISimpleGoal
    {
        internal Boolean Completed { get; set; }
        public SimpleGoal() {
            Init();
        }
        protected new void Init()
        {
            base.Init();
        }
        public override bool IsCompleted()
        {
            return Completed;
        }
        public override void DisplayGoal(int index = -1)
        {
            String check = " ";
            if (IsCompleted()) check = "X";
            if (index >= 0) Console.WriteLine($"{index})  [{check}] {Name}({Description})");
            else Console.WriteLine($"[{check}] {Name}({Description})");
        }
        public override int Report()
        {
            Completed = true;
            return PointValue;
        }

        public static explicit operator SimpleGoal(JSONGoal goal)
        {
            SimpleGoal result = null;
            if (goal.GetType() == typeof(JSONSimpleGoal))
            {
                result = new();
                result.Init((JSONSimpleGoal)goal);
                result.Completed = ((JSONSimpleGoal)goal).Completed;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONSimpleGoal : JSONGoal, ISimpleGoal
    {
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
            throw new NotImplementedException();
        }

        public override bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public override int Report()
        {
            throw new NotImplementedException();
        }
    }
}
