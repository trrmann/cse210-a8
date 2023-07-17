namespace FinalProject
{
    public class ScheduledGoNoGo : ScheduledBenchmark
    {
        protected GoNoGo GoNoGo { get; set; }
        public ScheduledGoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ScheduledGoNoGo()
        {
            Init();
        }
        public ScheduledGoNoGo(ScheduledGoNoGo task)
        {
            Init(task);
        }
        protected override void DisplayRequestNameMessage()
        {
            Console.WriteLine("\nPlease enter the task name.");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine("\nPlease enter the task description.");
        }
        /*TODO Init*/
        /**
        protected override void Init(String taskName, String taskDescription, Boolean empty = true)
        {
            switch (taskName)
            {
                case "":
                    Init();
                    break;
                default:
                    Name = taskName;
                    Description = taskDescription;
                    break;
            }
        }
        /**/
        private void Init(ScheduledGoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}