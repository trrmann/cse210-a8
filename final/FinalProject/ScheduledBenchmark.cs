namespace FinalProject
{
    public class ScheduledBenchmark : ScheduledTask
    {
        protected Benchmark Benchmark { get; set; }
        public ScheduledBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ScheduledBenchmark()
        {
            Init();
        }
        public ScheduledBenchmark(ScheduledBenchmark task)
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
        private void Init(ScheduledBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}