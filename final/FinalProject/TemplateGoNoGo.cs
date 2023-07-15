namespace FinalProject
{
    public class TemplateGoNoGo : TemplateTask
    {
        protected GoNoGo GoNoGo { get; set; }
        public TemplateGoNoGo(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public TemplateGoNoGo(Boolean empty = true)
        {
            Init(empty);
        }
        public TemplateGoNoGo(TemplateGoNoGo task)
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
        private void Init(TemplateGoNoGo task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override TemplateGoNoGo CreateCopy(String newName)
        {
        TemplateGoNoGo result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}