using System.ComponentModel;

namespace MindfullnessProgram
{
    public class ReflectionActivity : Activity
    {
        private static readonly String _ACTIVITY_NAME = "ReflectionActivity";
        private static readonly String _ACTIVITY_MENU_DESCRIPTION = "Reflection Activity";
        private static readonly String _STARTING_MESSAGE = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        private static readonly List<String> _QUESTIONS = new() {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        private static readonly List<String> _MESSAGES = new() {
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
        private static readonly int _SPINNER_TIME = 10;
        private static readonly int _DEFAULT_DURATION = 40;
        private static readonly int _PAUSE_TIME = 400;
        private static readonly int _MAX_QUESTIONS_USE_SPREAD = 1;
        private static readonly int _MIN_DAYS_QUESTIONS_USE_SPREAD = 1;
        private static readonly int _MAX_MESSAGES_USE_SPREAD = 1;
        private static readonly int _MIN_DAYS_MESSAGE_USE_SPREAD = 1;
        private static readonly Random _RANDOM = new();
        private List<int> _questionsTimesUsed;
        private List<List<int>> _messagesTimesUsed;
        private List<DateTime> _questionsLastUsed;
        private List<List<DateTime>> _messagesLastUsed;
        private static String SELECT_REFLECTION_ACTIVITY_QUESTION(List<int> availableIndexes)
        {
            return _QUESTIONS[availableIndexes[_RANDOM.Next(0, availableIndexes.Count)]];
        }
        private static String SELECT_REFLECTION_ACTIVITY_MESSAGE(List<int> availableIndexes)
        {
            return _MESSAGES[availableIndexes[_RANDOM.Next(0, availableIndexes.Count)]];
        }
        /**
         *  made private and commented out because not used.
        private ReflectionActivity(int defaultDuration) : base(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME)
        {
            Init(defaultDuration);
        }
         */
        private void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            ResetQuestionUsageData();
            if (callBaseInit) Init(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME);
            _defaultDuration = defaultDuration;
            base.LoadActivityUsageData();
        }
        private void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(_DEFAULT_DURATION);
        }
        private void ResetQuestionUsageData()
        {
            _questionsTimesUsed = new() { 0, 0, 0, 0 };
            _messagesTimesUsed = new() {
                new(){ 0,0,0,0,0,0,0,0,0},
                new(){ 0,0,0,0,0,0,0,0,0},
                new(){ 0,0,0,0,0,0,0,0,0},
                new(){ 0,0,0,0,0,0,0,0,0}
            };
            _questionsLastUsed = new() {
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue
            };
            _messagesLastUsed = new() {
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue },
                new(){ DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue }
            };
            ResetActivityUsageData();
        }
        private List<int> AvailableQuestionIndexes()
        {
            int minCount = int.MaxValue;
            DateTime minLastUsed = DateTime.MaxValue;
            _questionsTimesUsed.ForEach((count) => {
                if (count < minCount) minCount = count;
            });
            _questionsLastUsed.ForEach((dateTime) => {
                if (dateTime < minLastUsed) minLastUsed = dateTime;
            });
            List<int> result = new();
            _QUESTIONS.ForEach((question) => {
                Boolean available = true;
                int index = _QUESTIONS.IndexOf(question);
                int timesUsedSpread = _questionsTimesUsed[index] - minCount;
                int lastUsedSpread = (_questionsLastUsed[index] - minLastUsed).Days;
                if (timesUsedSpread >= _MAX_QUESTIONS_USE_SPREAD) available = false;
                if (_questionsLastUsed[index] > DateTime.MinValue && lastUsedSpread <= _MIN_DAYS_QUESTIONS_USE_SPREAD) available = false;
                if (available) result.Add(index);
            });
            if (result.Count == 0)
            {
                _QUESTIONS.ForEach((question) => {
                    Boolean available = true;
                    int index = _QUESTIONS.IndexOf(question);
                    int timesUsedSpread = _questionsTimesUsed[index] - minCount;
                    if (timesUsedSpread >= _MAX_QUESTIONS_USE_SPREAD) available = false;
                    if (available) result.Add(index);
                });
            }
            return result;
        }
        private List<int> AvailableMessageIndexesPerQuestionIndexes(String question)
        {
            int questionIndex = _QUESTIONS.IndexOf(question);
            int minCount = int.MaxValue;
            DateTime minLastUsed = DateTime.MaxValue;
            _messagesTimesUsed[questionIndex].ForEach((count) => {
                if (count < minCount) minCount = count;
            });
            _messagesLastUsed[questionIndex].ForEach((dateTime) => {
                if (dateTime < minLastUsed) minLastUsed = dateTime;
            });
            List<int> result = new();
            _MESSAGES.ForEach((message) => {
                Boolean available = true;
                int index = _MESSAGES.IndexOf(message);
                int timesUsedSpread = _messagesTimesUsed[questionIndex][index] - minCount;
                int lastUsedSpread = (_messagesLastUsed[questionIndex][index] - minLastUsed).Days;
                if (timesUsedSpread >= _MAX_MESSAGES_USE_SPREAD) available = false;
                if (_messagesLastUsed[questionIndex][index] > DateTime.MinValue && lastUsedSpread <= _MIN_DAYS_MESSAGE_USE_SPREAD) available = false;
                if (available) result.Add(index);
            });
            if (result.Count == 0)
            {
                _MESSAGES.ForEach((message) => {
                    Boolean available = true;
                    int index = _MESSAGES.IndexOf(message);
                    int timesUsedSpread = _messagesTimesUsed[questionIndex][index] - minCount;
                    if (timesUsedSpread >= _MAX_MESSAGES_USE_SPREAD) available = false;
                    if (available) result.Add(index);
                });
            }
            return result;
        }
        private void ReportMessageUsage(int duration, String question, String message, DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now;
            int questionIndex = _QUESTIONS.IndexOf(question);
            int messageIndex = _MESSAGES.IndexOf(message);
            _messagesTimesUsed[questionIndex][messageIndex]++;
            _messagesLastUsed[questionIndex][messageIndex] = (DateTime)dateTime;
        }
        private void ReportQuestionUsage(int duration, String question, DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now;
            int questionIndex = _QUESTIONS.IndexOf(question);
            _questionsTimesUsed[questionIndex]++;
            _questionsLastUsed[questionIndex] = (DateTime)dateTime;
            ReportUsage(duration, dateTime);
        }
        public ReflectionActivity() : base(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME)
        {
            Init();
        }
        public void RunReflectionActivity()
        {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            String question = SELECT_REFLECTION_ACTIVITY_QUESTION(AvailableQuestionIndexes());
            Console.WriteLine("\n" + question + "\n");
            DISPLAY_COUNTER(5, 1000);
            PREPARE_FOR_START(3, _SPINNER_TIME);
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(_duration);
            int timeRemain = _duration;
            int messageTime = 10;
            if (_duration > messageTime * _MESSAGES.Count) messageTime = _duration / _MESSAGES.Count;
            String message;
            while (done.CompareTo(DateTime.Now) > 0)
            {
                message = SELECT_REFLECTION_ACTIVITY_MESSAGE(AvailableMessageIndexesPerQuestionIndexes(question));
                Console.WriteLine("\n" + message + "\n");
                if (timeRemain < (messageTime * 2))
                {
                    DISPLAY_COUNTER(timeRemain, 1000);
                    timeRemain -= timeRemain;
                }
                else
                {
                    DISPLAY_COUNTER(messageTime, 1000);
                    timeRemain -= messageTime;
                }
                ReportMessageUsage(_duration, question, message);
            }
            Console.WriteLine(_FINISHING_MESSAGE);
            DISPLAY_COUNTER(8, 100, false);
            ReportQuestionUsage(_duration, question);
        }
        public String GetJSONInfo()
        {
            int counter = 0;
            int subCounter = 0;
            String questionsTimesUsedString = "\t\"questionsTimesUsed\" : [";
            _questionsTimesUsed.ForEach((count) => {
                if (counter == 0) questionsTimesUsedString += count.ToString() + ",\n";
                else if (counter < _questionsTimesUsed.Count-1) questionsTimesUsedString += "\t\t"+count.ToString() + ",\n";
                else questionsTimesUsedString += "\t\t"+count.ToString() + "],\n";
                counter++;
            });
            counter = 0;
            String messagesTimesUsedString = "\t\"messagesTimesUsed\" : [[";
            _messagesTimesUsed.ForEach((list) => {
                subCounter = 0;
                list.ForEach((count) => {
                    if (subCounter ==0 ) messagesTimesUsedString += count.ToString() + ",\n";
                    else if (subCounter < _messagesTimesUsed[counter].Count - 1) messagesTimesUsedString += "\t\t"+count.ToString() + ",\n";
                    else messagesTimesUsedString += "\t\t"+count.ToString() + "]";
                    subCounter++;
                });
                if (counter < _messagesTimesUsed.Count - 1) messagesTimesUsedString += ",[";
                else messagesTimesUsedString += "],\n";
                counter++;
            });
            counter = 0;
            String questionsLastUsedString = "\t\"questionsLastUsed\" : [";
            _questionsLastUsed.ForEach((count) => {
                if (counter ==0) questionsLastUsedString += "\""+count.ToString() + "\",\n";
                else if (counter < _questionsLastUsed.Count-1) questionsLastUsedString += "\t\t\""+ count.ToString() + "\",\n";
                else questionsLastUsedString += "\t\t\""+ count.ToString() + "\"],\n";
                counter++;
            });
            counter = 0;
            String messagesLastUsedString = "\t\"messagesLastUsed\" : [[";
            _messagesLastUsed.ForEach((list) => {
                subCounter = 0;
                list.ForEach((dateTime) => {
                    if (subCounter ==0) messagesLastUsedString += "\""+ dateTime.ToString() + "\",\n";
                    else if (subCounter < _messagesLastUsed[counter].Count - 1) messagesLastUsedString += "\t\t\""+dateTime.ToString() + "\",\n";
                    else messagesLastUsedString += "\t\t\""+dateTime.ToString() + "\"]";
                    subCounter++;
                });
                if (counter < _messagesLastUsed.Count - 1) messagesLastUsedString += ",[";
                else messagesLastUsedString += "]";
                counter++;
            });
            return $"{questionsTimesUsedString}{messagesTimesUsedString}{questionsLastUsedString}{messagesLastUsedString}";
        }
        public void ParseQuestionsTimesUsed(String questionsTimesUsedString)
        {
            if (questionsTimesUsedString.StartsWith("[")) questionsTimesUsedString = questionsTimesUsedString.Substring(1);
            if (questionsTimesUsedString.EndsWith("]")) questionsTimesUsedString = questionsTimesUsedString.Substring(0, questionsTimesUsedString.Length - 1);
            string[] allParts = questionsTimesUsedString.Split(",\n\t");
            int counter = 0;
            _questionsTimesUsed ??= new();
            if (_questionsTimesUsed.Count == 0) foreach(String question in _QUESTIONS) _questionsTimesUsed.Add(0);
            foreach (String part in allParts)
            {
                _questionsTimesUsed[counter] = int.Parse(part);
                counter++;
            }
        }
        public void ParseQuestionsLastUsed(String questionsLastUsedString)
        {
            if (questionsLastUsedString.StartsWith("[")) questionsLastUsedString = questionsLastUsedString.Substring(1);
            if (questionsLastUsedString.EndsWith("]")) questionsLastUsedString = questionsLastUsedString.Substring(0, questionsLastUsedString.Length - 1);
            string[] allParts = questionsLastUsedString.Split(",\n\t");
            int counter = 0;
            _questionsLastUsed ??= new();
            if (_questionsLastUsed.Count == 0) foreach (String question in _QUESTIONS) _questionsLastUsed.Add(DateTime.MinValue);
            String dateString;
            foreach (String part in allParts)
            {
                dateString = part;
                if (dateString.StartsWith("\"")) dateString = dateString.Substring(1);
                if (dateString.EndsWith("\"")) dateString = dateString.Substring(0, dateString.Length - 1);
                _questionsLastUsed[counter] = DateTime.Parse(dateString);
                counter++;
            }
        }
        public void ParseMessagesTimesUsed(String messagesTimesUsedString)
        {
            if (messagesTimesUsedString.StartsWith("[[")) messagesTimesUsedString = messagesTimesUsedString.Substring(2);
            if (messagesTimesUsedString.EndsWith("]]")) messagesTimesUsedString = messagesTimesUsedString.Substring(0, messagesTimesUsedString.Length - 2);
            string[] messagesString;
            string[] questionsString = messagesTimesUsedString.Split("],[");
            int counter, subCounter;
            _messagesTimesUsed ??= new();
            if (_messagesTimesUsed.Count == 0)
            {
                counter = 0;
                foreach (String question in _QUESTIONS)
                {
                    _messagesTimesUsed.Insert(counter, new());
                    if (_messagesTimesUsed[counter].Count == 0) foreach(String message in _MESSAGES) _messagesTimesUsed[counter].Add(0);
                    counter++;
                }
            }
            counter = 0;
            foreach (String message in questionsString)
            {
                messagesString = message.Split(",\n\t");
                subCounter = 0;
                foreach (String value in messagesString)
                {
                    _messagesTimesUsed[counter][subCounter] = int.Parse(value);
                    subCounter++;
                }
                counter++;
            }
        }
        public void ParseMessagesLastUsed(String messagesTimesLastString)
        {
            if (messagesTimesLastString.StartsWith("[[")) messagesTimesLastString = messagesTimesLastString.Substring(2);
            if (messagesTimesLastString.EndsWith("\n")) messagesTimesLastString = messagesTimesLastString.Substring(0, messagesTimesLastString.Length - 1);
            if (messagesTimesLastString.EndsWith("]]")) messagesTimesLastString = messagesTimesLastString.Substring(0, messagesTimesLastString.Length - 2);
            string[] messagesString;
            string[] questionsString = messagesTimesLastString.Split("],[");
            int counter, subCounter;
            _messagesLastUsed ??= new();
            if (_messagesLastUsed.Count == 0)
            {
                counter = 0;
                foreach (String question in _QUESTIONS)
                {
                    _messagesLastUsed.Insert(counter, new());
                    if (_messagesLastUsed[counter].Count == 0) foreach (String message in _MESSAGES) _messagesLastUsed[counter].Add(DateTime.MinValue);
                    counter++;
                }
            }
            counter = 0;
            foreach (String message in questionsString)
            {
                messagesString = message.Split(",\n\t");
                subCounter = 0;
                String dateString;
                foreach (String value in messagesString)
                {
                    dateString = value;
                    if (dateString.StartsWith("\"")) dateString = dateString.Substring(1);
                    if (dateString.EndsWith("\"")) dateString = dateString.Substring(0, dateString.Length - 1);
                    _messagesLastUsed[counter][subCounter] = DateTime.Parse(dateString);
                    subCounter++;
                }
                counter++;
            }
        }
    }
}
