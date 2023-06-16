using System.Text.Json.Serialization;

namespace Develop05
{
    public class Goals : List<Goal>
    {
        internal int Score { get; set; }
        public Goals()
        {
            Init();
        }
        public Goals(Goals goals) : base(goals)
        {
            Init(goals);
        }
        internal Goals(JSONGoals jsonGoals)
        {
            Init(jsonGoals);
        }
        internal void Init(JSONGoals jsonGoals)
        {
            JSONGoals.Convert(this, jsonGoals);
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
            Score = 0;
        }
        public void DisplayScore()
        {
            Console.WriteLine($"\nYour score is {Score}.\n");
        }
        public virtual void DisplayRequestSelectGoal()
        {
            Console.WriteLine("Please enter the number of your jsonGoal.");
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
        public void Report()
        {
            ForEach((goal) => {
                goal.DisplayGoal(IndexOf(goal)+1);
            });
            DisplayRequestSelectGoal();
            int id = RequestSelectGoal();
            Score = (Score + this[id - 1].Report());
        }
    }
    [Serializable]
    internal class JSONGoals
    {
        [JsonConstructor]
        public JSONGoals() { }
        [JsonInclude]
        [JsonPropertyName("Score")]
        [JsonPropertyOrder(-1)]
        public int Score {get; set; }
        [JsonInclude]
        [JsonPropertyName("Goals")]
        public List<JSONGoal> Goals {get; set;}
        public JSONGoals(Goals? goals = null)
        {
            if (goals is not null)
            {
                Goals = Convert(goals);
                Score = goals.Score;
            }
            else Goals = new();
        }
        protected List<JSONGoal> Convert(Goals goals)
        {
            List<JSONGoal> jSONGoals = new();
            goals.ForEach((goal) => {
                JSONGoal jsonGoal = null;
                if (goal.GetType() == typeof(SimpleGoal)) jsonGoal = new JSONSimpleGoal(goal);
                else if(goal.GetType() == typeof(EternalGoal)) jsonGoal = new JSONEternalGoal(goal);
                else if(goal.GetType() == typeof(ChecklistGoal)) jsonGoal = new JSONChecklistGoal(goal);
                if(jsonGoal is not null) jSONGoals.Add(jsonGoal);
            });
            return jSONGoals;
        }
        protected static void Convert(Goals goals, List<JSONGoal> jsonGoals, int score)
        {
            goals.Clear();
            jsonGoals.ForEach((jsonGoal) => {
                Goal goal = null;
                if (jsonGoal.GetType() == typeof(JSONSimpleGoal)) goal = (SimpleGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONEternalGoal)) goal = (EternalGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONChecklistGoal)) goal = (ChecklistGoal)jsonGoal;
                if (goal is not null) goals.Add(goal);
            });
            goals.Score = score;
        }
        internal static void Convert(Goals goals, JSONGoals jsonGoals)
        {
            List<JSONGoal> list = new();
            foreach (JSONGoal goal in jsonGoals.Goals) { list.Add(goal); }
            Convert(goals, list, jsonGoals.Score);
        }
    }
}