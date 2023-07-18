namespace FinalProject
{
    public enum TaskState
    {
        Template,
        Scheduled
    }
    public interface ITaskStateUtiltities
    {
        public static Dictionary<int, Tuple<TaskState, String>> stateOptionMap()
        {
            Dictionary<int, Tuple<TaskState, String>> result = new();
            int counter = 1;
            foreach(TaskState state in stateNameMap().Keys)
            {
                result.Add(counter, new(state, stateNameMap()[state]));
                counter++;
            }
            return result;
        }
        public static Dictionary<TaskState, String> stateNameMap()
        {
            return new()
            {
                { TaskState.Template, "Template" },
                { TaskState.Scheduled, "Scheduled" }
            };
        }
    }
}