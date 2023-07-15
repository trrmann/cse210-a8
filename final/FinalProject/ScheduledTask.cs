namespace FinalProject
{
    public class ScheduledTask : TemplateTask
    {
        protected DateTime ScheduledStart { get; set; }
        public ScheduledTask(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public ScheduledTask(Boolean empty = true)
        {
            Init(empty);
        }
        public ScheduledTask(ScheduledTask task)
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
        private void Init(ScheduledTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override ScheduledTask CreateCopy(String newName)
        {
        ScheduledTask result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}