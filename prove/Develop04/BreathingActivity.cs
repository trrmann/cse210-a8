namespace MindfullnessProgram
{
    public class BreathingActivity : Activity
    {
        private static readonly String _breathingName = "BreathingActivity";
        private static readonly String _breathingMenuDescription = "Breathing Activity";
        private static readonly String _breathingStartingMessage = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        private static readonly int _breathingDefaultDuration = 20;
        private static readonly int _breathingPauseTime = 600;
        private int _spinnerTime = 6;
        private static readonly List<String> messages = new(){"Breathe in...", "Breathe out..."};
        public BreathingActivity(int defaultDuration) : base(_breathingName, _breathingMenuDescription, _breathingStartingMessage, _breathingDefaultDuration, _breathingPauseTime) {
            Init(defaultDuration);
        }
        public BreathingActivity() : base(_breathingName, _breathingMenuDescription, _breathingStartingMessage, _breathingDefaultDuration, _breathingPauseTime)
        {
            Init();
        }
        protected void Init(int defaultDuration, Boolean callBaseInit=false)
        {
            if (callBaseInit) Init(_breathingName, _breathingMenuDescription, _breathingStartingMessage, _breathingDefaultDuration, _breathingPauseTime);
            _defaultDuration = defaultDuration;
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunBreathingActivity() {
            int duration = _defaultDuration;
            Activity.DisplaySpinner(0, _spinnerTime);
            Console.WriteLine(_startingMessage);
            DisplayCounter(duration, 1000);
            Activity.DisplaySpinner(1, _spinnerTime);
            DisplayCounter(duration, 1000, true, true);
            ReportUsage(duration);
        }
    }
}
