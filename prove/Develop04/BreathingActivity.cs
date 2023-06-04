namespace MindfullnessProgram
{
    public class BreathingActivity : Activity
    {
        private int _spinnerTime = 0;
        private static List<String> messages;
        public BreathingActivity(int defaultDuration) : base("BreathingActivity", "Breathing Activity", "to do", "to do", "to do", 20, 600) {
            Init(defaultDuration);
        }
        public BreathingActivity() : base("BreathingActivity", "Breathing Activity", "to do", "to do", "to do", 20, 600)
        {
            Init();
        }
        protected void Init(int defaultDuration, Boolean callBaseInit=false)
        {
            if (callBaseInit) Init("BreathingActivity", "Breathing Activity", "to do", "to do", "to do", 20, 600);
            _defaultDuration = defaultDuration;
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunBreathingActivity(int? duration = null) {
            duration ??= _defaultDuration;
            Activity.DisplaySpinner(_spinnerTime);
            ReportUsage((int)duration);
        }
    }
}
