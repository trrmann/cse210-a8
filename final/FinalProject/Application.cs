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
                    { 1, new(true, new(new("1)  Manage Plan Summary", null), new("PlanSummaryMenu", null))) },
                    { 2, new(true, new(new("2)  File Menu",null), new ("FileMenu", null))) },
                    { 3, new(true, new(new("3)  Display Plan",null), new ("", Plan.Display))) },
                    { 4, new(true, new(new("4)  Manage Plan",null), new ("PlanMenu", null))) },
                    { 5, new(true, new(new("5)  Manage Tasks",null), new ("TaskMenu", null))) },
                    { 6, new(true, new(new("6)  Manage Risks",null), new ("RiskMenu", null))) },
                    { 7, new(true, new(new("7)  Manage Backout Plan",null), new ("BackoutPlanMenu", null))) },
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
                    { 2, new(true, new(new("2)  Manage Scheduled Tasks", null), new("ScheduledTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Tasks", null), new("TasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TasksMenu", new(){
                    { 0, new(false, new(new("\nTask Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Task", null), new("", Plan.AddTask))) },
                    { 2, new(true, new(new("2)  Copy Task", null), new("", Plan.CopyTask))) },
                    { 3, new(true, new(new("3)  Edit Task", null), new("", Plan.EditTask))) },
                    { 4, new(true, new(new("4)  Remove Task", null), new("", Plan.RemoveTask))) },
                    { 5, new(true, new(new("5)  List Tasks", null), new("", Plan.ListTasks))) },
                    { 6, new(true, new(new("6)  Export Tasks", null), new("", Plan.ExportTasks))) },
                    { 7, new(true, new(new("7)  Import Tasks", null), new("", Plan.ImportTasks))) },
                    { 8, new(true, new(new("8)  Return to Task Management Menu", null), new("TaskMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
                },
                { "TemplateTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Template Tasks", null), new("TemplateRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Template Benchmark Tasks", null), new("TemplateBenchmarkTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Template Go / No Go Tasks", null), new("TemplateGoNoGoTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Template Mitigation Tasks", null), new("TemplateMitigationTasksMenu", null))) },
                    { 7, new(true, new(new("7)  Return to Task Management Menu", null), new("TaskMenu", null))) },
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
                    { 8, new(true, new(new("8)  Return to Template Task Management Menu", null), new("TemplateTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                    { 8, new(true, new(new("8)  Return to Template Task Management Menu", null), new("TemplateTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                    { 8, new(true, new(new("8)  Return to Template Task Management Menu", null), new("TemplateTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                    { 8, new(true, new(new("8)  Return to Template Task Management Menu", null), new("TemplateTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
                },
                { "ScheduledTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Scheduled Tasks", null), new("ScheduledRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Scheduled Benchmark Tasks", null), new("ScheduledBenchmarkTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Scheduled Go / No Go Tasks", null), new("ScheduledGoNoGoTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Scheduled Mitigation Tasks", null), new("ScheduledMitigationTasksMenu", null))) },
                    { 7, new(true, new(new("7)  Return to Task Management Menu", null), new("TaskMenu", null))) },
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
                    { 8, new(true, new(new("8)  Return to Scheduled Task Management Menu", null), new("ScheduledTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                    { 8, new(true, new(new("8)  Return to Scheduled Task Management Menu", null), new("ScheduledTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                    { 8, new(true, new(new("8)  Return to Scheduled Task Management Menu", null), new("ScheduledTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                    { 8, new(true, new(new("8)  Return to Scheduled Task Management Menu", null), new("ScheduledTasksMenu", null))) },
                    { 9, new(true, new(new("9)  Return to Main Menu", null), new("MainMenu", null))) } }
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
                },
                { "BackoutPlanMenu", new(){
                    { 0, new(false, new(new("\nBackout Plan Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Display Backout Plan", null), new("", Plan.DisplayBackOut))) },
                    { 2, new(true, new(new("2)  Manage Backout Plan", null), new("BackoutPlanManagementMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Backout Plan Tasks", null), new("BackoutTaskMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Backout Plan Risks", null), new("BackoutRiskMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutPlanManagementMenu", new(){
                    { 0, new(false, new(new("\nPlan Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Allocate Plan", null), new("", Plan.AllocateBackOut))) },
                    { 2, new(true, new(new("2)  Estimate Plan", null), new("", Plan.DeallocateBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutTaskMenu", new(){
                    { 0, new(false, new(new("\nTask Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Template Tasks", null), new("BackoutTemplateTasksMenu", null))) },
                    { 2, new(true, new(new("3)  Manage Scheduled Tasks", null), new("BackoutScheduledTasksMenu", null))) },
                    { 3, new(true, new(new("4)  Manage Tasks", null), new("TasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Task", null), new("", Plan.AddTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Task", null), new("", Plan.CopyTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Task", null), new("", Plan.EditTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Task", null), new("", Plan.RemoveTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Tasks", null), new("", Plan.ListTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Tasks", null), new("", Plan.ExportTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Tasks", null), new("", Plan.ImportTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutTemplateTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Template Tasks", null), new("BackoutTemplateRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Template Benchmark Tasks", null), new("BackoutTemplateBenchmarkTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Template Mitigation Tasks", null), new("BackoutTemplateMitigationTasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutTemplateRegularTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Regular Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template Task", null), new("", Plan.AddTemplateTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Template Task", null), new("", Plan.CopyTemplateTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Template Task", null), new("", Plan.EditTemplateTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Template Task", null), new("", Plan.RemoveTemplateTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Template Tasks", null), new("", Plan.ListTemplateTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Template Tasks", null), new("", Plan.ExportTemplateTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Template Tasks", null), new("", Plan.ImportTemplateTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutTemplateBenchmarkTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Benchmark Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template Benchmark Task", null), new("", Plan.AddTemplateBenchmarkTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Template Benchmark Task", null), new("", Plan.CopyTemplateBenchmarkTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Template Benchmark Task", null), new("", Plan.EditTemplateBenchmarkTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Template Benchmark Task", null), new("", Plan.RemoveTemplateBenchmarkTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Template Benchmark Tasks", null), new("", Plan.ListTemplateBenchmarkTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Template Benchmark Tasks", null), new("", Plan.ExportTemplateBenchmarkTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Template Benchmark Tasks", null), new("", Plan.ImportTemplateBenchmarkTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutTemplateMitigationTasksMenu", new(){
                    { 0, new(false, new(new("\nTemplate Mitigation Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Template Mitigation Task", null), new("", Plan.AddTemplateMitigationTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Template Mitigation Task", null), new("", Plan.CopyTemplateMitigationTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Template Mitigation Task", null), new("", Plan.EditTemplateMitigationTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Template Mitigation Task", null), new("", Plan.RemoveTemplateMitigationTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Template Mitigation Tasks", null), new("", Plan.ListTemplateMitigationTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Template Mitigation Tasks", null), new("", Plan.ExportTemplateMitigationTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Template Mitigation Tasks", null), new("", Plan.ImportTemplateMitigationTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutScheduledTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Scheduled Tasks", null), new("BackoutScheduledRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Scheduled Benchmark Tasks", null), new("BackoutScheduledBenchmarkTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Scheduled Mitigation Tasks", null), new("BackoutScheduledMitigationTasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutScheduledRegularTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Regular Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled Task", null), new("", Plan.AddScheduledTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Scheduled Task", null), new("", Plan.CopyScheduledTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Scheduled Task", null), new("", Plan.EditScheduledTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Scheduled Task", null), new("", Plan.RemoveScheduledTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Scheduled Tasks", null), new("", Plan.ListScheduledTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Scheduled Tasks", null), new("", Plan.ExportScheduledTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Scheduled Tasks", null), new("", Plan.ImportScheduledTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutScheduledBenchmarkTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Benchmark Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled Benchmark Task", null), new("", Plan.AddScheduledBenchmarkTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Scheduled Benchmark Task", null), new("", Plan.CopyScheduledBenchmarkTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Scheduled Benchmark Task", null), new("", Plan.EditScheduledBenchmarkTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Scheduled Benchmark Task", null), new("", Plan.RemoveScheduledBenchmarkTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Scheduled Benchmark Tasks", null), new("", Plan.ListScheduledBenchmarkTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Scheduled Benchmark Tasks", null), new("", Plan.ExportScheduledBenchmarkTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Scheduled Benchmark Tasks", null), new("", Plan.ImportScheduledBenchmarkTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutScheduledMitigationTasksMenu", new(){
                    { 0, new(false, new(new("\nScheduled Mitigation Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Scheduled Mitigation Task", null), new("", Plan.AddScheduledMitigationTaskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Scheduled Mitigation Task", null), new("", Plan.CopyScheduledMitigationTaskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Scheduled Mitigation Task", null), new("", Plan.EditScheduledMitigationTaskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Scheduled Mitigation Task", null), new("", Plan.RemoveScheduledMitigationTaskBackOut))) },
                    { 5, new(true, new(new("5)  List Scheduled Mitigation Tasks", null), new("", Plan.ListScheduledMitigationTasksBackOut))) },
                    { 6, new(true, new(new("6)  Export Scheduled Mitigation Tasks", null), new("", Plan.ExportScheduledMitigationTasksBackOut))) },
                    { 7, new(true, new(new("7)  Import Scheduled Mitigation Tasks", null), new("", Plan.ImportScheduledMitigationTasksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "BackoutRiskMenu", new(){
                    { 0, new(false, new(new("\nRisk Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Risk", null), new("", Plan.AddRiskBackOut))) },
                    { 2, new(true, new(new("2)  Copy Risk", null), new("", Plan.CopyRiskBackOut))) },
                    { 3, new(true, new(new("3)  Edit Risk", null), new("", Plan.EditRiskBackOut))) },
                    { 4, new(true, new(new("4)  Remove Risk", null), new("", Plan.RemoveRiskBackOut))) },
                    { 5, new(true, new(new("5)  List Risks", null), new("", Plan.ListRisksBackOut))) },
                    { 6, new(true, new(new("6)  Export Risks", null), new("", Plan.ExportRisksBackOut))) },
                    { 7, new(true, new(new("7)  Import Risks", null), new("", Plan.ImportRisksBackOut))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                }
            };
            } }
        internal void Run()
        {
            Plan = new(false,false);
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