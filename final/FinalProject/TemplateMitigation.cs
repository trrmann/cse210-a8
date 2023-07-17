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
        internal Mitigation Mitigation { get; set; } = new();
        internal Risk Risk { get { return Mitigation.Risk; } set { Mitigation.Risk = value; } }
        public TemplateMitigation()
        {
            Init();
        }
        public TemplateMitigation(Risks risks, Boolean interactive)
        {
            Init(risks, interactive);
        }
        public TemplateMitigation(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public TemplateMitigation(TemplateMitigation task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public TemplateMitigation(TemplateMitigation task)
        {
            Init(task);
        }
        protected override void Init(Boolean interactive = false)
        {
            Risks risks = new Risks();
            Init(risks, interactive);
        }
        protected virtual void Init(Risks risks, Boolean interactive = false)
        {
            Init(risks, "", NameType.Thing, "", TaskType.Mitigation, TaskState.Template, "", new(), new(), 0, 0, 0, new(), interactive);
        }

        protected virtual void Init(Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, risks, Risk, interactive);
        }

        protected virtual void Init(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        protected virtual void Init(DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        protected virtual void Init(Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risks Risks, Risk Risk, Boolean interactive = false)
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
                this.TaskType = TaskType.Mitigation;
                this.TaskState = TaskState.Template;
                this.Risk = Risk;
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
                RequestRisk(Risks);
            }
            else
            {
                this.TaskType = TaskType.Mitigation;
                this.TaskState = TaskState.Template;
                this.Command = Command;
                this.AssignedRoles = AssignedRoles;
                this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                this.DurationSeconds = DurationSeconds;
                this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                this.Risk = Risk;
            }
        }
        protected void Init(TemplateMitigation task, Boolean interactive = false)
        {
            base.Init(task, interactive);
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
        protected virtual void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
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
        protected void Init(TemplateMitigation task)
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
        protected virtual void DisplayRequestRiskMessage()
        {
            Console.WriteLine("\nPlease select the template mitigation task risk.");
        }
        protected virtual void DisplaySetRiskMessage()
        {
            Console.WriteLine("\nSet teamplate mitigation task risk");
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
        internal override TemplateMitigation CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            TemplateMitigation result = new(this);
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
            if (option >= 0) Console.WriteLine(String.Format("{0}   Risk:  {1}", new string(' ', option.ToString().Length), Risk.Name));
            else Console.WriteLine(String.Format("\tRisk:  {0}", Risk.Name));
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
                    Console.WriteLine(String.Format("{0}   Risk:  {1}", new string(' ', option.ToString().Length), Risk.Name));
                }
                else
                {
                    Console.WriteLine(String.Format("\tRisk:  {0}", Risk.Name.Value));
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
                    Console.WriteLine(String.Format("   Risk:  {0}", Risk.Name));
                }
                else
                {
                    Console.WriteLine(String.Format("\tRisk:  {0}", Risk.Name.Value));
                }
            }
        }
    }
}