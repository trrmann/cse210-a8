namespace Develop04
{
    public class Activity
    {
        private static int _maxActivityUseSpread;
        private static int _maxActivityDurationSpread;
        private static List<String> _spinnerStrings;
        private static int _spinner_delay;
        private String _activityName;
        private String _activityMenuDescription;
        private String _startingMessage;
        private String _activityDescription;
        private String _finishingMessage;
        private int _defaultDuration;
        private int _duration;
        private long _totalDuration;
        private int _timesUsed;
        private DateTime _lastUsed;
        private int _pauseTime;

        public Activity() { }
        public Activity(String activityName, String activityMenuDescription, String startingMessage, String activityDescription, String finishingMessage, int defaultDuration, int pauseTime) { }
        private static List<Activity> DefineActivities() { return new List<Activity>(); }
        protected static void DisplaySpinner(int duration) { }
        public void ResetActivityUsageData() { }
        protected void SaveActivityUsageData() { }
        protected void LoadActivityUsageData() { }
    }
}
