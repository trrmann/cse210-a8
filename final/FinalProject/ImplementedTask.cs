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
        public ImplementedTask(Boolean empty = true)
        {
            Init(empty);
        }
        public ImplementedTask(ImplementedTask task)
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
        private void Init(ImplementedTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override ImplementedTask CreateCopy(String newName)
        {
            ImplementedTask result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}