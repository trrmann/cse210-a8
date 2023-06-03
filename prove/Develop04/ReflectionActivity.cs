namespace Develop04
{
    public class ReflectionActivity : Activity
    {
        private static int _maxQuestionUseSpread;
        private static int _maxMessageUseSpread;
        private static List<String> questions;
        private static List<String> messages;
        private List<int> questionsTimesUsed;
        private List<List<int>> messagesTimesUsed;
        private List<DateTime> questionsLastUsed;
        private List<List<DateTime>> messagesLastUsed;

        public ReflectionActivity(int defaultDuration) { }

        public void RunReflectionActivity(int? duration = null) { }

        protected static String SelectReflectionActivityQuestion() { return ""; }
        public void ResetQuestionUsageData() { }
        protected List<int> AvailableQuestionIndexes() { return new List<int>(); }
        protected List<List<int>> AvailableMessageIndexesPerQuestionIndexes(List<int> QuestionIndexes) { return new List<List<int>>(); }
    }
}
