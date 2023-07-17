using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonTask), typeDiscriminator: "Task")]
    [JsonDerivedType(typeof(JsonBenchmark), typeDiscriminator: "Benchmark")]
    [JsonDerivedType(typeof(JsonMitigation), typeDiscriminator: "Mitigation")]
    [JsonDerivedType(typeof(JsonTemplateTask), typeDiscriminator: "TemplateTask")]
    [JsonDerivedType(typeof(JsonTemplateMitigation), typeDiscriminator: "TemplateMitigation")]
    [JsonDerivedType(typeof(JsonTemplateBenchmark), typeDiscriminator: "TemplateBenchmark")]
    [JsonDerivedType(typeof(JsonGoNoGo), typeDiscriminator: "GoNoGo")]
    internal class JsonTask : JsonDescribedObject
    {
        protected Task Task { get; set; }
        [JsonPropertyOrder(-5)]
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return Task;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(Task)))
                {
                    Task = (Task)value;
                }
                else
                {
                    Task = new();
                    Task.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return Task.Description; } set { Task.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TaskType")]
        public TaskType TaskType { get { return Task.TaskType; } set { Task.TaskType = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("TaskState")]
        public TaskState TaskState { get { return Task.TaskState; } set { Task.TaskState = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Command")]
        public String Command { get { return Task.Command; } set { Task.Command = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("AssignedRoles")]
        public List<String> AssignedRoles { get { return Task.AssignedRoles; } set { Task.AssignedRoles = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("RequiredPreRequisiteTasks")]
        public List<String> RequiredPreRequisiteTasks { get { return Task.RequiredPreRequisiteTasks; } set { Task.RequiredPreRequisiteTasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PreWaitTimeSeconds")]
        public int PreWaitTimeSeconds { get { return Task.PreWaitTimeSeconds; } set { Task.PreWaitTimeSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("DurationSeconds")]
        public int DurationSeconds { get { return Task.DurationSeconds; } set { Task.DurationSeconds = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("PostWaitTimeSeconds")]
        public int PostWaitTimeSeconds { get { return Task.PostWaitTimeSeconds; } set { Task.PostWaitTimeSeconds = value; } }
        public JsonTask()
        {
            Task = new();
        }
        [JsonConstructor]
        public JsonTask(JsonNamedObject NamedObject, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds) : base(NamedObject, Description)
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.TaskType = TaskType;
            this.TaskState = TaskState;
            this.Command = Command;
            this.AssignedRoles = AssignedRoles;
            this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
            this.PreWaitTimeSeconds = PreWaitTimeSeconds;
            this.DurationSeconds = DurationSeconds;
            this.PostWaitTimeSeconds = PostWaitTimeSeconds;
        }
        public JsonTask(Task Task) : base(Task, Task.Description)
        {
            this.Task = Task;
        }
        public static implicit operator JsonTask(Task task)
        {
            if (typeof(TemplateBenchmark).IsInstanceOfType(task))
            {
                return new JsonTemplateBenchmark((TemplateBenchmark)task);
            };
            if (typeof(Benchmark).IsInstanceOfType(task))
            {
                return new JsonBenchmark((Benchmark)task);
            };
            if (typeof(TemplateMitigation).IsInstanceOfType(task))
            {
                return new JsonTemplateMitigation((TemplateMitigation)task);
            };
            if (typeof(Mitigation).IsInstanceOfType(task))
            {
                return new JsonMitigation((Mitigation)task);
            };
            if (typeof(TemplateTask).IsInstanceOfType(task))
            {
                return new JsonTemplateTask((TemplateTask)task);
            };
            if (typeof(Task).IsInstanceOfType(task))
            {
                return new JsonTask(task);
            };
            return new(task);
        }
        public static implicit operator Task(JsonTask task)
        {
            if (typeof(JsonTemplateBenchmark).IsInstanceOfType(task))
            {
                JsonTemplateBenchmark jsonTemplateBenchmark = (JsonTemplateBenchmark)task;
                TemplateBenchmark templateBenchmark = new TemplateBenchmark(jsonTemplateBenchmark);
                return templateBenchmark;
            };
            if (typeof(JsonBenchmark).IsInstanceOfType(task))
            {
                JsonBenchmark jsonBenchmark = (JsonBenchmark)task;
                Benchmark benchmark = new Benchmark(jsonBenchmark);
                return benchmark;
            };
            if (typeof(JsonTemplateMitigation).IsInstanceOfType(task))
            {
                JsonTemplateMitigation jsonTemplateMitigation = (JsonTemplateMitigation)task;
                TemplateMitigation templateMitigation = new TemplateMitigation(jsonTemplateMitigation);
                return templateMitigation;
            };
            if (typeof(JsonMitigation).IsInstanceOfType(task))
            {
                JsonMitigation jsonMitigation = (JsonMitigation)task;
                Mitigation mitigation = new Mitigation(jsonMitigation);
                return mitigation;
            };
            if (typeof(JsonTemplateTask).IsInstanceOfType(task))
            {
                JsonTemplateTask jsonTemplateTask = (JsonTemplateTask)task;
                TemplateTask templateTask = new TemplateTask(jsonTemplateTask);
                return templateTask;
            };
            if (typeof(JsonTask).IsInstanceOfType(task))
            {
                return task.Task;
            };
            return task.Task;
        }
    }
    public class Task : DescribedObject
    {
        internal TaskType TaskType { get; set; } = TaskType.Task;
        internal TaskState TaskState { get; set; } = TaskState.Template;
        internal String Command { get; set; } = "";
        internal List<String> AssignedRoles { get; set; } = new();
        internal List<String> RequiredPreRequisiteTasks { get; set; } = new();
        internal int PreWaitTimeSeconds { get; set; } = 0;
        internal int DurationSeconds { get; set; } = 0;
        internal int PostWaitTimeSeconds { get; set; } = 0;
        public Task()
        {
            Init();
        }
        public Task(Boolean interactive)
        {
            Init(interactive);
        }
        public Task(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public Task(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(riskName, riskDescription, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public Task(DescribedObject name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(name, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public Task(Name name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(name, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        public Task(Task task, Boolean interactive = false)
        {
            Init(task, interactive);
        }
        protected override void Init(Boolean interactive = false)
        {
            Init("", NameType.Thing, "", TaskType.Task, TaskState.Template, "", new(), new(), 0, 0, 0, interactive);
        }
        protected virtual void Init(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(new Name(name, type), Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        protected virtual void Init(DescribedObject Name, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            Init(Name.Name, Name.Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds, interactive);
        }
        protected virtual void Init(Name Name, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
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
                RequestTaskType();
                RequestTaskState();
                RequestCommand();
                RequestAssignedRoles();
                RequestRequiredPreRequisiteTasks();
                RequestPreWaitTimeSeconds();
                RequestDurationSeconds();
                RequestPostWaitTimeSeconds();
            }
            else
            {
                this.TaskType = TaskType;
                this.TaskState = TaskState;
                this.Command = Command;
                this.AssignedRoles = AssignedRoles;
                this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                this.DurationSeconds = DurationSeconds;
                this.PostWaitTimeSeconds = PostWaitTimeSeconds;
            }
        }
        protected virtual void Init(Task task, Boolean interactive = false)
        {
            base.Init(task, interactive);
            Name = task.Name;
            Description = task.Description;
            TaskType = task.TaskType;
            TaskState = task.TaskState;
            Command = task.Command;
            AssignedRoles = task.AssignedRoles;
            RequiredPreRequisiteTasks = task.RequiredPreRequisiteTasks;
            PreWaitTimeSeconds = task.PreWaitTimeSeconds;
            DurationSeconds = task.DurationSeconds;
            PostWaitTimeSeconds = task.PostWaitTimeSeconds;
        }
        protected virtual void Init(String riskName, String riskDescription, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds, Boolean interactive = false)
        {
            switch (riskName)
            {
                case "":
                    Init(interactive);
                    break;
                default:
                    base.Init(riskName, riskDescription, interactive);
                    this.TaskType = TaskType;
                    this.TaskState = TaskState;
                    this.Command = Command;
                    this.AssignedRoles = AssignedRoles;
                    this.RequiredPreRequisiteTasks = RequiredPreRequisiteTasks;
                    this.PreWaitTimeSeconds = PreWaitTimeSeconds;
                    this.DurationSeconds = DurationSeconds;
                    this.PostWaitTimeSeconds = PostWaitTimeSeconds;
                    break;
            }
        }
        protected override void DisplaySetNameMessage()
        {
            Console.WriteLine("\nSet task name");
        }
        protected override void DisplaySetDescriptionMessage()
        {
            Console.WriteLine("\nSet task Description");
        }
        protected override void DisplayRequestNameMessage()
        {
            Console.WriteLine("\nPlease enter the task name.");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine("\nPlease enter the task description.");
        }
        protected virtual void DisplayRequestTaskTypeMessage()
        {
            Console.WriteLine("\nPlease enter the task type.");
        }
        protected virtual void DisplaySetTaskTypeMessage()
        {
            Console.WriteLine("\nSet task type");
        }
        protected void DisplayRequestTaskType()
        {
            DisplayRequestTaskTypeMessage();
            Dictionary<int, Tuple<TaskType, String>> optionMap = ITaskTypeUtiltities.typeOptionMap();
            int option = 0;
            String response;
            while (option<1)
            {
                foreach (int key in optionMap.Keys)
                {
                    Console.WriteLine($"{key})  {optionMap[key].Item2}");
                }
                Console.Write("Select the task type");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = -1;

                }
                if (!optionMap.ContainsKey(option)) option = -1;
            }
            TaskType = optionMap[option].Item1;
        }
        internal void RequestTaskType()
        {
            this.DisplaySetTaskTypeMessage();
            Display(false, true, -1);
            DisplayRequestTaskType();
        }
        protected virtual void DisplayRequestTaskStateMessage()
        {
            Console.WriteLine("\nPlease enter the task state.");
        }
        protected virtual void DisplaySetTaskStateMessage()
        {
            Console.WriteLine("\nSet task state");
        }
        protected void DisplayRequestTaskState()
        {
            DisplayRequestTaskStateMessage();
            Dictionary<int, Tuple<TaskState, String>> optionMap = ITaskStateUtiltities.stateOptionMap();
            int option = 0;
            String response;
            while (option < 1)
            {
                foreach (int key in optionMap.Keys)
                {
                    Console.WriteLine($"{key})  {optionMap[key].Item2}");
                }
                Console.Write("Select the task state");
                response = IApplication.READ_RESPONSE();
                try
                {
                    option = int.Parse(response);
                }
                catch
                {
                    option = -1;

                }
                if (!optionMap.ContainsKey(option)) option = -1;
            }
            TaskState = optionMap[option].Item1;
        }
        internal void RequestTaskState()
        {
            this.DisplaySetTaskStateMessage();
            Display(false, true, -1);
            DisplayRequestTaskState();
        }
        protected virtual void DisplayRequestCommandMessage()
        {
            Console.WriteLine("\nPlease enter the task command.");
        }
        protected virtual void DisplaySetCommandMessage()
        {
            Console.WriteLine("\nSet task command");
        }
        protected void DisplayRequestCommand()
        {
            DisplayRequestCommandMessage();
            Command = IApplication.READ_RESPONSE();
        }
        protected Boolean HasCommand()
        {
            return (Command != "");
        }
        internal void RequestCommand()
        {
            Boolean setSeverity = true;
            this.DisplaySetCommandMessage();
            if (HasCommand())
            {
                Display(false, true, -1);
                this.DisplayRequestCommand();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setSeverity = false;
            }
            if (setSeverity) DisplayRequestCommand();
        }
        protected virtual void DisplayRequestAssignedRolesMessage()
        {
            Console.WriteLine("\nPlease enter the task list of comma separated assigned roles.");
        }
        protected virtual void DisplaySetAssignedRolesMessage()
        {
            Console.WriteLine("\nSet task assigned roles");
        }
        protected void DisplayRequestAssignedRoles()
        {
            DisplayRequestAssignedRolesMessage();
            AssignedRoles = new(IApplication.READ_RESPONSE().Split(','));
        }
        protected Boolean HasAssignedRoles()
        {
            return (AssignedRoles.Count > 0);
        }
        internal void RequestAssignedRoles()
        {
            Boolean setSeverity = true;
            this.DisplaySetAssignedRolesMessage();
            if (HasAssignedRoles())
            {
                Display(false, true, -1);
                this.DisplayRequestAssignedRoles();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setSeverity = false;
            }
            if (setSeverity) DisplayRequestAssignedRoles();
        }
        protected virtual void DisplayRequestRequiredPreRequisiteTasksMessage()
        {
            Console.WriteLine("\nPlease enter the task comma separated list of required pre-requisite tasks.");
        }
        protected virtual void DisplaySetRequiredPreRequisiteTasksMessage()
        {
            Console.WriteLine("\nSet task required pre-requisite tasks");
        }
        protected void DisplayRequestRequiredPreRequisiteTasks()
        {
            DisplayRequestRequiredPreRequisiteTasksMessage();
            RequiredPreRequisiteTasks = new(IApplication.READ_RESPONSE().Split(','));
        }
        protected Boolean HasRequiredPreRequisiteTasks()
        {
            return (RequiredPreRequisiteTasks.Count > 0);
        }
        internal void RequestRequiredPreRequisiteTasks()
        {
            Boolean setSeverity = true;
            this.DisplaySetRequiredPreRequisiteTasksMessage();
            if (HasRequiredPreRequisiteTasks())
            {
                Display(false, true, -1);
                this.DisplayRequestRequiredPreRequisiteTasks();
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setSeverity = false;
            }
            if (setSeverity) DisplayRequestRequiredPreRequisiteTasks();
        }
        protected virtual void DisplayRequestPreWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nPlease enter the task pre-wait time in seconds.");
        }
        protected virtual void DisplaySetPreWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nSet task pre-wait time seconds");
        }
        protected void DisplayRequestPreWaitTimeSeconds()
        {
            String response;
            DisplayRequestPreWaitTimeSecondsMessage();
            PreWaitTimeSeconds = -2;
            while (PreWaitTimeSeconds < -1)
            {
                Console.Write("Enter the pre-wait time in seconds, where -1 is unlimited");
                response = IApplication.READ_RESPONSE();
                try
                {
                    PreWaitTimeSeconds = int.Parse(response);
                }
                catch {
                    PreWaitTimeSeconds = -2;
                }
            }
        }
        protected Boolean HasPreWaitTimeSeconds()
        {
            return (PreWaitTimeSeconds > -2);
        }
        internal void RequestPreWaitTimeSeconds()
        {
            this.DisplaySetPreWaitTimeSecondsMessage();
            DisplayRequestPreWaitTimeSeconds();
        }
        protected virtual void DisplayRequestDurationSecondsMessage()
        {
            Console.WriteLine("\nPlease enter the task duration in seconds.");
        }
        protected virtual void DisplaySetDurationSecondsMessage()
        {
            Console.WriteLine("\nSet task duration in seconds");
        }
        protected void DisplayRequestDurationSeconds()
        {
            String response;
            DisplayRequestDurationSecondsMessage();
            DurationSeconds = -2;
            while (DurationSeconds < -1)
            {
                Console.Write("Enter the duration in seconds, where -1 is unlimited");
                response = IApplication.READ_RESPONSE();
                try
                {
                    DurationSeconds = int.Parse(response);
                }
                catch
                {
                    DurationSeconds = -2;
                }
            }
        }
        protected Boolean HasDurationSeconds()
        {
            return (DurationSeconds > -1);
        }
        internal void RequestDurationSeconds()
        {
            this.DisplaySetDurationSecondsMessage();
            this.DisplayRequestDurationSeconds();
        }
        protected virtual void DisplayRequestPostWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nPlease enter the task post-wait time in seconds.");
        }
        protected virtual void DisplaySetPostWaitTimeSecondsMessage()
        {
            Console.WriteLine("\nSet task post-wait time seconds");
        }
        protected void DisplayRequestPostWaitTimeSeconds()
        {
            String response;
            DisplayRequestPostWaitTimeSecondsMessage();
            PostWaitTimeSeconds = -2;
            while (PostWaitTimeSeconds < -1)
            {
                Console.Write("Enter the post-wait time in seconds, where -1 is unlimited");
                response = IApplication.READ_RESPONSE();
                try
                {
                    PostWaitTimeSeconds = int.Parse(response);
                }
                catch
                {
                    PostWaitTimeSeconds = -2;
                }
            }
        }
        protected Boolean HasPostWaitTimeSeconds()
        {
            return (PostWaitTimeSeconds > -1);
        }
        internal void RequestPostWaitTimeSeconds()
        {
            this.DisplaySetPostWaitTimeSecondsMessage();
            this.DisplayRequestPostWaitTimeSeconds();
        }
        internal virtual Task CreateCopy(String newName)
        {
            //Task result = CreateTask(TaskType, TaskState);
            Task result = new(this);
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
            foreach(String role in AssignedRoles)
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
                }
            }
        }
        public static Task CreateTask(TaskType type, TaskState state)
        {
            switch (type)
            {
                case TaskType.Task:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateTask();
                        case TaskState.Scheduled:
                            return new ScheduledTask();
                        case TaskState.Assigned:
                            return new AssignedTask();
                        case TaskState.Implemented:
                            return new ImplementedTask();
                        default:
                            return new TemplateTask();
                    }
                case TaskType.Benchmark:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateBenchmark();
                        case TaskState.Scheduled:
                            return new ScheduledBenchmark();
                        case TaskState.Assigned:
                            return new AssignedBenchmark();
                        case TaskState.Implemented:
                            return new ImplementedBenchmark();
                        default:
                            return new TemplateBenchmark();
                    }
                case TaskType.GoNoGo:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateGoNoGo();
                        case TaskState.Scheduled:
                            return new ScheduledGoNoGo();
                        case TaskState.Assigned:
                            return new AssignedGoNoGo();
                        case TaskState.Implemented:
                            return new ImplementedGoNoGo();
                        default:
                            return new TemplateGoNoGo();
                    }
                case TaskType.Mitigation:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateMitigation();
                        case TaskState.Scheduled:
                            return new ScheduledMitigation();
                        case TaskState.Assigned:
                            return new AssignedMitigation();
                        case TaskState.Implemented:
                            return new ImplementedMitigation();
                        default:
                            return new TemplateMitigation();
                    }
                default:
                    return new TemplateTask();
            }
        }
        internal static Task CreateTask(TaskType type, TaskState state, String taskName, String taskDescription, Risks risks)
        {
            Task result;
            switch (type)
            {
                case TaskType.Task:
                    switch (state)
                    {
                        case TaskState.Template:
                            result = new TemplateTask(false);
                            result.Name = taskName;
                            result.Description= taskDescription;
                            return result;
                        case TaskState.Scheduled:
                            return new ScheduledTask(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedTask(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedTask(taskName, taskDescription);
                        default:
                            result = new TemplateTask(false);
                            result.Name = taskName;
                            result.Description = taskDescription;
                            return result;
                    }
                case TaskType.Benchmark:
                    switch (state)
                    {
                        case TaskState.Template:
                            result = new TemplateBenchmark(false);
                            result.Name = taskName;
                            result.Description = taskDescription;
                            return result;
                        case TaskState.Scheduled:
                            return new ScheduledBenchmark(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedBenchmark(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedBenchmark(taskName, taskDescription);
                        default:
                            result = new TemplateBenchmark(false);
                            result.Name = taskName;
                            result.Description = taskDescription;
                            return result;
                    }
                case TaskType.GoNoGo:
                    switch (state)
                    {
                        case TaskState.Template:
                            return new TemplateGoNoGo(taskName, taskDescription);
                        case TaskState.Scheduled:
                            return new ScheduledGoNoGo(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedGoNoGo(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedGoNoGo(taskName, taskDescription);
                        default:
                            return new TemplateGoNoGo(taskName, taskDescription);
                    }
                case TaskType.Mitigation:
                    switch (state)
                    {
                        case TaskState.Template:
                            result = new TemplateMitigation(risks, false);
                            result.Name = taskName;
                            result.Description = taskDescription;
                            return result;
                        case TaskState.Scheduled:
                            return new ScheduledMitigation(taskName, taskDescription);
                        case TaskState.Assigned:
                            return new AssignedMitigation(taskName, taskDescription);
                        case TaskState.Implemented:
                            return new ImplementedMitigation(taskName, taskDescription);
                        default:
                            result = new TemplateMitigation(risks, false);
                            result.Name = taskName;
                            result.Description = taskDescription;
                            return result;
                    }
                default:
                    result = new TemplateTask(false);
                    result.Name = taskName;
                    result.Description = taskDescription;
                    return result;
            }
        }
    }
}