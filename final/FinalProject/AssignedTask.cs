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
        public AssignedTask(Boolean empty = true)
        {
            Init(empty);
        }
        public AssignedTask(AssignedTask task)
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
        private void Init(AssignedTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override AssignedTask CreateCopy(String newName)
        {
            AssignedTask result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}