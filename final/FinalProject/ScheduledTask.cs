using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonScheduledTask), typeDiscriminator: "ScheduledTask")]
    [JsonDerivedType(typeof(JsonTemplateMitigation), typeDiscriminator: "TemplateMitigation")]
    [JsonDerivedType(typeof(JsonTemplateBenchmark), typeDiscriminator: "TemplateBenchmark")]
    internal class JsonScheduledTask : JsonTemplateTask
    {
        protected ScheduledTask ScheduledTask { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return ScheduledTask;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(ScheduledTask)))
                {
                    ScheduledTask = (ScheduledTask)value;
                }
                else
                {
                    ScheduledTask = new();
                    ScheduledTask.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return ScheduledTask.Description; } set { ScheduledTask.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledTaskType")]
        public TaskType ScheduledTaskType { get { return ScheduledTask.TaskType; } set { ScheduledTask.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledTaskState")]
        public TaskState ScheduledTaskState { get { return ScheduledTask.TaskState; } set { ScheduledTask.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return ScheduledTask.Command; } set { ScheduledTask.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return ScheduledTask.AssignedRoles; } set { ScheduledTask.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return ScheduledTask.RequiredPreRequisiteTasks; } set { ScheduledTask.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return ScheduledTask.PreWaitTimeSeconds; } set { ScheduledTask.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return ScheduledTask.DurationSeconds; } set { ScheduledTask.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return ScheduledTask.PostWaitTimeSeconds; } set { ScheduledTask.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledStart")]
        public DateTime ScheduledStart { get { return ScheduledTask.ScheduledStart; } set { ScheduledTask.ScheduledStart = value; } }
        public JsonScheduledTask()
        {
            ScheduledTask = new();
        }
        [JsonConstructor]
        public JsonScheduledTask(JsonNamedObject NamedObject, String Description, TaskType ScheduledTaskType, TaskState ScheduledTaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart) : base(NamedObject, Description, ScheduledTaskType, ScheduledTaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.ScheduledTaskType = ScheduledTaskType;
            this.ScheduledTaskState = ScheduledTaskState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.ScheduledStart = ScheduledStart;
        }
        public JsonScheduledTask(ScheduledTask ScheduledTask) : base((JsonNamedObject)ScheduledTask, ScheduledTask.Description, ScheduledTask.TaskType, ScheduledTask.TaskState, ScheduledTask.Command, ScheduledTask.AssignedRoles, ScheduledTask.RequiredPreRequisiteTasks, ScheduledTask.PreWaitTimeSeconds, ScheduledTask.DurationSeconds, ScheduledTask.PostWaitTimeSeconds)
        {
            this.ScheduledTask = ScheduledTask;
        }
        public static implicit operator JsonScheduledTask(ScheduledTask task)
        {
            return new(task);
        }
        public static implicit operator ScheduledTask(JsonScheduledTask task)
        {
            return task.ScheduledTask;
        }
    }
    public class ScheduledTask : TemplateTask
    {
        internal static new string ObjectNameDisplay { get; } = "scheduled task";
        internal static DateTime NonDate { get; } = new DateTime(1,1,1,0,0,0,0,1);
        internal DateTime ScheduledStart { get; set; } = NonDate;
        public ScheduledTask()
        {
            Init();
        }
        public ScheduledTask(Boolean interactive)
        {
            Init(interactive);
        }
        public ScheduledTask(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
        {
            Init(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, interactive);
        }
        public ScheduledTask(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
        {
            Init(riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, interactive);
        }
        public ScheduledTask(DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
        {
            Init(name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, interactive);
        }
        public ScheduledTask(Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, interactive);
        }
        public ScheduledTask(ScheduledTask task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public ScheduledTask(ScheduledTask task)
        {
            Init(task);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, new(), interactive);
        }
        protected virtual void Init(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, interactive);
        }
        protected virtual void Init(DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, interactive);
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
                this.ScheduledStart = ScheduledStart;
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
                RequestScheduledStart();
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
                this.ScheduledStart = ScheduledStart;
            }
        }
        protected void Init(ScheduledTask task, Boolean interactive = false)
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
            ScheduledStart = task.ScheduledStart;
        }
        protected virtual void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, Boolean interactive = false)
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
                    this.ScheduledStart = ScheduledStart;
                    break;
            }
        }
        protected void Init(ScheduledTask task)
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
        protected virtual void DisplayRequestScheduledStartMessage()
        {
            Console.WriteLine($"\nPlease enter the start date time of the tast.");
        }
        protected virtual void DisplaySetScheduledStartMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} start date time.");
        }
        protected void DisplayRequestScheduledStart()
        {
            Boolean valid = false;
            while (!valid)
            {
                DisplayRequestScheduledStartMessage();
                String response = IApplication.READ_RESPONSE();
                try
                {
                    ScheduledStart = DateTime.Parse(response);
                    valid = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please use the date format of Dow, DD Mon CCYY HH:MM:SS TZN, where HH is 24 hour clock");
                }
                catch
                {
                    valid = false;
                }
            }
        }
        protected Boolean HasScheduledStart()
        {
            return (ScheduledStart.CompareTo(NonDate) != 0);
        }
        internal void RequestScheduledStart()
        {
            Boolean setDate = true;
            this.DisplaySetScheduledStartMessage();
            if (HasScheduledStart())
            {
                Display(false, true, -1);
                DisplayAlreadyDefined(ScheduledStart.ToString());
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setDate = false;
            }
            if (setDate) DisplayRequestScheduledStart();
        }
        internal override void Edit(Task task, BackoutPlan plan, Risks risks)
        {
            if (task is not null)
            {
                base.Edit(task, plan, risks);
                Console.Write("\nchange start date time (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledTask)task).ScheduledStart = NonDate;
                    ((ScheduledTask)task).RequestScheduledStart();
                }
            }
        }
        internal override ScheduledTask CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            ScheduledTask result = new(this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1) => base.Display(option);
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1) => base.Display(name, description, option);
    }
}