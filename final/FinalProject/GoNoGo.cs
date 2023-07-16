namespace FinalProject
{
    public class GoNoGo : Benchmark
    {
        protected String BackOutPlanStartStepOnNoGo { get; set; }
        public GoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public GoNoGo()
        {
            Init();
        }
        public GoNoGo(GoNoGo task)
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
        private void Init(GoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
    }
}