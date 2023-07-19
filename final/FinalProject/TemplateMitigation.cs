using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonTemplateMitigation), typeDiscriminator: "TemplateMitigation")]
    internal class JsonTemplateMitigation : JsonTemplateTask
    {
        protected TemplateMitigation TemplateMitigation { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return TemplateMitigation;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(TemplateMitigation)))
                {
                    TemplateMitigation = (TemplateMitigation)value;
                }
                else
                {
                    TemplateMitigation = new();
                    TemplateMitigation.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return TemplateMitigation.Description; } set { TemplateMitigation.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateMitigationType")]
        public TaskType TemplateMitigationType { get { return TemplateMitigation.TaskType; } set { TemplateMitigation.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TemplateMitigationState")]
        public TaskState TemplateMitigationState { get { return TemplateMitigation.TaskState; } set { TemplateMitigation.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return TemplateMitigation.Command; } set { TemplateMitigation.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return TemplateMitigation.AssignedRoles; } set { TemplateMitigation.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return TemplateMitigation.RequiredPreRequisiteTasks; } set { TemplateMitigation.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return TemplateMitigation.PreWaitTimeSeconds; } set { TemplateMitigation.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return TemplateMitigation.DurationSeconds; } set { TemplateMitigation.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return TemplateMitigation.PostWaitTimeSeconds; } set { TemplateMitigation.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Risk")]
        public JsonRisk Risk { get { return TemplateMitigation.Risk; } set { TemplateMitigation.Risk = value; } }
        public JsonTemplateMitigation()
        {
            TemplateMitigation = new();
        }
        [JsonConstructor]
        public JsonTemplateMitigation(JsonNamedObject NamedObject, String Description, TaskType TemplateMitigationType, TaskState TemplateMitigationState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, JsonRisk Risk) : base(NamedObject, Description, TemplateMitigationType, TemplateMitigationState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.TemplateMitigationType = TemplateMitigationType;
            this.TemplateMitigationState = TemplateMitigationState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.Risk = Risk;
        }
        public JsonTemplateMitigation(TemplateMitigation TemplateMitigation) : base((JsonNamedObject)TemplateMitigation, TemplateMitigation.Description, TemplateMitigation.TaskType, TemplateMitigation.TaskState, TemplateMitigation.Command, TemplateMitigation.AssignedRoles, TemplateMitigation.RequiredPreRequisiteTasks, TemplateMitigation.PreWaitTimeSeconds, TemplateMitigation.DurationSeconds, TemplateMitigation.PostWaitTimeSeconds)
        {
            this.TemplateMitigation = TemplateMitigation;
        }
        public static implicit operator JsonTemplateMitigation(TemplateMitigation task)
        {
            return new(task);
        }
        public static implicit operator TemplateMitigation(JsonTemplateMitigation task)
        {
            return task.TemplateMitigation;
        }
    }
    public class TemplateMitigation : TemplateTask
    {
        internal static new string ObjectNameDisplay { get; } = "template mitigation task";
        internal Mitigation Mitigation { get; set; } = new (new(), new(), false);
        internal Risk Risk { get { return Mitigation.Risk; } set { Mitigation.Risk = value; } }
        public TemplateMitigation()
        {
            Init();
        }
        public TemplateMitigation(BackoutPlan plan, Risks risks, Boolean interactive)
        {
            Init(plan, risks, interactive);
        }
        public TemplateMitigation(BackoutPlan plan, Risks Risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, Risks, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, Name, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(BackoutPlan plan, Risks Risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, Risks, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(BackoutPlan plan, Risks risks, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(BackoutPlan plan, Risks risks, TemplateMitigation task, Boolean interactive = false)
        {
            Init(plan, risks, task, interactive);
        }
        public TemplateMitigation(BackoutPlan plan, Risks risks, TemplateMitigation task)
        {
            Init(task);
        }
        protected override void Init(BackoutPlan plan, Risks risks, Boolean interactive = false)
        {
            Init(plan, risks, "", NameType.Thing, "", TaskType.Mitigation, TaskState.Template, "", new(), new(), 0, 0, 0, new(), interactive);
        }

        protected virtual void Init(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, false, interactive);
        }

        protected virtual void Init(BackoutPlan plan, Risks Risks, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, Risks, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks Risks, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean useTaskCreate, Boolean interactive)
        {
            base.Init(plan, Risks, Name, Description, TaskType.Mitigation, TaskState.Template, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, useTaskCreate , interactive);
            Mitigation = new Mitigation(plan, Risks, false);
            if (interactive)
            {
                this.Risk = Risk;
                RequestRisk(Risks);
                this.TaskType = TaskType.Mitigation;
                this.TaskState = TaskState.Template;
            }
            else
            {
                this.Risk = Risk;
                this.TaskType = TaskType.Mitigation;
                this.TaskState = TaskState.Template;
            }
        }
        protected void Init(BackoutPlan plan, Risks Risks, TemplateMitigation task, Boolean interactive = false)
        {
            base.Init(plan, Risks, task, interactive);
            Name = task.Name;
            Description = task.Description;
            this.TaskType = TaskType.Mitigation;
            this.TaskState = TaskState.Template;
            Command = task.Command;
            AssignedRoles = task.AssignedRoles;
            RequiredPreRequisiteTasks = task.RequiredPreRequisiteTasks;
            PreWaitTimeSeconds = task.PreWaitTimeSeconds;
            DurationSeconds = task.DurationSeconds;
            PostWaitTimeSeconds = task.PostWaitTimeSeconds;
            Risk = task.Risk;
        }
        protected virtual void Init(BackoutPlan plan, Risks Risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            switch (riskName)
            {
                case "":
                    Init(interactive);
                    break;
                default:
                    base.Init(riskName, riskDescription, interactive);
                    this.TaskType = TaskType.Mitigation;
                    this.TaskState = TaskState.Template;
                    this.Command = Command;
                    this.AssignedRoles = AssignedRoles;
                    this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                    this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                    this.DurationSeconds = DurationSeconds;
                    this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                    this.Risk = Risk;
                    break;
            }
        }
        protected void Init(BackoutPlan plan, Risks Risks, TemplateMitigation task)
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
        protected virtual void DisplayRequestRiskMessage()
        {
            Console.WriteLine($"\nPlease select the {ObjectNameDisplay}.");
        }
        protected virtual void DisplaySetRiskMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay}");
        }
        protected void DisplayRequestRisk(Risks risks)
        {
            Mitigation.DisplayRequestRisk(risks);
        }
        protected Boolean HasRisk()
        {
            return Mitigation.HasRisk();
        }
        internal void RequestRisk(Risks risks)
        {
            Mitigation.RequestRisk(risks);
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
                base.Edit(task,plan,risks);
                Console.Write("\nchange risk (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((TemplateMitigation)task).Risk = new();
                    ((TemplateMitigation)task).RequestRisk(risks);
                }
            }
        }
        internal override TemplateMitigation CreateCopy(BackoutPlan plan, Risks risks, String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            TemplateMitigation result = new(plan, risks, this);
            result.Name = new Name(newName, NameType.Thing);
            return result;
        }
        internal override void Display(int option = -1)
        {
            base.Display(option);
            if (option >= 0) Console.WriteLine(String.Format("{0}   Risk Name:  {1}", new string(' ', option.ToString().Length), Risk.Name.Value));
            else Console.WriteLine(String.Format("\tRisk Name:  {0}", Risk.Name.Value));
        }
        internal override void Display(Boolean name = true, Boolean description = true, int option = -1)
        {
            base.Display(name, description, option);
            if (name && description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("{0}   Risk Name:  {1}", new string(' ', option.ToString().Length), Risk.Name.Value));
                }
                else
                {
                    Console.WriteLine(String.Format("\tRisk Name:  {0}", Risk.Name.Value));
                }
            }
            else if (description)
            {
                if (option >= 0)
                {
                    Console.WriteLine(String.Format("   Risk Name:  {0}", Risk.Name.Value));
                }
                else
                {
                    Console.WriteLine(String.Format("\tRisk Name:  {0}", Risk.Name.Value));
                }
            }
        }
    }
}