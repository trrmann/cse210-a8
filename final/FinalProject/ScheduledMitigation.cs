using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonScheduledMitigation), typeDiscriminator: "ScheduledMitigation")]
    internal class JsonScheduledMitigation : JsonScheduledTask
    {
        protected ScheduledMitigation ScheduledMitigation { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return ScheduledMitigation;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(ScheduledMitigation)))
                {
                    ScheduledMitigation = (ScheduledMitigation)value;
                }
                else
                {
                    ScheduledMitigation = new();
                    ScheduledMitigation.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return ScheduledMitigation.Description; } set { ScheduledMitigation.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledMitigationType")]
        public TaskType ScheduledMitigationType { get { return ScheduledMitigation.TaskType; } set { ScheduledMitigation.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledMitigationState")]
        public TaskState ScheduledMitigationState { get { return ScheduledMitigation.TaskState; } set { ScheduledMitigation.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return ScheduledMitigation.Command; } set { ScheduledMitigation.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return ScheduledMitigation.AssignedRoles; } set { ScheduledMitigation.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return ScheduledMitigation.RequiredPreRequisiteTasks; } set { ScheduledMitigation.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return ScheduledMitigation.PreWaitTimeSeconds; } set { ScheduledMitigation.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return ScheduledMitigation.DurationSeconds; } set { ScheduledMitigation.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return ScheduledMitigation.PostWaitTimeSeconds; } set { ScheduledMitigation.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("ScheduledStart")]
        public new DateTime ScheduledStart { get { return ScheduledMitigation.ScheduledStart; } set { ScheduledMitigation.ScheduledStart = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignmentOwnerName")]
        public new String AssignmentOwnerName { get { return ScheduledMitigation.AssignmentOwnerName; } set { ScheduledMitigation.AssignmentOwnerName = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Risk")]
        public JsonRisk Risk { get { return ScheduledMitigation.Risk; } set { ScheduledMitigation.Risk = value; } }
        public JsonScheduledMitigation()
        {
            ScheduledMitigation = new();
        }
        [JsonConstructor]
        public JsonScheduledMitigation(JsonNamedObject NamedObject, String Description, TaskType ScheduledMitigationType, TaskState ScheduledMitigationState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, JsonRisk Risk) : base(NamedObject, Description, ScheduledMitigationType, ScheduledMitigationState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.ScheduledMitigationType = ScheduledMitigationType;
            this.ScheduledMitigationState = ScheduledMitigationState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.ScheduledStart = ScheduledStart;
            this.AssignmentOwnerName = AssignmentOwnerName;
            this.Risk = Risk;
        }
        public JsonScheduledMitigation(ScheduledMitigation ScheduledMitigation) : base((JsonNamedObject)ScheduledMitigation, ScheduledMitigation.Description, ScheduledMitigation.TaskType, ScheduledMitigation.TaskState, ScheduledMitigation.Command, ScheduledMitigation.AssignedRoles, ScheduledMitigation.RequiredPreRequisiteTasks, ScheduledMitigation.PreWaitTimeSeconds, ScheduledMitigation.DurationSeconds, ScheduledMitigation.PostWaitTimeSeconds, ScheduledMitigation.ScheduledStart, ScheduledMitigation.AssignmentOwnerName)
        {
            this.ScheduledMitigation = ScheduledMitigation;
        }
        public static implicit operator JsonScheduledMitigation(ScheduledMitigation task)
        {
            return new(task);
        }
        public static implicit operator ScheduledMitigation(JsonScheduledMitigation task)
        {
            return task.ScheduledMitigation;
        }
    }
    public class ScheduledMitigation : ScheduledTask
    {
        internal static new string ObjectNameDisplay { get; } = "scheduled mitigation task";
        internal Mitigation Mitigation { get; set; } = new();
        internal Risk Risk { get { return Mitigation.Risk; } set { Mitigation.Risk = value; } }
        public ScheduledMitigation()
        {
            Init();
        }
        public ScheduledMitigation(Risks risks, Boolean interactive)
        {
            Init(risks, interactive);
        }
        public ScheduledMitigation(Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, Risk Risk, Boolean interactive = false)
        {
            Init(risks, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, Risk, interactive);
        }
        public ScheduledMitigation(Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, Risk Risk, Boolean interactive = false)
        {
            Init(risks, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, Risk, interactive);
        }
        public ScheduledMitigation(Risks risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, Risk Risk, Boolean interactive = false)
        {
            Init(risks, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, Risk, interactive);
        }
        public ScheduledMitigation(Risks risks, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(risks, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, Risk, interactive);
        }
        public ScheduledMitigation(ScheduledMitigation task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        public ScheduledMitigation(ScheduledMitigation task)
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
            Init(risks, "", NameType.Thing, "", TaskType.Mitigation, TaskState.Template, "", new(), new(), 0, 0, 0, new(), "", new(), interactive);
        }
        protected virtual void Init(Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, Risk Risk, Boolean interactive = false)
        {
            Init(risks, new DescribedObject(new Name(name, type), Description), TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, Risk, interactive);
        }
        protected virtual void Init(Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, Risk Risk, Boolean interactive = false)
        {
            Init(risks, new DescribedObject(new Name(riskName, NameType.Thing), riskDescription), TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, ScheduledStart, AssignmentOwnerName, Risk, interactive);
        }
        protected virtual void Init(Risks risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, DateTime ScheduledStart, String AssignmentOwnerName, Risk Risk, Boolean interactive = false)
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
                this.ScheduledStart = ScheduledStart;
                this.AssignmentOwnerName = AssignmentOwnerName;
                this.Risk = Risk;
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
                RequestScheduledStart();
                RequestAssignmentOwnerName();
                RequestRisk(risks);
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
                this.ScheduledStart = ScheduledStart;
                this.AssignmentOwnerName = AssignmentOwnerName;
                this.Risk = Risk;
            }
        }
        protected void Init(ScheduledMitigation task, Boolean interactive = false)
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
            ScheduledStart = task.ScheduledStart;
            AssignmentOwnerName = task.AssignmentOwnerName;
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
                    this.ScheduledStart = ScheduledStart;
                    this.AssignmentOwnerName = AssignmentOwnerName;
                    this.Risk = Risk;
                    break;
            }
        }
        protected void Init(ScheduledMitigation task)
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
                base.Edit(task, plan, risks);
                Console.Write("\nchange start date time (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledTask)task).ScheduledStart = NonDate;
                    ((ScheduledTask)task).RequestScheduledStart();
                }
                Console.Write("\nchange assignment (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledTask)task).AssignmentOwnerName = "";
                    ((ScheduledTask)task).RequestAssignmentOwnerName();
                }
                Console.Write("\nchange risk (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((ScheduledMitigation)task).Risk = new();
                    ((ScheduledMitigation)task).RequestRisk(risks);
                }
            }
        }
        internal override ScheduledMitigation CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            ScheduledMitigation result = new(this);
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