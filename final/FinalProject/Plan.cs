namespace FinalProject
{
    public class Plan : NamedObjectWithDetail
    {
        public Plan() {
            Init();
        }
        public Plan(Plan plan)
        {
            Init(plan);
        }
        public Plan(Organizations organizations)
        {
            Init(organizations);
        }
        public Plan(Plan plan, Organizations organizations)
        {
            Init(plan, organizations);
        }
        protected void Init()
        {
            Init(null, null, new(), new());
        }
        protected void Init(Organizations organizations)
        {
            Init(null, null, organizations, new());
        }
        protected void Init(Plan plan, Organizations organizations)
        {
            Init(plan.Description, plan.Manager, organizations, plan.Tasks);
        }
        protected void Init(Plan plan)
        {
            Init(plan.Description, plan.Manager, plan.Organizations, plan.Tasks);
        }
        protected void Init(String description, String managerKey, Organizations organizations, Tasks tasks)
        {
            base.Init(NameType.Thing, true);
            Description = description;
            Manager = managerKey;
            Organizations = organizations;
            Tasks = tasks;
        }
        public Organizations Organizations { get; internal set; }
        private String Manager { get; set; }
        private Tasks Tasks { get; set; }
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
            Organizations.DisplayPersonByKey(Manager);
        }
        internal String GetNameForMenus()
        {
            if (IsNamed() && IsManaged())
            {
                return Name + " by " + Organizations.People[Manager].ToNameString();
            }
            else if (IsNamed())
            {
                return Name;
            }
            else if (IsManaged())
            {
                return "? by " + Organizations.People[Manager].ToNameString();
            }
            else
            {
                return "?";
            }
        }
        private Boolean IsManaged()
        {
            return Manager != null;
        }
        protected override void DisplaySetName()
        {
            Console.WriteLine("\nAssign Name");
        }
        protected override void DisplayRequestReSetName()
        {
            Console.WriteLine("\nRename plan?");
        }
        protected override void DisplayRequestSetName()
        {
            Console.WriteLine("\nWhat is the name of the plan?");
        }
        protected override void DisplaySetDescription()
        {
            Console.WriteLine("\nAssign Description");
        }
        protected override void DisplayRequestReSetDescription()
        {
            Console.WriteLine("\nRedescribe plan?");
        }
        protected override void DisplayRequestSetDescription()
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
                int option = -1;
                Dictionary<int, String> optionMap = Organizations.People.GetOptionMap();
                while (!optionMap.Keys.Contains(option))
                {
                    Console.Write("\n");
                    Organizations.People.DisplayPersonOptions();
                    Console.WriteLine("\nWho is managing the plan?");
                    try
                    {
                        option = int.Parse(IApplication.READ_RESPONSE());
                    }
                    catch
                    {
                        IApplication.DisplayInvalidMenuSelection();
                    }
                }
                Manager = optionMap[option];
                Organizations.People[Manager].AddRole(Organizations.RoleDefinitions, "Manager");
            }
        }
        private void AddManager()
        {
            Manager = Organizations.AddPersonKey();
            Organizations.People[Manager].AddRole(Organizations.RoleDefinitions, "Manager");
        }
        internal void DisplaySummary()
        {
            Console.WriteLine($"\nView Summary ({GetNameForMenus()})");
            Console.WriteLine($"{Description}");
        }
        internal void AddTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyTask()
        {
            throw new NotImplementedException();
        }
        internal void EditTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTask()
        {
            throw new NotImplementedException();
        }
        internal void ListTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddBenchmark()
        {
            throw new NotImplementedException();
        }
        internal void CopyBenchmark()
        {
            throw new NotImplementedException();
        }
        internal void EditBenchmark()
        {
            throw new NotImplementedException();
        }
        internal void RemoveBenchmark()
        {
            throw new NotImplementedException();
        }
        internal void ListBenchmarks()
        {
            throw new NotImplementedException();
        }
        internal void AddRisk()
        {
            throw new NotImplementedException();
        }
        internal void CopyRisk()
        {
            throw new NotImplementedException();
        }
        internal void EditRisk()
        {
            throw new NotImplementedException();
        }
        internal void RemoveRisk()
        {
            throw new NotImplementedException();
        }
        internal void ListRisks()
        {
            throw new NotImplementedException();
        }
        internal void ExportRisks()
        {
            throw new NotImplementedException();
        }
        internal void ImportRisks()
        {
            throw new NotImplementedException();
        }
        internal void Display()
        {
            throw new NotImplementedException();
        }
        internal void Load()
        {
            throw new NotImplementedException();
        }
        internal void Save()
        {
            throw new NotImplementedException();
        }
        internal void Copy()
        {
            throw new NotImplementedException();
        }
        internal void Rename()
        {
            throw new NotImplementedException();
        }
        internal void Delete()
        {
            throw new NotImplementedException();
        }
        internal String GetAssignManagerOrAddManager()
        {
            if (Organizations.People.Count > 0) return "Assign Manager";
            else return "Add Manager";
        }
        internal void AssignManagerOrAddManager()
        {
            if (Organizations.People.Count > 0) SetManager();
            else AddManager();
        }

        internal void Test()
        {
            throw new NotImplementedException();
        }
        internal void Implement()
        {
            throw new NotImplementedException();
        }
        internal void PlanRollback()
        {
            throw new NotImplementedException();
        }
        internal void TestRollback()
        {
            throw new NotImplementedException();
        }
        internal void Rollback()
        {
            throw new NotImplementedException();
        }
        internal void Estimate()
        {
            throw new NotImplementedException();
        }
        internal void Allocate()
        {
            throw new NotImplementedException();
        }
        internal void AddTemplateTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyTemplateTask()
        {
            throw new NotImplementedException();
        }
        internal void EditTemplateTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTemplateTask()
        {
            throw new NotImplementedException();
        }
        internal void ListTemplateTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportTemplateTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportTemplateTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddTemplateBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyTemplateBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void EditTemplateBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTemplateBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void ListTemplateBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportTemplateBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportTemplateBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddTemplateGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyTemplateGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void EditTemplateGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTemplateGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void ListTemplateGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportTemplateGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportTemplateGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddTemplateMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyTemplateMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void EditTemplateMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveTemplateMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void ListTemplateMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportTemplateMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportTemplateMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddAssignedTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyAssignedTask()
        {
            throw new NotImplementedException();
        }
        internal void EditAssignedTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveAssignedTask()
        {
            throw new NotImplementedException();
        }
        internal void ListAssignedTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportAssignedTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportAssignedTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddAssignedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyAssignedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void EditAssignedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveAssignedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void ListAssignedBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportAssignedBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportAssignedBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddAssignedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyAssignedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void EditAssignedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveAssignedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void ListAssignedGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportAssignedGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportAssignedGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddAssignedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyAssignedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void EditAssignedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveAssignedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void ListAssignedMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportAssignedMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportAssignedMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddScheduledTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyScheduledTask()
        {
            throw new NotImplementedException();
        }
        internal void EditScheduledTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveScheduledTask()
        {
            throw new NotImplementedException();
        }
        internal void ListScheduledTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportScheduledTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportScheduledTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddScheduledBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyScheduledBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void EditScheduledBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveScheduledBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void ListScheduledBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportScheduledBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportScheduledBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddScheduledGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyScheduledGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void EditScheduledGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveScheduledGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void ListScheduledGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportScheduledGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportScheduledGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddScheduledMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyScheduledMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void EditScheduledMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveScheduledMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void ListScheduledMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportScheduledMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportScheduledMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddImplementedTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyImplementedTask()
        {
            throw new NotImplementedException();
        }
        internal void EditImplementedTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveImplementedTask()
        {
            throw new NotImplementedException();
        }
        internal void ListImplementedTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportImplementedTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportImplementedTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddImplementedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyImplementedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void EditImplementedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveImplementedBenchmarkTask()
        {
            throw new NotImplementedException();
        }
        internal void ListImplementedBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportImplementedBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportImplementedBenchmarkTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddImplementedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyImplementedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void EditImplementedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveImplementedGoNoGoTask()
        {
            throw new NotImplementedException();
        }
        internal void ListImplementedGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportImplementedGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportImplementedGoNoGoTasks()
        {
            throw new NotImplementedException();
        }
        internal void AddImplementedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void CopyImplementedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void EditImplementedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void RemoveImplementedMitigationTask()
        {
            throw new NotImplementedException();
        }
        internal void ListImplementedMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ExportImplementedMitigationTasks()
        {
            throw new NotImplementedException();
        }
        internal void ImportImplementedMitigationTasks()
        {
            throw new NotImplementedException();
        }
    }
}