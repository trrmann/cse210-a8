namespace Develop04
{
    public class Application
    {
        private Boolean _isRunning;
        private List<Activity> _activities;
        private Activity _current;

        public Application() { }

        private Boolean IsRunning() { return _isRunning; }

        public void Run() { }
        private String ReadResponse() { return Console.ReadLine(); }
        private Boolean EvaluateResponse(Activity activity, String response) {
            return false;
        }
        private void Exit() { }
    }
}
