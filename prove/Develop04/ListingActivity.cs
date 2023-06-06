﻿namespace MindfullnessProgram
{
    public class ListingActivity : Activity
    {
        private static readonly String _ACTIVITY_NAME = "ListingActivity";
        private static readonly String _ACTIVITY_MENU_DESCRIPTION = "Listing Activity";
        private static readonly String _STARTING_MESSAGE = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        private static readonly List<String> _QUESTIONS = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        private static readonly int _SPINNER_TIME = 10;
        private static readonly int _DEFAULT_DURATION = 30;
        private static readonly int _PAUSE_TIME = 500;
        private static readonly int _MAX_QUESTIONS_USE_SPREAD = 1;
        private static readonly int _MIN_DAYS_QUESTIONS_USE_SPREAD = 1;
        private static readonly Random _RANDOM = new();
        private List<int> questionsTimesUsed;
        private List<DateTime> questionsLastUsed;
        private static String SELECT_LISTING_ACTIVITY_QUESTION(List<int> availableIndexes)
        {
            int index = _RANDOM.Next(0, availableIndexes.Count);
            return _QUESTIONS[availableIndexes[index]];
        }
        /**
         *  made private and commented out because not used.
        private ListingActivity(int defaultDuration) : base(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME)
        {
            Init(defaultDuration);
        }
         */
        private void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME);
            _defaultDuration = defaultDuration;
            ResetQuestionUsageData();
        }
        private void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(_DEFAULT_DURATION);
        }
        private void ResetQuestionUsageData()
        {
            questionsTimesUsed = new() { 0, 0, 0, 0, 0 };
            questionsLastUsed = new() {
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue
            };
            ResetActivityUsageData();
        }
        private List<int> AvailableQuestionIndexes()
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
            _QUESTIONS.ForEach((question) => {
                Boolean available = true;
                int index = _QUESTIONS.IndexOf(question);
                int timesUsedSpread = questionsTimesUsed[index] - minCount;
                int lastUsedSpread = (questionsLastUsed[index] - minLastUsed).Days;
                if (timesUsedSpread >= _MAX_QUESTIONS_USE_SPREAD) available = false;
                if (questionsLastUsed[index] > DateTime.MinValue && lastUsedSpread <= _MIN_DAYS_QUESTIONS_USE_SPREAD) available = false;
                if (available) result.Add(index);
            });
            if (result.Count == 0)
            {
                _QUESTIONS.ForEach((question) => {
                    Boolean available = true;
                    int index = _QUESTIONS.IndexOf(question);
                    int timesUsedSpread = questionsTimesUsed[index] - minCount;
                    int lastUsedSpread = (questionsLastUsed[index] - minLastUsed).Days;
                    if (timesUsedSpread > _MAX_QUESTIONS_USE_SPREAD) available = false;
                    if (available) result.Add(index);
                });
            }
            return result;
        }
        private void ReportUsage(int duration, String question, DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now;
            int index = _QUESTIONS.IndexOf(question);
            questionsTimesUsed[index]++;
            questionsLastUsed[index] = (DateTime)dateTime;
            ReportUsage(duration, dateTime);
        }
        public ListingActivity() : base(_ACTIVITY_NAME, _ACTIVITY_MENU_DESCRIPTION, _STARTING_MESSAGE, _DEFAULT_DURATION, _PAUSE_TIME)
        {
            Init();
        }
        public void RunListingActivity()
        {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            String question = SELECT_LISTING_ACTIVITY_QUESTION(AvailableQuestionIndexes());
            Console.WriteLine("\n" + question + "\n");
            DISPLAY_COUNTER(5, 1000);
            PREPARE_FOR_START(2, _SPINNER_TIME);
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(_duration);
            int counter = 0;
            while (done.CompareTo(DateTime.Now) > 0)
            {
                String response = Console.ReadLine();
                if (response != "") counter++;
            }
            Console.WriteLine($"You entered {counter} items.");
            Activity.DISPLAY_SPINNER(3, _SPINNER_TIME);
            Console.WriteLine(_FINISHING_MESSAGE);
            ReportUsage(_duration, question);
        }
        public String GetJSONInfo()
        {
            int counter = 0;
            String questionsTimesUsedString = "_questionsTimesUsed : [";
            questionsTimesUsed.ForEach((count) => {
                if(counter<questionsTimesUsed.Count-1) questionsTimesUsedString += count.ToString() + " , ";
                else questionsTimesUsedString += count.ToString() + "] , ";
                counter++;
            });
            counter = 0;
            String questionsLastUsedString = "_questionsLastUsed : [";
            questionsLastUsed.ForEach((count) => {
                if (counter < questionsTimesUsed.Count-1) questionsLastUsedString += count.ToString() + " , ";
                else questionsLastUsedString += count.ToString() + "]";
                counter++;
            });
            return $"{questionsTimesUsedString}{questionsLastUsedString}";
        }
        public void ParseQuestionsTimesUsed(String questionsTimesUsedString)
        {
            if (questionsTimesUsedString.StartsWith("["))
            {
                questionsTimesUsedString = questionsTimesUsedString.Substring(1);
            }
            if (questionsTimesUsedString.EndsWith("]"))
            {
                questionsTimesUsedString = questionsTimesUsedString.Substring(0, questionsTimesUsedString.Length - 1);
            }
            string[] allParts = questionsTimesUsedString.Split(" , ");
            int counter = 0;
            questionsTimesUsed ??= new();
            if (questionsTimesUsed.Count == 0)
            {
                foreach (String question in _QUESTIONS)
                {
                    questionsTimesUsed.Add(0);
                }
            }
            foreach (String part in allParts)
            {
                questionsTimesUsed[counter] = int.Parse(part);
                counter++;
            }
        }
        public void ParseQuestionsLastUsed(String questionsLastUsedString)
        {
            if (questionsLastUsedString.StartsWith("["))
            {
                questionsLastUsedString = questionsLastUsedString.Substring(1);
            }
            if (questionsLastUsedString.EndsWith("]"))
            {
                questionsLastUsedString = questionsLastUsedString.Substring(0, questionsLastUsedString.Length - 1);
            }
            string[] allParts = questionsLastUsedString.Split(" , ");
            int counter = 0;
            questionsLastUsed ??= new();
            if (questionsLastUsed.Count == 0)
            {
                foreach (String question in _QUESTIONS)
                {
                    questionsLastUsed.Add(DateTime.MinValue);
                }
            }
            foreach (String part in allParts)
            {
                questionsLastUsed[counter] = DateTime.Parse(part);
                counter++;
            }
        }
    }
}
