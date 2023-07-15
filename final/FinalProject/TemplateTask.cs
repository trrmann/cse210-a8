namespace FinalProject
{
    public class TemplateTask : Task
    {
        public TemplateTask(String taskName, String taskDescription)
        {
            Init(taskName, taskDescription);
        }
        public TemplateTask(Boolean empty = true)
        {
            Init(empty);
        }
        public TemplateTask(TemplateTask task)
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
        private void Init(TemplateTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override TemplateTask CreateCopy(String newName)
        {
            TemplateTask result = new(this);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}