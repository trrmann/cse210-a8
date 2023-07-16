namespace FinalProject
{
    public class ImplementedMitigation : ImplementedTask
    {
        protected Mitigation Mitigation { get; set; }
        public ImplementedMitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ImplementedMitigation()
        {
            Init();
        }
        public ImplementedMitigation(ImplementedMitigation task)
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
        private void Init(ImplementedMitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}