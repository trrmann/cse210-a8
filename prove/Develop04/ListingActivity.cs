namespace MindfullnessProgram
{
    public class ListingActivity : Activity
    {
        private static readonly String _listingName = "ListingActivity";
        private static readonly String _listingMenuDescription = "Listing Activity";
        private static readonly String _listingStartingMessage = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        private static readonly List<String> questions = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        private static readonly int _spinnerTime = 10;
        private static readonly int _listingDefaultDuration = 30;
        private static readonly int _listingPauseTime = 500;
        private static readonly int _maxQuestionUseSpread = 1;
        private static readonly int _minDaysQuestionUseSpread = 1;
        private List<int> questionsTimesUsed;
        private List<DateTime> questionsLastUsed;
        private static String SelectListingActivityQuestion(List<int> availableIndexes)
        {
            Random random = new();
            int index = random.Next(0, availableIndexes.Count);
            return questions[availableIndexes[index]];
        }
        private void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init(_listingName, _listingMenuDescription, _listingStartingMessage, _listingDefaultDuration, _listingPauseTime);
            _defaultDuration = defaultDuration;
            ResetQuestionUsageData();
        }
        private void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(_listingDefaultDuration);
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
        private void ReportUsage(int duration, String question, DateTime? dateTime = null)
        {
            dateTime ??= DateTime.Now;
            int index = questions.IndexOf(question);
            questionsTimesUsed[index]++;
            questionsLastUsed[index] = (DateTime)dateTime;
            ReportUsage(duration, dateTime);
        }
        public ListingActivity(int defaultDuration) : base(_listingName, _listingMenuDescription, _listingStartingMessage, _listingDefaultDuration, _listingPauseTime)
        {
            Init(defaultDuration);
        }
        public ListingActivity() : base(_listingName, _listingMenuDescription, _listingStartingMessage, _listingDefaultDuration, _listingPauseTime)
        {
            Init();
        }
        public void RunListingActivity()
        {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            String question = SelectListingActivityQuestion(AvailableQuestionIndexes());
            Console.WriteLine("\n" + question + "\n");
            DisplayCounter(5, 1000);
            PrepareForStart(2, _spinnerTime);
            DateTime dateTime = DateTime.Now;
            DateTime done = dateTime.AddSeconds(_duration);
            int counter = 0;
            while (done.CompareTo(DateTime.Now) > 0)
            {
                String response = Console.ReadLine();
                if (response != "") counter++;
            }
            Console.WriteLine($"You entered {counter} items.");
            Activity.DisplaySpinner(3, _spinnerTime);
            Console.WriteLine(_finishingMessage);
            ReportUsage(_duration, question);
        }
        public String GetJSONInfo()
        {
            int counter = 0;
            String questionsTimesUsedString = "questionsTimesUsed : [";
            questionsTimesUsed.ForEach((count) => {
                if(counter<questionsTimesUsed.Count-1) questionsTimesUsedString += count.ToString() + " , ";
                else questionsTimesUsedString += count.ToString() + "] , ";
                counter++;
            });
            counter = 0;
            String questionsLastUsedString = "questionsLastUsed : [";
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
                foreach (String question in questions)
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
                foreach (String question in questions)
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
