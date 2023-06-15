using System.Numerics;

namespace Learning05
{
    public interface ISimpleGoal : IGoal
    {
    }
    public class SimpleGoal : Goal, ISimpleGoal
    {
        private Boolean Completed { get; set; }
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
        public override BigInteger Report()
        {
            Completed = true;
            return PointValue;
        }
    }
}
