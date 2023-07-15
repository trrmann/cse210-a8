namespace FinalProject
{
    public class GoNoGo : Benchmark
    {
        protected String BackOutPlanStartStepOnNoGo { get; set; }
        public GoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public GoNoGo(Boolean empty = true)
        {
            Init(empty);
        }
        public GoNoGo(GoNoGo task)
        {
            Init(task);
        }
        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the task name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the task description.");
        }
        protected override void Init(String taskName, String taskDescription, Boolean empty = true)
        {
            switch (taskName)
            {
                case "":
                    Init(false);
                    break;
                default:
                    Name = new ThingName(taskName);
                    Description = taskDescription;
                    break;
            }
        }
        private void Init(GoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override GoNoGo CreateCopy(String newName)
        {
            GoNoGo result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}