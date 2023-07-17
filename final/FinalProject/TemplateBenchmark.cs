using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonTemplateBenchmark), typeDiscriminator: "TemplateBenchmark")]
    internal class JsonTemplateBenchmark : JsonTemplateTask
    {
        protected TemplateBenchmark TemplateBenchmark { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return TemplateBenchmark;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(TemplateBenchmark)))
                {
                    TemplateBenchmark = (TemplateBenchmark)value;
                }
                else
                {
                    TemplateBenchmark = new();
                    TemplateBenchmark.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return TemplateBenchmark.Description; } set { TemplateBenchmark.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateBenchmarkType")]
        public TaskType TemplateBenchmarkType { get { return TemplateBenchmark.TaskType; } set { TemplateBenchmark.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateBenchmarkState")]
        public TaskState TemplateBenchmarkState { get { return TemplateBenchmark.TaskState; } set { TemplateBenchmark.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return TemplateBenchmark.Command; } set { TemplateBenchmark.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return TemplateBenchmark.AssignedRoles; } set { TemplateBenchmark.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return TemplateBenchmark.RequiredPreRequisiteTasks; } set { TemplateBenchmark.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return TemplateBenchmark.PreWaitTimeSeconds; } set { TemplateBenchmark.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return TemplateBenchmark.DurationSeconds; } set { TemplateBenchmark.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return TemplateBenchmark.PostWaitTimeSeconds; } set { TemplateBenchmark.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToPeople")]
        public List<String> ReportToPeople { get { return TemplateBenchmark.ReportToPeople; } set { TemplateBenchmark.ReportToPeople = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToTeams")]
        public List<String> ReportToTeams { get { return TemplateBenchmark.ReportToTeams; } set { TemplateBenchmark.ReportToTeams = value; } }
        public JsonTemplateBenchmark()
        {
            TemplateBenchmark = new();
        }
        [JsonConstructor]
        public JsonTemplateBenchmark(JsonNamedObject NamedObject, String Description, TaskType TemplateBenchmarkType, TaskState TemplateBenchmarkState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams) : base(NamedObject, Description, TemplateBenchmarkType, TemplateBenchmarkState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.TemplateBenchmarkType = TemplateBenchmarkType;
            this.TemplateBenchmarkState = TemplateBenchmarkState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.ReportToPeople = ReportToPeople;
            this.ReportToTeams = ReportToTeams;
        }
        public JsonTemplateBenchmark(TemplateBenchmark TemplateBenchmark) : base((JsonNamedObject)TemplateBenchmark, TemplateBenchmark.Description, TemplateBenchmark.TaskType, TemplateBenchmark.TaskState, TemplateBenchmark.Command, TemplateBenchmark.AssignedRoles, TemplateBenchmark.RequiredPreRequisiteTasks, TemplateBenchmark.PreWaitTimeSeconds, TemplateBenchmark.DurationSeconds, TemplateBenchmark.PostWaitTimeSeconds)
        {
            this.TemplateBenchmark = TemplateBenchmark;
        }
        public static implicit operator JsonTemplateBenchmark(TemplateBenchmark task)
        {
            return new(task);
        }
        public static implicit operator TemplateBenchmark(JsonTemplateBenchmark task)
        {
            return task.TemplateBenchmark;
        }
    }
    public class TemplateBenchmark : TemplateTask
    {
        protected Benchmark Benchmark { get; set; }
        internal List<String> ReportToPeople { get { return Benchmark.ReportToPeople; } set { Benchmark.ReportToPeople = value; } }
        internal List<String> ReportToTeams { get { return Benchmark.ReportToTeams; } set { Benchmark.ReportToTeams = value; } }
        public TemplateBenchmark()
        {
            Init();
        }
        public TemplateBenchmark(Boolean interactive)
        {
            Init(interactive);
        }
        public TemplateBenchmark(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        public TemplateBenchmark(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        public TemplateBenchmark(DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        public TemplateBenchmark(Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        public TemplateBenchmark(TemplateBenchmark task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public TemplateBenchmark(TemplateBenchmark task)
        {
            Init(task);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", TaskType.Benchmark, TaskState.Template, "", new(), new(), 0, 0, 0, new(), new(), interactive);
        }
        protected virtual void Init(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        protected virtual void Init(DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        protected virtual void Init(Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            base.Init(Name, Description, interactive);
            Benchmark = new Benchmark(interactive);
            if (interactive)
            {
                this.TaskType = TaskType;
                this.TaskState = TaskState;
                this.Command = Command;
                this.AssignedRoles = AssignedRoles;
                this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                this.DurationSeconds = DurationSeconds;
                this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                this.TaskType = TaskType.Benchmark;
                this.TaskState = TaskState.Template;
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
                RequestReportToPeople();
                RequestReportToTeams();
            }
            else
            {
                this.TaskType = TaskType.Benchmark;
                this.TaskState = TaskState.Template;
                this.Command = Command;
                this.AssignedRoles = AssignedRoles;
                this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                this.DurationSeconds = DurationSeconds;
                this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
            }
        }
        protected void Init(TemplateBenchmark task, Boolean interactive = false)
        {
            base.Init(task, interactive);
            Name = task.Name;
            Description = task.Description;
            this.TaskType = TaskType.Benchmark;
            this.TaskState = TaskState.Template;
            Command = task.Command;
            AssignedRoles = task.AssignedRoles;
            RequiredPreRequisiteTasks = task.RequiredPreRequisiteTasks;
            PreWaitTimeSeconds = task.PreWaitTimeSeconds;
            DurationSeconds = task.DurationSeconds;
            PostWaitTimeSeconds = task.PostWaitTimeSeconds;
            ReportToPeople = task.ReportToPeople;
            ReportToTeams = task.ReportToTeams;
        }
        protected virtual void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            switch (riskName)
            {
                case "":
                    Init(interactive);
                    break;
                default:
                    base.Init(riskName, riskDescription, interactive);
                    this.TaskType = TaskType.Benchmark;
                    this.TaskState = TaskState.Template;
                    this.Command = Command;
                    this.AssignedRoles = AssignedRoles;
                    this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                    this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                    this.DurationSeconds = DurationSeconds;
                    this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                    this.ReportToPeople = ReportToPeople;
                    this.ReportToTeams = ReportToTeams;
                    break;
            }
        }
        protected void Init(TemplateBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        protected override void DisplaySetNameMessage()
        {
            Console.WriteLine("\nSet template mitigation task name");
        }
        protected override void DisplaySetDescriptionMessage()
        {
            Console.WriteLine("\nSet template mitigation task Description");
        }
        protected override void DisplayRequestNameMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task name.");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task description.");
        }
        protected override void DisplayRequestTaskTypeMessage()
        {
            base.DisplayRequestTaskTypeMessage();
        }
        protected override void DisplaySetTaskTypeMessage()
        {
            base.DisplaySetTaskTypeMessage();
        }
        protected override void DisplayRequestTaskStateMessage()
        {
            base.DisplayRequestTaskStateMessage();
        }
        protected override void DisplaySetTaskStateMessage()
        {
            base.DisplaySetTaskStateMessage();
        }
        protected override void DisplayRequestCommandMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task command.");
        }
        protected override void DisplaySetCommandMessage()
        {
            Console.WriteLine("\nSet template mitigation task command");
        }
        protected override void DisplayRequestAssignedRolesMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task list of comma separated assigned roles.");
        }
        protected override void DisplaySetAssignedRolesMessage()
        {
            Console.WriteLine("\nSet template mitigation task assigned roles");
        }
        protected override void DisplayRequestRequiredPreRequisiteTasksMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task comma separated list of required pre-requisite tasks.");
        }
        protected override void DisplaySetRequiredPreRequisiteTasksMessage()
        {
            Console.WriteLine("\nSet template mitigation task required pre-requisite tasks");
        }
        protected override void DisplayRequestPreWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task pre-wait time in seconds.");
        }
        protected override void DisplaySetPreWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nSet template mitigation task pre-wait time seconds");
        }
        protected override void DisplayRequestDurationSecondsMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task duration in seconds.");
        }
        protected override void DisplaySetDurationSecondsMessage()
        {
            Console.WriteLine("\nSet template mitigation task duration in seconds");
        }
        protected override void DisplayRequestPostWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nPlease enter the template mitigation task post-wait time in seconds.");
        }
        protected override void DisplaySetPostWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nSet template mitigation task post-wait time seconds");
        }
        protected virtual void DisplayRequestReportToPeopleMessage()
        {
            Console.WriteLine("\nPlease enter the benchmark comma separated list of people to report this status to");
        }
        protected virtual void DisplaySetReportToPeopleMessage()
        {
            Console.WriteLine("\nSet task report to people");
        }
        protected void DisplayRequestReportToPeople()
        {
            DisplayRequestReportToPeopleMessage();
            String response = IApplication.READ_RESPONSE();
            ReportToPeople = new List<String>(response.Split(','));
        }
        protected Boolean HasReportToPeople()
        {
            return (ReportToPeople.Count > 0);
        }
        internal void RequestReportToPeople()
        {
            Boolean setRisk = true;
            this.DisplaySetReportToPeopleMessage();
            if (HasReportToPeople())
            {
                Display(false, true, -1);
                this.DisplayRequestReportToPeople();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setRisk = false;
            }
            if (setRisk) DisplayRequestReportToPeople();
        }
        protected virtual void DisplayRequestReportToTeamsMessage()
        {
            Console.WriteLine("\nPlease enter the benchmark comma separated list of teams to report this status to");
        }
        protected virtual void DisplaySetReportToTeamsMessage()
        {
            Console.WriteLine("\nSet task report to teams");
        }
        protected void DisplayRequestReportToTeams()
        {
            DisplayRequestReportToTeamsMessage();
            String response = IApplication.READ_RESPONSE();
            ReportToTeams = new List<String>(response.Split(','));
        }
        protected Boolean HasReportToTeams()
        {
            return (ReportToTeams.Count > 0);
        }
        internal void RequestReportToTeams()
        {
            Boolean setRisk = true;
            this.DisplaySetReportToTeamsMessage();
            if (HasReportToTeams())
            {
                Display(false, true, -1);
                this.DisplayRequestReportToTeams();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setRisk = false;
            }
            if (setRisk) DisplayRequestReportToTeams();
        }
        internal override TemplateBenchmark CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            TemplateBenchmark result = new(this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1)
        {
            Dictionary<TaskType, String> typeMap = ITaskTypeUtiltities.typeNameMap();
            Dictionary<TaskState, String> stateMap = ITaskStateUtiltities.stateNameMap();
            base.Display(option);
            if (option >= 0) Console.WriteLine(String.Format("{0}   {1}", new string(' ', option.ToString().Length), typeMap[TaskType]));
            else Console.WriteLine(String.Format("\t{0}", typeMap[TaskType]));
            if (option >= 0) Console.WriteLine(String.Format("{0}   {1}", new string(' ', option.ToString().Length), stateMap[TaskState]));
            else Console.WriteLine(String.Format("\t{0}", stateMap[TaskState]));
            if (option >= 0) Console.WriteLine(String.Format("{0}   Command:  {1}", new string(' ', option.ToString().Length), Command));
            else Console.WriteLine(String.Format("\tCommand:  {0}", Command));
            int counter = 1;
            foreach (String role in AssignedRoles)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0}   Role {1}:  {2}", new string(' ', option.ToString().Length), counter, role));
                else Console.WriteLine(String.Format("\tRole {0}:  {1}", counter, role));
                counter++;
            }
            counter = 1;
            foreach (String preRequisite in RequiredPreRequisiteTasks)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0}   PreRequisite {1}:  {2}", new string(' ', option.ToString().Length), counter, preRequisite));
                else Console.WriteLine(String.Format("\tPreRequisite {0}:  {1}", counter, preRequisite));
                counter++;
            }
            if (option >= 0) Console.WriteLine(String.Format("{0}   Pre-Wait:  {1} Seconds", new string(' ', option.ToString().Length), PreWaitTimeSeconds));
            else Console.WriteLine(String.Format("\tPre-Wait:  {0} Seconds", PreWaitTimeSeconds));
            if (option >= 0) Console.WriteLine(String.Format("{0}   Duration:  {1} Seconds", new string(' ', option.ToString().Length), DurationSeconds));
            else Console.WriteLine(String.Format("\tDuration:  {0} Seconds", DurationSeconds));
            if (option >= 0) Console.WriteLine(String.Format("{0}   Post-Wait:  {1} Seconds", new string(' ', option.ToString().Length), PostWaitTimeSeconds));
            else Console.WriteLine(String.Format("\tPost-Wait:  {0} Seconds", PostWaitTimeSeconds));
            counter = 1;
            foreach (String reportToPerson in ReportToPeople)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0}   {1} Report to:  {2}", new string(' ', option.ToString().Length), counter, reportToPerson));
                else Console.WriteLine(String.Format("\t{0} Report to:  {1}", counter, reportToPerson));
                counter++;
            }
            counter = 1;
            foreach (String reportToTeam in ReportToTeams)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0}   {1} Report to team:  {2}", new string(' ', option.ToString().Length), counter, reportToTeam));
                else Console.WriteLine(String.Format("\t{0} Report to team:  {1}", counter, reportToTeam));
                counter++;
            }
        }
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            Dictionary<TaskType, String> typeMap = ITaskTypeUtiltities.typeNameMap();
            Dictionary<TaskState, String> stateMap = ITaskStateUtiltities.stateNameMap();
            if (name) { base.Display(option); }
            if (name && description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("{0}   {1}", new string(' ', option.ToString().Length), typeMap[TaskType]));
                    Console.WriteLine(String.Format("{0}   {1}", new string(' ', option.ToString().Length), stateMap[TaskState]));
                    Console.WriteLine(String.Format("{0}   Command:  {1}", new string(' ', option.ToString().Length), Command));
                    int counter = 1;
                    foreach (String role in AssignedRoles)
                    {
                        Console.WriteLine(String.Format("{0}   Role {1}:  {2}", new string(' ', option.ToString().Length), counter, role));
                        counter++;
                    }
                    counter = 1;
                    foreach (String preRequisite in RequiredPreRequisiteTasks)
                    {
                        Console.WriteLine(String.Format("{0}   PreRequisite {1}:  {2}", new string(' ', option.ToString().Length), counter, preRequisite));
                        counter++;
                    }
                    Console.WriteLine(String.Format("{0}   Pre-Wait:  {1} Seconds", new string(' ', option.ToString().Length), PreWaitTimeSeconds));
                    Console.WriteLine(String.Format("{0}   Duration:  {1} Seconds", new string(' ', option.ToString().Length), DurationSeconds));
                    Console.WriteLine(String.Format("{0}   Post-Wait:  {1} Seconds", new string(' ', option.ToString().Length), PostWaitTimeSeconds));
                    counter = 1;
                    foreach (String reportToPerson in ReportToPeople)
                    {
                        Console.WriteLine(String.Format("{0}   {1} Report to:  {2}", new string(' ', option.ToString().Length), counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("{0}   {1} Report to team:  {2}", new string(' ', option.ToString().Length), counter, reportToTeam));
                        counter++;
                    }
                }
                else
                {
                    int counter = 1;
                    foreach (String reportToPerson in ReportToPeople)
                    {
                        Console.WriteLine(String.Format("\t{0} Report to:  {1}", counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("\t{0} Report to team:  {1}", counter, reportToTeam));
                        counter++;
                    }
                }
            }
            else if (description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("   {0}", typeMap[TaskType]));
                    Console.WriteLine(String.Format("   {0}", stateMap[TaskState]));
                    Console.WriteLine(String.Format("   Command:  {0}", Command));
                    int counter = 1;
                    foreach (String role in AssignedRoles)
                    {
                        Console.WriteLine(String.Format("   Role {0}:  {1}", counter, role));
                        counter++;
                    }
                    counter = 1;
                    foreach (String preRequisite in RequiredPreRequisiteTasks)
                    {
                        Console.WriteLine(String.Format("   PreRequisite {0}:  {1}", counter, preRequisite));
                        counter++;
                    }
                    Console.WriteLine(String.Format("   Pre-Wait:  {0} Seconds", PreWaitTimeSeconds));
                    Console.WriteLine(String.Format("   Duration:  {0} Seconds", DurationSeconds));
                    Console.WriteLine(String.Format("   Post-Wait:  {0} Seconds", PostWaitTimeSeconds));
                    counter = 1;
                    foreach (String reportToPerson in ReportToPeople)
                    {
                        Console.WriteLine(String.Format("   {0} Report to:  {1}", counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("   {0} Report to team:  {1}", counter, reportToTeam));
                        counter++;
                    }
                }
                else
                {
                    int counter = 1;
                    foreach (String reportToPerson in ReportToPeople)
                    {
                        Console.WriteLine(String.Format("\t{0} Report to:  {1}", counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("\t{0} Report to team:  {1}", counter, reportToTeam));
                        counter++;
                    }
                }
            }
        }
    }
}