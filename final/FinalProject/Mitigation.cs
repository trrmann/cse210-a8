namespace FinalProject
{
    public class Mitigation : Task
    {
        protected String RiskName { get; set; }
        public Mitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public Mitigation(Boolean empty = true)
        {
            Init(empty);
        }
        public Mitigation(Mitigation task)
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
        private void Init(Mitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override Mitigation CreateCopy(String newName)
        {
            Mitigation result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}