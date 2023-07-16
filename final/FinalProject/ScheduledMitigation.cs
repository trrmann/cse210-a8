namespace FinalProject
{
    public class ScheduledMitigation : ScheduledTask
    {
        protected Mitigation Mitigation { get; set; }
        public ScheduledMitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ScheduledMitigation()
        {
            Init();
        }
        public ScheduledMitigation(ScheduledMitigation task)
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
        private void Init(ScheduledMitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}