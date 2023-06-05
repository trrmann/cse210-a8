namespace MindfullnessProgram
{
    public class ReflectionActivity : Activity
    {
        private static readonly String _reflectionName = "ReflectionActivity";
        private static readonly String _reflectionMenuDescription = "Reflection Activity";
        private static readonly String _reflectionStartingMessage = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        private static readonly int _reflectionDefaultDuration = 40;
        private static readonly int _reflectionPauseTime = 400;
        private static readonly int _maxQuestionUseSpread = 1;
        private static readonly int _minDaysQuestionUseSpread = 1;
        private static readonly int _maxMessageUseSpread = 1;
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
        private readonly int _spinnerTime = 6;
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
            ResetQuestionUsageData();
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunReflectionActivity() {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            String question = SelectListingActivityQuestion(AvailableQuestionIndexes());
            Console.WriteLine("\n" + question + "\n");
            DisplayCounter(5, 1000);
            PrepareForStart(3, _spinnerTime);
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(_duration);
            int timeRemain = _duration;
            String message;
            while (done.CompareTo(DateTime.Now) > 0)
            {
                message = SelectListingActivityMessage(AvailableMessageIndexesPerQuestionIndexes(question));
                Console.WriteLine("\n"+ message+"\n");
                if(timeRemain < 20)
                {
                    DisplayCounter(timeRemain, 1000);
                    timeRemain -= timeRemain;
                }
                else
                {
                    DisplayCounter(10, 1000);
                    timeRemain -= 10;
                }
                ReportMessageUsage(question, message);
            }
            Console.WriteLine(_finishingMessage);
            DisplayCounter(8, 100, false);
            ReportUsage(_duration);
        }
        public void ResetQuestionUsageData() {
            questionsTimesUsed = new() { 0, 0, 0, 0 };
            messagesTimesUsed = new() {
                new(){ 0,0,0,0,0,0,0,0,0},
                new(){ 0,0,0,0,0,0,0,0,0},
                new(){ 0,0,0,0,0,0,0,0,0},
                new(){ 0,0,0,0,0,0,0,0,0}
            };
            questionsLastUsed = new() {
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue
            };
            messagesLastUsed = new() {
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue }
            };
            ResetActivityUsageData();
        }
        protected static String SelectListingActivityQuestion(List<int> availableIndexes)
        {
            Random random = new();
            int index = random.Next(0, availableIndexes.Count);
            return questions[availableIndexes[index]];
        }
        protected List<int> AvailableQuestionIndexes()
        {
            int minCount = int.MaxValue;
            DateTime minLastUsed = DateTime.MaxValue;
            questionsTimesUsed.ForEach((count) => {
                if (count < minCount) minCount = count;
            });
            questionsLastUsed.ForEach((dateTime) => {
                if (dateTime < minLastUsed) minLastUsed = dateTime;
            });
            List<int> result = new();
            questions.ForEach((question) => {
                Boolean available = true;
                int index = questions.IndexOf(question);
                int timesUsedSpread = questionsTimesUsed[index] - minCount;
                int lastUsedSpread = (questionsLastUsed[index] - minLastUsed).Days;
                if (timesUsedSpread >= _maxQuestionUseSpread) available = false;
                if (questionsLastUsed[index] > DateTime.MinValue && lastUsedSpread <= _minDaysQuestionUseSpread) available = false;
                if (available) result.Add(index);
            });
            if (result.Count == 0)
            {
                questions.ForEach((question) => {
                    Boolean available = true;
                    int index = questions.IndexOf(question);
                    int timesUsedSpread = questionsTimesUsed[index] - minCount;
                    int lastUsedSpread = (questionsLastUsed[index] - minLastUsed).Days;
                    if (timesUsedSpread > _maxQuestionUseSpread) available = false;
                    if (available) result.Add(index);
                });
            }
            return result;
        }
        protected static String SelectListingActivityMessage(List<int> availableIndexes)
        {
            Random random = new();
            int index = random.Next(0, availableIndexes.Count);
            return messages[availableIndexes[index]];
        }
        protected List<int> AvailableMessageIndexesPerQuestionIndexes(String question) {
            int questionIndex = questions.IndexOf(question);
            int minCount = int.MaxValue;
            DateTime minLastUsed = DateTime.MaxValue;
            messagesTimesUsed[questionIndex].ForEach((count) => {
                if (count < minCount) minCount = count;
            });
            messagesLastUsed[questionIndex].ForEach((dateTime) => {
                if (dateTime < minLastUsed) minLastUsed = dateTime;
            });
            List<int> result = new();
            messages.ForEach((message) => {
                Boolean available = true;
                int index = messages.IndexOf(message);
                int timesUsedSpread = messagesTimesUsed[questionIndex][index] - minCount;
                int lastUsedSpread = (messagesLastUsed[questionIndex][index] - minLastUsed).Days;
                if (timesUsedSpread >= _maxMessageUseSpread) available = false;
                if (messagesLastUsed[questionIndex][index] > DateTime.MinValue && lastUsedSpread <= _minDaysMessageUseSpread) available = false;
                if (available) result.Add(index);
            });
            if (result.Count == 0)
            {
                messages.ForEach((message) => {
                    Boolean available = true;
                    int index = messages.IndexOf(message);
                    int timesUsedSpread = messagesTimesUsed[questionIndex][index] - minCount;
                    if (timesUsedSpread >= _maxMessageUseSpread) available = false;
                    if (available) result.Add(index);
                });
            }
            return result; 
        }
        protected void ReportMessageUsage(String question, String message) {
            int questionIndex = questions.IndexOf(question);
            int messageIndex = messages.IndexOf(message);
            messagesTimesUsed[questionIndex][messageIndex]++;
            messagesLastUsed[questionIndex][messageIndex] = DateTime.Now;
        }
    }
}
