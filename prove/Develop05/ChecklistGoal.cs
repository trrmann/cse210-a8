using System.Numerics;
using System.Text.Json.Serialization;

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
        internal int TargetNumberOfTimes { get; set; }
        internal int NumberOfTimes { get; set; }
        internal int BonusPointValue { get; set; }
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
        public override int Report()
        {
            NumberOfTimes++;
            if (IsCompleted()) return PointValue + BonusPointValue;
            else return PointValue;
        }

        public static explicit operator ChecklistGoal(JSONGoal goal)
        {
            ChecklistGoal result = null;
            if (goal.GetType() == typeof(JSONChecklistGoal))
            {
                result = new();
                result.Init((JSONChecklistGoal)goal);
                result.TargetNumberOfTimes = ((JSONChecklistGoal)goal).TargetNumberOfTimes;
                result.NumberOfTimes = ((JSONChecklistGoal)goal).NumberOfTimes;
                result.BonusPointValue = ((JSONChecklistGoal)goal).BonusPointValue;
            }
            return result;
        }
    }
    [Serializable]
    internal class JSONChecklistGoal : JSONGoal, IChecklistGoal
    {
        [JsonInclude]
        [JsonPropertyName("TargetNumberOfTimes")]
        [JsonPropertyOrder(5)]
        public int TargetNumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("NumberOfTimes")]
        [JsonPropertyOrder(4)]
        public int NumberOfTimes { get; set; }
        [JsonInclude]
        [JsonPropertyName("BonusPointValue")]
        [JsonPropertyOrder(3)]
        public int BonusPointValue { get; set; }
        public JSONChecklistGoal(Goal goal)
        {
            if (goal.GetType() == typeof(ChecklistGoal))
            {
                Init((ChecklistGoal)goal);
                TargetNumberOfTimes = ((ChecklistGoal)goal).TargetNumberOfTimes;
                NumberOfTimes = ((ChecklistGoal)goal).NumberOfTimes;
                BonusPointValue = ((ChecklistGoal)goal).BonusPointValue;
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

        void IChecklistGoal.DisplayRequestBonusPoints()
        {
            throw new NotImplementedException();
        }

        void IChecklistGoal.DisplayRequestNumberOfTimes()
        {
            throw new NotImplementedException();
        }

        void IChecklistGoal.RequestBonusPoints()
        {
            throw new NotImplementedException();
        }

        void IChecklistGoal.RequestNumberOfTimes()
        {
            throw new NotImplementedException();
        }
    }
}