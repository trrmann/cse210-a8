namespace FinalProject
{
    public class AssignedMitigation : AssignedTask
    {
        protected Mitigation Mitigation { get; set; }
        public AssignedMitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedMitigation()
        {
            Init();
        }
        public AssignedMitigation(AssignedMitigation task)
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
        private void Init(AssignedMitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}