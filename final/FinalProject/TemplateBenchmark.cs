namespace FinalProject
{
    public class TemplateBenchmark : TemplateTask
    {
        protected Benchmark Benchmark { get; set; }
        public TemplateBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public TemplateBenchmark(Boolean empty = true)
        {
            Init(empty);
        }
        public TemplateBenchmark(TemplateBenchmark task)
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
        private void Init(TemplateBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override TemplateBenchmark CreateCopy(String newName)
        {
        TemplateBenchmark result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}