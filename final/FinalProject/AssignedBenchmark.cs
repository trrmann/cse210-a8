namespace FinalProject
{
    public class AssignedBenchmark : AssignedTask
    {
        protected Benchmark Benchmark { get; set; }
        public AssignedBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedBenchmark()
        {
            Init();
        }
        public AssignedBenchmark(AssignedBenchmark task)
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
        private void Init(AssignedBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}