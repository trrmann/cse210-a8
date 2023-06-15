using System.Numerics;
using System.Text.Json;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Learning05
{
    public interface IGoals
    {
        void List();
        BigInteger Report(BigInteger score);
        void DisplayRequestSelectGoal();
        int RequestSelectGoal();
    }
    public class Goals : List<Goal>, IGoals
    {
        public Goals()
        {
            Init();
        }
        public Goals(Goals goals) : base(goals)
        {
            Init(goals);
        }
        protected void Init(Goals goals)
        {
            Init((List<Goal>)goals);
        }
        protected void Init(List<Goal> goals)
        {
            Clear();
            goals.ForEach(goal => Add(goal));
        }
        protected void Init()
        {
            Init(new List<Goal>());
        }
        public virtual void DisplayRequestSelectGoal()
        {
            Console.WriteLine("Please enter the number of your goal.");
        }
        public String ReadResponse()
        {
            Console.Write(">  ");
            return Console.ReadLine();
        }
        public int RequestSelectGoal()
        {
            return int.Parse(ReadResponse());
        }
        public void List()
        {
            ForEach((goal) => {
                goal.DisplayGoal();
            });
        }
        public BigInteger Report(BigInteger score)
        {
            ForEach((goal) => {
                goal.DisplayGoal(IndexOf(goal)+1);
            });
            DisplayRequestSelectGoal();
            int id = RequestSelectGoal();
            return score + this[id - 1].Report();
        }
    }

}