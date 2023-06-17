using System.Text.Json;
using System.Text.Json.Serialization;

namespace Develop05
{
    public class Goals : List<Goal>
    {
        internal int Score { get; set; }
        internal Configuration Configuration { get; set; }
        public Goals(Configuration configuration)
        {
            Init(configuration);
        }
        public Goals(Goals goals, Configuration configuration) : base(goals)
        {
            Init(goals, configuration);
        }
        internal Goals(JSONGoals jsonGoals, Configuration configuration)
        {
            Init(jsonGoals, configuration);
        }
        internal void Init(JSONGoals jsonGoals, Configuration configuration)
        {
            JSONGoals.Convert(this, jsonGoals, configuration);
        }
        protected void Init(Goals goals, Configuration configuration)
        {
            Init((List<Goal>)goals, goals.Score, configuration);
        }
        protected void Init(List<Goal> goals, int score, Configuration configuration)
        {
            Clear();
            goals.ForEach(goal => Add(goal));
            Score = score;
            Configuration = configuration;
        }
        protected void Init(Configuration configuration)
        {
            Init(new List<Goal>(), 0, configuration);
        }
        public void DisplayScore()
        {
            Console.WriteLine(String.Format((String)Configuration.Dictionary["ScoreMessage"],Score));
        }
        public virtual void DisplayRequestSelectGoal()
        {
            Console.WriteLine(Configuration.Dictionary["RequestGoalMessage"]);
        }
        public int RequestSelectGoal()
        {
            int result = -1;
            while (result < 0)
            {
                try
                {
                    result = int.Parse(IApplication.ReadResponse(Configuration));
                }
                catch
                {
                    result = -1;
                }
            }
            return result;
        }
        public void ListCurrent()
        {
            ForEach((goal) => {
                if (!goal.IsCompleted()) goal.DisplayGoal();
            });
        }
        public void ListAll()
        {
            ListCurrent();
            ForEach((goal) => {
                if (goal.IsCompleted()) goal.DisplayGoal();
            });
        }
        internal void AddSimpleGoal()
        {
            Add(new SimpleGoal(Configuration));
        }
        internal void AddEternalGoal()
        {
            Add(new EternalGoal(Configuration));
        }
        internal void AddChecklistGoal()
        {
            Add(new ChecklistGoal(Configuration));
        }
        internal void ReuseCompletedGoal()
        {
            Dictionary<int, int> optionMap = new();
            int option = 1;
            ForEach((goal) => {
                if (goal.IsCompleted())
                {
                    optionMap.Add(option, IndexOf(goal));
                    goal.DisplayGoal(option);
                    option++;
                }
            });
            if(optionMap.Count > 0) {
                DisplayRequestSelectGoal();
                option = RequestSelectGoal();
                Goal goal = this[optionMap[option]];
                if (goal.GetType() == typeof(SimpleGoal))
                {
                    ((SimpleGoal)goal).Completed = false;
                    Add(new SimpleGoal(goal));
                    ((SimpleGoal)goal).Completed = true;
                }
                else if (goal.GetType() == typeof(EternalGoal))
                {
                    Add(new EternalGoal(goal));
                }
                else if (goal.GetType() == typeof(ChecklistGoal))
                {
                    int count = ((ChecklistGoal)goal).NumberOfTimes;
                    ((ChecklistGoal)goal).NumberOfTimes = 0;
                    Add(new ChecklistGoal(goal));
                    ((ChecklistGoal)goal).NumberOfTimes = count;
                }
            }
        }
        public void Report()
        {
            Dictionary<int,int> optionMap = new();
            int option = 1;
            ForEach((goal) => {
                if(!goal.IsCompleted())
                {
                    optionMap.Add(option, IndexOf(goal));
                    goal.DisplayGoal(option);
                    option++;
                }
            });
            DisplayRequestSelectGoal();
            option = RequestSelectGoal();
            int earned = this[optionMap[option]].Report();
            Console.WriteLine(String.Format((String)Configuration.Dictionary["AwardMessage"], earned));
            Score += earned;
        }
        internal void SaveGoals()
        {            
            String fileName = (String)Configuration.Dictionary["DefaultFilename"];
            JSONGoals jsonGoals = new(this);
            var options = new JsonSerializerOptions { WriteIndented = true };
            String jsonString = JsonSerializer.Serialize(jsonGoals, options);
            File.WriteAllText(fileName, jsonString);
        }
        internal void LoadGoals()
        {
            String fileName = (String)Configuration.Dictionary["DefaultFilename"];
            String json = File.ReadAllText(fileName);
            JSONGoals jsonGoals = JsonSerializer.Deserialize<JSONGoals>(json);
            Init(new Goals(jsonGoals, Configuration), Configuration);
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
        protected static void Convert(Goals goals, List<JSONGoal> jsonGoals, int score, Configuration configuration)
        {
            goals.Clear();
            jsonGoals.ForEach((jsonGoal) => {
                Goal goal = null;
                jsonGoal.Configuration = configuration;
                if (jsonGoal.GetType() == typeof(JSONSimpleGoal)) goal = (SimpleGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONEternalGoal)) goal = (EternalGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONChecklistGoal)) goal = (ChecklistGoal)jsonGoal;
                if (goal is not null) goals.Add(goal);
            });
            goals.Score = score;
            goals.Configuration = configuration;
        }
        internal static void Convert(Goals goals, JSONGoals jsonGoals, Configuration configuration)
        {
            List<JSONGoal> list = new();
            foreach (JSONGoal goal in jsonGoals.Goals) { list.Add(goal); }
            Convert(goals, list, jsonGoals.Score, configuration);
        }
    }
}