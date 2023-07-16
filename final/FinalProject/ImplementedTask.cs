namespace FinalProject
{
    public class ImplementedTask : AssignedTask
    {
        protected String CurrentStatus { get; set; }
        protected DateTime StatusUpdateTime { get; set; }
        protected DateTime ActualStartTime { get; set; }
        protected DateTime ActualCompleteTime { get; set; }
        public ImplementedTask(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ImplementedTask()
        {
            Init();
        }
        public ImplementedTask(ImplementedTask task)
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
        private void Init(ImplementedTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}