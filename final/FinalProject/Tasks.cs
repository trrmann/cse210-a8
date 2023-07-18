using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinalProject
{
    internal class JsonTasks : Dictionary<String, JsonTask>
    {
        protected Tasks _tasks
        {
            get
            {
                Tasks tasks = new();
                foreach (String key in Keys)
                {
                    tasks.Add(key, this[key]);
                }
                return tasks;
            }
            set
            {
                Clear();
                foreach (String key in value.Keys)
                {
                    Add(key, value[key]);
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Tasks")]
        public Dictionary<String, JsonTask> Tasks
        {
            get
            {
                return this;
            }
            set
            {
                Clear();
                foreach (String key in value.Keys)
                {
                    Add(key, value[key]);
                }
            }
        }
        public JsonTasks() : base()
        {
            this.Tasks = new();
        }
        [JsonConstructor]
        public JsonTasks(Dictionary<String, JsonTask> Tasks) : base()
        {
            this.Tasks = Tasks;
        }
        public JsonTasks(Tasks Tasks) : base()
        {
            _tasks = Tasks;
        }
        public static implicit operator JsonTasks(Tasks tasks)
        {
            return new(tasks);
        }
        public static implicit operator Tasks(JsonTasks tasks)
        {
            return tasks._tasks;
        }
        /**
        internal static JsonDictionaryNamedObject<JsonTask> Convert(Tasks value)
        {
            Dictionary<String, JsonTask> tasks = new();
            foreach (String key in value.Keys)
            {
                tasks.Add(key, value[key]);
            }
            return new(tasks);
        }
        /**/
    }
    public class Tasks : Dictionary<String, Task>
    {
        internal Task CreateTask(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds)
        {
            return new(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds);
        }
        internal void Add<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayAddMessage(plan);
            TaskType templateTask = instance.Create<TaskType>(plan.BackoutPlan, plan.Risks, true);
            if (Keys.Contains(templateTask.Key))
            {
                instance.DisplayAlreadyDefined(templateTask.Name.Value);
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Remove(templateTask.Key);
                    Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Add(templateTask.Key, templateTask);
            }
        }
        internal TaskType SelectTask<TaskType>(Plan plan, Boolean ensureResult = false) where TaskType : Task, new()
        {
            TaskType instance = new();
            if (Count == 0)
            {
                if (ensureResult)
                {
                    Add<TaskType>(plan);
                    return (TaskType)this.First().Value;
                }
                else
                {
                    return null;
                }
            }
            else if (Count == 1) return (TaskType)this.First().Value;
            else
            {
                int option = 0;
                Dictionary<int, TaskType> optionMap = new();
                while (option < 1)
                {
                    int counter = 1;
                    optionMap = new();
                    foreach (String key in Keys)
                    {
                        this[key].Display(counter);
                        optionMap.Add(counter, (TaskType)this[key]);
                        counter++;
                    }
                    instance.DisplaySelectMessage();
                    String response = IApplication.READ_RESPONSE();
                    try
                    {
                        option = int.Parse(response);
                    }
                    catch
                    {
                        option = -1;
                    }
                    if (!optionMap.Keys.Contains(option)) option = -1;
                }
                return optionMap[option];
            }
        }
        internal void Copy<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayCopyMessage(plan);
            TaskType task = SelectTask<TaskType>(plan);
            if (task is not null)
            {
                Console.WriteLine();
                task.Display();
                TaskType newTask = instance.Create(task);
                newTask.Name = "";
                newTask.RequestName();
                if (Keys.Contains(newTask.Key))
                {
                    instance.DisplayAlreadyDefined(newTask.Name.Value);
                    String response = IApplication.READ_RESPONSE().ToLower();
                    if (IApplication.YES_RESPONSE.Contains(response))
                    {
                        Remove(newTask.Key);
                        Add(newTask.Key, newTask);
                    }
                }
                else
                {
                    Add(newTask.Key, newTask);
                }
            }
        }
        internal void Edit<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayEditMessage(plan);
            TaskType task = SelectTask<TaskType>(plan);
            instance.Edit(task, plan.BackoutPlan, plan.Risks);

        }
        internal void RemoveTask<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayRemoveMessage(plan);
            TaskType task = SelectTask<TaskType>(plan);
            if (task is not null) Remove(task.Key);
        }
        internal void Display<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayListMessage(plan);
            foreach (String key in Keys)
            {
                this[key].Display();
            }
        }
        internal void Export<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayExportMessage(plan);
            Tasks tasks = new();
            foreach (String key in Keys) { if (typeof(TaskType).IsInstanceOfType(this[key])) tasks.Add(key, this[key]); }
            JsonTasks jsonTasks = new(tasks);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 5
            };
            String jsonText = JsonSerializer.Serialize(jsonTasks, options);
            instance.DisplayRequestFilenameWriteMessage();
            String fileName = IApplication.READ_RESPONSE();
            File.WriteAllText(fileName, jsonText);
        }
        internal void Import<TaskType>(Plan plan) where TaskType : Task, new()
        {
            TaskType instance = new();
            instance.DisplayImportMessage(plan);
            instance.DisplayRequestFilenameReadMessage();
            String fileName = IApplication.READ_RESPONSE();
            String jsonText = File.ReadAllText(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 5
            };
            JsonTasks jsonTasks = JsonSerializer.Deserialize<JsonTasks>(jsonText, options);
            Tasks tasks = (Tasks)jsonTasks;
            /* TODO convert classes to be correct listed types*/
            foreach (String key in tasks.Keys)
            {
                /*TODO - fix import collisions*/
                if (typeof(TemplateTask).IsInstanceOfType(tasks[key])) Add(key, tasks[key]);
            }
        }
    }
}