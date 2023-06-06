namespace MindfullnessProgram
{
    public class Activity
    {
        private static readonly List<List<String>> _SPINNER_STRINGS = new() {
            new() {"-","\\","|","/"},
            new() {"^",">","v","<"},
            new() {".","o","O","o"},
            new() {".","x","X","x"}
        };
        private static readonly int _SPINNER_MS_DELAY = 250;
        private static readonly int _MAX_ACTIVITY_USE_SPREAD = 5;
        private static readonly long _MAX_ACTIVITY_DURATION_SECONDS_SPREAD = 60 * 60 * 12; // 12 hours
        private static readonly int _MIN_DAYS_SPREAD = 1;
        private String _activityName = "Uninitialized";
        private String _activityMenuDescription = "Uninitialized";
        private DateTime _lastUsed;
        private long _totalDuration;
        private int _timesUsed;
        private int _pauseTime = 500;
        /**
         *  made private and commented out because not used.
        private Activity()
        {
            Init();
        }
         */
        private int MinTimes(int minCount)
        {
            if (_timesUsed < minCount) return _timesUsed;
            else return minCount;
        }
        private long MinTotalDuration(long minTotalDuration)
        {
            if (_totalDuration < minTotalDuration) return _totalDuration;
            else return minTotalDuration;
        }
        private DateTime MinLastUsed(DateTime minLastUsed)
        {
            if (_lastUsed < minLastUsed) return _lastUsed;
            else return minLastUsed;
        }
        private Boolean Available(int minCount, long minTotalDuration, DateTime minLastUsed, Boolean useLastUsed = true)
        {
            Boolean available = true;
            int timesSpread = _timesUsed - minCount;
            long durationSpread = _totalDuration - minTotalDuration;
            TimeSpan dateSpread = _lastUsed - minLastUsed;
            if (timesSpread >= _MAX_ACTIVITY_USE_SPREAD) available = false;
            if (durationSpread >= _MAX_ACTIVITY_DURATION_SECONDS_SPREAD) available = false;
            if (useLastUsed && _lastUsed > DateTime.MinValue && dateSpread.Days <= _MIN_DAYS_SPREAD) available = false;
            return available;
        }
        private String ToJSON()
        {
            if (GetType() == typeof(Activity)) return "{" +
                $"activityName : \"{_activityName}\" , " +
                $"activityMenuDescription : \"{_activityMenuDescription}\" , " +
                $"lastUsed : {_lastUsed} , " +
                $"totalDuration : {_totalDuration} , " +
                $"timesUsed : {_timesUsed} , " +
                $"pauseTime : {_pauseTime}" +
                "}";
            else if (GetType() == typeof(BreathingActivity)) return "{" +
                $"activityName : \"{_activityName}\" , " +
                $"activityMenuDescription : \"{_activityMenuDescription}\" , " +
                $"lastUsed : {_lastUsed} , " +
                $"totalDuration : {_totalDuration} , " +
                $"timesUsed : {_timesUsed} , " +
                $"pauseTime : {_pauseTime}" +
                "}";
            else if (GetType() == typeof(ReflectionActivity)) return "{" +
                $"activityName : \"{_activityName}\" , " +
                $"activityMenuDescription : \"{_activityMenuDescription}\" , " +
                $"lastUsed : {_lastUsed} , " +
                $"totalDuration : {_totalDuration} , " +
                $"timesUsed : {_timesUsed} , " +
                $"pauseTime : {_pauseTime} , " +
                $"{((ReflectionActivity)this).GetJSONInfo()}" +
                "}";
            else if (GetType() == typeof(ListingActivity)) return "{" +
                $"activityName : \"{_activityName}\" , " +
                $"activityMenuDescription : \"{_activityMenuDescription}\" , " +
                $"lastUsed : {_lastUsed} , " +
                $"totalDuration : {_totalDuration} , " +
                $"timesUsed : {_timesUsed} , " +
                $"pauseTime : {_pauseTime} , " +
                $"{((ListingActivity)this).GetJSONInfo()}" +
                "}";
            else return "{}";
        }
        private void ParseJSON(String json)
        {
            string[] allParts = json.Split(" , ");
            List<String> allPartsList = new(allParts);
            List<String> partsList = new();
            int counter = 0;
            allPartsList.ForEach((part) => {
                if (part.StartsWith("{"))
                {
                    part= part.Substring(1);
                }
                if(part.EndsWith("}"))
                {
                    part = part.Substring(0,part.Length-1);
                }
                if (part.Contains(" : "))
                {
                    partsList.Insert(counter, part);
                    counter++;
                }
                else partsList[counter - 1]= partsList[counter-1] + " , " + part;
            });
            partsList.ForEach((part) => {
                List<String> pair = new();
                List<String> subPair = new();
                string[] subParts = part.Split(" : ");
                List<String> subPartsList = new(subParts);
                pair.Add(subPartsList[0]);
                subPartsList.RemoveAt(0);
                pair.Add(String.Join(" : ", subPartsList));
            switch(pair[0])
                {
                    case "activityName":
                        subParts = pair[1].Split("\"");
                        subPartsList = new(subParts);
                        subPartsList.RemoveAt(0);
                        subPartsList.RemoveAt(subPartsList.Count-1);
                        _activityName = String.Join("\"", subPartsList);
                        break;
                    case "activityMenuDescription":
                        subParts = pair[1].Split("\"");
                        subPartsList = new(subParts);
                        subPartsList.RemoveAt(0);
                        subPartsList.RemoveAt(subPartsList.Count - 1);
                        _activityMenuDescription = String.Join("\"", subPartsList);
                        break;
                    case "lastUsed":
                        _lastUsed = DateTime.Parse(pair[1]);
                        break;
                    case "totalDuration":
                        _totalDuration = long.Parse(pair[1]);
                        break;
                    case "timesUsed":
                        _timesUsed = int.Parse(pair[1]);
                        break;
                    case "pauseTime":
                        _pauseTime = int.Parse(pair[1]);
                        break;
                    case "_questionsTimesUsed":
                        if (GetType() == typeof(ReflectionActivity)) {
                            ((ReflectionActivity)this).ParseQuestionsTimesUsed(pair[1]);
                        } else if (GetType() == typeof(ListingActivity)) {
                            ((ListingActivity)this).ParseQuestionsTimesUsed(pair[1]);
                        }
                        break;
                    case "_messagesTimesUsed":
                        ((ReflectionActivity)this).ParseMessagesTimesUsed(pair[1]);
                        break;
                    case "_questionsLastUsed":
                        if (GetType() == typeof(ReflectionActivity))
                        {
                            ((ReflectionActivity)this).ParseQuestionsLastUsed(pair[1]);
                        }
                        else if (GetType() == typeof(ListingActivity))
                        {
                            ((ListingActivity)this).ParseQuestionsLastUsed(pair[1]);
                        }
                        break;
                    case "_messagesLastUsed":
                        ((ReflectionActivity)this).ParseMessagesLastUsed(pair[1]);
                        break;
                    default:
                        break;
                }
            });
        }
        private String Filename()
        {
            return $"{_activityName}.json";
        }
        private void SaveActivityUsageData()
        {
            File.WriteAllText(Filename(), ToJSON());
        }
        private void LoadActivityUsageData()
        {
            if(File.Exists(Filename()))
            {
                ParseJSON(File.ReadAllText(Filename()));
            }
        }
        protected static readonly String _FINISHING_MESSAGE = "\nGreat job.\n\n";
        protected String _startingMessage = "Uninitialized";
        protected int _defaultDuration = 30;
        protected int _duration = 0;
        protected static void PREPARE_FOR_START(int spinnerIndex, int spinnerTime)
        {
            Console.WriteLine("Prepare to begin... ");
            Activity.DISPLAY_SPINNER(spinnerIndex, ((spinnerTime * 1000 / 12) * 4) / 1000);
            Console.WriteLine("On your mark... ");
            Activity.DISPLAY_SPINNER(spinnerIndex, ((spinnerTime * 1000 / 12) * 4) / 1000);
            Console.WriteLine("Get set... ");
            Activity.DISPLAY_SPINNER(spinnerIndex, ((spinnerTime * 1000 / 12) * 4) / 1000);
            Console.WriteLine("Go!");
        }
        protected static void DISPLAY_SPINNER(int spinnerIndex, int duration)
        {
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(duration);
            int index = 0;
            Boolean init = false;
            while (done.CompareTo(DateTime.Now) > 0)
            {
                if (init) Console.Write("\b \b");
                init = true;
                Console.Write(_SPINNER_STRINGS[spinnerIndex][index]);
                Thread.Sleep(_SPINNER_MS_DELAY);
                index++;
                if (index >= _SPINNER_STRINGS[spinnerIndex].Count) index = 0;
            }
            Console.Write("\b \b");
        }
        protected static void DISPLAY_COUNTER(int durationInSeconds, int incrementalPauseMS, Boolean showNumeric = true, Boolean numericForward = false, Boolean cleanNumeric = true, int maxNonNumeric = 10)
        {
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(durationInSeconds);
            int index;
            if (incrementalPauseMS < 1) incrementalPauseMS = 1;
            if (maxNonNumeric < 0) maxNonNumeric = 0;
            if (numericForward)
            {
                index = 1;
            }
            else
            {
                index = durationInSeconds * (1000 / incrementalPauseMS);
            }
            String prev;
            Boolean init = false;
            while (done.CompareTo(DateTime.Now) > 0)
            {
                if (init && showNumeric && cleanNumeric)
                {
                    if (numericForward) prev = (index - 1).ToString();
                    else prev = (index + 1).ToString();
                    foreach (char c in prev) Console.Write("\b");
                    foreach (char c in prev) Console.Write(" ");
                    foreach (char c in prev) Console.Write("\b");
                }
                else if (init && showNumeric && !cleanNumeric)
                {
                    Console.Write(" ");
                }
                init = true;
                if (showNumeric) Console.Write(index);
                else if (maxNonNumeric > 0)
                {
                    if (!showNumeric && !numericForward && (index / maxNonNumeric) % 2 == 0) Console.Write("\b \b");
                    else if (!showNumeric && numericForward && (index / maxNonNumeric) % 2 == 1) Console.Write("\b \b");
                    else Console.Write(".");
                }
                else Console.Write(".");
                Thread.Sleep(incrementalPauseMS);
                if (numericForward) index++;
                else index--;
            }
            if (init && showNumeric && cleanNumeric)
            {
                if (numericForward) prev = (index - 1).ToString();
                else prev = (index + 1).ToString();
                for (int i = 0; i < prev.Length; i++) Console.Write("\b");
                for (int i = 0; i < prev.Length; i++) Console.Write(" ");
                for (int i = 0; i < prev.Length; i++) Console.Write("\b");
            }
            else
            {
                Console.WriteLine("");
            }
        }
        protected void Init(String activityName, String activityMenuDescription, String startingMessage, int defaultDuration, int pauseTime)
        {
            _activityName = activityName;
            _activityMenuDescription = activityMenuDescription;
            _startingMessage = startingMessage;
            _defaultDuration = defaultDuration;
            _pauseTime = pauseTime;
            ResetActivityUsageData();
            if (_activityName != "Undefined") LoadActivityUsageData();
        }
        protected void Init()
        {
            Init("Undefined", "Undefined", "Undefined", _defaultDuration, _pauseTime);
        }
        protected void PromptForDuration()
        {
            Console.WriteLine("How long would you like to perform this activity in seconds?");
            Console.Write(">  ");
            String response = Console.ReadLine();
            int duration;
            try
            {
                duration = int.Parse(response);
            }
            catch (FormatException)
            {
                duration = _defaultDuration;
            }
            if (duration < 0) duration = _defaultDuration;
            _duration = duration;
        }
        protected void ReportUsage(int duration, DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now;
            _lastUsed = (DateTime)dateTime;
            _totalDuration += duration;
            _timesUsed++;
            if (_activityName != "Undefined") SaveActivityUsageData();
        }
        protected void ResetActivityUsageData()
        {
            _totalDuration = 0;
            _timesUsed = 0;
            _lastUsed = DateTime.MinValue;
        }
        public Activity(String activityName, String activityMenuDescription, String startingMessage, int defaultDuration, int pauseTime)
        {
            Init(activityName, activityMenuDescription, startingMessage, defaultDuration, pauseTime);
        }
        public static List<Activity> DEFINE_ACTIVITIES()
        {
            List<Activity> result = new()
            {
                new BreathingActivity()
                , new ReflectionActivity()
                , new ListingActivity()
            };
            return result;
        }
        public static List<Activity> AVAILABLE_ACTIVITIES(List<Activity> allActivities)
        {
            int minCount = int.MaxValue;
            long minTotalDuration = long.MaxValue;
            DateTime minLastUsed = DateTime.MaxValue;
            allActivities.ForEach((activity) => {
                minCount = activity.MinTimes(minCount);
                minTotalDuration = activity.MinTotalDuration(minTotalDuration);
                minLastUsed = activity.MinLastUsed(minLastUsed);
            });
            List<Activity> result = new();
            allActivities.ForEach((activity) => {
                if (activity.Available(minCount, minTotalDuration, minLastUsed)) result.Add(activity);
            });
            if (result.Count == 0) allActivities.ForEach((activity) => {
                if (activity.Available(minCount, minTotalDuration, minLastUsed, false)) result.Add(activity);
            });
            return result;
        }
        public void DisplayMenuLine(int menuOptionNumber, String separator)
        {
            Console.WriteLine($"{menuOptionNumber}{separator}{_activityMenuDescription}");
        }
    }
}
