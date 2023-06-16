using System.Numerics;

namespace Learning05
{
    public interface IEternalGoal : IGoal
    {
    }
    public class EternalGoal : Goal, IEternalGoal
    {
        public EternalGoal()
        {
            Init();
        }
        protected new void Init()
        {
            base.Init();
        }
        public override void DisplayRequestPointValue()
        {
            Console.WriteLine("Please enter the point value for each completion of your goal.");
        }
        public override bool IsCompleted()
        {
            return false;
        }
        public override void DisplayGoal(int index = -1)
        {
            if (index >= 0) Console.WriteLine($"{index})  [ ] {Name}({Description})");
            else Console.WriteLine($"[ ] {Name}({Description})");
        }
        public override int Report()
        {
            return PointValue;
        }

        public static explicit operator EternalGoal(JSONGoal goal)
        {
            EternalGoal result = null;
            if (goal.GetType() == typeof(JSONEternalGoal))
            {
                result = new();
                result.Init((JSONEternalGoal)goal);
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONEternalGoal : JSONGoal, IEternalGoal
    {
        public JSONEternalGoal(Goal goal)
        {
            if (goal.GetType() == typeof(EternalGoal))
            {
                Init((EternalGoal)goal);
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
