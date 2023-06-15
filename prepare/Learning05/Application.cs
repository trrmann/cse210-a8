using System.Numerics;
using System.Text.Json;

namespace Learning05
{
    public interface IApplication
    {
        void Run();
        void DisplayScore();
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
            Score = 0;
            Goals = new Goals();
        }
        public Boolean Running { get; set; }
        private BigInteger Score { get; set; }
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
        public void DisplayScore()
        {
            Console.WriteLine($"\nYour score is {Score}.\n");
        }
        public void DisplayMainMenu()
        {
            DisplayScore();
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
            Console.WriteLine("\nSave goals.");
            //JSONGoals jsonGoals = new(Goals);
            String jsonString = JsonSerializer.Serialize(Goals);
            //JSONGoals jsonObject = new(Goals);
            //String json = jsonObject.ToJSONString();
        }
        public void LoadGoals()
        {
            Console.WriteLine("\nLoad goals.");
            String json = "[{},{},{}]";
            Goals = JsonSerializer.Deserialize<Goals>(json);
            //JSONGoals jsonObject = new(Goals);
            //jsonObject.FromJSONString(json);
            //Goals.Init(jsonObject);
        }

        private void FromJSONString(string json)
        {
            throw new NotImplementedException();
        }

        public void ReportEvent()
        {
            Console.WriteLine("\nReport an event.");
            Score = Goals.Report(Score);
        }
    }
}