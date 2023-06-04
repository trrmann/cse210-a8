namespace MindfullnessProgram
{
    public class ReflectionActivity : Activity
    {
        private int _spinnerTime = 0;
        private static int _maxQuestionUseSpread;
        private static int _maxMessageUseSpread;
        private static List<String> questions;
        private static List<String> messages;
        private List<int> questionsTimesUsed;
        private List<List<int>> messagesTimesUsed;
        private List<DateTime> questionsLastUsed;
        private List<List<DateTime>> messagesLastUsed;

        public ReflectionActivity(int defaultDuration) : base("ReflectionActivity", "Reflection Activity", "to do", "to do", "to do", 20, 600)
        {
            Init(defaultDuration);
        }

        public ReflectionActivity() : base("ReflectionActivity", "Reflection Activity", "to do", "to do", "to do", 20, 600)
        {
            Init();
        }

        protected void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init("ReflectionActivity", "Reflection Activity", "to do", "to do", "to do", 20, 600);
            _defaultDuration = defaultDuration;
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunReflectionActivity(int? duration = null) {
            duration ??= _defaultDuration;
            Activity.DisplaySpinner(_spinnerTime);
            ReportUsage((int)duration);
        }

        protected static String SelectReflectionActivityQuestion() { return ""; }
        public void ResetQuestionUsageData() { }
        protected List<int> AvailableQuestionIndexes() { return new List<int>(); }
        protected List<List<int>> AvailableMessageIndexesPerQuestionIndexes(List<int> QuestionIndexes) { return new List<List<int>>(); }
    }
}
