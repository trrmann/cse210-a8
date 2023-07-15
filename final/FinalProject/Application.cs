using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject
{
    public class Application : IApplication
    {
        private Boolean Running { get; set; }
        private Plan Plan { get; set; }
        private Organizations Organizations { get { return Plan; } set { Plan = new Plan(Plan, value);  } }
        private BackoutPlan BackoutPlan {  get; set; }
        private String CurrentMenuName { get; set; }
        private Dictionary<String, Dictionary<int, Tuple<Boolean, Tuple<Tuple<String, Func<String>>, Tuple<String, Action>>>>> MenuDictionary { get { return new() {
                { "MainMenu", new(){
                    { 0, new(false, new(new("\nMain Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  File Menu",null), new ("FileMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Tasks",null), new ("TaskMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Risks",null), new ("RiskMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Plan",null), new ("PlanMenu", null))) },
                    { 5, new(true, new(new("5)  Display Plan",null), new ("", Plan.Display))) },
                    { 8, new(true, new(new("8)  Plan Options",null), new ("PlanOptionsMenu", null))) },
                    { 9, new(true, new(new("9)  Quit.",null), new ("", Exit))) } }
                },
                { "FileMenu", new(){
                    { 0, new(false, new(new("\nFile Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Open Plan", null), new("", Plan.Load))) },
                    { 2, new(true, new(new("2)  Save Plan", null), new("", Plan.Save))) },
                    { 3, new(true, new(new("3)  Copy Plan", null), new("", Plan.Copy))) },
                    { 4, new(true, new(new("4)  Rename Plan", null), new("", Plan.Rename))) },
                    { 5, new(true, new(new("5)  Delete Plan", null), new("", Plan.Delete))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TaskMenu", new(){
                    { 0, new(false, new(new("\nTask Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Template Tasks", null), new("TemplateTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Assigned Tasks", null), new("AssignedTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Scheduled Tasks", null), new("ScheduledTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Implemented Tasks", null), new("ImplementedTasksMenu", null))) },
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
                { "AssignedTasksMenu", new(){
                    { 0, new(false, new(new("\nAssigned Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Assigned Tasks", null), new("AssignedRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Assigned Benchmark Tasks", null), new("AssignedBenchmarkTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Assigned Go / No Go Tasks", null), new("AssignedGoNoGoTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Assigned Mitigation Tasks", null), new("AssignedMitigationTasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "AssignedRegularTasksMenu", new(){
                    { 0, new(false, new(new("\nAssigned Regular Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Assigned Task", null), new("", Plan.AddAssignedTask))) },
                    { 2, new(true, new(new("2)  Copy Assigned Task", null), new("", Plan.CopyAssignedTask))) },
                    { 3, new(true, new(new("3)  Edit Assigned Task", null), new("", Plan.EditAssignedTask))) },
                    { 4, new(true, new(new("4)  Remove Assigned Task", null), new("", Plan.RemoveAssignedTask))) },
                    { 5, new(true, new(new("5)  List Assigned Tasks", null), new("", Plan.ListAssignedTasks))) },
                    { 6, new(true, new(new("6)  Export Assigned Tasks", null), new("", Plan.ExportAssignedTasks))) },
                    { 7, new(true, new(new("7)  Import Assigned Tasks", null), new("", Plan.ImportAssignedTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "AssignedBenchmarkTasksMenu", new(){
                    { 0, new(false, new(new("\nAssigned Benchmark Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Assigned Benchmark Task", null), new("", Plan.AddAssignedBenchmarkTask))) },
                    { 2, new(true, new(new("2)  Copy Assigned Benchmark Task", null), new("", Plan.CopyAssignedBenchmarkTask))) },
                    { 3, new(true, new(new("3)  Edit Assigned Benchmark Task", null), new("", Plan.EditAssignedBenchmarkTask))) },
                    { 4, new(true, new(new("4)  Remove Assigned Benchmark Task", null), new("", Plan.RemoveAssignedBenchmarkTask))) },
                    { 5, new(true, new(new("5)  List Assigned Benchmark Tasks", null), new("", Plan.ListAssignedBenchmarkTasks))) },
                    { 6, new(true, new(new("6)  Export Assigned Benchmark Tasks", null), new("", Plan.ExportAssignedBenchmarkTasks))) },
                    { 7, new(true, new(new("7)  Import Assigned Benchmark Tasks", null), new("", Plan.ImportAssignedBenchmarkTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "AssignedGoNoGoTasksMenu", new(){
                    { 0, new(false, new(new("\nAssigned GoNoGo Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Assigned GoNoGo Task", null), new("", Plan.AddAssignedGoNoGoTask))) },
                    { 2, new(true, new(new("2)  Copy Assigned GoNoGo Task", null), new("", Plan.CopyAssignedGoNoGoTask))) },
                    { 3, new(true, new(new("3)  Edit Assigned GoNoGo Task", null), new("", Plan.EditAssignedGoNoGoTask))) },
                    { 4, new(true, new(new("4)  Remove Assigned GoNoGo Task", null), new("", Plan.RemoveAssignedGoNoGoTask))) },
                    { 5, new(true, new(new("5)  List Assigned GoNoGo Tasks", null), new("", Plan.ListAssignedGoNoGoTasks))) },
                    { 6, new(true, new(new("6)  Export Assigned GoNoGo Tasks", null), new("", Plan.ExportAssignedGoNoGoTasks))) },
                    { 7, new(true, new(new("7)  Import Assigned GoNoGo Tasks", null), new("", Plan.ImportAssignedGoNoGoTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "AssignedMitigationTasksMenu", new(){
                    { 0, new(false, new(new("\nAssigned Mitigation Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Assigned Mitigation Task", null), new("", Plan.AddAssignedMitigationTask))) },
                    { 2, new(true, new(new("2)  Copy Assigned Mitigation Task", null), new("", Plan.CopyAssignedMitigationTask))) },
                    { 3, new(true, new(new("3)  Edit Assigned Mitigation Task", null), new("", Plan.EditAssignedMitigationTask))) },
                    { 4, new(true, new(new("4)  Remove Assigned Mitigation Task", null), new("", Plan.RemoveAssignedMitigationTask))) },
                    { 5, new(true, new(new("5)  List Assigned Mitigation Tasks", null), new("", Plan.ListAssignedMitigationTasks))) },
                    { 6, new(true, new(new("6)  Export Assigned Mitigation Tasks", null), new("", Plan.ExportAssignedMitigationTasks))) },
                    { 7, new(true, new(new("7)  Import Assigned Mitigation Tasks", null), new("", Plan.ImportAssignedMitigationTasks))) },
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
                { "ImplementedTasksMenu", new(){
                    { 0, new(false, new(new("\nImplemented Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Implemented Tasks", null), new("ImplementedRegularTasksMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Implemented Benchmark Tasks", null), new("ImplementedBenchmarkTasksMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Implemented Go / No Go Tasks", null), new("ImplementedGoNoGoTasksMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Implemented Mitigation Tasks", null), new("ImplementedMitigationTasksMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ImplementedRegularTasksMenu", new(){
                    { 0, new(false, new(new("\nImplemented Regular Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Implemented Task", null), new("", Plan.AddImplementedTask))) },
                    { 2, new(true, new(new("2)  Copy Implemented Task", null), new("", Plan.CopyImplementedTask))) },
                    { 3, new(true, new(new("3)  Edit Implemented Task", null), new("", Plan.EditImplementedTask))) },
                    { 4, new(true, new(new("4)  Remove Implemented Task", null), new("", Plan.RemoveImplementedTask))) },
                    { 5, new(true, new(new("5)  List Implemented Tasks", null), new("", Plan.ListImplementedTasks))) },
                    { 6, new(true, new(new("6)  Export Implemented Tasks", null), new("", Plan.ExportImplementedTasks))) },
                    { 7, new(true, new(new("7)  Import Implemented Tasks", null), new("", Plan.ImportImplementedTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ImplementedBenchmarkTasksMenu", new(){
                    { 0, new(false, new(new("\nImplemented Benchmark Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Implemented Benchmark Task", null), new("", Plan.AddImplementedBenchmarkTask))) },
                    { 2, new(true, new(new("2)  Copy Implemented Benchmark Task", null), new("", Plan.CopyImplementedBenchmarkTask))) },
                    { 3, new(true, new(new("3)  Edit Implemented Benchmark Task", null), new("", Plan.EditImplementedBenchmarkTask))) },
                    { 4, new(true, new(new("4)  Remove Implemented Benchmark Task", null), new("", Plan.RemoveImplementedBenchmarkTask))) },
                    { 5, new(true, new(new("5)  List Implemented Benchmark Tasks", null), new("", Plan.ListImplementedBenchmarkTasks))) },
                    { 6, new(true, new(new("6)  Export Implemented Benchmark Tasks", null), new("", Plan.ExportImplementedBenchmarkTasks))) },
                    { 7, new(true, new(new("7)  Import Implemented Benchmark Tasks", null), new("", Plan.ImportImplementedBenchmarkTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ImplementedGoNoGoTasksMenu", new(){
                    { 0, new(false, new(new("\nImplemented GoNoGo Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Implemented GoNoGo Task", null), new("", Plan.AddImplementedGoNoGoTask))) },
                    { 2, new(true, new(new("2)  Copy Implemented GoNoGo Task", null), new("", Plan.CopyImplementedGoNoGoTask))) },
                    { 3, new(true, new(new("3)  Edit Implemented GoNoGo Task", null), new("", Plan.EditImplementedGoNoGoTask))) },
                    { 4, new(true, new(new("4)  Remove Implemented GoNoGo Task", null), new("", Plan.RemoveImplementedGoNoGoTask))) },
                    { 5, new(true, new(new("5)  List Implemented GoNoGo Tasks", null), new("", Plan.ListImplementedGoNoGoTasks))) },
                    { 6, new(true, new(new("6)  Export Implemented GoNoGo Tasks", null), new("", Plan.ExportImplementedGoNoGoTasks))) },
                    { 7, new(true, new(new("7)  Import Implemented GoNoGo Tasks", null), new("", Plan.ImportImplementedGoNoGoTasks))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "ImplementedMitigationTasksMenu", new(){
                    { 0, new(false, new(new("\nImplemented Mitigation Task Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Implemented Mitigation Task", null), new("", Plan.AddImplementedMitigationTask))) },
                    { 2, new(true, new(new("2)  Copy Implemented Mitigation Task", null), new("", Plan.CopyImplementedMitigationTask))) },
                    { 3, new(true, new(new("3)  Edit Implemented Mitigation Task", null), new("", Plan.EditImplementedMitigationTask))) },
                    { 4, new(true, new(new("4)  Remove Implemented Mitigation Task", null), new("", Plan.RemoveImplementedMitigationTask))) },
                    { 5, new(true, new(new("5)  List Implemented Mitigation Tasks", null), new("", Plan.ListImplementedMitigationTasks))) },
                    { 6, new(true, new(new("6)  Export Implemented Mitigation Tasks", null), new("", Plan.ExportImplementedMitigationTasks))) },
                    { 7, new(true, new(new("7)  Import Implemented Mitigation Tasks", null), new("", Plan.ImportImplementedMitigationTasks))) },
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
                    { 2, new(true, new(new("2)  Estimate Plan", null), new("", Plan.Estimate))) },
                    { 3, new(true, new(new("3)  Test Plan", null), new("", Plan.Test))) },
                    { 4, new(true, new(new("4)  Implement Plan", null), new("", Plan.Implement))) },
                    { 5, new(true, new(new("5)  Plan Rollback", null), new("", Plan.PlanRollback))) },
                    { 6, new(true, new(new("6)  Test Rollback Plan", null), new("", Plan.TestRollback))) },
                    { 7, new(true, new(new("7)  Rollback Plan", null), new("", Plan.Rollback))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "PlanOptionsMenu", new(){
                    { 0, new(false, new(new("\nPlan Options Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Manage Plan Summary", null), new("PlanSummaryMenu", null))) },
                    { 2, new(true, new(new("2)  Manage Organizations", null), new("OrganizationsMenu", null))) },
                    { 3, new(true, new(new("3)  Manage Units", null), new("UnitsMenu", null))) },
                    { 4, new(true, new(new("4)  Manage Roles", null), new("RolesMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "PlanSummaryMenu", new(){
                    { 0, new(false, new(new("\nPlan Summary Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Assign Name", null), new("", Plan.SetName))) },
                    { 2, new(true, new(new("2)  Assign Description", null), new("", Plan.SetDescription))) },
                    { 3, new(true, new(new("3)  {0}", Plan.GetAssignManagerOrAddManager), new("", Plan.AssignManagerOrAddManager))) },
                    { 4, new(true, new(new("4)  Display Summary", null), new("", Plan.DisplaySummary))) },
                    { 7, new(true, new(new("7)  Return to Plan Options Menu", null), new("PlanOptionsMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "OrganizationsMenu", new(){
                    { 0, new(false, new(new("\nOrganizations Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Organization", null), new("", Organizations.AddOrganization))) },
                    { 2, new(true, new(new("2)  Copy Organization", null), new("", Organizations.CopyOrganization))) },
                    { 3, new(true, new(new("3)  Manage Organizations", null), new("OrganizationMenu", null))) },
                    { 4, new(true, new(new("4)  Remove Organization", null), new("", Plan.RemoveOrganization))) },
                    { 5, new(true, new(new("5)  List Organizations", null), new("", Organizations.ListOrganizations))) },
                    { 6, new(true, new(new("6)  Export Organizations", null), new("", Organizations.ExportOrganizations))) },
                    { 7, new(true, new(new("7)  Import Organizations", null), new("", Organizations.ImportOrganizations))) },
                    { 8, new(true, new(new("8)  Return to Plan Options Menu", null), new("PlanOptionsMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "OrganizationMenu", new(){
                    { 0, new(false, new(new("\nOrganization Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Team", null), new("", Organizations.AddTeam))) },
                    { 2, new(true, new(new("2)  Copy Team", null), new("", Organizations.CopyTeam))) },
                    { 3, new(true, new(new("3)  Manage Team", null), new("TeamMenu", null))) },
                    { 4, new(true, new(new("4)  Remove Team", null), new("", Plan.RemoveTeam))) },
                    { 5, new(true, new(new("5)  List Members", null), new("", Organizations.ListTeams))) },
                    { 6, new(true, new(new("6)  Import/Export Members", null), new("", Organizations.ImportExportTeams))) },
                    { 7, new(true, new(new("7)  Team Options", null), new("OrganizationOptionMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Organization Menu", null), new("OrganizationsMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "OrganizationOptionMenu", new(){
                    { 0, new(false, new(new("\nOrganization Options Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Name Organization", null), new("", Organizations.NameOrganization))) },
                    { 2, new(true, new(new("2)  Describe Organization", null), new("", Organizations.DescribeOrganization))) },
                    { 3, new(true, new(new("3)  Display Organization", null), new("", Organizations.DisplayOrganization))) },
                    { 8, new(true, new(new("8)  Return to Organization Menu", null), new("OrganizationMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TeamMenu", new(){
                    { 0, new(false, new(new("\nTeam Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Member", null), new("", Organizations.AddMember))) },
                    { 2, new(true, new(new("2)  Copy Member", null), new("", Organizations.CopyMember))) },
                    { 3, new(true, new(new("3)  Manage Members", null), new("MemberMenu", null))) },
                    { 4, new(true, new(new("4)  Remove Member", null), new("", Organizations.RemoveMember))) },
                    { 5, new(true, new(new("5)  List Members", null), new("", Organizations.ListMembers))) },
                    { 6, new(true, new(new("6)  Import/Export Members", null), new("", Organizations.ImportExportTeamMembers))) },
                    { 7, new(true, new(new("7)  Team Options", null), new("TeamOptionMenu", null))) },
                    { 8, new(true, new(new("8)  Return to Organization Menu", null), new("OrganizationMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "TeamOptionMenu", new(){
                    { 0, new(false, new(new("\nTeam Option Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Assign Team Name", null), new("", Organizations.NameTeam))) },
                    // Describe Team
                    { 2, new(true, new(new("2)  Assign Manager", null), new("", Organizations.AssignTeamManager))) },
                    { 3, new(true, new(new("3)  Add Reporting Team", null), new("", Organizations.AddReportingTeam))) },
                    { 4, new(true, new(new("4)  Remove Reporting Team", null), new("", Organizations.RemoveReportingTeam))) },
                    { 5, new(true, new(new("5)  Add Staff Memebers", null), new("", Organizations.AddTeamStaff))) },
                    { 6, new(true, new(new("6)  Remove Staff Memebers", null), new("", Organizations.RemoveTeamStaff))) },
                    { 7, new(true, new(new("7)  Display Team", null), new("", Organizations.DisplayTeam))) },
                    { 8, new(true, new(new("8)  Return to Organization Menu", null), new("OrganizationMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "MemberMenu", new(){
                    { 0, new(false, new(new("\nMember Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Reassign Name", null), new("", Organizations.NamePerson))) },
                    { 2, new(true, new(new("2)  Assign Team", null), new("", Organizations.AssignPersonTeam))) },
                    { 3, new(true, new(new("3)  Add Role Assignment", null), new("", Organizations.AddPersonRole))) },
                    { 4, new(true, new(new("4)  Remove Role Assignment", null), new("", Organizations.RemovePersonRole))) },
                    { 5, new(true, new(new("5)  List Assigned Roles", null), new("", Organizations.ListPersonRoles))) },
                    { 6, new(true, new(new("6)  Display Member", null), new("", Organizations.DisplayMember))) },
                    { 8, new(true, new(new("8)  Return to Team Menu", null), new("TeamMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "RolesMenu", new(){
                    { 0, new(false, new(new("\nRoles Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Role", null), new("", Organizations.AddRole))) },
                    { 2, new(true, new(new("2)  Copy Role", null), new("", Organizations.CopyRole))) },
                    { 3, new(true, new(new("3)  Remove Role", null), new("", Organizations.RemoveRole))) },
                    { 4, new(true, new(new("4)  List Roles", null), new("", Organizations.ListRoles))) },
                    { 5, new(true, new(new("5)  Export Roles", null), new("", Organizations.ExportRoles))) },
                    { 6, new(true, new(new("6)  Import Roles", null), new("", Organizations.ImportRoles))) },
                    { 8, new(true, new(new("8)  Return to Plan Options Menu", null), new("PlanOptionsMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                },
                { "UnitsMenu", new(){
                    { 0, new(false, new(new("\nUnit Management Menu ({0})", Plan.GetNameForMenus), new("", null))) },
                    { 1, new(true, new(new("1)  Add Unit", null), new("", Organizations.AddUnit))) },
                    { 2, new(true, new(new("2)  Copy Unit", null), new("", Organizations.CopyUnit))) },
                    { 3, new(true, new(new("3)  Edit Unit", null), new("", Organizations.EditUnit))) },
                    { 4, new(true, new(new("4)  Remove Unit", null), new("", Organizations.RemoveUnit))) },
                    { 5, new(true, new(new("5)  List Units", null), new("", Organizations.ListUnits))) },
                    { 6, new(true, new(new("6)  Export Units", null), new("", Organizations.ExportUnits))) },
                    { 7, new(true, new(new("7)  Import Units", null), new("", Organizations.ImportUnits))) },
                    { 8, new(true, new(new("8)  Return to Main Menu", null), new("MainMenu", null))) },
                    { 9, new(true, new(new("9)  Quit", null), new("", Exit))) } }
                }
            };
            } }
        internal void Run()
        {
            Plan = new(new Organizations());
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