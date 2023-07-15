namespace FinalProject
{
    public class AssignedMitigation : AssignedTask
    {
        protected Mitigation Mitigation { get; set; }
        public AssignedMitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public AssignedMitigation(Boolean empty = true)
        {
            Init(empty);
        }
        public AssignedMitigation(AssignedMitigation task)
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
        private void Init(AssignedMitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override AssignedMitigation CreateCopy(String newName)
        {
        AssignedMitigation result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}