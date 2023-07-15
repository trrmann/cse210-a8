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
        public Benchmark(Boolean empty = true)
        {
            Init(empty);
        }
        public Benchmark(Benchmark task)
        {
            Init(task);
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the task name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the task description.");
        }
        protected override void Init(String taskName, String taskDescription, Boolean empty = true)
        {
            switch (taskName)
            {
                case "":
                    Init(false);
                    break;
                default:
                    Name = new ThingName(taskName);
                    Description = taskDescription;
                    break;
            }
        }
        private void Init(Benchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override Benchmark CreateCopy(String newName)
        {
            Benchmark result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}