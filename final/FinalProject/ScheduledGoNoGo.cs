using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonScheduledGoNoGo), typeDiscriminator: "ScheduledGoNoGo")]
    internal class JsonScheduledGoNoGo : JsonScheduledBenchmark
    {
        protected ScheduledGoNoGo ScheduledGoNoGo { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return ScheduledGoNoGo;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(ScheduledGoNoGo)))
                {
                    ScheduledGoNoGo = (ScheduledGoNoGo)value;
                }
                else
                {
                    ScheduledGoNoGo = new(new BackoutPlan());
                    ScheduledGoNoGo.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return ScheduledGoNoGo.Description; } set { ScheduledGoNoGo.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledGoNoGoType")]
        public TaskType ScheduledGoNoGoType { get { return ScheduledGoNoGo.TaskType; } set { ScheduledGoNoGo.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledGoNoGoState")]
        public TaskState ScheduledGoNoGoState { get { return ScheduledGoNoGo.TaskState; } set { ScheduledGoNoGo.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return ScheduledGoNoGo.Command; } set { ScheduledGoNoGo.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return ScheduledGoNoGo.AssignedRoles; } set { ScheduledGoNoGo.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return ScheduledGoNoGo.RequiredPreRequisiteTasks; } set { ScheduledGoNoGo.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return ScheduledGoNoGo.PreWaitTimeSeconds; } set { ScheduledGoNoGo.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return ScheduledGoNoGo.DurationSeconds; } set { ScheduledGoNoGo.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return ScheduledGoNoGo.PostWaitTimeSeconds; } set { ScheduledGoNoGo.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledStart")]
        public new DateTime ScheduledStart { get { return ScheduledTask.ScheduledStart; } set { ScheduledTask.ScheduledStart = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignmentOwnerName")]
        public new String AssignmentOwnerName { get { return ScheduledTask.AssignmentOwnerName; } set { ScheduledTask.AssignmentOwnerName = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToPeople")]
        public new List<String> ReportToPeople { get { return ScheduledGoNoGo.ReportToPeople; } set { ScheduledGoNoGo.ReportToPeople = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToTeams")]
        public new List<String> ReportToTeams { get { return ScheduledGoNoGo.ReportToTeams; } set { ScheduledGoNoGo.ReportToTeams = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("BackOutPlanStartStepOnNoGo")]
        public JsonTask BackOutPlanStartStepOnNoGo { get { return ScheduledGoNoGo.BackOutPlanStartStepOnNoGo; } set { ScheduledGoNoGo.BackOutPlanStartStepOnNoGo = value; } }
        public JsonScheduledGoNoGo()
        {
            ScheduledGoNoGo = new(new BackoutPlan());
        }
        [JsonConstructor]
        public JsonScheduledGoNoGo(JsonNamedObject NamedObject, String Description, TaskType ScheduledGoNoGoType, TaskState ScheduledGoNoGoState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, JsonTask BackOutPlanStartStepOnNoGo) : base(NamedObject, Description, ScheduledGoNoGoType, ScheduledGoNoGoState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.ScheduledGoNoGoType = ScheduledGoNoGoType;
            this.ScheduledGoNoGoState = ScheduledGoNoGoState;
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
            this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
        }
        public JsonScheduledGoNoGo(ScheduledGoNoGo ScheduledGoNoGo) : base((JsonNamedObject)ScheduledGoNoGo, ScheduledGoNoGo.Description, ScheduledGoNoGo.TaskType, ScheduledGoNoGo.TaskState, ScheduledGoNoGo.Command, ScheduledGoNoGo.AssignedRoles, ScheduledGoNoGo.RequiredPreRequisiteTasks, ScheduledGoNoGo.PreWaitTimeSeconds, ScheduledGoNoGo.DurationSeconds, ScheduledGoNoGo.PostWaitTimeSeconds, ScheduledGoNoGo.ScheduledStart, ScheduledGoNoGo.AssignmentOwnerName, ScheduledGoNoGo.ReportToPeople, ScheduledGoNoGo.ReportToTeams)
        {
            this.ScheduledGoNoGo = ScheduledGoNoGo;
        }
        public static implicit operator JsonScheduledGoNoGo(ScheduledGoNoGo task)
        {
            return new(task);
        }
        public static implicit operator ScheduledGoNoGo(JsonScheduledGoNoGo task)
        {
            return task.ScheduledGoNoGo;
        }
    }
    public class ScheduledGoNoGo : ScheduledBenchmark
    {
        internal static new string ObjectNameDisplay { get; } = "scheduled go / no go task";
        protected GoNoGo GoNoGo { get; set; } = new();
        internal Task BackOutPlanStartStepOnNoGo { get { return GoNoGo.BackOutPlanStartStepOnNoGo; } set { GoNoGo.BackOutPlanStartStepOnNoGo = value; } }
        public ScheduledGoNoGo()
        {
            Init();
        }
        public ScheduledGoNoGo(BackoutPlan plan)
        {
            Init(plan);
        }
        public ScheduledGoNoGo(Boolean interactive = false)
        {
            Init(interactive);
        }
        public ScheduledGoNoGo(BackoutPlan plan, Boolean interactive)
        {
            Init(plan, interactive);
        }
        public ScheduledGoNoGo(BackoutPlan plan, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public ScheduledGoNoGo(BackoutPlan plan, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public ScheduledGoNoGo(BackoutPlan plan, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public ScheduledGoNoGo(BackoutPlan plan, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public ScheduledGoNoGo(ScheduledGoNoGo task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public ScheduledGoNoGo(ScheduledGoNoGo task)
        {
            Init(task);
        }
        protected override void Init(Boolean interactive = false)
        {
            if (!interactive)
            {
                Init(new BackoutPlan(), interactive);
            }
            else
            {
                //TODO fix no backout plan available
                throw new NotImplementedException();
            }
        }
        protected virtual void Init(BackoutPlan plan, Boolean interactive = false)
        {
            Init(plan, "", NameType.Thing, "", TaskType.Benchmark, TaskState.Template, "", new(), new(), 0, 0, 0, new(), "", new(), new(), new(), interactive);
        }
        protected virtual void Init(BackoutPlan plan, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        protected virtual void Init(BackoutPlan plan, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            base.Init(Name, Description, TaskType.GoNoGo, TaskState.Scheduled, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, ReportToPeople, ReportToTeams, interactive);
            GoNoGo = new GoNoGo(false);
            if (interactive)
            {
                this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                RequestBackOutPlanStartStepOnNoGo(plan);
                this.TaskType = TaskType.GoNoGo;
                this.TaskState = TaskState.Scheduled;
            }
            else
            {
                this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                this.TaskType = TaskType.GoNoGo;
                this.TaskState = TaskState.Scheduled;
            }
        }
        protected void Init(ScheduledGoNoGo task, Boolean interactive = false)
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
            ScheduledStart = task.ScheduledStart;
            AssignmentOwnerName = task.AssignmentOwnerName;
            ReportToPeople = task.ReportToPeople;
            ReportToTeams = task.ReportToTeams;
            BackOutPlanStartStepOnNoGo = task.BackOutPlanStartStepOnNoGo;
        }
        protected virtual void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
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
                    this.ScheduledStart = ScheduledStart;
                    this.AssignmentOwnerName = AssignmentOwnerName;
                    this.ReportToPeople = ReportToPeople;
                    this.ReportToTeams = ReportToTeams;
                    this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                    break;
            }
        }
        protected void Init(ScheduledGoNoGo task)
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
        protected override void DisplayRequestReportToPeopleMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of people to report this status to");
        }
        protected override void DisplaySetReportToPeopleMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} report to people");
        }
        protected override void DisplayRequestReportToTeamsMessage()
        {
            Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of teams to report this status to");
        }
        protected override void DisplaySetReportToTeamsMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} report to teams");
        }
        protected virtual void DisplayRequestBackOutPlanStartStepOnNoGoMessage()
        {
            Console.WriteLine($"\nPlease select the backout plan task to start at for a no go.");
        }
        protected virtual void DisplaySetBackOutPlanStartStepOnNoGoMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} backout plan start step on no go");
        }
        protected void DisplayRequestBackOutPlanStartStepOnNoGo(BackoutPlan plan)
        {
            GoNoGo.DisplayRequestBackOutPlanStartStepOnNoGo(plan);
        }
        protected Boolean HasBackOutPlanStartStepOnNoGo()
        {
            return GoNoGo.HasBackOutPlanStartStepOnNoGo();
        }
        internal void RequestBackOutPlanStartStepOnNoGo(BackoutPlan plan)
        {
            GoNoGo.RequestBackOutPlanStartStepOnNoGo(plan);
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
                Console.Write("\nchange the backout plan task to start at for a no go (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledGoNoGo)task).BackOutPlanStartStepOnNoGo = new();
                    ((ScheduledGoNoGo)task).RequestBackOutPlanStartStepOnNoGo(plan);
                }
            }
        }
        internal override ScheduledGoNoGo CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            ScheduledGoNoGo result = new(this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
            if (option >= 0) Console.WriteLine(String.Format("{0}   Backout Step on No Go:  {1}", new string(' ', option.ToString().Length), BackOutPlanStartStepOnNoGo.Name.Value));
            else Console.WriteLine(String.Format("\tBackout Step on No Go:  {0}", BackOutPlanStartStepOnNoGo.Name.Value));
        }
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            base.Display(name, description, option);
            if (name && description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("{0}   Backout Step on No Go:  {1}", new string(' ', option.ToString().Length), BackOutPlanStartStepOnNoGo.Name.Value));
                }
                else
                {
                    Console.WriteLine(String.Format("\tBackout Step on No Go:  {0}", BackOutPlanStartStepOnNoGo.Name.Value));
                }
            }
            else if (description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("   Backout Step on No Go:  {0}", BackOutPlanStartStepOnNoGo.Name.Value));
                }
                else
                {
                    Console.WriteLine(String.Format("\tBackout Step on No Go:  {0}", BackOutPlanStartStepOnNoGo.Name.Value));
                }
            }
        }
    }
}