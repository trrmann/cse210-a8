using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonTemplateGoNoGo), typeDiscriminator: "TemplateGoNoGo")]
    internal class JsonTemplateGoNoGo : JsonTemplateBenchmark
    {
        protected TemplateGoNoGo TemplateGoNoGo { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return TemplateGoNoGo;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(TemplateGoNoGo)))
                {
                    TemplateGoNoGo = (TemplateGoNoGo)value;
                }
                else
                {
                    TemplateGoNoGo = new(new BackoutPlan());
                    TemplateGoNoGo.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return TemplateGoNoGo.Description; } set { TemplateGoNoGo.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateGoNoGoType")]
        public TaskType TemplateGoNoGoType { get { return TemplateGoNoGo.TaskType; } set { TemplateGoNoGo.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateGoNoGoState")]
        public TaskState TemplateGoNoGoState { get { return TemplateGoNoGo.TaskState; } set { TemplateGoNoGo.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return TemplateGoNoGo.Command; } set { TemplateGoNoGo.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return TemplateGoNoGo.AssignedRoles; } set { TemplateGoNoGo.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return TemplateGoNoGo.RequiredPreRequisiteTasks; } set { TemplateGoNoGo.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return TemplateGoNoGo.PreWaitTimeSeconds; } set { TemplateGoNoGo.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return TemplateGoNoGo.DurationSeconds; } set { TemplateGoNoGo.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return TemplateGoNoGo.PostWaitTimeSeconds; } set { TemplateGoNoGo.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToPeople")]
        public new List<String> ReportToPeople { get { return TemplateGoNoGo.ReportToPeople; } set { TemplateGoNoGo.ReportToPeople = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToTeams")]
        public new List<String> ReportToTeams { get { return TemplateGoNoGo.ReportToTeams; } set { TemplateGoNoGo.ReportToTeams = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("BackOutPlanStartStepOnNoGo")]
        public JsonTask BackOutPlanStartStepOnNoGo { get { return TemplateGoNoGo.BackOutPlanStartStepOnNoGo; } set { TemplateGoNoGo.BackOutPlanStartStepOnNoGo = value; } }
        public JsonTemplateGoNoGo()
        {
            TemplateGoNoGo = new(new BackoutPlan());
        }
        [JsonConstructor]
        public JsonTemplateGoNoGo(JsonNamedObject NamedObject, String Description, TaskType TemplateGoNoGoType, TaskState TemplateGoNoGoState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, JsonTask BackOutPlanStartStepOnNoGo) : base(NamedObject, Description, TemplateGoNoGoType, TemplateGoNoGoState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.TemplateGoNoGoType = TemplateGoNoGoType;
            this.TemplateGoNoGoState = TemplateGoNoGoState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.ReportToPeople = ReportToPeople;
            this.ReportToTeams = ReportToTeams;
            this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
        }
        public JsonTemplateGoNoGo(TemplateGoNoGo TemplateGoNoGo) : base((JsonNamedObject)TemplateGoNoGo, TemplateGoNoGo.Description, TemplateGoNoGo.TaskType, TemplateGoNoGo.TaskState, TemplateGoNoGo.Command, TemplateGoNoGo.AssignedRoles, TemplateGoNoGo.RequiredPreRequisiteTasks, TemplateGoNoGo.PreWaitTimeSeconds, TemplateGoNoGo.DurationSeconds, TemplateGoNoGo.PostWaitTimeSeconds, TemplateGoNoGo.ReportToPeople, TemplateGoNoGo.ReportToTeams)
        {
            this.TemplateGoNoGo = TemplateGoNoGo;
        }
        public static implicit operator JsonTemplateGoNoGo(TemplateGoNoGo task)
        {
            return new(task);
        }
        public static implicit operator TemplateGoNoGo(JsonTemplateGoNoGo task)
        {
            return task.TemplateGoNoGo;
        }
    }
    public class TemplateGoNoGo : TemplateBenchmark
    {
        internal static new string ObjectNameDisplay { get; } = "template go / no go task";
        protected GoNoGo GoNoGo { get; set; } = new(false);
        internal Task BackOutPlanStartStepOnNoGo { get { return GoNoGo.BackOutPlanStartStepOnNoGo; } set { GoNoGo.BackOutPlanStartStepOnNoGo = value; } }
        public TemplateGoNoGo()
        {
            Init();
        }
        public TemplateGoNoGo(BackoutPlan plan)
        {
            Init(plan);
        }
        public TemplateGoNoGo(Boolean interactive = false)
        {
            Init(interactive);
        }
        public TemplateGoNoGo(BackoutPlan plan, Boolean interactive)
        {
            Init(plan, interactive);
        }
        public TemplateGoNoGo(BackoutPlan plan, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public TemplateGoNoGo(BackoutPlan plan, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public TemplateGoNoGo(BackoutPlan plan, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public TemplateGoNoGo(BackoutPlan plan, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public TemplateGoNoGo(TemplateGoNoGo task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public TemplateGoNoGo(TemplateGoNoGo task)
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
            Init(plan, "", NameType.Thing, "", TaskType.Benchmark, TaskState.Template, "", new(), new(), 0, 0, 0, new(), new(), new(), interactive);
        }
        protected virtual void Init(BackoutPlan plan, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        protected virtual void Init(BackoutPlan plan, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            base.Init(Name, Description, TaskType.GoNoGo, TaskState.Template, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, interactive);
            if (interactive)
            {
                this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                RequestBackOutPlanStartStepOnNoGo(plan);
                this.TaskType = TaskType.GoNoGo;
                this.TaskState = TaskState.Template;
            }
            else
            {
                this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                this.TaskType = TaskType.GoNoGo;
                this.TaskState = TaskState.Template;
            }
        }
        protected void Init(TemplateGoNoGo task, Boolean interactive = false)
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
            BackOutPlanStartStepOnNoGo = task.BackOutPlanStartStepOnNoGo;
        }
        protected virtual void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
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
                    this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                    break;
            }
        }
        protected void Init(TemplateGoNoGo task)
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
                    ((TemplateGoNoGo)task).BackOutPlanStartStepOnNoGo = new();
                    ((TemplateGoNoGo)task).RequestBackOutPlanStartStepOnNoGo(plan);
                }
            }
        }
        internal override TemplateGoNoGo CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            TemplateGoNoGo result = new(this);
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