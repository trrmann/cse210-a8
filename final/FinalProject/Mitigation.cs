using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonMitigation), typeDiscriminator: "Mitigation")]
    internal class JsonMitigation : JsonTask
    {
        protected Mitigation Mitigation { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return Mitigation;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(Mitigation)))
                {
                    Mitigation = (Mitigation)value;
                }
                else
                {
                    Mitigation = new();
                    Mitigation.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return Mitigation.Description; } set { Mitigation.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("MitigationType")]
        public TaskType MitigationType { get { return Mitigation.TaskType; } set { Mitigation.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("MitigationState")]
        public TaskState MitigationState { get { return Mitigation.TaskState; } set { Mitigation.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public new String Command { get { return Mitigation.Command; } set { Mitigation.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public new List<String> AssignedRoles { get { return Mitigation.AssignedRoles; } set { Mitigation.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public new List<String> RequiredPreRequisiteTasks { get { return Mitigation.RequiredPreRequisiteTasks; } set { Mitigation.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public new int PreWaitTimeSeconds { get { return Mitigation.PreWaitTimeSeconds; } set { Mitigation.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public new int DurationSeconds { get { return Mitigation.DurationSeconds; } set { Mitigation.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public new int PostWaitTimeSeconds { get { return Mitigation.PostWaitTimeSeconds; } set { Mitigation.PostWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Risk")]
        public JsonRisk Risk { get { return Mitigation.Risk; } set { Mitigation.Risk = value; } }
        public JsonMitigation()
        {
            Mitigation = new();
        }
        [JsonConstructor]
        public JsonMitigation(JsonNamedObject NamedObject, String Description, TaskType MitigationType, TaskState MitigationState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, JsonRisk Risk) : base(NamedObject, Description, MitigationType, MitigationState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.MitigationType = MitigationType;
            this.MitigationState = MitigationState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            this.Risk= Risk;
        }
        public JsonMitigation(Mitigation Mitigation) : base((JsonNamedObject)Mitigation, Mitigation.Description, Mitigation.TaskType, Mitigation.TaskState, Mitigation.Command, Mitigation.AssignedRoles, Mitigation.RequiredPreRequisiteTasks, Mitigation.PreWaitTimeSeconds, Mitigation.DurationSeconds, Mitigation.PostWaitTimeSeconds)
        {
            this.Mitigation = Mitigation;
        }
        public static implicit operator JsonMitigation(Mitigation task)
        {
            return new(task);
        }
        public static implicit operator Mitigation(JsonMitigation task)
        {
            return task.Mitigation;
        }
    }
    public class Mitigation : Task
    {
        internal static new string ObjectNameDisplay { get; } = "mitigation task";
        internal Risk Risk { get; set; }
        public Mitigation()
        {
            Init();
        }
        public Mitigation(BackoutPlan plan, Risks risks, Boolean interactive)
        {
            Init(plan, risks, interactive);
        }
        public Mitigation(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public Mitigation(BackoutPlan plan, Risks risks, String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public Mitigation(BackoutPlan plan, Risks risks, DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public Mitigation(BackoutPlan plan, Risks risks, Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        public Mitigation(BackoutPlan plan, Risks risks, Mitigation task, Boolean interactive = false)
        {
            Init(plan, risks, task, interactive);
        }
        public Mitigation(BackoutPlan plan, Risks risks, Mitigation task)
        {
            Init(plan, risks, task);
        }
        protected override void Init(BackoutPlan plan, Risks risks, Boolean interactive = false)
        {
            Init(plan, risks, "", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, new(), interactive);
        }

        protected virtual void Init(BackoutPlan plan, Risks risks, String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, risks, Risk, false, interactive);
        }

        protected virtual void Init(BackoutPlan plan, Risks risks, DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risk Risk, Boolean interactive = false)
        {
            Init(plan, risks, Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, Risk, interactive);
        }
        protected virtual void Init(BackoutPlan plan, Risks risks, Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Risks Risks, Risk Risk, Boolean useTaskCreate , Boolean interactive )
        {
            base.Init(plan, risks, Name, Description, TaskType.Mitigation, TaskState.Template, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, false, interactive);
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
        protected void Init(BackoutPlan plan, Risks risks, Mitigation task, Boolean interactive = false)
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
            Risk = task.Risk;
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
                    this.Risk = Risk;
                        break;
            }
        }
        protected void Init(BackoutPlan plan, Risks risks, Mitigation task)
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
            Console.WriteLine($"\nPlease select the {ObjectNameDisplay} risk.");
        }
        protected virtual void DisplaySetRiskMessage()
        {
            Console.WriteLine($"\nSet {ObjectNameDisplay} risk");
        }
        internal void DisplayRequestRisk(Risks risks)
        {
            String response;
            int counter;
            Risk risk = new();
            int option = -1;
            Dictionary<int, Risk> optionMap = new();
            while(option < 0)
            {
                optionMap = new();
                counter = 1;
                Console.WriteLine("0)  Add and use a new risk.");
                foreach(String key in risks.Keys)
                {
                    risk= risks[key];
                    risk.Display(true, false, counter);
                    optionMap.Add(counter, risk);
                    counter++;
                }
                DisplayRequestRiskMessage();
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                } catch
                {
                    option = -1;
                }
                if (option != 0 && !optionMap.Keys.Contains(option)) option = -1;
                if (option == 0)
                {
                    optionMap.Add(0, new(true));
                    risks.Add(optionMap[0].Key, optionMap[0]);
                }
            }
            Risk = optionMap[option];
        }
        internal Boolean HasRisk()
        {
            return (Risk.Name.Value != "");
        }
        internal void RequestRisk(Risks risks)
        {
            Boolean setRisk = true;
            this.DisplaySetRiskMessage();
            if (HasRisk())
            {
                Display(false, true, -1);
                DisplayAlreadyDefined(Risk.Name.Value);
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setRisk = false;
            }
            if (setRisk) DisplayRequestRisk(risks);
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
                Console.Write("\nchange risk (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    ((TemplateMitigation)task).Risk = new();
                    ((TemplateMitigation)task).RequestRisk(risks);
                }
            }
        }
        internal override Mitigation CreateCopy(BackoutPlan plan, Risks risks, String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            Mitigation result = new(plan, risks, this);
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