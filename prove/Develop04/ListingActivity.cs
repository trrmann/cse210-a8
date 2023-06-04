namespace MindfullnessProgram
{
    public class ListingActivity : Activity
    {
        private static readonly String _listingName = "ListingActivity";
        private static readonly String _listingMenuDescription = "Listing Activity";
        private static readonly String _listingStartingMessage = "to do.";
        private static readonly int _listingDefaultDuration = 30;
        private static readonly int _listingPauseTime = 500;
        private int _spinnerTime = 6;
        private static int _maxQuestionUseSpread;
        private static List<String> questions;
        private List<int> questionsTimesUsed;
        private List<DateTime> questionsLastUsed;

        public ListingActivity(int defaultDuration) : base(_listingName, _listingMenuDescription, _listingStartingMessage, _listingDefaultDuration, _listingPauseTime)
        {
            Init(defaultDuration);
        }

        public ListingActivity() : base(_listingName, _listingMenuDescription, _listingStartingMessage, _listingDefaultDuration, _listingPauseTime)
        {
            Init();
        }

        protected void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init(_listingName, _listingMenuDescription, _listingStartingMessage, _listingDefaultDuration, _listingPauseTime);
            _defaultDuration = defaultDuration;
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunListingActivity() {
            Console.WriteLine(_startingMessage);
            PromptForDuration();
            PrepareForStart(2, _spinnerTime);
            DisplayCounter(_duration, 500, true, false, false);
            Activity.DisplaySpinner(3, _spinnerTime);
            DisplayCounter(_duration, 1000, true, true, false);
            Console.WriteLine(_finishingMessage);
            ReportUsage(_duration);
        }
        public void ResetQuestionUsageData() { }

        protected static String SelectListingActivityQuestion() { return ""; }
        protected List<int> AvailableQuestionIndexi() { return new List<int>(); }
    }
}
