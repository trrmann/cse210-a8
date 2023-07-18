using FinalProject;
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
        internal BackoutPlan BackoutPlan { get; set; }

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
        internal void AddAssignedTask() => Tasks.Add<AssignedTask>(this);
        internal void CopyAssignedTask() => Tasks.Copy<AssignedTask>(this);
        internal void EditAssignedTask() => Tasks.Edit<AssignedTask>(this);
        internal void RemoveAssignedTask() => Tasks.RemoveTask<AssignedTask>(this);
        internal void ListAssignedTasks() => Tasks.Display<AssignedTask>(this);
        internal void ExportAssignedTasks() => Tasks.Export<AssignedTask>(this);
        internal void ImportAssignedTasks() => Tasks.Import<AssignedTask>(this);
        internal void AddAssignedBenchmarkTask() => Tasks.Add<AssignedBenchmark>(this);
        internal void CopyAssignedBenchmarkTask() => Tasks.Copy<AssignedBenchmark>(this);
        internal void EditAssignedBenchmarkTask() => Tasks.Edit<AssignedBenchmark>(this);
        internal void RemoveAssignedBenchmarkTask() => Tasks.RemoveTask<AssignedBenchmark>(this);
        internal void ListAssignedBenchmarkTasks() => Tasks.Display<AssignedBenchmark>(this);
        internal void ExportAssignedBenchmarkTasks() => Tasks.Export<AssignedBenchmark>(this);
        internal void ImportAssignedBenchmarkTasks() => Tasks.Import<AssignedBenchmark>(this);
        internal void AddAssignedGoNoGoTask() => Tasks.Add<AssignedGoNoGo>(this);
        internal void CopyAssignedGoNoGoTask() => Tasks.Copy<AssignedGoNoGo>(this);
        internal void EditAssignedGoNoGoTask() => Tasks.Edit<AssignedGoNoGo>(this);
        internal void RemoveAssignedGoNoGoTask() => Tasks.RemoveTask<AssignedGoNoGo>(this);
        internal void ListAssignedGoNoGoTasks() => Tasks.Display<AssignedGoNoGo>(this);
        internal void ExportAssignedGoNoGoTasks() => Tasks.Export<AssignedGoNoGo>(this);
        internal void ImportAssignedGoNoGoTasks() => Tasks.Import<AssignedGoNoGo>(this);
        internal void AddAssignedMitigationTask() => Tasks.Add<AssignedMitigation>(this);
        internal void CopyAssignedMitigationTask() => Tasks.Copy<AssignedMitigation>(this);
        internal void EditAssignedMitigationTask() => Tasks.Edit<AssignedMitigation>(this);
        internal void RemoveAssignedMitigationTask() => Tasks.RemoveTask<AssignedMitigation>(this);
        internal void ListAssignedMitigationTasks() => Tasks.Display<AssignedMitigation>(this);
        internal void ExportAssignedMitigationTasks() => Tasks.Export<AssignedMitigation>(this);
        internal void ImportAssignedMitigationTasks() => Tasks.Import<AssignedMitigation>(this);
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
        internal void AddImplementedTask() => Tasks.Add<ImplementedTask>(this);
        internal void CopyImplementedTask() => Tasks.Copy<ImplementedTask>(this);
        internal void EditImplementedTask() => Tasks.Edit<ImplementedTask>(this);
        internal void RemoveImplementedTask() => Tasks.RemoveTask<ImplementedTask>(this);
        internal void ListImplementedTasks() => Tasks.Display<ImplementedTask>(this);
        internal void ExportImplementedTasks() => Tasks.Export<ImplementedTask>(this);
        internal void ImportImplementedTasks() => Tasks.Import<ImplementedTask>(this);
        internal void AddImplementedBenchmarkTask() => Tasks.Add<ImplementedBenchmark>(this);
        internal void CopyImplementedBenchmarkTask() => Tasks.Copy<ImplementedBenchmark>(this);
        internal void EditImplementedBenchmarkTask() => Tasks.Edit<ImplementedBenchmark>(this);
        internal void RemoveImplementedBenchmarkTask() => Tasks.RemoveTask<ImplementedBenchmark>(this);
        internal void ListImplementedBenchmarkTasks() => Tasks.Display<ImplementedBenchmark>(this);
        internal void ExportImplementedBenchmarkTasks() => Tasks.Export<ImplementedBenchmark>(this);
        internal void ImportImplementedBenchmarkTasks() => Tasks.Import<ImplementedBenchmark>(this);
        internal void AddImplementedGoNoGoTask() => Tasks.Add<ImplementedGoNoGo>(this);
        internal void CopyImplementedGoNoGoTask() => Tasks.Copy<ImplementedGoNoGo>(this);
        internal void EditImplementedGoNoGoTask() => Tasks.Edit<ImplementedGoNoGo>(this);
        internal void RemoveImplementedGoNoGoTask() => Tasks.RemoveTask<ImplementedGoNoGo>(this);
        internal void ListImplementedGoNoGoTasks() => Tasks.Display<ImplementedGoNoGo>(this);
        internal void ExportImplementedGoNoGoTasks() => Tasks.Export<ImplementedGoNoGo>(this);
        internal void ImportImplementedGoNoGoTasks() => Tasks.Import<ImplementedGoNoGo>(this);
        internal void AddImplementedMitigationTask() => Tasks.Add<ImplementedMitigation>(this);
        internal void CopyImplementedMitigationTask() => Tasks.Copy<ImplementedMitigation>(this);
        internal void EditImplementedMitigationTask() => Tasks.Edit<ImplementedMitigation>(this);
        internal void RemoveImplementedMitigationTask() => Tasks.RemoveTask<ImplementedMitigation>(this);
        internal void ListImplementedMitigationTasks() => Tasks.Display<ImplementedMitigation>(this);
        internal void ExportImplementedMitigationTasks() => Tasks.Export<ImplementedMitigation>(this);
        internal void ImportImplementedMitigationTasks() => Tasks.Import<ImplementedMitigation>(this);
    }
}