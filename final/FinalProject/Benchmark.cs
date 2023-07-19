using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonBenchmark), typeDiscriminator: "Benchmark")]
    [JsonDerivedType(typeof(JsonGoNoGo), typeDiscriminator: "GoNoGo")]
    internal class JsonBenchmark : JsonTask
    {
        protected Benchmark Benchmark { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return Benchmark;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(Benchmark)))
                {
                    Benchmark = (Benchmark)value;
                }
                else
                {
                    Benchmark = new();
                    Benchmark.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return Benchmark.Description; } set { Benchmark.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("BenchmarkType")]
        public TaskType BenchmarkType { get { return Benchmark.TaskType; } set { Benchmark.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("BenchmarkState")]
        public TaskState BenchmarkState { get { return Benchmark.TaskState; } set { Benchmark.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return Benchmark.Command; } set { Benchmark.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return Benchmark.AssignedRoles; } set { Benchmark.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return Benchmark.RequiredPreRequisiteTasks; } set { Benchmark.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return Benchmark.PreWaitTimeSeconds; } set { Benchmark.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return Benchmark.DurationSeconds; } set { Benchmark.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return Benchmark.PostWaitTimeSeconds; } set { Benchmark.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToPeople")]
        public List<String> ReportToPeople { get { return Benchmark.ReportToPeople; } set { Benchmark.ReportToPeople = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToTeams")]
        public List<String> ReportToTeams { get { return Benchmark.ReportToTeams; } set { Benchmark.ReportToTeams = value; } }
        public JsonBenchmark()
        {
            Benchmark = new();
        }
        [JsonConstructor]
        public JsonBenchmark(JsonNamedObject NamedObject, String Description, TaskType BenchmarkType, TaskState BenchmarkState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams) : base(NamedObject, Description, BenchmarkType, BenchmarkState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.BenchmarkType = BenchmarkType;
            this.BenchmarkState = BenchmarkState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.ReportToPeople = ReportToPeople;
            this.ReportToTeams = ReportToTeams;
        }
        public JsonBenchmark(Benchmark Benchmark) : base((JsonNamedObject)Benchmark, Benchmark.Description, Benchmark.TaskType, Benchmark.TaskState, Benchmark.Command, Benchmark.AssignedRoles, Benchmark.RequiredPreRequisiteTasks, Benchmark.PreWaitTimeSeconds, Benchmark.DurationSeconds, Benchmark.PostWaitTimeSeconds)
        {
            this.Benchmark = Benchmark;
        }
        public static implicit operator JsonBenchmark(Benchmark task)
        {
            return new(task);
        }
        public static implicit operator Benchmark(JsonBenchmark task)
        {
            return task.Benchmark;
        }
    }
    public class Benchmark : Task
    {
        internal static new string ObjectNameDisplay { get; } = "benchmark task";
        internal List<String> ReportToPeople { get; set; }
        internal List<String> ReportToTeams { get; set; }
        public Benchmark()
        {
            Init();
        }
        public Benchmark(BackoutPlan plan, Risks risks, Boolean interactive)
        {
            Init(plan, risks, interactive);
        }
        public Benchmark(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        public Benchmark(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, false, interactive);
        }
        public Benchmark(BackoutPlan plan, Risks risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
        }
        public Benchmark(BackoutPlan plan, Risks risks, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, false, interactive);
        }
        public Benchmark(BackoutPlan plan, Risks risks, Benchmark task, Boolean interactive = false)
        {
            Init(plan, risks, task, interactive);
        }
        public Benchmark(BackoutPlan plan, Risks risks, Benchmark task)
        {
            Init(plan, risks, task);
        }
        protected override void Init(BackoutPlan plan, Risks risks, Boolean interactive = false)
        {
            Init(plan, risks, "", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, new(), new(), interactive);
        }

        protected virtual void Init(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, false, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean interactive = false)
        {
            Init(plan, risks, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, false, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Boolean useTaskCreate , Boolean interactive )
        {
            base.Init(plan, risks, Name, Description, TaskType.Benchmark, TaskState.Template, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, false, interactive);
            if (interactive)
            {
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
                RequestReportToPeople();
                RequestReportToTeams();
                this.TaskType = TaskType.Benchmark;
                this.TaskState = TaskState.Template;
            }
            else
            {
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
                this.TaskType = TaskType.Benchmark;
                this.TaskState = TaskState.Template;
            }
        }
        protected void Init(BackoutPlan plan, Risks risks, Benchmark task, Boolean interactive = false)
        {
            base.Init(plan, risks, task, interactive);
            Name = task.Name;
            Description = task.Description;
            this.TaskType = TaskType.Task;
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
        protected virtual void Init(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            switch (riskName)
            {
                case "":
                    Init(interactive);
                    break;
                default:
                    base.Init(riskName, riskDescription, interactive);
                    this.TaskType = TaskType.Task;
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
        protected void Init(BackoutPlan plan, Risks risks, Benchmark task)
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
        protected virtual void DisplayRequestReportToPeopleMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of people to report this status to");
        }
        protected virtual void DisplaySetReportToPeopleMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} report to people");
        }
        internal void DisplayRequestReportToPeople()
        {
            DisplayRequestReportToPeopleMessage();
            String response = IApplication.READ_RESPONSE();
            ReportToPeople = new List<String>(response.Split(','));
        }
        internal Boolean HasReportToPeople()
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
                DisplayAlreadyDefined(String.Join(", ", ReportToPeople));
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setRisk = false;
            }
            if (setRisk) DisplayRequestReportToPeople();
        }
        protected virtual void DisplayRequestReportToTeamsMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of teams to report this status to");
        }
        protected virtual void DisplaySetReportToTeamsMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} report to teams");
        }
        internal void DisplayRequestReportToTeams()
        {
            DisplayRequestReportToTeamsMessage();
            String response = IApplication.READ_RESPONSE();
            ReportToTeams = new List<String>(response.Split(','));
        }
        internal Boolean HasReportToTeams()
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
                DisplayAlreadyDefined(String.Join(", ", ReportToTeams));
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setRisk = false;
            }
            if (setRisk) DisplayRequestReportToTeams();
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
                    ((TemplateBenchmark)task).ReportToPeople = new();
                    ((TemplateBenchmark)task).RequestReportToPeople();
                }
                Console.Write("\nchange report to teams (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((TemplateBenchmark)task).ReportToTeams = new();
                    ((TemplateBenchmark)task).RequestReportToTeams();
                }
            }
        }
        internal override Benchmark CreateCopy(BackoutPlan plan, Risks risks, String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            Benchmark result = new(plan, risks, this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
            int counter = 1;
            foreach (String reportToPerson in ReportToPeople)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0}   {1}) Report to:  {2}", new string(' ', option.ToString().Length), counter, reportToPerson));
                else Console.WriteLine(String.Format("\t{0}) Report to:  {1}", counter, reportToPerson));
                counter++;
            }
            counter = 1;
            foreach (String reportToTeam in ReportToTeams)
            {
                if (option >= 0) Console.WriteLine(String.Format("{0}   {1}) Report to team:  {2}", new string(' ', option.ToString().Length), counter, reportToTeam));
                else Console.WriteLine(String.Format("\t{0}) Report to team:  {1}", counter, reportToTeam));
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
                        Console.WriteLine(String.Format("{0}   {1}) Report to:  {2}", new string(' ', option.ToString().Length), counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("{0}   {1}) Report to team:  {2}", new string(' ', option.ToString().Length), counter, reportToTeam));
                        counter++;
                    }
                }
                else
                {
                    int counter = 1;
                    foreach (String reportToPerson in ReportToPeople)
                    {
                        Console.WriteLine(String.Format("\t{0}) Report to:  {1}", counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("\t{0}) Report to team:  {1}", counter, reportToTeam));
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
                        Console.WriteLine(String.Format("   {0}) Report to:  {1}", counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("   {0}) Report to team:  {1}", counter, reportToTeam));
                        counter++;
                    }
                }
                else
                {
                    int counter = 1;
                    foreach (String reportToPerson in ReportToPeople)
                    {
                        Console.WriteLine(String.Format("\t{0}) Report to:  {1}", counter, reportToPerson));
                        counter++;
                    }
                    counter = 1;
                    foreach (String reportToTeam in ReportToTeams)
                    {
                        Console.WriteLine(String.Format("\t{0}) Report to team:  {1}", counter, reportToTeam));
                        counter++;
                    }
                }
            }
        }
    }
}