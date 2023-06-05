namespace MindfullnessProgram
{
    public class BreathingActivity : Activity
    {
        private static readonly String _breathingName = "BreathingActivity";
        private static readonly String _breathingMenuDescription = "Breathing Activity";
        private static readonly String _breathingStartingMessage = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        private static readonly List<String> _messages = new() { "Breathe in...", "Breathe out..." };
        private static readonly int _spinnerTime = 10;
        private static readonly int _breathingDefaultDuration = 20;
        private static readonly int _breathingPauseTime = 600;
        private void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init(_breathingName, _breathingMenuDescription, _breathingStartingMessage, _breathingDefaultDuration, _breathingPauseTime);
            _defaultDuration = defaultDuration;
        }
        private void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(_breathingDefaultDuration);
        }
        public BreathingActivity(int defaultDuration) : base(_breathingName, _breathingMenuDescription, _breathingStartingMessage, _breathingDefaultDuration, _breathingPauseTime)
        {
            Init(defaultDuration);
        }
        public BreathingActivity() : base(_breathingName, _breathingMenuDescription, _breathingStartingMessage, _breathingDefaultDuration, _breathingPauseTime)
        {
            Init();
        }
        public void RunBreathingActivity()
        {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            PrepareForStart(0, _spinnerTime);
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
                    Console.WriteLine("\n" + _messages[0] + "\n");
                    DisplayCounter(eventTime, eventUnitMS);
                }
                else
                {
                    Console.WriteLine("\n" + _messages[1] + "\n");
                    DisplayCounter(eventTime, eventUnitMS, true, true);
                }
                first = !first;
            }
            Console.WriteLine(_finishingMessage);
            Activity.DisplaySpinner(1, _spinnerTime);
            ReportUsage(_duration);
        }
    }
}
