namespace MindfullnessProgram
{
    public class ListingActivity : Activity
    {
        private int _spinnerTime = 0;
        private static int _maxQuestionUseSpread;
        private static List<String> questions;
        private List<int> questionsTimesUsed;
        private List<DateTime> questionsLastUsed;

        public ListingActivity(int defaultDuration) : base("ListingActivity", "Listing Activity", "to do", "to do", "to do", 20, 600)
        {
            Init(defaultDuration);
        }

        public ListingActivity() : base("ListingActivity", "Listing Activity", "to do", "to do", "to do", 20, 600)
        {
            Init();
        }

        protected void Init(int defaultDuration, Boolean callBaseInit = false)
        {
            if (callBaseInit) Init("ListingActivity", "Listing Activity", "to do", "to do", "to do", 20, 600);
            _defaultDuration = defaultDuration;
        }
        protected void Init(Boolean callBaseInit = false)
        {
            if (callBaseInit) base.Init();
            Init(20);
        }
        public void RunListingActivity(int? duration = null) {
            duration ??= _defaultDuration;
            Activity.DisplaySpinner(_spinnerTime);
            ReportUsage((int)duration);
        }
        public void ResetQuestionUsageData() { }

        protected static String SelectListingActivityQuestion() { return ""; }
        protected List<int> AvailableQuestionIndexi() { return new List<int>(); }
    }
}
