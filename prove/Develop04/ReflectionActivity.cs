namespace MindfullnessProgram
{
    public class ReflectionActivity : Activity
    {
        private static readonly String _reflectionName = "ReflectionActivity";
        private static readonly String _reflectionMenuDescription = "Reflection Activity";
        private static readonly String _reflectionStartingMessage = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        private static readonly int _reflectionDefaultDuration = 40;
        private static readonly int _reflectionPauseTime = 400;
        private readonly int _spinnerTime = 6;
        private static int _maxQuestionUseSpread = 5;
        private static readonly int _minDaysQuestionUseSpread = 1;
        private static int _maxMessageUseSpread = 5;
        private static readonly int _minDaysMessageUseSpread = 1;
        private static readonly List<String> questions = new() {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        private static readonly List<String> messages = new() {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        private List<int> questionsTimesUsed = new(){0,0,0,0};
        private List<List<int>> messagesTimesUsed = new() {
            new(){ 0,0,0,0,0,0,0,0,0},
            new(){ 0,0,0,0,0,0,0,0,0},
            new(){ 0,0,0,0,0,0,0,0,0},
            new(){ 0,0,0,0,0,0,0,0,0}
        };
        private List<DateTime> questionsLastUsed = new() {
            DateTime.MinValue,
            DateTime.MinValue,
            DateTime.MinValue,
            DateTime.MinValue
        };
        private List<List<DateTime>> messagesLastUsed = new() {
            new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
            new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
            new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
            new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue }
        };

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
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            PrepareForStart(2, _spinnerTime);
            DisplayCounter(_duration, 500, false);
            DisplayCounter(_duration, 500, false, true);
            Activity.DisplaySpinner(3, _spinnerTime);
            DisplayCounter(_duration, 500, false, true, true, 0);
            Console.WriteLine(_finishingMessage);
            ReportUsage(_duration);
        }

        protected static String SelectReflectionActivityQuestion() { return ""; }
        public void ResetQuestionUsageData() { }
        protected List<int> AvailableQuestionIndexes() { return new List<int>(); }
        protected List<List<int>> AvailableMessageIndexesPerQuestionIndexes(List<int> QuestionIndexes) { return new List<List<int>>(); }
    }
}
