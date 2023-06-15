using System.Numerics;

namespace Learning05
{
    public interface IChecklistGoal : IGoal
    {
        void DisplayRequestNumberOfTimes();
        void RequestNumberOfTimes();
        void DisplayRequestBonusPoints();
        void RequestBonusPoints();
    }
    public class ChecklistGoal : Goal, IChecklistGoal
    {
        public ChecklistGoal()
        {
            Init();
        }
        protected new void Init()
        {
            base.Init();
            RequestNumberOfTimes();
            RequestBonusPoints();
            NumberOfTimes = 0;
        }
        protected int TargetNumberOfTimes { get; set; }
        protected int NumberOfTimes { get; set; }
        protected int BonusPointValue { get; set; }
        public override void DisplayRequestPointValue()
        {
            Console.WriteLine("Please enter the point value for each completion of your goal.");
        }
        public virtual void DisplayRequestNumberOfTimes()
        {
            Console.WriteLine("Please enter the number times required to complete your overall goal.");
        }
        public virtual void DisplayRequestBonusPoints()
        {
            Console.WriteLine("Please enter the bonus point value of your overall goal.");
        }
        public void RequestNumberOfTimes()
        {
            DisplayRequestNumberOfTimes();
            TargetNumberOfTimes = int.Parse(ReadResponse());
        }
        public void RequestBonusPoints()
        {
            DisplayRequestBonusPoints();
            BonusPointValue = int.Parse(ReadResponse());
        }
        public override bool IsCompleted()
        {
            return NumberOfTimes>=TargetNumberOfTimes;
        }
        public override void DisplayGoal(int index = -1)
        {
            String check = " ";
            if (IsCompleted()) check = "X";
            if (index  >= 0) Console.WriteLine($"{index})  [{check}] {Name}({Description}) {NumberOfTimes}/{TargetNumberOfTimes}");
            else Console.WriteLine($"[{check}] {Name}({Description}) {NumberOfTimes}/{TargetNumberOfTimes}");
        }
        public override BigInteger Report()
        {
            NumberOfTimes++;
            if (IsCompleted()) return PointValue + BonusPointValue;
            else return PointValue;
        }
    }
}