namespace FinalProject
{
    public class ImplementedBenchmark : ImplementedTask
    {
        protected Benchmark Benchmark { get; set; }
        public ImplementedBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ImplementedBenchmark()
        {
            Init();
        }
        public ImplementedBenchmark(ImplementedBenchmark task)
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
        private void Init(ImplementedBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}