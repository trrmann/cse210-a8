namespace FinalProject
{
    public class ImplementedTask : AssignedTask
    {
        protected String CurrentStatus { get; set; }
        protected DateTime StatusUpdateTime { get; set; }
        protected DateTime ActualStartTime { get; set; }
        protected DateTime ActualCompleteTime { get; set; }
    }
}