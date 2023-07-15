namespace FinalProject
{
    public class AssignedGoNoGo : AssignedTask
    {
        protected GoNoGo GoNoGo { get; set; }
        public AssignedGoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedGoNoGo(Boolean empty = true)
        {
            Init(empty);
        }
        public AssignedGoNoGo(AssignedGoNoGo task)
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
        private void Init(AssignedGoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override AssignedGoNoGo CreateCopy(String newName)
        {
            AssignedGoNoGo result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}