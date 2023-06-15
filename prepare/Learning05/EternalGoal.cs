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
        public override BigInteger Report()
        {
            return PointValue;
        }
    }
}
