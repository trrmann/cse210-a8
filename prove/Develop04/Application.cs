namespace MindfullnessProgram
{
    public class Application
    {
        private Boolean _isRunning;
        private List<Activity> _activities;
        private Activity? _current;
        public Application() {
            _isRunning = false;
            _current = null;
            _activities = Activity.DefineActivities();
        }
        private Boolean IsRunning() { return _isRunning; }
        public void Run() {
            _isRunning = true;
            while(IsRunning())
            {
                List<Activity> activities = Activity.AvailableActivities(_activities);
                List<Activity> menuListIndex = new();
                int menuIndex = 0;
                foreach (Activity activity in activities)
                {
                    menuListIndex.Insert(menuIndex, activity);
                    activity.DisplayMenuLine(menuIndex + 1, ")  ");
                    menuIndex++;
                }
                Console.WriteLine($"{menuIndex + 1})  Exit.");
                Console.Write(">  ");
                _isRunning = EvaluateResponse(menuListIndex, ReadResponse());
            }
            Exit();
        }
        private static String ReadResponse() { return Console.ReadLine(); }
        private Boolean EvaluateResponse(List<Activity> activities, String response) {
            try
            {
                int optionSelected = int.Parse(response);
                if (optionSelected > 0 && optionSelected <= activities.Count) {
                    _current = activities[optionSelected - 1];
                    if (_current.GetType()==typeof(BreathingActivity)) ((BreathingActivity)_current).RunBreathingActivity();
                    else if (_current.GetType() == typeof(ReflectionActivity)) ((ReflectionActivity)_current).RunReflectionActivity();
                    else if (_current.GetType() == typeof(ListingActivity)) ((ListingActivity)_current).RunListingActivity();
                    return true;
                }
                else if(optionSelected == activities.Count+1) return false;
                else return true;
                }
            catch (FormatException)
            {
                return true;
            }
        }
        private void Exit() {
            _isRunning = false;
            _current = null;
        }
    }
}