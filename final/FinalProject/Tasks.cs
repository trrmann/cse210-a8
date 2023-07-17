﻿using System.Collections.Generic;
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
            Dictionary<String, JsonTask> result = new();
            foreach (String key in value.Keys)
            {
                result.Add(key, value[key]);
            }
            return new(result);
        }
        /**/
    }
    public class Tasks : Dictionary<String, Task>
    {
        internal Task CreateTask(String name, NameType type, String Description, TaskType TaskType, TaskState TaskState, String Command, List<String> AssignedRoles, List<String> RequiredPreRequisiteTasks, int PreWaitTimeSeconds, int DurationSeconds, int PostWaitTimeSeconds)
        {
            return new(name, type, Description, TaskType, TaskState, Command, AssignedRoles, RequiredPreRequisiteTasks, PreWaitTimeSeconds, DurationSeconds, PostWaitTimeSeconds);
        }

        internal void Export()
        {
            JsonTasks risks = new(this);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 5
            };
            String json = JsonSerializer.Serialize(risks, options);
            Console.Write("Enter the filename to write to");
            String fileName = IApplication.READ_RESPONSE();
            File.WriteAllText(fileName, json);
        }

        internal Tasks Import()
        {
            Console.Write("Enter the filename to read from");
            String fileName = IApplication.READ_RESPONSE();
            String json = File.ReadAllText(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 5
            };
            JsonTasks risks = JsonSerializer.Deserialize<JsonTasks>(json, options);
            Tasks result = (Tasks)risks;
            /* TODO convert classes to be correct listed types*/
            return result;
        }
    }
}