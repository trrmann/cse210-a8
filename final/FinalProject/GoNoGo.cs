using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonGoNoGo), typeDiscriminator: "GoNoGo")]
    internal class JsonGoNoGo : JsonBenchmark
    {
        protected GoNoGo GoNoGo { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return GoNoGo;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(GoNoGo)))
                {
                    GoNoGo = (GoNoGo)value;
                }
                else
                {
                    GoNoGo = new(new BackoutPlan());
                    GoNoGo.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return GoNoGo.Description; } set { GoNoGo.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("GoNoGoType")]
        public TaskType GoNoGoType { get { return GoNoGo.TaskType; } set { GoNoGo.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("GoNoGoState")]
        public TaskState GoNoGoState { get { return GoNoGo.TaskState; } set { GoNoGo.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return GoNoGo.Command; } set { GoNoGo.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return GoNoGo.AssignedRoles; } set { GoNoGo.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return GoNoGo.RequiredPreRequisiteTasks; } set { GoNoGo.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return GoNoGo.PreWaitTimeSeconds; } set { GoNoGo.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return GoNoGo.DurationSeconds; } set { GoNoGo.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return GoNoGo.PostWaitTimeSeconds; } set { GoNoGo.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToPeople")]
        public new List<String> ReportToPeople { get { return GoNoGo.ReportToPeople; } set { GoNoGo.ReportToPeople = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ReportToTeams")]
        public new List<String> ReportToTeams { get { return GoNoGo.ReportToTeams; } set { GoNoGo.ReportToTeams = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("BackOutPlanStartStepOnNoGo")]
        protected JsonTask BackOutPlanStartStepOnNoGo { get { return GoNoGo.BackOutPlanStartStepOnNoGo; } set { GoNoGo.BackOutPlanStartStepOnNoGo = value; } }
        public JsonGoNoGo()
        {
            GoNoGo = new(new BackoutPlan());
        }
        public JsonGoNoGo(BackoutPlan plan)
        {
            GoNoGo = new(plan);
        }
        [JsonConstructor]
        public JsonGoNoGo(JsonNamedObject NamedObject, String Description, TaskType GoNoGoType, TaskState GoNoGoState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, JsonTask BackOutPlanStartStepOnNoGo) : base(NamedObject, Description, GoNoGoType, GoNoGoState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.GoNoGoType = GoNoGoType;
            this.GoNoGoState = GoNoGoState;
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
        public JsonGoNoGo(GoNoGo GoNoGo) : base((JsonNamedObject)GoNoGo, GoNoGo.Description, GoNoGo.TaskType, GoNoGo.TaskState, GoNoGo.Command, GoNoGo.AssignedRoles, GoNoGo.RequiredPreRequisiteTasks, GoNoGo.PreWaitTimeSeconds, GoNoGo.DurationSeconds, GoNoGo.PostWaitTimeSeconds, GoNoGo.ReportToPeople, GoNoGo.ReportToTeams)
        {
            this.GoNoGo = GoNoGo;
        }
        public static implicit operator JsonGoNoGo(GoNoGo task)
        {
            return new(task);
        }
        public static implicit operator GoNoGo(JsonGoNoGo task)
        {
            return task.GoNoGo;
        }
    }
    public class GoNoGo : Benchmark
    {
        internal static new string ObjectNameDisplay { get; } = "go / no go task";
        internal Task BackOutPlanStartStepOnNoGo { get; set; }
        public GoNoGo(BackoutPlan plan)
        {
            Init(plan);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, Boolean interactive =false)
        {
            Init(plan, risks, interactive);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, risks, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, risks, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, false, interactive);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, risks, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, risks, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, false, interactive);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, GoNoGo task, Boolean interactive = false)
        {
            Init(plan, risks, task, interactive);
        }
        public GoNoGo(BackoutPlan plan, Risks risks, GoNoGo task)
        {
            Init(plan, risks, task);
        }
        protected override void Init(BackoutPlan plan, Risks risks, Boolean interactive = false)
        {
            Init(plan, risks, "", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, new(), new(), new(), interactive);
        }

        protected virtual void Init(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, risks, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, false, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, risks, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, false, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean useTaskCreate , Boolean interactive )
        {
            base.Init(plan, risks, Name, Description, TaskType.GoNoGo, TaskState.Template, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, false , interactive);
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
        protected void Init(BackoutPlan plan, Risks risks, GoNoGo task, Boolean interactive = false)
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
            BackOutPlanStartStepOnNoGo = task.BackOutPlanStartStepOnNoGo;
        }
        protected override void Init(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
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
                    this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                    break;
            }
        }
        protected void Init(BackoutPlan plan, Risks risks, GoNoGo task)
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
            Console.WriteLine($"\nSet go/no go task backout plan start step on no go");
        }
        internal void DisplayRequestBackOutPlanStartStepOnNoGo(BackoutPlan plan)
        {
            Tasks backoutPlanTasks = plan.Tasks;
            int counter;
            int option = -1;
            Dictionary<int, Task> optionMap = new();
            while(option < 0)
            {
                counter = 1;
                optionMap=new();         
                Console.WriteLine("\n0) Add a new task to the backout plan.");
                foreach(String key in backoutPlanTasks.Keys)
                {
                    optionMap.Add(counter, backoutPlanTasks[key]);
                    backoutPlanTasks[key].Display(true, false, counter);
                    counter++;
                }
                DisplayRequestBackOutPlanStartStepOnNoGoMessage();
                String response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                } catch
                {
                    option = -1;
                }
                if (option == 0)
                {
                    Task task = new(plan, new(), true);
                    backoutPlanTasks.Add(task.Key, task);
                    optionMap.Add(0, task);
                }
                if (!optionMap.Keys.Contains(option)) option = -1;
            }
            BackOutPlanStartStepOnNoGo = optionMap[option];
        }
        internal Boolean HasBackOutPlanStartStepOnNoGo()
        {
            try
            {
                return (BackOutPlanStartStepOnNoGo.Name.Value != "");
            }
            catch
            {
                return false;
            }
        }
        internal void RequestBackOutPlanStartStepOnNoGo(BackoutPlan plan)
        {
            Boolean setRisk = true;
            this.DisplaySetBackOutPlanStartStepOnNoGoMessage();
            if (HasBackOutPlanStartStepOnNoGo())
            {
                Display(false, true, -1);
                DisplayAlreadyDefined(BackOutPlanStartStepOnNoGo.Name.Value);
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setRisk = false;
            }
            if (setRisk) DisplayRequestBackOutPlanStartStepOnNoGo(plan);
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
        internal override GoNoGo CreateCopy(BackoutPlan plan, Risks risks, String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            GoNoGo result = new(plan, risks, this);
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