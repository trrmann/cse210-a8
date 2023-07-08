namespace FinalProject
{
    public abstract class Task : NamedObjectWithDetail
    {
        public static Task CreateTask(TaskType type, TaskState state)
        {
            switch (type)
            {
                case TaskType.Task:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateTask();
                        case TaskState.Scheduled:
                            return new ScheduledTask();
                        case TaskState.Assigned:
                            return new AssignedTask();
                        case TaskState.Implemented:
                            return new ImplementedTask();
                        default:
                            return new TemplateTask();
                    }
                case TaskType.Benchmark:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateBenchmark();
                        case TaskState.Scheduled:
                            return new ScheduledBenchmark();
                        case TaskState.Assigned:
                            return new AssignedBenchmark();
                        case TaskState.Implemented:
                            return new ImplementedBenchmark();
                        default:
                            return new TemplateBenchmark();
                    }
                case TaskType.GoNoGo:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateGoNoGo();
                        case TaskState.Scheduled:
                            return new ScheduledGoNoGo();
                        case TaskState.Assigned:
                            return new AssignedGoNoGo();
                        case TaskState.Implemented:
                            return new ImplementedGoNoGo();
                        default:
                            return new TemplateGoNoGo();
                    }
                case TaskType.Mitigation:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateMitigation();
                        case TaskState.Scheduled:
                            return new ScheduledMitigation();
                        case TaskState.Assigned:
                            return new AssignedMitigation();
                        case TaskState.Implemented:
                            return new ImplementedMitigation();
                        default:
                            return new TemplateMitigation();
                    }
                default:
                    return new TemplateTask();
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
    }
}