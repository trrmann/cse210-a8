namespace MindfullnessProgram
{
    public class ListingActivity : Activity
    {
        private static int _maxQuestionUseSpread;
        private static List<String> questions;
        private List<int> questionsTimesUsed;
        private List<DateTime> questionsLastUsed;

        public ListingActivity(int defaultDuration) { }

        public ListingActivity()
        {
        }

        public void RunListingActivity(int? duration = null) { }

        protected static String SelectListingActivityQuestion() { return ""; }
        protected List<int> AvailableQuestionIndexi() { return new List<int>(); }
    }
}
