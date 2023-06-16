using System.Text.Json;

namespace Develop05
{
    public interface IApplication
    {
        void Run();
        void DisplayMainMenu();
        String ReadResponse();
        Boolean ProcessResponse(String response);
        void AddSimpleGoal();
        void AddEternalGoal();
        void AddChecklistGoal();
        void ListGoals();
        void SaveGoals();
        void LoadGoals();
        void ReportEvent();
    }
    public class Application : IApplication
    {
        public Application()
        {
            Init();
        }
        protected void Init()
        {
            Running = false;
            Goals = new Goals();
        }
        public Boolean Running { get; set; }
        private Goals Goals { get; set; }
        public void Run()
        {
            Running = true;
            while (Running)
            {
                DisplayMainMenu();
                Running = ProcessResponse(ReadResponse());
            }
        }
        public void DisplayMainMenu()
        {
            Goals.DisplayScore();
            Console.WriteLine("1)  Add a simple goal.");
            Console.WriteLine("2)  Add an eternal goal.");
            Console.WriteLine("3)  Add a checklist goal.");
            Console.WriteLine("4)  List goals.");
            Console.WriteLine("5)  Save goals.");
            Console.WriteLine("6)  Load goals.");
            Console.WriteLine("7)  Report Event.");
            Console.WriteLine("Press Enter to quit!");
        }
        public String ReadResponse()
        {
            Console.Write(">  ");
            return Console.ReadLine();
        }
        public Boolean ProcessResponse(String response)
        {
            if (response == "") return false;
            int option;
            try
            {
                option = int.Parse(response);
            }
            catch
            {
                option = 0;
            }
            switch (option)
            {
                case 1:
                    AddSimpleGoal();
                    break;
                case 2:
                    AddEternalGoal();
                    break;
                case 3:
                    AddChecklistGoal();
                    break;
                case 4:
                    ListGoals();
                    break;
                case 5:
                    SaveGoals();
                    break;
                case 6:
                    LoadGoals();
                    break;
                case 7:
                    ReportEvent();
                    break;
                default:
                    return true;
            }
            return true;
        }
        public void AddSimpleGoal()
        {
            Console.WriteLine("\nAdd simple goal!");
            Goals.Add(new SimpleGoal());
        }
        public void AddEternalGoal()
        {
            Console.WriteLine("\nAdd eternal goal!");
            Goals.Add(new EternalGoal());
        }
        public void AddChecklistGoal()
        {
            Console.WriteLine("\nAdd checklist goal!");
            Goals.Add(new ChecklistGoal());
        }
        public void ListGoals()
        {
            Console.WriteLine("\nList goals!");
            Goals.List();
        }
        public void SaveGoals()
        {
            String fileName = "Goals.json";
            Console.WriteLine("\nSave goals.");
            JSONGoals jsonGoals = new(Goals);
            var options = new JsonSerializerOptions { WriteIndented = true };
            String jsonString = JsonSerializer.Serialize(jsonGoals, options);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine(File.ReadAllText(fileName));
        }
        public void LoadGoals()
        {
            String fileName = "Goals.json";
            Console.WriteLine("\nLoad goals.");
            String json = File.ReadAllText(fileName);
            JSONGoals jsonGoals = JsonSerializer.Deserialize<JSONGoals>(json);
            Goals = new(jsonGoals);
        }
        public void ReportEvent()
        {
            Console.WriteLine("\nReport an event.");
            Goals.Report();
        }
    }
}