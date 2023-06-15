using System.Numerics;

namespace Learning05
{
    public interface IGoal
    {
        void DisplayGoal(int index = -1);
        void DisplayRequestName();
        void DisplayRequestDescription();
        void DisplayRequestPointValue();
        void RequestName();
        void RequestDescription();
        void RequestPointValue();
        String ReadResponse();
        Boolean IsCompleted();
        BigInteger Report();
    }
    public abstract class Goal : IGoal
    {
        internal void Init() {
            RequestName();
            RequestDescription();
            RequestPointValue();
        }
        internal void Init(Goal goal)
        {
            Name = goal.Name;
            Description = goal.Description;
            PointValue = goal.PointValue;
        }
        protected String Name { get; set; }
        protected String Description { get; set; }
        protected int PointValue { get; set; }
        public abstract void DisplayGoal(int index = -1);
        public abstract Boolean IsCompleted();
        public virtual void DisplayRequestName()
        {
            Console.WriteLine("Please enter the name of your goal.");
        }
        public virtual void DisplayRequestDescription()
        {
            Console.WriteLine("Please enter the description of your goal.");
        }
        public virtual void DisplayRequestPointValue()
        {
            Console.WriteLine("Please enter the point value of your goal.");
        }
        public String ReadResponse()
        {
            Console.Write(">  ");
            return Console.ReadLine();
        }
        public void RequestName()
        {
            DisplayRequestName();
            Name = ReadResponse();
        }
        public void RequestDescription()
        {
            DisplayRequestDescription();
            Description = ReadResponse();
        }
        public void RequestPointValue()
        {
            DisplayRequestPointValue();
            PointValue = int.Parse(ReadResponse());
        }
        public abstract BigInteger Report();
    }
}
