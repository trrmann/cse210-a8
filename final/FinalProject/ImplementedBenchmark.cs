namespace FinalProject
{
    public class ImplementedBenchmark : ImplementedTask
    {
        protected Benchmark Benchmark { get; set; }
        public ImplementedBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ImplementedBenchmark(Boolean empty = true)
        {
            Init(empty);
        }
        public ImplementedBenchmark(ImplementedBenchmark task)
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
        private void Init(ImplementedBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override ImplementedBenchmark CreateCopy(String newName)
        {
            ImplementedBenchmark result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}