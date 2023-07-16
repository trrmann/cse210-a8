using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class JsonPlan : JsonDescribedObject
    {
        protected Plan Plan { get; set; }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("NamedObject")]
        public new JsonNamedObject NamedObject
        {
            get
            {
                return Plan;
            }
            set
            {
                if (value.GetType().IsInstanceOfType(typeof(Plan)))
                {
                    Plan = (Plan)value;
                }
                else
                {
                    Plan = new();
                    Plan.Name = value.Name;
                }
            }
        }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Description")]
        public new String Description { get { return Plan.Description; } set { Plan.Description = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Manager")]
        public JsonName Manager { get { return Plan.Manager; } set { Plan.Manager = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Tasks")]
        public JsonTasks Tasks { get { return Plan.Tasks; } set { Plan.Tasks = value; } }
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("Risks")]
        public JsonRisks Risks { get { return Plan.Risks; } set { Plan.Risks = value; } }
        public JsonPlan() : base()
        {
            this.Plan = new();
        }
        [JsonConstructor]
        public JsonPlan(JsonNamedObject NamedObject, String Description, JsonName Manager, JsonTasks Tasks, JsonRisks Risks) : base()
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.Manager = Manager;
            this.Tasks = Tasks;
            this.Risks = Risks;
        }
        public JsonPlan(Plan Plan) : base()
        {
            this.Plan = Plan;
        }
        public static implicit operator JsonPlan(Plan plan)
        {
            return new(plan);
        }
        public static implicit operator Plan(JsonPlan plan)
        {
            return plan.Plan;
        }
    }
    public class Plan : DescribedObject
    {
        public Plan() {
            Init();
        }
        public Plan(Plan plan)
        {
            Init(plan);
        }
        public Plan(String Name, String Description, String Manager, Tasks Tasks, Risks Risks)
        {
            Init(Name, Description, Manager, Tasks, Risks);
        }
        protected void Init()
        {
            Init("", "", "", new(), new());
        }
        protected void Init(Plan plan)
        {
            Init(plan.Name, plan.Description, plan.Manager, plan.Tasks, plan.Risks);
        }
        protected void Init(String Name, String Description, String Manager, Tasks Tasks, Risks Risks)
        {
            Init(new Name(Name, NameType.Thing), Description, new Name(Manager, NameType.Person), Tasks, Risks);
        }
        protected void Init(Name Name, String Description, Name Manager, Tasks Tasks, Risks Risks)
        {
            this.Name = Name;
            this.Description = Description;
            this.Manager = Manager;
            this.Tasks = Tasks;
            this.Risks = Risks;
        }
        internal Name Manager { get; set; }
        internal Tasks Tasks { get; set; }
        internal Risks Risks { get; set; }

        private void DisplayName(int option = -1)
        {
            base.Display(option);
        }
        private void DisplayDescription()
        {
            Console.WriteLine(Description);
        }
        private void DisplayManager()
        {
            Manager.Display();
        }
        internal String GetNameForMenus()
        {
            if (IsNamed() && IsManaged())
            {
                return Name + " by " + Manager;
            }
            else if (IsNamed())
            {
                return Name;
            }
            else if (IsManaged())
            {
                return "? by " + Manager;
            }
            else
            {
                return "?";
            }
        }
        private Boolean IsManaged()
        {
            return Manager != "";
        }
        protected override void DisplaySetNameMessage()
        {
            Console.WriteLine("\nAssign Name");
        }
        protected override void DisplayRequestReSetNameMessage()
        {
            Console.WriteLine("\nRename plan?");
        }
        protected override void DisplayRequestNameMessage()
        {
            Console.WriteLine("\nWhat is the name of the plan?");
        }
        protected override void DisplaySetDescriptionMessage()
        {
            Console.WriteLine("\nAssign Description");
        }
        protected override void DisplayRequestReSetDescriptionMessage()
        {
            Console.WriteLine("\nRedescribe plan?");
        }
        protected override void DisplayRequestDescriptionMessage()
        {
            Console.WriteLine("\nWhat is the description of the plan?");
        }
        internal void SetManager()
        {
            Boolean setManager = true;
            Console.WriteLine("\nAssign manager");
            if (IsManaged())
            {
                Console.Write("Current Manager:  ");
                DisplayManager();
                Console.WriteLine("\nReown plan?");
                if (!IApplication.YES_RESPONSE.Contains(IApplication.READ_RESPONSE().ToLower())) setManager = false;
            }
            if (setManager)
            {
                Console.Write("\n");
                Console.WriteLine("\nWho is managing the plan?");
                Manager = IApplication.READ_RESPONSE();
            }
        }
        internal void DisplaySummary()
        {
            Console.WriteLine($"\nView Summary ({GetNameForMenus()})");
            Console.WriteLine($"{Description}");
        }
        internal void AddTask()
        {
            Console.WriteLine($"\nAdd a task ({GetNameForMenus()})");
            Task templateTask = new Task(true);
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal Task SelectTask(Boolean ensureResult = false)
        {
            if (Tasks.Count == 0)
            {
                if (ensureResult)
                {
                    AddTask();
                    return Tasks.First().Value;
                }
                else
                {
                    return null;
                }
            }
            else if (Tasks.Count == 1) return Tasks.First().Value;
            else
            {
                int option = 0;
                Dictionary<int, Task> optionMap = new();
                while (option < 1)
                {
                    int counter = 1;
                    optionMap = new();
                    foreach (String key in Tasks.Keys)
                    {
                        Tasks[key].Display(counter);
                        optionMap.Add(counter, Tasks[key]);
                        counter++;
                    }
                    Console.Write("Select a task");
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
        internal void CopyTask()
        {
            Console.WriteLine($"\nCopy a Task ({GetNameForMenus()})");
            Task risk = SelectTask();
            if (risk is not null)
            {
                Console.WriteLine();
                risk.Display();
                Task newrisk = new Task(risk);
                newrisk.Name = "";
                newrisk.RequestName();
                if (Tasks.Keys.Contains(newrisk.Key))
                {
                    Console.WriteLine($"{newrisk.Name.Value} already defined.");
                    Console.Write("overwrite (y/n)");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    if (IApplication.YES_RESPONSE.Contains(response))
                    {
                        Tasks.Remove(newrisk.Key);
                        Tasks.Add(newrisk.Key, newrisk);
                    }
                }
                else
                {
                    Tasks.Add(newrisk.Key, newrisk);
                }
            }
        }
        internal void EditTask()
        {
            Console.WriteLine($"\nEdit a Task ({GetNameForMenus()})");
            Task risk = SelectTask();
            if (risk is not null)
            {
                Console.WriteLine();
                risk.Display();
                Console.Write("\nrename (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Name = "";
                    risk.RequestName();
                }
                Console.Write("\nchange description (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Description = "";
                    risk.RequestDescription();
                }
                Console.Write("\nchange task type (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.RequestTaskType();
                }
                Console.Write("\nchange task state (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.RequestTaskState();
                }
                Console.Write("\nchange command (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Command = "";
                    risk.RequestCommand();
                }
                Console.Write("\nchange assugned roles (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.AssignedRoles.Clear();
                    risk.RequestAssignedRoles();
                }
                Console.Write("\nchange required pre-requisite tasks (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.RequiredPreRequisiteTasks.Clear();
                    risk.RequestRequiredPreRequisiteTasks();
                }
                Console.Write("\nchange pre-wait time (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.PreWaitTimeSeconds = -2;
                    risk.RequestPreWaitTimeSeconds();
                }
                Console.Write("\nchange duration (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.DurationSeconds = -2;
                    risk.RequestDurationSeconds();
                }
                Console.Write("\nchange post-wait time (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.PostWaitTimeSeconds = -2;
                    risk.RequestPostWaitTimeSeconds();
                }
            }
        }
        internal void RemoveTask()
        {
            Console.WriteLine($"\nRemove a Task ({GetNameForMenus()})");
            Task risk = SelectTask();
            if (risk is not null) Tasks.Remove(risk.Key);
        }
        internal void ListTasks()
        {
            Console.WriteLine($"\nDisplay Taskss ({GetNameForMenus()})\n");
            foreach (String key in Tasks.Keys)
            {
                Tasks[key].Display();
            }
        }
        internal void ExportTasks()
        {
            Tasks.Export();
        }
        internal void ImportTasks()
        {
            Tasks = Tasks.Import();
        }
        internal void AddBenchmark()
        {
            Console.WriteLine($"\nAdd a benchmark task ({GetNameForMenus()})");
            //Benchmark templateTask = new Benchmark(true);
            /*TODO Add Benchmark*/
            Benchmark templateTask = new Benchmark();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyBenchmark()
        {
            /*TODO - CopyBenchmark*/
            throw new NotImplementedException();
        }
        internal void EditBenchmark()
        {
            /*TODO - EditBenchmark*/
            throw new NotImplementedException();
        }
        internal void RemoveBenchmark()
        {
            /*TODO - RemoveBenchmark*/
            throw new NotImplementedException();
        }
        internal void ListBenchmarks()
        {
            /*TODO - ListBenchmarks*/
            throw new NotImplementedException();
        }
        internal void AddRisk()
        {
            Console.WriteLine($"\nAdd a Risk ({GetNameForMenus()})");
            Risk risk = new Risk(true);
            if(Risks.Keys.Contains(risk.Key))
            {
                Console.WriteLine($"{risk.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if(IApplication.YES_RESPONSE.Contains(response))
                {
                    Risks.Remove(risk.Key);
                    Risks.Add(risk.Key, risk);
                }
            } else
            {
                Risks.Add(risk.Key, risk);
            }
        }
        internal Risk SelectRisk(Boolean ensureResult = false)
        {
            if(Risks.Count == 0)
            {
                if(ensureResult)
                {
                    AddRisk();
                    return Risks.First().Value;
                } else
                {
                    return null;
                }
            } else if (Risks.Count == 1) return Risks.First().Value;
            else
            {
                int option = 0;
                Dictionary<int, Risk> optionMap = new();
                while(option<1)
                {
                    int counter = 1;
                    optionMap = new();
                    foreach(String key in Risks.Keys)
                    {
                        Risks[key].Display(counter);
                        optionMap.Add(counter, Risks[key]);
                        counter++;
                    }
                    Console.Write("Select a templateTask");
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
        internal void CopyRisk()
        {
            Console.WriteLine($"\nCopy a Risk ({GetNameForMenus()})");
            Risk risk = SelectRisk();
            if(risk is not null)
            {
                Console.WriteLine();
                risk.Display();
                Risk newrisk = new Risk(risk);
                newrisk.Name = "";
                newrisk.RequestName();
                if (Risks.Keys.Contains(newrisk.Key))
                {
                    Console.WriteLine($"{newrisk.Name.Value} already defined.");
                    Console.Write("overwrite (y/n)");
                    String response = IApplication.READ_RESPONSE().ToLower();
                    if (IApplication.YES_RESPONSE.Contains(response))
                    {
                        Risks.Remove(newrisk.Key);
                        Risks.Add(newrisk.Key, newrisk);
                    }
                }
                else
                {
                    Risks.Add(newrisk.Key, newrisk);
                }
            }
        }
        internal void EditRisk()
        {
            Console.WriteLine($"\nEdit a Risk ({GetNameForMenus()})");
            Risk risk = SelectRisk();
            if (risk is not null)
            {
                Console.WriteLine();
                risk.Display();
                Console.Write("\nrename (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Name = "";
                    risk.RequestName();
                }
                Console.Write("\nchange description (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Description = "";
                    risk.RequestDescription();
                }
                Console.Write("\nchange severity (y/n)");
                response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    risk.Severity = "";
                    risk.RequestSeverity();
                }
            }
        }
        internal void RemoveRisk()
        {
            Console.WriteLine($"\nRemove a Risk ({GetNameForMenus()})");
            Risk risk = SelectRisk();
            if (risk is not null) Risks.Remove(risk.Key);
        }
        internal void ListRisks()
        {
            Console.WriteLine($"\nDisplay Risks ({GetNameForMenus()})\n");
            foreach (String key in Risks.Keys)
            {
                Risks[key].Display();
            }
        }
        internal void ExportRisks()
        {
            Risks.Export();
        }
        internal void ImportRisks()
        {
            Risks = Risks.Import();
        }
        internal void Display()
        {
            Console.WriteLine($"\nDisplay Plan ({GetNameForMenus()})");
            Console.WriteLine($"{Description}");
            ListRisks();
            ListTasks();
        }
        internal void Load()
        {
            Console.Write("Enter the filename to read from");
            String fileName = IApplication.READ_RESPONSE();
            String json = File.ReadAllText(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 10
            };
            JsonPlan plan = JsonSerializer.Deserialize<JsonPlan>(json, options);
            Plan result = (Plan)plan;
            Init(result);
        }
        internal void Save()
        {
            JsonPlan plan = new(this);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IncludeFields = true,
                MaxDepth = 10
            };
            String json = JsonSerializer.Serialize(plan, options);
            Console.Write("Enter the filename to write to");
            String fileName = IApplication.READ_RESPONSE();
            File.WriteAllText(fileName, json);
        }
        internal void Copy()
        {
            Boolean overwrite = false;
            Console.Write("Enter the filename to copy.");
            String filename = IApplication.READ_RESPONSE();
            Console.Write("Enter the new filename.");
            String newFilename = IApplication.READ_RESPONSE();
            if (File.Exists(newFilename))
            {
                Console.WriteLine($"File {newFilename} already exists.");
                Console.Write($"overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                overwrite = IApplication.YES_RESPONSE.Contains(response);
            }
            else overwrite = true;
            if (File.Exists(filename) && overwrite)
            {
                File.Copy(filename, newFilename, overwrite);
                if (File.Exists(filename) && File.Exists(newFilename))
                {
                    Console.WriteLine($"File {filename} copied to {newFilename}.");
                }
            }
            else
            {
                if (overwrite) Console.WriteLine($"Can't find file {filename}.");
            }
        }
        internal void Rename()
        {
            Boolean overwrite = false;
            Console.Write("Enter the filename to ranme.");
            String filename = IApplication.READ_RESPONSE();
            Console.Write("Enter the new filename.");
            String newFilename = IApplication.READ_RESPONSE();
            if (File.Exists(newFilename))
            {
                Console.WriteLine($"File {newFilename} already exists.");
                Console.Write($"overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                overwrite = IApplication.YES_RESPONSE.Contains(response);
            }
            else overwrite = true;
            if (File.Exists(filename)&& overwrite)
            {
                File.Move(filename, newFilename, overwrite);
                if (!File.Exists(filename)&& File.Exists(newFilename))
                {
                    Console.WriteLine($"File {filename} renamed to {newFilename}.");
                }
            }
            else
            {
                if (overwrite) Console.WriteLine($"Can't find file {filename}.");
            }
        }
        internal void Delete()
        {
            Console.Write("Enter the filename to delete.");
            String filename = IApplication.READ_RESPONSE();
            if(File.Exists(filename))
            {
                File.Delete(filename);
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"File {filename} delated.");
                }
            } else
            {
                Console.WriteLine($"Can't find file {filename}.");
            }
        }
        internal void Showfiles()
        {
            List<String> files = new List<String>(Directory.GetFiles("."));
            Console.WriteLine("\nShow files.");
            foreach (String file in files)
            {
                List<String> parts = new List<String>(file.Split('\\'));
                parts.RemoveAt(0);
                Console.WriteLine(String.Join('\\', parts));
            }
        }
        internal void Test()
        {
            /*TODO - Test*/
            throw new NotImplementedException();
        }
        internal void Implement()
        {
            /*TODO - Implement*/
            throw new NotImplementedException();
        }
        internal void PlanRollback()
        {
            /*TODO - PlanRollback*/
            throw new NotImplementedException();
        }
        internal void TestRollback()
        {
            /*TODO - TestRollback*/
            throw new NotImplementedException();
        }
        internal void Rollback()
        {
            /*TODO - Rollback*/
            throw new NotImplementedException();
        }
        internal void Estimate()
        {
            /*TODO - Estimate*/
            throw new NotImplementedException();
        }
        internal void Allocate()
        {
            /*TODO - Allocate*/
            throw new NotImplementedException();
        }
        internal void AddTemplateTask()
        {
            Console.WriteLine($"\nAdd a template task ({GetNameForMenus()})");
            //TemplateTask templateTask = new TemplateTask(true);
            /*TODO AddTemplateTask*/
            TemplateTask templateTask = new TemplateTask();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyTemplateTask()
        {
            /*TODO - CopyTemplateTask*/
            throw new NotImplementedException();
        }
        internal void EditTemplateTask()
        {
            /*TODO - EditTemplateTask*/
            throw new NotImplementedException();
        }
        internal void RemoveTemplateTask()
        {
            /*TODO - RemoveTemplateTask*/
            throw new NotImplementedException();
        }
        internal void ListTemplateTasks()
        {
            /*TODO - ListTemplateTasks*/
            throw new NotImplementedException();
        }
        internal void ExportTemplateTasks()
        {
            Tasks.Export();
            /*TODO - ExportTemplateTasks*/
            throw new NotImplementedException();
        }
        internal void ImportTemplateTasks()
        {
            Tasks.Import();
            /*TODO - ImportTemplateTasks*/
            throw new NotImplementedException();
        }
        internal void AddTemplateBenchmarkTask()
        {
            Console.WriteLine($"\nAdd a template benchmark task ({GetNameForMenus()})");
            //TemplateBenchmark templateTask = new TemplateBenchmark(true);
            /*TODO AddTemplateBenchmarkTask*/
            TemplateBenchmark templateTask = new TemplateBenchmark();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyTemplateBenchmarkTask()
        {
            /*TODO - CopyTemplateBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void EditTemplateBenchmarkTask()
        {
            /*TODO - EditTemplateBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void RemoveTemplateBenchmarkTask()
        {
            /*TODO - RemoveTemplateBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void ListTemplateBenchmarkTasks()
        {
            /*TODO - ListTemplateBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ExportTemplateBenchmarkTasks()
        {
            /*TODO - ExportTemplateBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ImportTemplateBenchmarkTasks()
        {
            /*TODO - ImportTemplateBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void AddTemplateGoNoGoTask()
        {
            Console.WriteLine($"\nAdd a template Go/NoGo task ({GetNameForMenus()})");
            //TemplateGoNoGo templateTask = new TemplateGoNoGo(true);
            /*TODO AddTemplateGoNoGoTask*/
            TemplateGoNoGo templateTask = new TemplateGoNoGo();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyTemplateGoNoGoTask()
        {
            /*TODO - CopyTemplateGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void EditTemplateGoNoGoTask()
        {
            /*TODO - EditTemplateGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void RemoveTemplateGoNoGoTask()
        {
            /*TODO - RemoveTemplateGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void ListTemplateGoNoGoTasks()
        {
            /*TODO - ListTemplateGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ExportTemplateGoNoGoTasks()
        {
            /*TODO - ExportTemplateGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ImportTemplateGoNoGoTasks()
        {
            /*TODO - ImportTemplateGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void AddTemplateMitigationTask()
        {
            Console.WriteLine($"\nAdd a template mitigation task ({GetNameForMenus()})");
            //TemplateMitigation templateTask = new TemplateMitigation(true);
            /*TODO AddTemplateMitigationTask*/
            TemplateMitigation templateTask = new TemplateMitigation();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyTemplateMitigationTask()
        {
            /*TODO - CopyTemplateMitigationTask*/
            throw new NotImplementedException();
        }
        internal void EditTemplateMitigationTask()
        {
            /*TODO - EditTemplateMitigationTask*/
            throw new NotImplementedException();
        }
        internal void RemoveTemplateMitigationTask()
        {
            /*TODO - RemoveTemplateMitigationTask*/
            throw new NotImplementedException();
        }
        internal void ListTemplateMitigationTasks()
        {
            /*TODO - ListTemplateMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ExportTemplateMitigationTasks()
        {
            /*TODO - ExportTemplateMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ImportTemplateMitigationTasks()
        {
            /*TODO - ImportTemplateMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void AddAssignedTask()
        {
            Console.WriteLine($"\nAdd an assigned task ({GetNameForMenus()})");
            //AssignedTask templateTask = new AssignedTask(true);
            /*TODO AddAssignedTask*/
            AssignedTask templateTask = new AssignedTask();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyAssignedTask()
        {
            /*TODO - CopyAssignedTask*/
            throw new NotImplementedException();
        }
        internal void EditAssignedTask()
        {
            /*TODO - EditAssignedTask*/
            throw new NotImplementedException();
        }
        internal void RemoveAssignedTask()
        {
            /*TODO - RemoveAssignedTask*/
            throw new NotImplementedException();
        }
        internal void ListAssignedTasks()
        {
            /*TODO - ListAssignedTasks*/
            throw new NotImplementedException();
        }
        internal void ExportAssignedTasks()
        {
            /*TODO - ExportAssignedTasks*/
            throw new NotImplementedException();
        }
        internal void ImportAssignedTasks()
        {
            /*TODO - ImportAssignedTasks*/
            throw new NotImplementedException();
        }
        internal void AddAssignedBenchmarkTask()
        {
            Console.WriteLine($"\nAdd an assigned benchmark task ({GetNameForMenus()})");
            //AssignedBenchmark templateTask = new AssignedBenchmark(true);
            /*TODO AddAssignedBenchmarkTask*/
            AssignedBenchmark templateTask = new AssignedBenchmark();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyAssignedBenchmarkTask()
        {
            /*TODO - CopyAssignedBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void EditAssignedBenchmarkTask()
        {
            /*TODO - EditAssignedBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void RemoveAssignedBenchmarkTask()
        {
            /*TODO - RemoveAssignedBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void ListAssignedBenchmarkTasks()
        {
            /*TODO - ListAssignedBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ExportAssignedBenchmarkTasks()
        {
            /*TODO - ExportAssignedBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ImportAssignedBenchmarkTasks()
        {
            /*TODO - ImportAssignedBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void AddAssignedGoNoGoTask()
        {
            Console.WriteLine($"\nAdd an assigned Go/NoGo task ({GetNameForMenus()})");
            //AssignedGoNoGo templateTask = new AssignedGoNoGo(true);
            /*TODO AddAssignedGoNoGoTask*/
            AssignedGoNoGo templateTask = new AssignedGoNoGo();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyAssignedGoNoGoTask()
        {
            /*TODO - CopyAssignedGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void EditAssignedGoNoGoTask()
        {
            /*TODO - EditAssignedGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void RemoveAssignedGoNoGoTask()
        {
            /*TODO - RemoveAssignedGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void ListAssignedGoNoGoTasks()
        {
            /*TODO - ListAssignedGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ExportAssignedGoNoGoTasks()
        {
            /*TODO - ExportAssignedGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ImportAssignedGoNoGoTasks()
        {
            /*TODO - ImportAssignedGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void AddAssignedMitigationTask()
        {
            Console.WriteLine($"\nAdd an assigned mitigation task ({GetNameForMenus()})");
            //AssignedMitigation templateTask = new AssignedMitigation(true);
            /*TODO AddAssignedMitigationTask*/
            AssignedMitigation templateTask = new AssignedMitigation();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyAssignedMitigationTask()
        {
            /*TODO - CopyAssignedMitigationTask*/
            throw new NotImplementedException();
        }
        internal void EditAssignedMitigationTask()
        {
            /*TODO - EditAssignedMitigationTask*/
            throw new NotImplementedException();
        }
        internal void RemoveAssignedMitigationTask()
        {
            /*TODO - RemoveAssignedMitigationTask*/
            throw new NotImplementedException();
        }
        internal void ListAssignedMitigationTasks()
        {
            /*TODO - ListAssignedMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ExportAssignedMitigationTasks()
        {
            /*TODO - ExportAssignedMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ImportAssignedMitigationTasks()
        {
            /*TODO - ImportAssignedMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void AddScheduledTask()
        {
            Console.WriteLine($"\nAdd a scheduled task ({GetNameForMenus()})");
            //ScheduledTask templateTask = new ScheduledTask(true);
            /*TODO AddScheduledTask*/
            ScheduledTask templateTask = new ScheduledTask();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
            /*TODO - AddScheduledTask*/
            throw new NotImplementedException();
        }
        internal void CopyScheduledTask()
        {
            /*TODO - CopyScheduledTask*/
            throw new NotImplementedException();
        }
        internal void EditScheduledTask()
        {
            /*TODO - EditScheduledTask*/
            throw new NotImplementedException();
        }
        internal void RemoveScheduledTask()
        {
            /*TODO - RemoveScheduledTask*/
            throw new NotImplementedException();
        }
        internal void ListScheduledTasks()
        {
            /*TODO - ListScheduledTasks*/
            throw new NotImplementedException();
        }
        internal void ExportScheduledTasks()
        {
            /*TODO - ExportScheduledTasks*/
            throw new NotImplementedException();
        }
        internal void ImportScheduledTasks()
        {
            /*TODO - ImportScheduledTasks*/
            throw new NotImplementedException();
        }
        internal void AddScheduledBenchmarkTask()
        {
            Console.WriteLine($"\nAdd a scheduled benchmark task ({GetNameForMenus()})");
            //ScheduledBenchmark templateTask = new ScheduledBenchmark(true);
            /*TODO AddScheduledBenchmarkTask*/
            ScheduledBenchmark templateTask = new ScheduledBenchmark();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyScheduledBenchmarkTask()
        {
            /*TODO - CopyScheduledBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void EditScheduledBenchmarkTask()
        {
            /*TODO - EditScheduledBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void RemoveScheduledBenchmarkTask()
        {
            /*TODO - RemoveScheduledBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void ListScheduledBenchmarkTasks()
        {
            /*TODO - ListScheduledBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ExportScheduledBenchmarkTasks()
        {
            /*TODO - ExportScheduledBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ImportScheduledBenchmarkTasks()
        {
            /*TODO - ImportScheduledBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void AddScheduledGoNoGoTask()
        {
            Console.WriteLine($"\nAdd a scheduled Go/NoGo task ({GetNameForMenus()})");
            //ScheduledGoNoGo templateTask = new ScheduledGoNoGo(true);
            /*TODO AddScheduledGoNoGoTask*/
            ScheduledGoNoGo templateTask = new ScheduledGoNoGo();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyScheduledGoNoGoTask()
        {
            /*TODO - CopyScheduledGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void EditScheduledGoNoGoTask()
        {
            /*TODO - EditScheduledGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void RemoveScheduledGoNoGoTask()
        {
            /*TODO - RemoveScheduledGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void ListScheduledGoNoGoTasks()
        {
            /*TODO - ListScheduledGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ExportScheduledGoNoGoTasks()
        {
            /*TODO - ExportScheduledGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ImportScheduledGoNoGoTasks()
        {
            /*TODO - ImportScheduledGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void AddScheduledMitigationTask()
        {
            Console.WriteLine($"\nAdd a scheduled mitigation task ({GetNameForMenus()})");
            //ScheduledMitigation templateTask = new ScheduledMitigation(true);
            /*TODO AddScheduledMitigationTask*/
            ScheduledMitigation templateTask = new ScheduledMitigation();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyScheduledMitigationTask()
        {
            /*TODO - CopyScheduledMitigationTask*/
            throw new NotImplementedException();
        }
        internal void EditScheduledMitigationTask()
        {
            /*TODO - EditScheduledMitigationTask*/
            throw new NotImplementedException();
        }
        internal void RemoveScheduledMitigationTask()
        {
            /*TODO - RemoveScheduledMitigationTask*/
            throw new NotImplementedException();
        }
        internal void ListScheduledMitigationTasks()
        {
            /*TODO - ListScheduledMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ExportScheduledMitigationTasks()
        {
            /*TODO - ExportScheduledMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ImportScheduledMitigationTasks()
        {
            /*TODO - ImportScheduledMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void AddImplementedTask()
        {
            Console.WriteLine($"\nAdd an implemented task ({GetNameForMenus()})");
            //ImplementedTask templateTask = new ImplementedTask(true);
            /*TODO AddImplementedTask*/
            ImplementedTask templateTask = new ImplementedTask();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyImplementedTask()
        {
            /*TODO - CopyImplementedTask*/
            throw new NotImplementedException();
        }
        internal void EditImplementedTask()
        {
            /*TODO - EditImplementedTask*/
            throw new NotImplementedException();
        }
        internal void RemoveImplementedTask()
        {
            /*TODO - RemoveImplementedTask*/
            throw new NotImplementedException();
        }
        internal void ListImplementedTasks()
        {
            /*TODO - ListImplementedTasks*/
            throw new NotImplementedException();
        }
        internal void ExportImplementedTasks()
        {
            /*TODO - ExportImplementedTasks*/
            throw new NotImplementedException();
        }
        internal void ImportImplementedTasks()
        {
            /*TODO - ImportImplementedTasks*/
            throw new NotImplementedException();
        }
        internal void AddImplementedBenchmarkTask()
        {
            Console.WriteLine($"\nAdd an implemented benchmark task ({GetNameForMenus()})");
            //ImplementedBenchmark templateTask = new ImplementedBenchmark(true);
            /*TODO AddImplementedBenchmarkTask*/
            ImplementedBenchmark templateTask = new ImplementedBenchmark();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyImplementedBenchmarkTask()
        {
            /*TODO - CopyImplementedBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void EditImplementedBenchmarkTask()
        {
            /*TODO - EditImplementedBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void RemoveImplementedBenchmarkTask()
        {
            /*TODO - RemoveImplementedBenchmarkTask*/
            throw new NotImplementedException();
        }
        internal void ListImplementedBenchmarkTasks()
        {
            /*TODO - ListImplementedBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ExportImplementedBenchmarkTasks()
        {
            /*TODO - ExportImplementedBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void ImportImplementedBenchmarkTasks()
        {
            /*TODO - ImportImplementedBenchmarkTasks*/
            throw new NotImplementedException();
        }
        internal void AddImplementedGoNoGoTask()
        {
            Console.WriteLine($"\nAdd an implemented Go/NoGo task ({GetNameForMenus()})");
            //ImplementedGoNoGo templateTask = new ImplementedGoNoGo(true);
            /*TODO AddImplementedGoNoGoTask*/
            ImplementedGoNoGo templateTask = new ImplementedGoNoGo();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyImplementedGoNoGoTask()
        {
            /*TODO - CopyImplementedGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void EditImplementedGoNoGoTask()
        {
            /*TODO - EditImplementedGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void RemoveImplementedGoNoGoTask()
        {
            /*TODO - RemoveImplementedGoNoGoTask*/
            throw new NotImplementedException();
        }
        internal void ListImplementedGoNoGoTasks()
        {
            /*TODO - ListImplementedGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ExportImplementedGoNoGoTasks()
        {
            /*TODO - ExportImplementedGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void ImportImplementedGoNoGoTasks()
        {
            /*TODO - ImportImplementedGoNoGoTasks*/
            throw new NotImplementedException();
        }
        internal void AddImplementedMitigationTask()
        {
            Console.WriteLine($"\nAdd an implemented mitigation task ({GetNameForMenus()})");
            //ImplementedMitigation templateTask = new ImplementedMitigation(true);
            /*TODO AddImplementedMitigationTask*/
            ImplementedMitigation templateTask = new ImplementedMitigation();
            if (Tasks.Keys.Contains(templateTask.Key))
            {
                Console.WriteLine($"{templateTask.Name.Value} already defined.");
                Console.Write("overwrite (y/n)");
                String response = IApplication.READ_RESPONSE().ToLower();
                if (IApplication.YES_RESPONSE.Contains(response))
                {
                    Tasks.Remove(templateTask.Key);
                    Tasks.Add(templateTask.Key, templateTask);
                }
            }
            else
            {
                Tasks.Add(templateTask.Key, templateTask);
            }
        }
        internal void CopyImplementedMitigationTask()
        {
            /*TODO - CopyImplementedMitigationTask*/
            throw new NotImplementedException();
        }
        internal void EditImplementedMitigationTask()
        {
            /*TODO - EditImplementedMitigationTask*/
            throw new NotImplementedException();
        }
        internal void RemoveImplementedMitigationTask()
        {
            /*TODO - RemoveImplementedMitigationTask*/
            throw new NotImplementedException();
        }
        internal void ListImplementedMitigationTasks()
        {
            /*TODO - ListImplementedMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ExportImplementedMitigationTasks()
        {
            /*TODO - ExportImplementedMitigationTasks*/
            throw new NotImplementedException();
        }
        internal void ImportImplementedMitigationTasks()
        {
            /*TODO - ImportImplementedMitigationTasks*/
            throw new NotImplementedException();
        }
    }
}