namespace MindfullnessProgram
{
    public class ReflectionActivity : Activity
    {
        private static readonly String _reflectionName = "ReflectionActivity";
        private static readonly String _reflectionMenuDescription = "Reflection Activity";
        private static readonly String _reflectionStartingMessage = "to do.";
        private static readonly int _reflectionDefaultDuration = 40;
        private static readonly int _reflectionPauseTime = 400;
        private int _spinnerTime = 6;
        private static int _maxQuestionUseSpread;
        private static int _maxMessageUseSpread;
        private static List<String> questions;
        private static List<String> messages;
        private List<int> questionsTimesUsed;
        private List<List<int>> messagesTimesUsed;
        private List<DateTime> questionsLastUsed;
        private List<List<DateTime>> messagesLastUsed;

        public ReflectionActivity(int defaultDuration) : base(_reflectionName, _reflectionMenuDescription, _reflectionStartingMessage, _reflectionDefaultDuration, _reflectionPauseTime)
        {
            Init(defaultDuration);
        }

        public ReflectionActivity() : base(_reflectionName, _reflectionMenuDescription, _reflectionStartingMessage, _reflectionDefaultDuration, _reflectionPauseTime)
        {
            Init();
        }

        protected void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init(_reflectionName, _reflectionMenuDescription, _reflectionStartingMessage, _reflectionDefaultDuration, _reflectionPauseTime);
            _defaultDuration = defaultDuration;
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunReflectionActivity() {
            int duration = _defaultDuration;
            Activity.DisplaySpinner(2, _spinnerTime);
            Console.WriteLine(_startingMessage);
            DisplayCounter(duration, 500, false);
            DisplayCounter(duration, 500, false, true);
            Activity.DisplaySpinner(3, _spinnerTime);
            DisplayCounter(duration, 500, false, true, true, 0);
            ReportUsage(duration);
        }

        protected static String SelectReflectionActivityQuestion() { return ""; }
        public void ResetQuestionUsageData() { }
        protected List<int> AvailableQuestionIndexes() { return new List<int>(); }
        protected List<List<int>> AvailableMessageIndexesPerQuestionIndexes(List<int> QuestionIndexes) { return new List<List<int>>(); }
    }
}
