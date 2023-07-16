namespace FinalProject
{
    public class ScheduledTask : TemplateTask
    {
        protected DateTime ScheduledStart { get; set; }
        public ScheduledTask(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ScheduledTask()
        {
            Init();
        }
        public ScheduledTask(ScheduledTask task)
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
        private void Init(ScheduledTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}