namespace MindfullnessProgram
{
    public class BreathingActivity : Activity
    {
        private static readonly String _ACTIVITY_NAME = "BreathingActivity";
        private static readonly String _ACTIVITY_MENU_DESCRIPTION = "Breathing Activity";
        private static readonly String _STARTING_MESSAGE = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        private static readonly List<String> _MESSAGES = new() { "Breathe in...", "Breathe out..." };
        private static readonly int _SPINNER_TIME = 10;
        private static readonly int _DEFAULT_DURATION = 20;
        private static readonly int _PAUSE_TIME = 600;
        /**
         *  made private and commented out because not used.
        private BreathingActivity(int defaultDuration) : base(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME)
        {
            Init(defaultDuration);
        }
         */
        private void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME);
            _defaultDuration = defaultDuration;
        }
        private void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(_DEFAULT_DURATION);
        }
        public BreathingActivity() : base(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME)
        {
            Init();
        }
        public void RunBreathingActivity()
        {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            PREPARE_FOR_START(0, _SPINNER_TIME);
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(_duration);
            int eventTime;
            int eventUnitMS;
            Boolean first = true;
            if (_duration > 20)
            {
                eventTime = 5;
                eventUnitMS = 1000;
            }
            else if (_duration > 15)
            {
                eventTime = 4;
                eventUnitMS = 1000;
            }
            else if (_duration > 5)
            {
                eventTime = 3;
                eventUnitMS = 1000;
            }
            else
            {
                eventTime = 1;
                eventUnitMS = 250;
            }
            while (done.CompareTo(DateTime.Now) > 0)
            {
                if (first)
                {
                    Console.WriteLine("\n" + _MESSAGES[0] + "\n");
                    DISPLAY_COUNTER(eventTime, eventUnitMS);
                }
                else
                {
                    Console.WriteLine("\n" + _MESSAGES[1] + "\n");
                    DISPLAY_COUNTER(eventTime, eventUnitMS, true, true);
                }
                first = !first;
            }
            Console.WriteLine(_FINISHING_MESSAGE);
            Activity.DISPLAY_SPINNER(1, _SPINNER_TIME);
            ReportUsage(_duration);
        }
    }
}
