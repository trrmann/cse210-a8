using System.Text.Json;
using System.Text.Json.Serialization;
using Develop05External;

namespace Develop05
{
    internal class Goals : List<Goal>
    {
        internal int Score { get; set; }
        internal Configuration Configuration { get; set; }
        internal Goals(Configuration configuration)
        {
            Init(configuration);
        }
        private Goals(Goals goals, Configuration configuration) : base(goals)
        {
            Init(goals, configuration);
        }
        internal Goals(JSONGoals jsonGoals, Configuration configuration)
        {
            Init(jsonGoals, configuration);
        }
        internal void Init(JSONGoals jsonGoals, Configuration configuration)
        {
            JSONGoals.CONVERT(this, jsonGoals, configuration);
        }
        private void Init(Goals goals, Configuration configuration)
        {
            Init((List<Goal>)goals, goals.Score, configuration);
        }
        private void Init(List<Goal> goals, int score, Configuration configuration)
        {
            Clear();
            goals.ForEach(goal => Add(goal));
            Score = score;
            Configuration = configuration;
        }
        private void Init(Configuration configuration)
        {
            Init(new List<Goal>(), 0, configuration);
        }
        internal void DisplayScore()
        {
            Console.WriteLine(String.Format((String)Configuration.Dictionary["ScoreMessage"],Score));
        }
        protected virtual void DisplayRequestSelectGoal()
        {
            Console.WriteLine(Configuration.Dictionary["RequestGoalMessage"]);
        }
        private int RequestSelectGoal()
        {
            int result = -1;
            while (result < 0)
            {
                try
                {
                    result = int.Parse(IApplication.READ_RESPONSE(Configuration));
                }
                catch
                {
                    result = -1;
                }
            }
            return result;
        }
        internal void ListCurrent()
        {
            ForEach((goal) => {
                if (!goal.IsCompleted()) goal.DisplayGoal();
            });
        }
        internal void ListAll()
        {
            ListCurrent();
            ForEach((goal) => {
                if (goal.IsCompleted()) goal.DisplayGoal();
            });
        }
        private void DisplayRequestIsSMARTGoal()
        {
            Console.WriteLine(Configuration.Dictionary["RequestIsSMARTGoalMessage"]);
        }
        private Boolean RequestIsSMARTGoal()
        {
            String response = "undefined";
            while (response != "y" && response != "yes" && response != "n" && response != "no" && response != "")
            {
                DisplayRequestIsSMARTGoal();
                response = IApplication.READ_RESPONSE(Configuration);
            }
            if (response == "y" || response == "yes" || response == "") return true;
            else return false;
        }
        internal void AddSimpleGoal()
        {
            if(RequestIsSMARTGoal())
            {
                Add(new SimpleSMARTGoal(Configuration));
            }
            else
            {
                Add(new SimpleGoal(Configuration));
            }
        }
        internal void AddEternalGoal()
        {
            if (RequestIsSMARTGoal())
            {
                Add(new EternalSMARTGoal(Configuration));
            }
            else
            {
                Add(new EternalGoal(Configuration));
            }
        }
        internal void AddChecklistGoal()
        {
            if (RequestIsSMARTGoal())
            {
                Add(new ChecklistSMARTGoal(Configuration));
            }
            else
            {
                Add(new ChecklistGoal(Configuration));
            }
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
                if(optionMap.Keys.Contains(option)){
                    Goal goal = this[optionMap[option]];
                    if (goal.GetType() == typeof(SimpleGoal))
                    {
                        ((SimpleGoal)goal).Completed = false;
                        Add(new SimpleGoal(goal));
                        ((SimpleGoal)goal).Completed = true;
                    }
                    else if (goal.GetType() == typeof(SimpleSMARTGoal))
                    {
                        ((SimpleSMARTGoal)goal).Completed = false;
                        SimpleSMARTGoal simpleSMARTGoal = new SimpleSMARTGoal(goal);
                        ((SimpleSMARTGoal)goal).Completed = true;
                        simpleSMARTGoal.Created=DateTime.Now;
                        Add(simpleSMARTGoal);
                    }
                    else if (goal.GetType() == typeof(EternalGoal))
                    {
                        Add(new EternalGoal(goal));
                    }
                    else if (goal.GetType() == typeof(EternalSMARTGoal))
                    {
                        EternalSMARTGoal eternalSMARTGoal = new EternalSMARTGoal(goal);
                        eternalSMARTGoal.Created = DateTime.Now;
                        Add(eternalSMARTGoal);
                    }
                    else if (goal.GetType() == typeof(ChecklistGoal))
                    {
                        int count = ((ChecklistGoal)goal).NumberOfTimes;
                        ((ChecklistGoal)goal).NumberOfTimes = 0;
                        Add(new ChecklistGoal(goal));
                        ((ChecklistGoal)goal).NumberOfTimes = count;
                    }
                    else if (goal.GetType() == typeof(ChecklistSMARTGoal))
                    {
                        int count = ((ChecklistSMARTGoal)goal).NumberOfTimes;
                        ((ChecklistSMARTGoal)goal).NumberOfTimes = 0;
                        ChecklistSMARTGoal checklistSMARTGoal = new ChecklistSMARTGoal(goal);
                        checklistSMARTGoal.Created = DateTime.Now;
                        Add(checklistSMARTGoal);
                        ((ChecklistSMARTGoal)goal).NumberOfTimes = count;
                    }
                }
            }
        }
        internal void Report()
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
            if (optionMap.Keys.Contains(option)) {
                int earned = this[optionMap[option]].Report();
                Console.WriteLine(String.Format((String)Configuration.Dictionary["AwardMessage"], earned));
                Score += earned;
            }
        }
        internal void SaveGoals()
        {
            Console.WriteLine(Configuration.Dictionary["RequestFilenameMessage"]);
            String fileName = IApplication.READ_RESPONSE(Configuration);
            if(fileName=="") fileName = (String)Configuration.Dictionary["DefaultFilename"];
            JSONGoals jsonGoals = new(this);
            var options = new JsonSerializerOptions { WriteIndented = true };
            String jsonString = JsonSerializer.Serialize(jsonGoals, options);
            File.WriteAllText(fileName, jsonString);
        }
        internal void LoadGoals()
        {
            Console.WriteLine(Configuration.Dictionary["RequestFilenameMessage"]);
            String fileName = IApplication.READ_RESPONSE(Configuration);
            if (fileName == "") fileName = (String)Configuration.Dictionary["DefaultFilename"];
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
        private List<JSONGoal> Convert(Goals goals)
        {
            List<JSONGoal> jSONGoals = new();
            goals.ForEach((goal) => {
                JSONGoal jsonGoal = null;
                if (goal.GetType() == typeof(SimpleGoal)) jsonGoal = new JSONSimpleGoal(goal);
                else if (goal.GetType() == typeof(SimpleSMARTGoal)) jsonGoal = new JSONSimpleSMARTGoal(goal);
                else if (goal.GetType() == typeof(EternalGoal)) jsonGoal = new JSONEternalGoal(goal);
                else if (goal.GetType() == typeof(EternalSMARTGoal)) jsonGoal = new JSONEternalSMARTGoal(goal);
                else if (goal.GetType() == typeof(ChecklistGoal)) jsonGoal = new JSONChecklistGoal(goal);
                else if (goal.GetType() == typeof(ChecklistSMARTGoal)) jsonGoal = new JSONChecklistSMARTGoal(goal);
                if (jsonGoal is not null) jSONGoals.Add(jsonGoal);
            });
            return jSONGoals;
        }
        private static void CONVERT(Goals goals, List<JSONGoal> jsonGoals, int score, Configuration configuration)
        {
            goals.Clear();
            jsonGoals.ForEach((jsonGoal) => {
                Goal goal = null;
                jsonGoal.Configuration = configuration;
                if (jsonGoal.GetType() == typeof(JSONSimpleGoal)) goal = (SimpleGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONSimpleSMARTGoal)) goal = new SimpleSMARTGoal(jsonGoal);
                else if (jsonGoal.GetType() == typeof(JSONEternalGoal)) goal = (EternalGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONEternalSMARTGoal)) goal = new EternalSMARTGoal(jsonGoal);
                else if (jsonGoal.GetType() == typeof(JSONChecklistGoal)) goal = (ChecklistGoal)jsonGoal;
                else if (jsonGoal.GetType() == typeof(JSONChecklistSMARTGoal)) goal = new ChecklistSMARTGoal(jsonGoal);
                if (goal is not null) goals.Add(goal);
            });
            goals.Score = score;
            goals.Configuration = configuration;
        }
        internal static void CONVERT(Goals goals, JSONGoals jsonGoals, Configuration configuration)
        {
            List<JSONGoal> list = new();
            foreach (JSONGoal goal in jsonGoals.Goals) { list.Add(goal); }
            CONVERT(goals, list, jsonGoals.Score, configuration);
        }
    }
}