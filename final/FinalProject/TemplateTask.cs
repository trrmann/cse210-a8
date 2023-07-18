using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonScheduledTask), typeDiscriminator: "ScheduledTask")]
    [JsonDerivedType(typeof(JsonTemplateTask), typeDiscriminator: "TemplateTask")]
    [JsonDerivedType(typeof(JsonTemplateMitigation), typeDiscriminator: "TemplateMitigation")]
    [JsonDerivedType(typeof(JsonTemplateBenchmark), typeDiscriminator: "TemplateBenchmark")]
    [JsonDerivedType(typeof(JsonTemplateGoNoGo), typeDiscriminator: "TemplateGoNoGo")]
    internal class JsonTemplateTask : JsonTask
    {
        protected TemplateTask TemplateTask { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return TemplateTask;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(TemplateTask)))
                {
                    TemplateTask = (TemplateTask)value;
                }
                else
                {
                    TemplateTask = new();
                    TemplateTask.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return TemplateTask.Description; } set { TemplateTask.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateTaskType")]
        public TaskType TemplateTaskType { get { return TemplateTask.TaskType; } set { TemplateTask.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateTaskState")]
        public TaskState TemplateTaskState { get { return TemplateTask.TaskState; } set { TemplateTask.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return TemplateTask.Command; } set { TemplateTask.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return TemplateTask.AssignedRoles; } set { TemplateTask.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return TemplateTask.RequiredPreRequisiteTasks; } set { TemplateTask.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return TemplateTask.PreWaitTimeSeconds; } set { TemplateTask.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return TemplateTask.DurationSeconds; } set { TemplateTask.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return TemplateTask.PostWaitTimeSeconds; } set { TemplateTask.PostWaitTimeSeconds = value; } }
        public JsonTemplateTask()
        {
            TemplateTask = new();
        }
        [JsonConstructor]
        public JsonTemplateTask(JsonNamedObject NamedObject, String Description, TaskType TemplateTaskType, TaskState TemplateTaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds) : base(NamedObject, Description, TemplateTaskType, TemplateTaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.TemplateTaskType = TemplateTaskType;
            this.TemplateTaskState = TemplateTaskState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
        }
        public JsonTemplateTask(TemplateTask TemplateTask) : base((JsonNamedObject)TemplateTask, TemplateTask.Description, TemplateTask.TaskType,TemplateTask.TaskState, TemplateTask.Command, TemplateTask.AssignedRoles,TemplateTask.RequiredPreRequisiteTasks, TemplateTask.PreWaitTimeSeconds, TemplateTask.DurationSeconds, TemplateTask.PostWaitTimeSeconds)
        {
            this.TemplateTask = TemplateTask;
        }
        public static implicit operator JsonTemplateTask(TemplateTask task)
        {
            return new(task);
        }
        public static implicit operator TemplateTask(JsonTemplateTask task)
        {
            return task.TemplateTask;
        }
    }
    public class TemplateTask : Task
    {
        internal static new string ObjectNameDisplay { get; } = "template task";
        public TemplateTask()
        {
            Init();
        }
        public TemplateTask(Boolean interactive)
        {
            Init(interactive);
        }
        public TemplateTask(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public TemplateTask(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public TemplateTask(DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public TemplateTask(Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public TemplateTask(TemplateTask task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public TemplateTask(TemplateTask task)
        {
            Init(task);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, interactive);
        }
        protected override void Init(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        protected override void Init(DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        protected override void Init(Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
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
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
            }
            else
            {
                this.Command = Command;
                this.AssignedRoles = AssignedRoles;
                this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                this.DurationSeconds = DurationSeconds;
                this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                this.TaskType = TaskType.Task;
                this.TaskState = TaskState.Template;
            }
        }
        protected void Init(TemplateTask task, Boolean interactive = false)
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
        }
        protected override void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
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
                    break;
            }
        }
        protected void Init(TemplateTask task)
        {
            Name = task.Name;
            Description = task.Description;
        }
        protected override void DisplaySetNameMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} name");
        protected override void DisplaySetDescriptionMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} Description");
        protected override void DisplayRequestNameMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} name.");
        protected override void DisplayRequestDescriptionMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} description.");
        protected override void DisplayRequestTaskTypeMessage() => base.DisplayRequestTaskTypeMessage();
        protected override void DisplaySetTaskTypeMessage() => base.DisplaySetTaskTypeMessage();
        protected override void DisplayRequestTaskStateMessage() => base.DisplayRequestTaskStateMessage();
        protected override void DisplaySetTaskStateMessage() => base.DisplaySetTaskStateMessage();
        protected override void DisplayRequestCommandMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} command.");
        protected override void DisplaySetCommandMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} command");
        protected override void DisplayRequestAssignedRolesMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} list of comma separated assigned roles.");
        protected override void DisplaySetAssignedRolesMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} assigned roles");
        protected override void DisplayRequestRequiredPreRequisiteTasksMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} comma separated list of required pre-requisite tasks.");
        protected override void DisplaySetRequiredPreRequisiteTasksMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} required pre-requisite tasks");
        protected override void DisplayRequestPreWaitTimeSecondsMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} pre-wait time in seconds.");
        protected override void DisplaySetPreWaitTimeSecondsMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} pre-wait time seconds");
        protected override void DisplayRequestDurationSecondsMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} duration in seconds.");
        protected override void DisplaySetDurationSecondsMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} duration in seconds");
        protected override void DisplayRequestPostWaitTimeSecondsMessage() => Console.WriteLine($"\nPlease enter the {ObjectNameDisplay} post-wait time in seconds.");
        protected override void DisplaySetPostWaitTimeSecondsMessage() => Console.WriteLine($"\nSet {ObjectNameDisplay} post-wait time seconds");
        internal override void DisplayAddMessage(Plan plan) => Console.WriteLine($"\nAdd a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        internal override void DisplayAlreadyDefined(string value)
        {
            Console.WriteLine($"{value} already defined.");
            Console.Write("overwrite (y/n)");
        }
        internal override void DisplaySelectMessage() => Console.Write($"Select a {ObjectNameDisplay}");
        internal override void DisplayCopyMessage(Plan plan) => Console.WriteLine($"\nCopy a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        internal override void DisplayEditMessage(Plan plan) => Console.WriteLine($"\nEdit a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        internal override void DisplayRemoveMessage(Plan plan) => Console.WriteLine($"\nRemove a {ObjectNameDisplay} ({plan.GetNameForMenus()})");
        internal override void DisplayListMessage(Plan plan) => Console.WriteLine($"\nDisplay {ObjectNameDisplay}s ({plan.GetNameForMenus()})\n");
        internal override void DisplayExportMessage(Plan plan) => Console.WriteLine($"\nExport {ObjectNameDisplay}s ({plan.GetNameForMenus()})\n");
        internal override void DisplayImportMessage(Plan plan) => Console.WriteLine($"\nImport {ObjectNameDisplay}s ({plan.GetNameForMenus()})\n");
        internal override void Edit(Task task, BackoutPlan plan, Risks risks) => base.Edit(task, plan, risks);
        internal override TemplateTask CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            TemplateTask result = new(this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1) => base.Display(option);
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1) => base.Display(name, description, option);
    }
}