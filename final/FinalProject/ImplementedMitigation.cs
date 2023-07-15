namespace FinalProject
{
    public class ImplementedMitigation : ImplementedTask
    {
        protected Mitigation Mitigation { get; set; }
        public ImplementedMitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ImplementedMitigation(Boolean empty = true)
        {
            Init(empty);
        }
        public ImplementedMitigation(ImplementedMitigation task)
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
        private void Init(ImplementedMitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override ImplementedMitigation CreateCopy(String newName)
        {
            ImplementedMitigation result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}