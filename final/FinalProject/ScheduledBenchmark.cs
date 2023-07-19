using System.Numerics;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonScheduledBenchmark), typeDiscriminator: "ScheduledBenchmark")]
    internal class JsonScheduledBenchmark : JsonScheduledTask
    {
        protected ScheduledBenchmark ScheduledBenchmark { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return ScheduledBenchmark;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(ScheduledBenchmark)))
                {
                    ScheduledBenchmark = (ScheduledBenchmark)value;
                }
                else
                {
                    ScheduledBenchmark = new();
                    ScheduledBenchmark.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return ScheduledBenchmark.Description; } set { ScheduledBenchmark.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledBenchmarkType")]
        public TaskType ScheduledBenchmarkType { get { return ScheduledBenchmark.TaskType; } set { ScheduledBenchmark.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledBenchmarkState")]
        public TaskState ScheduledBenchmarkState { get { return ScheduledBenchmark.TaskState; } set { ScheduledBenchmark.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return ScheduledBenchmark.Command; } set { ScheduledBenchmark.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return ScheduledBenchmark.AssignedRoles; } set { ScheduledBenchmark.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return ScheduledBenchmark.RequiredPreRequisiteTasks; } set { ScheduledBenchmark.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return ScheduledBenchmark.PreWaitTimeSeconds; } set { ScheduledBenchmark.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return ScheduledBenchmark.DurationSeconds; } set { ScheduledBenchmark.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return ScheduledBenchmark.PostWaitTimeSeconds; } set { ScheduledBenchmark.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledStart")]
        public new DateTime ScheduledStart { get { return ScheduledBenchmark.ScheduledStart; } set { ScheduledBenchmark.ScheduledStart = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignmentOwnerName")]
        public new String AssignmentOwnerName { get { return ScheduledBenchmark.AssignmentOwnerName; } set { ScheduledBenchmark.AssignmentOwnerName = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToPeople")]
        public List<String> ReportToPeople { get { return ScheduledBenchmark.ReportToPeople; } set { ScheduledBenchmark.ReportToPeople = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToTeams")]
        public List<String> ReportToTeams { get { return ScheduledBenchmark.ReportToTeams; } set { ScheduledBenchmark.ReportToTeams = value; } }
        public JsonScheduledBenchmark()
        {
            ScheduledBenchmark = new();
        }
        [JsonConstructor]
        public JsonScheduledBenchmark(JsonNamedObject NamedObject, String Description, TaskType ScheduledBenchmarkType, TaskState ScheduledBenchmarkState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams) : base(NamedObject, Description, ScheduledBenchmarkType, ScheduledBenchmarkState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.ScheduledBenchmarkType = ScheduledBenchmarkType;
            this.ScheduledBenchmarkState = ScheduledBenchmarkState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.ScheduledStart = ScheduledStart;
            this.AssignmentOwnerName = AssignmentOwnerName;
            this.ReportToPeople = ReportToPeople;
            this.ReportToTeams = ReportToTeams;
        }
        public JsonScheduledBenchmark(ScheduledBenchmark ScheduledBenchmark) : base((JsonNamedObject)ScheduledBenchmark, ScheduledBenchmark.Description, ScheduledBenchmark.TaskType, ScheduledBenchmark.TaskState, ScheduledBenchmark.Command, ScheduledBenchmark.AssignedRoles, ScheduledBenchmark.RequiredPreRequisiteTasks, ScheduledBenchmark.PreWaitTimeSeconds, ScheduledBenchmark.DurationSeconds, ScheduledBenchmark.PostWaitTimeSeconds, ScheduledBenchmark.ScheduledStart, ScheduledBenchmark.AssignmentOwnerName)
        {
            this.ScheduledBenchmark = ScheduledBenchmark;
        }
        public static implicit operator JsonScheduledBenchmark(ScheduledBenchmark task)
        {
            return new(task);
        }
        public static implicit operator ScheduledBenchmark(JsonScheduledBenchmark task)
        {
            return task.ScheduledBenchmark;
        }
    }
    public class ScheduledBenchmark : ScheduledTask
    {
        internal static new string ObjectNameDisplay { get; } = "scheduled benchmark task";
        protected Benchmark Benchmark { get; set; } = new();
        internal List<String> ReportToPeople { get { return Benchmark.ReportToPeople; } set { Benchmark.ReportToPeople = value; } }
        internal List<String> ReportToTeams { get { return Benchmark.ReportToTeams; } set { Benchmark.ReportToTeams = value; } }
        public ScheduledBenchmark()
        {
            Init();
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, Boolean interactive)
        {
            Init(plan, risks, interactive);
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, interactive);
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, interactive);
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, interactive);
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, interactive);
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, ScheduledBenchmark task, Boolean interactive = false)
        {
            Init(plan, risks, task, interactive);
        }
        public ScheduledBenchmark(BackoutPlan plan, Risks risks, ScheduledBenchmark task)
        {
            Init(plan, risks, task);
        }
        protected override void Init(BackoutPlan plan, Risks risks, Boolean interactive = false)
        {
            Init(plan, risks, "", NameType.Thing, "", TaskType.Benchmark, TaskState.Template, "", new(), new(), 0, 0, 0, new(), "", new(), new(), interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, false, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean useTaskCreate, Boolean interactive )
        {
            base.Init(plan, risks, Name, Description, TaskType.Benchmark, TaskState.Scheduled, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, useTaskCreate, interactive);
            Benchmark = new Benchmark(plan, risks, false);
            if (interactive)
            {
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
                RequestReportToPeople();
                RequestReportToTeams();
                this.TaskType = TaskType.Benchmark;
                this.TaskState = TaskState.Scheduled;
            }
            else
            {
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
                this.TaskType = TaskType.Benchmark;
                this.TaskState = TaskState.Scheduled;
            }
        }
        protected void Init(BackoutPlan plan, Risks risks, ScheduledBenchmark task, Boolean interactive = false)
        {
            base.Init(plan, risks, task, interactive);
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
            ScheduledStart = task.ScheduledStart;
            AssignmentOwnerName = task.AssignmentOwnerName;
            ReportToPeople = task.ReportToPeople;
            ReportToTeams = task.ReportToTeams;
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            switch (riskName)
            {
                case "":
                    Init(plan, risks, interactive);
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
                    this.ScheduledStart = ScheduledStart;
                    this.AssignmentOwnerName = AssignmentOwnerName;
                    this.ReportToPeople = ReportToPeople;
                    this.ReportToTeams = ReportToTeams;
                    break;
            }
        }
        protected void Init(BackoutPlan plan, Risks risks, ScheduledBenchmark task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        protected override void DisplaySetNameMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} name");
        }
        protected override void DisplaySetDescriptionMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} Description");
        }
        protected override void DisplayRequestNameMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} name.");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} description.");
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
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} command.");
        }
        protected override void DisplaySetCommandMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} command");
        }
        protected override void DisplayRequestAssignedRolesMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} list of comma separated assigned roles.");
        }
        protected override void DisplaySetAssignedRolesMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} assigned roles");
        }
        protected override void DisplayRequestRequiredPreRequisiteTasksMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of required pre-requisite tasks.");
        }
        protected override void DisplaySetRequiredPreRequisiteTasksMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} required pre-requisite tasks");
        }
        protected override void DisplayRequestPreWaitTimeSecondsMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} pre-wait time in seconds.");
        }
        protected override void DisplaySetPreWaitTimeSecondsMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} pre-wait time seconds");
        }
        protected override void DisplayRequestDurationSecondsMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} duration in seconds.");
        }
        protected override void DisplaySetDurationSecondsMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} duration in seconds");
        }
        protected override void DisplayRequestPostWaitTimeSecondsMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} post-wait time in seconds.");
        }
        protected override void DisplaySetPostWaitTimeSecondsMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} post-wait time seconds");
        }
        protected override void DisplayRequestScheduledStartMessage()
        {
            Console.WriteLine($"\nPlease enter the start date time of the task.");
        }
        protected override void DisplaySetScheduledStartMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} start date time.");
        }
        protected override void DisplayRequestAssignmentOwnerNameMessage()
        {
            Console.WriteLine($"\nPlease enter the name of the preson or team assigned to perform this task.");
        }
        protected override void DisplaySetAssignmentOwnerNameMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} assignment.");
        }
        protected virtual void DisplayRequestReportToPeopleMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of people to report this status to");
        }
        protected virtual void DisplaySetReportToPeopleMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} report to people");
        }
        protected void DisplayRequestReportToPeople()
        {
            Benchmark.DisplayRequestReportToPeople();
        }
        protected Boolean HasReportToPeople()
        {
            return Benchmark.HasReportToPeople();
        }
        internal void RequestReportToPeople()
        {
            Benchmark.RequestReportToPeople();
        }
        protected virtual void DisplayRequestReportToTeamsMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of teams to report this status to");
        }
        protected virtual void DisplaySetReportToTeamsMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} report to teams");
        }
        protected void DisplayRequestReportToTeams()
        {
            Benchmark.DisplayRequestReportToTeams();
        }
        protected Boolean HasReportToTeams()
        {
            return Benchmark.HasReportToTeams();
        }
        internal void RequestReportToTeams()
        {
            Benchmark.RequestReportToTeams();
        }
        internal override void DisplayAddMessage(Plan plan)
        {
            Console.WriteLine($"\nAdd a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        }
        internal override void DisplayAlreadyDefined(string value)
        {
            Console.WriteLine($"{value} already defined.");
            Console.Write("overwrite (y/n)");
        }
        internal override void DisplaySelectMessage()
        {
            Console.Write($"Select a {ObjectNameDisplay}");
        }
        internal override void DisplayCopyMessage(Plan plan)
        {
            Console.WriteLine($"\nCopy a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        }
        internal override void DisplayEditMessage(Plan plan)
        {
            Console.WriteLine($"\nEdit a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        }
        internal override void DisplayRemoveMessage(Plan plan)
        {
            Console.WriteLine($"\nRemove a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        }
        internal override void DisplayListMessage(Plan plan)
        {
            Console.WriteLine($"\nDisplay {ObjectNameDisplay}s ({plan.GetNameForMenus()})\n");
        }
        internal override void DisplayExportMessage(Plan plan)
        {
            Console.WriteLine($"\nExport {ObjectNameDisplay}s ({plan.GetNameForMenus()})\n");
        }
        internal override void DisplayImportMessage(Plan plan)
        {
            Console.WriteLine($"\nImport {ObjectNameDisplay}s ({plan.GetNameForMenus()})\n");
        }
        internal override void Edit(Task task, BackoutPlan plan, Risks risks)
        {
            if (task is not null)
            {
                base.Edit(task, plan, risks);
                Console.Write("\nchange report to people (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledBenchmark)task).ReportToPeople = new();
                    ((ScheduledBenchmark)task).RequestReportToPeople();
                }
                Console.Write("\nchange report to teams (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledBenchmark)task).ReportToTeams = new();
                    ((ScheduledBenchmark)task).RequestReportToTeams();
                }
            }
        }
        internal override ScheduledBenchmark CreateCopy(BackoutPlan plan, Risks risks, String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            ScheduledBenchmark result = new(plan, risks, this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
            int counter = 1;
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
            base.Display(name, description, option);
            if (name && description)
            {
                if (option >= 0)
                {
                    int counter = 1;
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
                    int counter = 1;
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