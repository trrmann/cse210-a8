namespace FinalProject
{
    public class Plan : DescribedObject
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
        protected void Init(String description, Person manager, Organizations organizations, Tasks tasks)
        {
            base.Init(NameType.Thing, true);
            Description = description;
            Manager = manager;
            Organizations = organizations;
            Tasks = tasks;
        }
        public Organizations Organizations { get; internal set; }
        internal Person Manager { get; set; }
        private Tasks Tasks { get; set; }
        private Risks Risks { get; set; }

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
            Organizations.DisplayPerson(Manager);
        }
        internal String GetNameForMenus()
        {
            if (IsNamed() && IsManaged())
            {
                return Name + " by " + Manager.ToNameString();
            }
            else if (IsNamed())
            {
                return Name;
            }
            else if (IsManaged())
            {
                return "? by " + Manager.ToNameString();
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
            Console.WriteLine("\nAssign _name");
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
                Dictionary<int, Person> optionMap = Organizations.People.GetOptionMap();
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
                Manager.AddRole(Organizations.OrganizationalRoles, "Manager");
            }
        }
        private void AddManager()
        {
            Manager = Organizations.AddPerson();
            Manager.AddRole(Organizations.OrganizationalRoles, "Manager");
        }
        internal void DisplaySummary()
        {
            Console.WriteLine($"\nView Summary ({GetNameForMenus()})");
            Console.WriteLine($"{Description}");
        }
        internal void RemoveOrganization() {
            Organizations.RemoveOrganization(this);
        }
        internal void RemoveTeam()
        {
            Organizations.RemoveTeam(this);
        }
        internal void RemovePerson()
        {
            Organizations.RemovePerson(this);
        }
        internal void CopyPerson()
        {
            Organizations.CopyPerson(this);
        }
        internal void EditPerson()
        {
            Organizations.EditPerson(this);
        }
        internal void AddTask()
        {
            /*TODO - AddTask*/
            throw new NotImplementedException();
        }
        internal void CopyTask()
        {
            /*TODO - CopyTask*/
            throw new NotImplementedException();
        }
        internal void EditTask()
        {
            /*TODO - EditTask*/
            throw new NotImplementedException();
        }
        internal void RemoveTask()
        {
            /*TODO - RemoveTask*/
            throw new NotImplementedException();
        }
        internal void ListTasks()
        {
            /*TODO - ListTasks*/
            throw new NotImplementedException();
        }
        internal void ExportTasks()
        {
            Tasks.Export(Tasks);
        }
        internal void ImportTasks()
        {
            Tasks.Import(Tasks);
        }
        internal void AddBenchmark()
        {
            /*TODO - AddBenchmark*/
            throw new NotImplementedException();
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
            /*TODO - AddRisk*/
            throw new NotImplementedException();
        }
        internal void CopyRisk()
        {
            /*TODO - CopyRisk*/
            throw new NotImplementedException();
        }
        internal void EditRisk()
        {
            /*TODO - EditRisk*/
            throw new NotImplementedException();
        }
        internal void RemoveRisk()
        {
            /*TODO - RemoveRisk*/
            throw new NotImplementedException();
        }
        internal void ListRisks()
        {
            /*TODO - ListRisks*/
            throw new NotImplementedException();
        }
        internal void ExportRisks()
        {
            Risks.Export(Risks);
        }
        internal void ImportRisks()
        {
            Risks.Import(Risks);
        }
        internal void Display()
        {
            /*TODO - Display*/
            throw new NotImplementedException();
        }
        internal void Load()
        {
            /*TODO - Load*/
            throw new NotImplementedException();
        }
        internal void Save()
        {
            /*TODO - Save*/
            throw new NotImplementedException();
        }
        internal void Copy()
        {
            /*TODO - Copy*/
            throw new NotImplementedException();
        }
        internal void Rename()
        {
            /*TODO - Rename*/
            throw new NotImplementedException();
        }
        internal void Delete()
        {
            /*TODO - Delete*/
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
            /*TODO - AddTemplateTask*/
            throw new NotImplementedException();
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
            Tasks.Export(Tasks);
            /*TODO - ExportTemplateTasks*/
            throw new NotImplementedException();
        }
        internal void ImportTemplateTasks()
        {
            Tasks.Import(Tasks);
            /*TODO - ImportTemplateTasks*/
            throw new NotImplementedException();
        }
        internal void AddTemplateBenchmarkTask()
        {
            /*TODO - AddTemplateBenchmarkTask*/
            throw new NotImplementedException();
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
            /*TODO - AddTemplateGoNoGoTask*/
            throw new NotImplementedException();
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
            /*TODO - AddTemplateMitigationTask*/
            throw new NotImplementedException();
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
            /*TODO - AddAssignedTask*/
            throw new NotImplementedException();
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
            /*TODO - AddAssignedBenchmarkTask*/
            throw new NotImplementedException();
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
            /*TODO - AddAssignedGoNoGoTask*/
            throw new NotImplementedException();
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
            /*TODO - AddAssignedMitigationTask*/
            throw new NotImplementedException();
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
            /*TODO - AddScheduledBenchmarkTask*/
            throw new NotImplementedException();
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
            /*TODO - AddScheduledGoNoGoTask*/
            throw new NotImplementedException();
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
            /*TODO - AddScheduledMitigationTask*/
            throw new NotImplementedException();
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
            /*TODO - AddImplementedTask*/
            throw new NotImplementedException();
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
            /*TODO - ImportImplementedTasks*/
            throw new NotImplementedException();
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
            /*TODO - AddImplementedGoNoGoTask*/
            throw new NotImplementedException();
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
            /*TODO - AddImplementedMitigationTask*/
            throw new NotImplementedException();
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