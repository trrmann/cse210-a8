namespace FinalProject
{
    public class AssignedGoNoGo : AssignedBenchmark
    {
        protected GoNoGo GoNoGo { get; set; }
        public AssignedGoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedGoNoGo()
        {
            Init();
        }
        public AssignedGoNoGo(AssignedGoNoGo task)
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
        private void Init(AssignedGoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}