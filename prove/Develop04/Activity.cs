using System.Collections.Generic;

namespace MindfullnessProgram
{
    public class Activity
    {
        private static readonly int _maxActivityUseSpread = 5;
        private static readonly int _maxActivityDurationSpread = 60 * 60 * 12;
        private static readonly int _minDaysSpread = 1;
        private static readonly List<String> _spinnerStrings = new() {"-","\\","|","/"};
        private static readonly int _spinner_delay = 750;
        private String _activityName = "Uninitialized";
        private String _activityMenuDescription = "Uninitialized";
        protected String _startingMessage = "Uninitialized";
        protected String _activityDescription = "Uninitialized";
        protected String _finishingMessage = "Uninitialized";
        private int _defaultDuration = 30;
        protected int _duration = 0;
        private long _totalDuration = 0;
        private int _timesUsed = 0;
        private DateTime _lastUsed = DateTime.MinValue;
        private int _pauseTime = 500;
        public Activity(String activityName, String activityMenuDescription, String startingMessage, String activityDescription, String finishingMessage, int defaultDuration, int pauseTime)
        {
            Init(activityName, activityMenuDescription, startingMessage, activityDescription, finishingMessage, defaultDuration, pauseTime);
        }
        public Activity() {
            Init();
        }
        public static List<Activity> DefineActivities() {
            List<Activity> result = new()
            {
                new BreathingActivity()
//                , new ReflectionActivity()
//                , new ListingActivity()
            };
            return result;
        }
        protected void Init(String activityName, String activityMenuDescription, String startingMessage, String activityDescription, String finishingMessage, int defaultDuration, int pauseTime)
        {
            _activityName = activityName;
            _activityMenuDescription = activityMenuDescription;
            _startingMessage = startingMessage;
            _activityDescription = activityDescription;
            _finishingMessage = finishingMessage;
            _defaultDuration = defaultDuration;
            _pauseTime = pauseTime;
            if(_activityName != "Undefined") LoadActivityUsageData();
        }
        protected void Init()
        {
            Init("Undefined", "Undefined", "Undefined", "Undefined", "Undefined", _defaultDuration, _pauseTime);
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
            if(timesSpread > _maxActivityUseSpread) available = false;
            if (durationSpread > _maxActivityDurationSpread) available = false;
            if (useLastUsed && _lastUsed > DateTime.MinValue && dateSpread.Days < _minDaysSpread) available = false;
            return available;
        }
        public void DisplayMenuLine(int menuOptionNumber, String separator)
        {
            Console.WriteLine($"{menuOptionNumber}{separator}{_activityMenuDescription}");
        }
        protected static void DisplaySpinner(int duration) {
            DateTime dateTime = DateTime.Now;
            DateTime done = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second + duration, dateTime.Millisecond);
            int index = 0;
            Boolean init = false;
            while(done.CompareTo(DateTime.Now) > 0)
            {
                if (init) Console.Write("\b \b");
                init = true;
                Console.Write(_spinnerStrings[index]);
                Thread.Sleep(_spinner_delay);
                index++;
                if (index >= _spinnerStrings.Count) index = 0;
            }
            Console.Write("\b \b");
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
