namespace FinalProject
{
    public class TemplateMitigation : TemplateTask
    {
        protected Mitigation Mitigation { get; set; }
        public TemplateMitigation(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public TemplateMitigation(Boolean empty = true)
        {
            Init(empty);
        }
        public TemplateMitigation(TemplateMitigation task)
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
        private void Init(TemplateMitigation task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override TemplateMitigation CreateCopy(String newName)
        {
        TemplateMitigation result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}