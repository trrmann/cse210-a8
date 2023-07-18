using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject
{
    public class Application : IApplication
    {
        private Boolean Running { get; set; }
        private Plan Plan { get; set; }
        private String CurrentMenuName { get; set; }
        private Dictionary<String, Dictionary<int, Tuple<Boolean, Tuple<Tuple<String, Func<String>>, Tuple<String, Action>>>>> MenuDictionary { get { return new() {
                { "MainMenu", new(){
                    { 0, new(false, new(new("\nMain Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  File Menu",null), new ("FileMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Tasks",null), new ("TaskMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Risks",null), new ("RiskMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Plan",null), new ("PlanMenu", null))) },
                    { 5, new(true, new(new("5)  Manage Plan Summary", null), new("PlanSummaryMenu", null))) },
                    { 6, new(true, new(new("6)  Display Plan",null), new ("", Plan.Display))) },
                    { 9, new(true, new(new("9)  Quit.",null), new ("", Exit))) } }
                },
                { "FileMenu", new(){
                    { 0, new(false, new(new("\nFile Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Open Plan", null), new("", Plan.Load))) },
                    { 2, new(true, new(new("2)  Save Plan", null), new("", Plan.Save))) },
                    { 3, new(true, new(new("3)  Copy Plan", null), new("", Plan.Copy))) },
                    { 4, new(true, new(new("4)  Rename Plan", null), new("", Plan.Rename))) },
                    { 5, new(true, new(new("5)  Delete Plan", null), new("", Plan.Delete))) },
                    { 6, new(true, new(new("6)  List Files", null), new("", Plan.Showfiles))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TaskMenu", new(){
                    { 0, new(false, new(new("\nTask Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Template Tasks", null), new("TemplateTasksMenu", null))) },
                    { 2, new(true, new(new("3)  Manage Scheduled Tasks", null), new("ScheduledTasksMenu", null))) },
                    { 3, new(true, new(new("4)  Manage Tasks", null), new("TasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Task", null), new("", Plan.AddTask))) },
                    { 2, new(true, new(new("2)  Copy Task", null), new("", Plan.CopyTask))) },
                    { 3, new(true, new(new("3)  Edit Task", null), new("", Plan.EditTask))) },
                    { 4, new(true, new(new("4)  Remove Task", null), new("", Plan.RemoveTask))) },
                    { 5, new(true, new(new("5)  List Tasks", null), new("", Plan.ListTasks))) },
                    { 6, new(true, new(new("6)  Export Tasks", null), new("", Plan.ExportTasks))) },
                    { 7, new(true, new(new("7)  Import Tasks", null), new("", Plan.ImportTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TemplateTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Template Tasks", null), new("TemplateRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Template Benchmark Tasks", null), new("TemplateBenchmarkTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Template Go / No Go Tasks", null), new("TemplateGoNoGoTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Template Mitigation Tasks", null), new("TemplateMitigationTasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TemplateRegularTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Regular Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template Task", null), new("", Plan.AddTemplateTask))) },
                    { 2, new(true, new(new("2)  Copy Template Task", null), new("", Plan.CopyTemplateTask))) },
                    { 3, new(true, new(new("3)  Edit Template Task", null), new("", Plan.EditTemplateTask))) },
                    { 4, new(true, new(new("4)  Remove Template Task", null), new("", Plan.RemoveTemplateTask))) },
                    { 5, new(true, new(new("5)  List Template Tasks", null), new("", Plan.ListTemplateTasks))) },
                    { 6, new(true, new(new("6)  Export Template Tasks", null), new("", Plan.ExportTemplateTasks))) },
                    { 7, new(true, new(new("7)  Import Template Tasks", null), new("", Plan.ImportTemplateTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TemplateBenchmarkTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Benchmark Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template Benchmark Task", null), new("", Plan.AddTemplateBenchmarkTask))) },
                    { 2, new(true, new(new("2)  Copy Template Benchmark Task", null), new("", Plan.CopyTemplateBenchmarkTask))) },
                    { 3, new(true, new(new("3)  Edit Template Benchmark Task", null), new("", Plan.EditTemplateBenchmarkTask))) },
                    { 4, new(true, new(new("4)  Remove Template Benchmark Task", null), new("", Plan.RemoveTemplateBenchmarkTask))) },
                    { 5, new(true, new(new("5)  List Template Benchmark Tasks", null), new("", Plan.ListTemplateBenchmarkTasks))) },
                    { 6, new(true, new(new("6)  Export Template Benchmark Tasks", null), new("", Plan.ExportTemplateBenchmarkTasks))) },
                    { 7, new(true, new(new("7)  Import Template Benchmark Tasks", null), new("", Plan.ImportTemplateBenchmarkTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TemplateGoNoGoTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate GoNoGo Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template GoNoGo Task", null), new("", Plan.AddTemplateGoNoGoTask))) },
                    { 2, new(true, new(new("2)  Copy Template GoNoGo Task", null), new("", Plan.CopyTemplateGoNoGoTask))) },
                    { 3, new(true, new(new("3)  Edit Template GoNoGo Task", null), new("", Plan.EditTemplateGoNoGoTask))) },
                    { 4, new(true, new(new("4)  Remove Template GoNoGo Task", null), new("", Plan.RemoveTemplateGoNoGoTask))) },
                    { 5, new(true, new(new("5)  List Template GoNoGo Tasks", null), new("", Plan.ListTemplateGoNoGoTasks))) },
                    { 6, new(true, new(new("6)  Export Template GoNoGo Tasks", null), new("", Plan.ExportTemplateGoNoGoTasks))) },
                    { 7, new(true, new(new("7)  Import Template GoNoGo Tasks", null), new("", Plan.ImportTemplateGoNoGoTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TemplateMitigationTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Mitigation Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template Mitigation Task", null), new("", Plan.AddTemplateMitigationTask))) },
                    { 2, new(true, new(new("2)  Copy Template Mitigation Task", null), new("", Plan.CopyTemplateMitigationTask))) },
                    { 3, new(true, new(new("3)  Edit Template Mitigation Task", null), new("", Plan.EditTemplateMitigationTask))) },
                    { 4, new(true, new(new("4)  Remove Template Mitigation Task", null), new("", Plan.RemoveTemplateMitigationTask))) },
                    { 5, new(true, new(new("5)  List Template Mitigation Tasks", null), new("", Plan.ListTemplateMitigationTasks))) },
                    { 6, new(true, new(new("6)  Export Template Mitigation Tasks", null), new("", Plan.ExportTemplateMitigationTasks))) },
                    { 7, new(true, new(new("7)  Import Template Mitigation Tasks", null), new("", Plan.ImportTemplateMitigationTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ScheduledTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Scheduled Tasks", null), new("ScheduledRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Scheduled Benchmark Tasks", null), new("ScheduledBenchmarkTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Scheduled Go / No Go Tasks", null), new("ScheduledGoNoGoTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Scheduled Mitigation Tasks", null), new("ScheduledMitigationTasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ScheduledRegularTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Regular Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled Task", null), new("", Plan.AddScheduledTask))) },
                    { 2, new(true, new(new("2)  Copy Scheduled Task", null), new("", Plan.CopyScheduledTask))) },
                    { 3, new(true, new(new("3)  Edit Scheduled Task", null), new("", Plan.EditScheduledTask))) },
                    { 4, new(true, new(new("4)  Remove Scheduled Task", null), new("", Plan.RemoveScheduledTask))) },
                    { 5, new(true, new(new("5)  List Scheduled Tasks", null), new("", Plan.ListScheduledTasks))) },
                    { 6, new(true, new(new("6)  Export Scheduled Tasks", null), new("", Plan.ExportScheduledTasks))) },
                    { 7, new(true, new(new("7)  Import Scheduled Tasks", null), new("", Plan.ImportScheduledTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ScheduledBenchmarkTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Benchmark Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled Benchmark Task", null), new("", Plan.AddScheduledBenchmarkTask))) },
                    { 2, new(true, new(new("2)  Copy Scheduled Benchmark Task", null), new("", Plan.CopyScheduledBenchmarkTask))) },
                    { 3, new(true, new(new("3)  Edit Scheduled Benchmark Task", null), new("", Plan.EditScheduledBenchmarkTask))) },
                    { 4, new(true, new(new("4)  Remove Scheduled Benchmark Task", null), new("", Plan.RemoveScheduledBenchmarkTask))) },
                    { 5, new(true, new(new("5)  List Scheduled Benchmark Tasks", null), new("", Plan.ListScheduledBenchmarkTasks))) },
                    { 6, new(true, new(new("6)  Export Scheduled Benchmark Tasks", null), new("", Plan.ExportScheduledBenchmarkTasks))) },
                    { 7, new(true, new(new("7)  Import Scheduled Benchmark Tasks", null), new("", Plan.ImportScheduledBenchmarkTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ScheduledGoNoGoTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled GoNoGo Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled GoNoGo Task", null), new("", Plan.AddScheduledGoNoGoTask))) },
                    { 2, new(true, new(new("2)  Copy Scheduled GoNoGo Task", null), new("", Plan.CopyScheduledGoNoGoTask))) },
                    { 3, new(true, new(new("3)  Edit Scheduled GoNoGo Task", null), new("", Plan.EditScheduledGoNoGoTask))) },
                    { 4, new(true, new(new("4)  Remove Scheduled GoNoGo Task", null), new("", Plan.RemoveScheduledGoNoGoTask))) },
                    { 5, new(true, new(new("5)  List Scheduled GoNoGo Tasks", null), new("", Plan.ListScheduledGoNoGoTasks))) },
                    { 6, new(true, new(new("6)  Export Scheduled GoNoGo Tasks", null), new("", Plan.ExportScheduledGoNoGoTasks))) },
                    { 7, new(true, new(new("7)  Import Scheduled GoNoGo Tasks", null), new("", Plan.ImportScheduledGoNoGoTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ScheduledMitigationTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Mitigation Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled Mitigation Task", null), new("", Plan.AddScheduledMitigationTask))) },
                    { 2, new(true, new(new("2)  Copy Scheduled Mitigation Task", null), new("", Plan.CopyScheduledMitigationTask))) },
                    { 3, new(true, new(new("3)  Edit Scheduled Mitigation Task", null), new("", Plan.EditScheduledMitigationTask))) },
                    { 4, new(true, new(new("4)  Remove Scheduled Mitigation Task", null), new("", Plan.RemoveScheduledMitigationTask))) },
                    { 5, new(true, new(new("5)  List Scheduled Mitigation Tasks", null), new("", Plan.ListScheduledMitigationTasks))) },
                    { 6, new(true, new(new("6)  Export Scheduled Mitigation Tasks", null), new("", Plan.ExportScheduledMitigationTasks))) },
                    { 7, new(true, new(new("7)  Import Scheduled Mitigation Tasks", null), new("", Plan.ImportScheduledMitigationTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "RiskMenu", new(){
                    { 0, new(false, new(new("\nRisk Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Risk", null), new("", Plan.AddRisk))) },
                    { 2, new(true, new(new("2)  Copy Risk", null), new("", Plan.CopyRisk))) },
                    { 3, new(true, new(new("3)  Edit Risk", null), new("", Plan.EditRisk))) },
                    { 4, new(true, new(new("4)  Remove Risk", null), new("", Plan.RemoveRisk))) },
                    { 5, new(true, new(new("5)  List Risks", null), new("", Plan.ListRisks))) },
                    { 6, new(true, new(new("6)  Export Risks", null), new("", Plan.ExportRisks))) },
                    { 7, new(true, new(new("7)  Import Risks", null), new("", Plan.ImportRisks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "PlanMenu", new(){
                    { 0, new(false, new(new("\nPlan Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Allocate Plan", null), new("", Plan.Allocate))) },
                    { 2, new(true, new(new("2)  Estimate Plan", null), new("", Plan.Deallocate))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "PlanSummaryMenu", new(){
                    { 0, new(false, new(new("\nPlan Summary Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Assign Name", null), new("", Plan.RequestName))) },
                    { 2, new(true, new(new("2)  Assign Description", null), new("", Plan.RequestDescription))) },
                    { 3, new(true, new(new("3)  Assign Manager", null), new("", Plan.SetManager))) },
                    { 4, new(true, new(new("4)  Display Summary", null), new("", Plan.DisplaySummary))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                }
            };
            } }
        internal void Run()
        {
            Plan = new();
            Running = true;
            CurrentMenuName = "MainMenu";
            while (Running)
            {
                DisplayMenu();
                Running = EvaluateMenuResponse(IApplication.READ_RESPONSE());
            }
        }
        private void DisplayMenu()
        {
            foreach(int key in MenuDictionary[CurrentMenuName].Keys)
            {
                if (MenuDictionary[CurrentMenuName][key].Item2.Item1.Item2 != null) Console.WriteLine(String.Format(MenuDictionary[CurrentMenuName][key].Item2.Item1.Item1, MenuDictionary[CurrentMenuName][key].Item2.Item1.Item2.Invoke()));
                else Console.WriteLine(MenuDictionary[CurrentMenuName][key].Item2.Item1.Item1);
            }
        }
        private Boolean EvaluateMenuResponse(String response)
        {
            List<int> optionList = new();
            foreach (int key in MenuDictionary[CurrentMenuName].Keys)
            {
                if (MenuDictionary[CurrentMenuName][key].Item1) optionList.Add(key);
            }
            int option;
            try
            {
                option = int.Parse(response);
                if(optionList.Contains(option))
                {
                    if(MenuDictionary[CurrentMenuName][option].Item2.Item2.Item2 is null) CurrentMenuName = MenuDictionary[CurrentMenuName][option].Item2.Item2.Item1;
                    else MenuDictionary[CurrentMenuName][option].Item2.Item2.Item2.Invoke();
                } else IApplication.DisplayInvalidMenuSelection();
                return Running;
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                IApplication.DisplayInvalidMenuSelection();
                return true;
            }
            catch
            {
                IApplication.DisplayInvalidMenuSelection();
                return true;
            }
        }
        private void Exit()
        {
            Running = false;
        }
    }

    public interface IApplication
    {
        public static String READ_RESPONSE()
        {
            Console.Write(">  ");
            return Console.ReadLine();
        }
        public static List<String> YES_RESPONSE { get; } = new List<String>() { "y", "yes" };
        public static void DisplayInvalidMenuSelection()
        {
            Console.WriteLine("Invalid Menu Selection, please try again.");
        }
    }
}