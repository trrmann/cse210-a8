namespace FinalProject
{
    public class Benchmark : Task
    {
        protected List<String> ReportToPeople { get; set; }
        protected List<String> ReportToTeams { get; set; }
        public Benchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public Benchmark()
        {
            Init();
        }
        public Benchmark(Benchmark task)
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
        private void Init(Benchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}