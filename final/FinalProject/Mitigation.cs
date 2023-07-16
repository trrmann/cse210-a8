namespace FinalProject
{
    public class Mitigation : Task
    {
        protected String RiskName { get; set; }
        public Mitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public Mitigation()
        {
            Init();
        }
        public Mitigation(Mitigation task)
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
        private void Init(Mitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}