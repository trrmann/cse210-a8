namespace FinalProject
{
    public enum TaskType
    {
        Task,
        Benchmark,
        GoNoGo,
        Mitigation
    }
    public interface ITaskTypeUtiltities
    {
        public static Dictionary<int, Tuple<TaskType, String>> typeOptionMap()
        {
            Dictionary<int, Tuple<TaskType, String>> result = new();
            int counter = 1;
            foreach (TaskType type in typeNameMap().Keys)
            {
                result.Add(counter, new(type, typeNameMap()[type]));
                counter++;
            }
            return result;
        }
        public static Dictionary<TaskType, String> typeNameMap()
        {
            return new()
            {
                { TaskType.Task, "Task" },
                { TaskType.Benchmark, "Benchmark" },
                { TaskType.GoNoGo, "Go/No Go" },
                { TaskType.Mitigation, "Mitigation" }
            };
        }
    }
}