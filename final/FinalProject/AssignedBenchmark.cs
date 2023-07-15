namespace FinalProject
{
    public class AssignedBenchmark : AssignedTask
    {
        protected Benchmark Benchmark { get; set; }
        public AssignedBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedBenchmark(Boolean empty = true)
        {
            Init(empty);
        }
        public AssignedBenchmark(AssignedBenchmark task)
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
        private void Init(AssignedBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override AssignedBenchmark CreateCopy(String newName)
        {
            AssignedBenchmark result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}