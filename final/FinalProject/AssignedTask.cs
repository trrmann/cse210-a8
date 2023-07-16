namespace FinalProject
{
    public class AssignedTask : ScheduledTask
    {
        protected String AssignmentOwnerName { get; set; }
        protected Boolean AssignmentNameIsTeam { get; set; }
        public AssignedTask(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedTask()
        {
            Init();
        }
        public AssignedTask(AssignedTask task)
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
        private void Init(AssignedTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}