namespace FinalProject
{
    public class TemplateBenchmark : TemplateTask
    {
        protected Benchmark Benchmark { get; set; }
        public TemplateBenchmark(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public TemplateBenchmark()
        {
            Init();
        }
        public TemplateBenchmark(TemplateBenchmark task)
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
        private void Init(TemplateBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}