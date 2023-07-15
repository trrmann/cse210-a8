namespace FinalProject
{
    public abstract class Task : DescribedObject
    {
        public static Task CreateTask(TaskType type, TaskState state, Boolean empty=true)
        {
            switch (type)
            {
                case TaskType.Task:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateTask(empty);
                        case TaskState.Scheduled:
                            return new ScheduledTask(empty);
                        case TaskState.Assigned:
                            return new AssignedTask(empty);
                        case TaskState.Implemented:
                            return new ImplementedTask(empty);
                        default:
                            return new TemplateTask(empty);
                    }
                case TaskType.Benchmark:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateBenchmark(empty);
                        case TaskState.Scheduled:
                            return new ScheduledBenchmark(empty);
                        case TaskState.Assigned:
                            return new AssignedBenchmark(empty);
                        case TaskState.Implemented:
                            return new ImplementedBenchmark(empty);
                        default:
                            return new TemplateBenchmark(empty);
                    }
                case TaskType.GoNoGo:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateGoNoGo(empty);
                        case TaskState.Scheduled:
                            return new ScheduledGoNoGo(empty);
                        case TaskState.Assigned:
                            return new AssignedGoNoGo(empty);
                        case TaskState.Implemented:
                            return new ImplementedGoNoGo(empty);
                        default:
                            return new TemplateGoNoGo(empty);
                    }
                case TaskType.Mitigation:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateMitigation(empty);
                        case TaskState.Scheduled:
                            return new ScheduledMitigation(empty);
                        case TaskState.Assigned:
                            return new AssignedMitigation(empty);
                        case TaskState.Implemented:
                            return new ImplementedMitigation(empty);
                        default:
                            return new TemplateMitigation(empty);
                    }
                default:
                    return new TemplateTask(empty);
            }
        }

        internal static Task CreateTask(TaskType type, TaskState state, String taskName, String taskDescription)
        {
            switch (type)
            {
                case TaskType.Task:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateTask(taskName, taskDescription);
                        case TaskState.Scheduled:
                            return new ScheduledTask(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedTask(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedTask(taskName, taskDescription);
                        default:
                            return new TemplateTask(taskName, taskDescription);
                    }
                case TaskType.Benchmark:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateBenchmark(taskName, taskDescription);
                        case TaskState.Scheduled:
                            return new ScheduledBenchmark(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedBenchmark(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedBenchmark(taskName, taskDescription);
                        default:
                            return new TemplateBenchmark(taskName, taskDescription);
                    }
                case TaskType.GoNoGo:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateGoNoGo(taskName, taskDescription);
                        case TaskState.Scheduled:
                            return new ScheduledGoNoGo(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedGoNoGo(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedGoNoGo(taskName, taskDescription);
                        default:
                            return new TemplateGoNoGo(taskName, taskDescription);
                    }
                case TaskType.Mitigation:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateMitigation(taskName, taskDescription);
                        case TaskState.Scheduled:
                            return new ScheduledMitigation(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedMitigation(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedMitigation(taskName, taskDescription);
                        default:
                            return new TemplateMitigation(taskName, taskDescription);
                    }
                default:
                    return new TemplateTask(taskName, taskDescription);
            }
        }

        protected TaskType TaskType { get; set; }
        protected TaskState TaskState { get; set; }
        protected String Command { get; set; }
        protected List<String> AssignedRoles { get; set; }
        protected List<String> RequiredPreRequisiteTasks { get; set; }
        protected int PreWaitTimeSeconds { get; set; }
        protected int DurationSeconds { get; set; }
        protected int PostWaitTimeSeconds { get; set; }


        protected override void DisplayRequestname()
        {
            Console.WriteLine("\nPlease enter the task name.");
        }
        protected override void DisplayRequestDescription()
        {
            Console.WriteLine("\nPlease enter the task description.");
        }
        protected virtual void Init(String taskName, String taskDescription, Boolean empty = true)
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
        private void Init(Task task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        internal override String ToKeyString()
        {
            return Name.ToKeyString();
        }
        internal override Task CreateCopy(String newName)
        {
            Task result = CreateTask(TaskType, TaskState);
            result.Name = new ThingName(newName);
            return result;
        }
    }
}