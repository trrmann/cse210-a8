using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace MindfullnessProgram
{
    public class Activity
    {
        private static readonly int _maxActivityUseSpread = 5;
        private static readonly int _maxActivityDurationSpread = 60 * 60 * 12;
        private static readonly int _minDaysSpread = 1;
        private static readonly List<List<String>> _spinnerStrings = new() {
            new() {"-","\\","|","/"},
            new() {"^",">","v","<"},
            new() {".","o","O","o"},
            new() {".","x","X","x"}
        };
        private static readonly int _spinner_delay = 750;
        protected static readonly String _finishingMessage = "to do.";
        private String _activityName = "Uninitialized";
        private String _activityMenuDescription = "Uninitialized";
        protected String _startingMessage = "Uninitialized";
        protected int _defaultDuration = 30;
        protected int _duration = 0;
        private long _totalDuration;
        private int _timesUsed;
        private DateTime _lastUsed;
        private int _pauseTime = 500;
        public Activity(String activityName, String activityMenuDescription, String startingMessage, int defaultDuration, int pauseTime)
        {
            Init(activityName, activityMenuDescription, startingMessage, defaultDuration, pauseTime);
        }
        public Activity() {
            Init();
        }
        public static List<Activity> DefineActivities() {
            List<Activity> result = new()
            {
                new BreathingActivity()
                , new ReflectionActivity()
                , new ListingActivity()
            };
            return result;
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
        public static List<Activity> AvailableActivities(List<Activity> allActivities)
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
                if(activity.Available(minCount, minTotalDuration, minLastUsed)) result.Add(activity);
            });
            if(result.Count == 0) allActivities.ForEach((activity) => {
                    if (activity.Available(minCount, minTotalDuration, minLastUsed, false)) result.Add(activity);
                });
            return result;
        }
        public int MinTimes(int minCount)
        {
            if(_timesUsed<minCount) return _timesUsed;
            else return minCount;
        }
        public long MinTotalDuration(long minTotalDuration)
        {
            if (_totalDuration < minTotalDuration) return _totalDuration;
            else return minTotalDuration;
        }
        public DateTime MinLastUsed(DateTime minLastUsed)
        {
            if (_lastUsed < minLastUsed) return _lastUsed;
            else return minLastUsed;
        }
        public Boolean Available(int minCount, long minTotalDuration, DateTime minLastUsed, Boolean useLastUsed = true)
        {
            Boolean available = true;
            int timesSpread = _timesUsed - minCount;
            long durationSpread = _totalDuration - minTotalDuration;
            TimeSpan dateSpread = _lastUsed - minLastUsed;
            if(timesSpread >= _maxActivityUseSpread) available = false;
            if (durationSpread >= _maxActivityDurationSpread) available = false;
            if (useLastUsed && _lastUsed > DateTime.MinValue && dateSpread.Days <= _minDaysSpread) available = false;
            return available;
        }
        public void DisplayMenuLine(int menuOptionNumber, String separator)
        {
            Console.WriteLine($"{menuOptionNumber}{separator}{_activityMenuDescription}");
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
        protected static void PrepareForStart(int spinnerIndex, int spinnerTime)
        {
            Console.WriteLine("Prepare to begin... ");
            Activity.DisplaySpinner(spinnerIndex, ((spinnerTime * 1000 / 12) * 4) / 1000);
            Console.WriteLine("On your mark... ");
            Activity.DisplaySpinner(spinnerIndex, ((spinnerTime * 1000 / 12) * 4) / 1000);
            Console.WriteLine("Get set... ");
            Activity.DisplaySpinner(spinnerIndex, ((spinnerTime * 1000 / 12) * 4) / 1000);
            Console.WriteLine("Go!");
        }
        protected static void DisplaySpinner(int spinnerIndex, int duration) {
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(duration);
            int index = 0;
            Boolean init = false;
            while(done.CompareTo(DateTime.Now) > 0)
            {
                if (init) Console.Write("\b \b");
                init = true;
                Console.Write(_spinnerStrings[spinnerIndex][index]);
                Thread.Sleep(_spinner_delay);
                index++;
                if (index >= _spinnerStrings[spinnerIndex].Count) index = 0;
            }
            Console.Write("\b \b");
        }
        protected static void DisplayCounter(int durationInSeconds, int incrementalPauseMS, Boolean showNumeric=true, Boolean numericForward=false, Boolean cleanNumeric=true, int maxNonNumeric = 10)
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
                index = durationInSeconds * (1000/incrementalPauseMS);
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
                } else if (init && showNumeric && !cleanNumeric)
                {
                    Console.Write(" ");
                }
                init = true;
                if (showNumeric) Console.Write(index);
                else if(maxNonNumeric>0) {
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
        protected void ReportUsage(int duration, DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now;
            _lastUsed = (DateTime)dateTime;
            _totalDuration += duration;
            _timesUsed++;
            if(_activityName != "Undefined") SaveActivityUsageData();
        }
        public void ResetActivityUsageData() {
            _totalDuration = 0;
            _timesUsed = 0;
            _lastUsed = DateTime.MinValue;
        }
        protected void SaveActivityUsageData() { }
        protected void LoadActivityUsageData() { }
    }
}
