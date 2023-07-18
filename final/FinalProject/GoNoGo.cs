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
        public GoNoGo(Boolean interactive=false)
        {
            Init(interactive);
        }
        public GoNoGo(BackoutPlan plan, Boolean interactive)
        {
            Init(plan, interactive);
        }
        public GoNoGo(BackoutPlan plan, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public GoNoGo(BackoutPlan plan, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public GoNoGo(BackoutPlan plan, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public GoNoGo(BackoutPlan plan, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, List<String> ReportToPeople, List<String> ReportToTeams, Task BackOutPlanStartStepOnNoGo, Boolean interactive = false)
        {
            Init(plan, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ReportToPeople, ReportToTeams, BackOutPlanStartStepOnNoGo, interactive);
        }
        public GoNoGo(GoNoGo task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public GoNoGo(GoNoGo task)
        {
            Init(task);
        }
        protected override void Init(Boolean interactive = false)
        {
            if(!interactive) {
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
            Init(plan, "", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, new(), new(), new(), interactive);
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
            base.Init(Name, Description, interactive);
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
                this.TaskType = TaskType.Task;
                this.TaskState = TaskState.Template;
                this.ReportToPeople = ReportToPeople;
                this.ReportToTeams = ReportToTeams;
                this.BackOutPlanStartStepOnNoGo = BackOutPlanStartStepOnNoGo;
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
                RequestReportToPeople();
                RequestReportToTeams();
                RequestBackOutPlanStartStepOnNoGo(plan);
            }
            else
            {
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
            }
        }
        protected void Init(GoNoGo task, Boolean interactive = false)
        {
            base.Init(task, interactive);
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
        protected override void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
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
        protected void Init(GoNoGo task)
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
            while(option < 1)
            {
                counter = 1;
                optionMap=new();
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
        internal override GoNoGo CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            GoNoGo result = new(this);
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
                    Console.WriteLine(String.Format("\t{0}", typeMap[TaskType]));
                    Console.WriteLine(String.Format("\t{0}", stateMap[TaskState]));
                    Console.WriteLine(String.Format("\tCommand:  {0}", Command));
                    int counter = 1;
                    foreach (String role in AssignedRoles)
                    {
                        Console.WriteLine(String.Format("\tRole {0}:  {1}", counter, role));
                        counter++;
                    }
                    counter = 1;
                    foreach (String preRequisite in RequiredPreRequisiteTasks)
                    {
                        Console.WriteLine(String.Format("\tPreRequisite {0}:  {1}", counter, preRequisite));
                        counter++;
                    }
                    Console.WriteLine(String.Format("\tPre-Wait:  {0} Seconds", PreWaitTimeSeconds));
                    Console.WriteLine(String.Format("\tDuration:  {0} Seconds", DurationSeconds));
                    Console.WriteLine(String.Format("\tPost-Wait:  {0} Seconds", PostWaitTimeSeconds));
                    counter = 1;
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
                    Console.WriteLine(String.Format("\t{0}", typeMap[TaskType]));
                    Console.WriteLine(String.Format("\t{0}", stateMap[TaskState]));
                    Console.WriteLine(String.Format("\tCommand:  {0}", Command));
                    int counter = 1;
                    foreach (String role in AssignedRoles)
                    {
                        Console.WriteLine(String.Format("\tRole {0}:  {1}", counter, role));
                        counter++;
                    }
                    counter = 1;
                    foreach (String preRequisite in RequiredPreRequisiteTasks)
                    {
                        Console.WriteLine(String.Format("\tPreRequisite {0}:  {1}", counter, preRequisite));
                        counter++;
                    }
                    Console.WriteLine(String.Format("\tPre-Wait:  {0} Seconds", PreWaitTimeSeconds));
                    Console.WriteLine(String.Format("\tDuration:  {0} Seconds", DurationSeconds));
                    Console.WriteLine(String.Format("\tPost-Wait:  {0} Seconds", PostWaitTimeSeconds));

                    counter = 1;
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