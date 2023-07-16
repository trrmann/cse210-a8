namespace FinalProject
{
    public class TemplateGoNoGo : TemplateTask
    {
        protected GoNoGo GoNoGo { get; set; }
        public TemplateGoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public TemplateGoNoGo()
        {
            Init();
        }
        public TemplateGoNoGo(TemplateGoNoGo task)
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
        private void Init(TemplateGoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}