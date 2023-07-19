using FinalProject;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalProject
{
    //[JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
    //[JsonDerivedType(typeof(WeatherForecastWithCity))]
    [JsonDerivedType(typeof(JsonPlan), typeDiscriminator: "Plan")]
    [JsonDerivedType(typeof(JsonBackoutPlan), typeDiscriminator: "BackoutPlan")]
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
                    Plan = new(false, false);
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
        [JsonInclude]
        [JsonRequired]
        [JsonPropertyName("BackoutPlan")]
        public JsonBackoutPlan BackoutPlan {
            get {
                if (Plan is null) return null; 
                return Plan.BackoutPlan;
            } set {
                if (Plan is not null) Plan.BackoutPlan = value;
            } }
        public JsonPlan() : base()
        {
            Plan = new(false, false);
        }
        [JsonConstructor]
        public JsonPlan(JsonNamedObject NamedObject, String Description, JsonName Manager, JsonTasks Tasks, JsonRisks Risks, JsonBackoutPlan BackoutPlan) : base()
        {
            this.NamedObject = NamedObject;
            this.Description = Description;
            this.Manager = Manager;
            this.Tasks = Tasks;
            this.Risks = Risks;
            this.BackoutPlan = BackoutPlan;
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
        internal Name Manager { get; set; }
        internal Tasks Tasks { get; set; }
        internal Risks Risks { get; set; }
        internal BackoutPlan BackoutPlan { get; set; }
        public Plan(Boolean interactive = false)
        {
            Init(false, interactive);
        }
        public Plan(Boolean backup = false, Boolean interactive = false) {
            Init(backup, interactive);
        }
        public Plan(Plan plan)
        {
            Init(plan);
        }
        public Plan(String Name, String Description, String Manager, Tasks Tasks, Risks Risks, BackoutPlan BackoutPlan)
        {
            Init(Name, Description, Manager, Tasks, Risks, BackoutPlan);
        }
        protected void Init(Boolean backup = false, Boolean interactive = false)
        {
            if(backup)
            {
                Init("", "", "", new(), new(), null);
            }
            else
            {
                Init("", "", "", new(), new(), new BackoutPlan());
            }
        }
        protected void Init(Plan plan)
        {
            Init(plan.Name, plan.Description, plan.Manager, plan.Tasks, plan.Risks, plan.BackoutPlan);
        }
        protected void Init(String Name, String Description, String Manager, Tasks Tasks, Risks Risks, BackoutPlan BackoutPlan)
        {
            Init(new Name(Name, NameType.Thing), Description, new Name(Manager, NameType.Person), Tasks, Risks, BackoutPlan);
        }
        protected void Init(Name Name, String Description, Name Manager, Tasks Tasks, Risks Risks, BackoutPlan BackoutPlan)
        {
            this.Name = Name;
            this.Description = Description;
            this.Manager = Manager;
            this.Tasks = Tasks;
            this.Risks = Risks;
            this.BackoutPlan = BackoutPlan;
            if(BackoutPlan is not null) BackoutPlan.Init(Name, Description, Manager, new(), new(), null);
        }

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
        internal void Display()
        {
            Console.WriteLine($"\nDisplay Plan ({GetNameForMenus()})");
            Console.WriteLine($"{Description}");
            ListRisks();
            ListTasks();
            if (BackoutPlan is not null) DisplayBackOut();
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
                MaxDepth = 20
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
                MaxDepth = 20
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
        internal void AddRisk() => Risks.Add(this);
        internal void CopyRisk() => Risks.Copy(this);
        internal void EditRisk() => Risks.Edit(this);
        internal void RemoveRisk() => Risks.RemoveRisk(this);
        internal void ListRisks() => Risks.Display(this);
        internal void ExportRisks() => Risks.Export(this);
        internal void ImportRisks() => Risks = Risks.Import(this);
        internal void AddTask() => Tasks.Add<Task>(this);
        internal void CopyTask() => Tasks.Copy<Task>(this);
        internal void EditTask() => Tasks.Edit<Task>(this);
        internal void RemoveTask() => Tasks.RemoveTask<Task>(this);
        internal void ListTasks() => Tasks.Display<Task>(this);
        internal void ExportTasks() => Tasks.Export<Task>(this);
        internal void ImportTasks() => Tasks.Import<Task>(this);
        internal void AddBenchmark() => Tasks.Add<Benchmark>(this);
        internal void CopyBenchmark() => Tasks.Copy<Benchmark>(this);
        internal void EditBenchmark() => Tasks.Edit<Benchmark>(this);
        internal void RemoveBenchmark() => Tasks.RemoveTask<Benchmark>(this);
        internal void ListBenchmarks() => Tasks.Display<Benchmark>(this);
        internal void AddTemplateTask() => Tasks.Add<TemplateTask>(this);
        internal void CopyTemplateTask() => Tasks.Copy<TemplateTask>(this);
        internal void EditTemplateTask() => Tasks.Edit<TemplateTask>(this);
        internal void RemoveTemplateTask() => Tasks.RemoveTask<TemplateTask>(this);
        internal void ListTemplateTasks() => Tasks.Display<TemplateTask>(this);
        internal void ExportTemplateTasks() => Tasks.Export<TemplateTask>(this);
        internal void ImportTemplateTasks() => Tasks.Import<TemplateTask>(this);
        internal void AddTemplateBenchmarkTask() => Tasks.Add<TemplateBenchmark>(this);
        internal void CopyTemplateBenchmarkTask() => Tasks.Copy<TemplateBenchmark>(this);
        internal void EditTemplateBenchmarkTask() => Tasks.Edit<TemplateBenchmark>(this);
        internal void RemoveTemplateBenchmarkTask() => Tasks.RemoveTask<TemplateBenchmark>(this);
        internal void ListTemplateBenchmarkTasks() => Tasks.Display<TemplateBenchmark>(this);
        internal void ExportTemplateBenchmarkTasks() => Tasks.Export<TemplateBenchmark>(this);
        internal void ImportTemplateBenchmarkTasks() => Tasks.Import<TemplateBenchmark>(this);
        internal void AddTemplateGoNoGoTask() => Tasks.Add<TemplateGoNoGo>(this);
        internal void CopyTemplateGoNoGoTask() => Tasks.Copy<TemplateGoNoGo>(this);
        internal void EditTemplateGoNoGoTask() => Tasks.Edit<TemplateGoNoGo>(this);
        internal void RemoveTemplateGoNoGoTask() => Tasks.RemoveTask<TemplateGoNoGo>(this);
        internal void ListTemplateGoNoGoTasks() => Tasks.Display<TemplateGoNoGo>(this);
        internal void ExportTemplateGoNoGoTasks() => Tasks.Export<TemplateGoNoGo>(this);
        internal void ImportTemplateGoNoGoTasks() => Tasks.Import<TemplateGoNoGo>(this);
        internal void AddTemplateMitigationTask() => Tasks.Add<TemplateMitigation>(this);
        internal void CopyTemplateMitigationTask() => Tasks.Copy<TemplateMitigation>(this);
        internal void EditTemplateMitigationTask() => Tasks.Edit<TemplateMitigation>(this);
        internal void RemoveTemplateMitigationTask() => Tasks.RemoveTask<TemplateMitigation>(this);
        internal void ListTemplateMitigationTasks() => Tasks.Display<TemplateMitigation>(this);
        internal void ExportTemplateMitigationTasks() => Tasks.Export<TemplateMitigation>(this);
        internal void ImportTemplateMitigationTasks() => Tasks.Import<TemplateMitigation>(this);
        internal void AddScheduledTask() => Tasks.Add<ScheduledTask>(this);
        internal void CopyScheduledTask() => Tasks.Copy<ScheduledTask>(this);
        internal void EditScheduledTask() => Tasks.Edit<ScheduledTask>(this);
        internal void RemoveScheduledTask() => Tasks.RemoveTask<ScheduledTask>(this);
        internal void ListScheduledTasks() => Tasks.Display<ScheduledTask>(this);
        internal void ExportScheduledTasks() => Tasks.Export<ScheduledTask>(this);
        internal void ImportScheduledTasks() => Tasks.Import<ScheduledTask>(this);
        internal void AddScheduledBenchmarkTask() => Tasks.Add<ScheduledBenchmark>(this);
        internal void CopyScheduledBenchmarkTask() => Tasks.Copy<ScheduledBenchmark>(this);
        internal void EditScheduledBenchmarkTask() => Tasks.Edit<ScheduledBenchmark>(this);
        internal void RemoveScheduledBenchmarkTask() => Tasks.RemoveTask<ScheduledBenchmark>(this);
        internal void ListScheduledBenchmarkTasks() => Tasks.Display<ScheduledBenchmark>(this);
        internal void ExportScheduledBenchmarkTasks() => Tasks.Export<ScheduledBenchmark>(this);
        internal void ImportScheduledBenchmarkTasks() => Tasks.Import<ScheduledBenchmark>(this);
        internal void AddScheduledGoNoGoTask() => Tasks.Add<ScheduledGoNoGo>(this);
        internal void CopyScheduledGoNoGoTask() => Tasks.Copy<ScheduledGoNoGo>(this);
        internal void EditScheduledGoNoGoTask() => Tasks.Edit<ScheduledGoNoGo>(this);
        internal void RemoveScheduledGoNoGoTask() => Tasks.RemoveTask<ScheduledGoNoGo>(this);
        internal void ListScheduledGoNoGoTasks() => Tasks.Display<ScheduledGoNoGo>(this);
        internal void ExportScheduledGoNoGoTasks() => Tasks.Export<ScheduledGoNoGo>(this);
        internal void ImportScheduledGoNoGoTasks() => Tasks.Import<ScheduledGoNoGo>(this);
        internal void AddScheduledMitigationTask() => Tasks.Add<ScheduledMitigation>(this);
        internal void CopyScheduledMitigationTask() => Tasks.Copy<ScheduledMitigation>(this);
        internal void EditScheduledMitigationTask() => Tasks.Edit<ScheduledMitigation>(this);
        internal void RemoveScheduledMitigationTask() => Tasks.RemoveTask<ScheduledMitigation>(this);
        internal void ListScheduledMitigationTasks() => Tasks.Display<ScheduledMitigation>(this);
        internal void ExportScheduledMitigationTasks() => Tasks.Export<ScheduledMitigation>(this);
        internal void ImportScheduledMitigationTasks() => Tasks.Import<ScheduledMitigation>(this);
        internal void DisplayBackOut()
        {
            Console.WriteLine($"\nDisplay Backout Plan ({GetNameForMenus()})");
            Console.WriteLine($"{Description}");
            ListRisksBackOut();
            ListTasksBackOut();
        }
        internal void AddRiskBackOut() => BackoutPlan.Risks.Add(this);
        internal void CopyRiskBackOut() => BackoutPlan.Risks.Copy(this);
        internal void EditRiskBackOut() => BackoutPlan.Risks.Edit(this);
        internal void RemoveRiskBackOut() => BackoutPlan.Risks.Remove(this);
        internal void ListRisksBackOut() => BackoutPlan.Risks.Display(this);
        internal void ExportRisksBackOut() => BackoutPlan.Risks.Export(this);
        internal void ImportRisksBackOut() => BackoutPlan.Risks = BackoutPlan.Risks.Import(this);
        internal void AddTaskBackOut() => BackoutPlan.Tasks.Add<Task>(this);
        internal void CopyTaskBackOut() => BackoutPlan.Tasks.Copy<Task>(this);
        internal void EditTaskBackOut() => BackoutPlan.Tasks.Edit<Task>(this);
        internal void RemoveTaskBackOut() => BackoutPlan.Tasks.RemoveTask<Task>(this);
        internal void ListTasksBackOut() => BackoutPlan.Tasks.Display<Task>(this);
        internal void ExportTasksBackOut() => BackoutPlan.Tasks.Export<Task>(this);
        internal void ImportTasksBackOut() => BackoutPlan.Tasks.Import<Task>(this);
        internal void AddTemplateTaskBackOut() => BackoutPlan.Tasks.Add<TemplateTask>(this);
        internal void CopyTemplateTaskBackOut() => BackoutPlan.Tasks.Copy<TemplateTask>(this);
        internal void EditTemplateTaskBackOut() => BackoutPlan.Tasks.Edit<TemplateTask>(this);
        internal void RemoveTemplateTaskBackOut() => BackoutPlan.Tasks.RemoveTask<TemplateTask>(this);
        internal void ListTemplateTasksBackOut() => BackoutPlan.Tasks.Display<TemplateTask>(this);
        internal void ExportTemplateTasksBackOut() => BackoutPlan.Tasks.Export<TemplateTask>(this);
        internal void ImportTemplateTasksBackOut() => BackoutPlan.Tasks.Import<TemplateTask>(this);
        internal void AddTemplateBenchmarkTaskBackOut() => BackoutPlan.Tasks.Add<TemplateBenchmark>(this);
        internal void CopyTemplateBenchmarkTaskBackOut() => BackoutPlan.Tasks.Copy<TemplateBenchmark>(this);
        internal void EditTemplateBenchmarkTaskBackOut() => BackoutPlan.Tasks.Edit<TemplateBenchmark>(this);
        internal void RemoveTemplateBenchmarkTaskBackOut() => BackoutPlan.Tasks.RemoveTask<TemplateBenchmark>(this);
        internal void ListTemplateBenchmarkTasksBackOut() => BackoutPlan.Tasks.Display<TemplateBenchmark>(this);
        internal void ExportTemplateBenchmarkTasksBackOut() => BackoutPlan.Tasks.Export<TemplateBenchmark>(this);
        internal void ImportTemplateBenchmarkTasksBackOut() => BackoutPlan.Tasks.Import<TemplateBenchmark>(this);
        internal void AddTemplateMitigationTaskBackOut() => BackoutPlan.Tasks.Add<TemplateMitigation>(this);
        internal void CopyTemplateMitigationTaskBackOut() => BackoutPlan.Tasks.Copy<TemplateMitigation>(this);
        internal void EditTemplateMitigationTaskBackOut() => BackoutPlan.Tasks.Edit<TemplateMitigation>(this);
        internal void RemoveTemplateMitigationTaskBackOut() => BackoutPlan.Tasks.RemoveTask<TemplateMitigation>(this);
        internal void ListTemplateMitigationTasksBackOut() => BackoutPlan.Tasks.Display<TemplateMitigation>(this);
        internal void ExportTemplateMitigationTasksBackOut() => BackoutPlan.Tasks.Export<TemplateMitigation>(this);
        internal void ImportTemplateMitigationTasksBackOut() => BackoutPlan.Tasks.Import<TemplateMitigation>(this);
        internal void AddScheduledTaskBackOut() => BackoutPlan.Tasks.Add<ScheduledTask>(this);
        internal void CopyScheduledTaskBackOut() => BackoutPlan.Tasks.Copy<ScheduledTask>(this);
        internal void EditScheduledTaskBackOut() => BackoutPlan.Tasks.Edit<ScheduledTask>(this);
        internal void RemoveScheduledTaskBackOut() => BackoutPlan.Tasks.RemoveTask<ScheduledTask>(this);
        internal void ListScheduledTasksBackOut() => BackoutPlan.Tasks.Display<ScheduledTask>(this);
        internal void ExportScheduledTasksBackOut() => BackoutPlan.Tasks.Export<ScheduledTask>(this);
        internal void ImportScheduledTasksBackOut() => BackoutPlan.Tasks.Import<ScheduledTask>(this);
        internal void AddScheduledBenchmarkTaskBackOut() => BackoutPlan.Tasks.Add<ScheduledBenchmark>(this);
        internal void CopyScheduledBenchmarkTaskBackOut() => BackoutPlan.Tasks.Copy<ScheduledBenchmark>(this);
        internal void EditScheduledBenchmarkTaskBackOut() => BackoutPlan.Tasks.Edit<ScheduledBenchmark>(this);
        internal void RemoveScheduledBenchmarkTaskBackOut() => BackoutPlan.Tasks.RemoveTask<ScheduledBenchmark>(this);
        internal void ListScheduledBenchmarkTasksBackOut() => BackoutPlan.Tasks.Display<ScheduledBenchmark>(this);
        internal void ExportScheduledBenchmarkTasksBackOut() => BackoutPlan.Tasks.Export<ScheduledBenchmark>(this);
        internal void ImportScheduledBenchmarkTasksBackOut() => BackoutPlan.Tasks.Import<ScheduledBenchmark>(this);
        internal void AddScheduledMitigationTaskBackOut() => BackoutPlan.Tasks.Add<ScheduledMitigation>(this);
        internal void CopyScheduledMitigationTaskBackOut() => BackoutPlan.Tasks.Copy<ScheduledMitigation>(this);
        internal void EditScheduledMitigationTaskBackOut() => BackoutPlan.Tasks.Edit<ScheduledMitigation>(this);
        internal void RemoveScheduledMitigationTaskBackOut() => BackoutPlan.Tasks.RemoveTask<ScheduledMitigation>(this);
        internal void ListScheduledMitigationTasksBackOut() => BackoutPlan.Tasks.Display<ScheduledMitigation>(this);
        internal void ExportScheduledMitigationTasksBackOut() => BackoutPlan.Tasks.Export<ScheduledMitigation>(this);
        internal void ImportScheduledMitigationTasksBackOut() => BackoutPlan.Tasks.Import<ScheduledMitigation>(this);
    }
}