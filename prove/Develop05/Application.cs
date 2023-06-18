using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Develop05
{
    public interface IApplication
    {
        static String READ_RESPONSE(Configuration configuration)
        {
            Console.Write(configuration.Dictionary["Prompt"]);
            return Console.ReadLine();
        }
        void BuildDefaultConfiguration();
        Configuration ReadConfiguration();
        void Run();
        void DisplayMainMenu();
        Boolean ProcessResponse(String response);
        void AddSimpleGoal();
        void AddEternalGoal();
        void AddChecklistGoal();
        void ReuseCompletedGoal();
        void ListCurrentGoals();
        void ListAllGoals();
        void SaveGoals();
        void LoadGoals();
        void ReportEvent();
    }
    public class Application : IApplication
    {
        public Boolean Running { get; private set; }
        private Goals Goals { get; set; }
        private String ConfigurationFilename { get; set; }
        private Configuration Configuration { get; set; }
        public Application()
        {
            Init();
        }
        protected void Init()
        {
            ConfigurationFilename = "conf.xml";
            Running = false;
            Configuration = ReadConfiguration();
            Goals = new Goals(Configuration);
        }
        public void Run()
        {
            Running = true;
            while (Running)
            {
                DisplayMainMenu();
                Running = ProcessResponse(IApplication.READ_RESPONSE(Configuration));
            }
        }
        public void BuildDefaultConfiguration()
        {
            Dictionary<String, String> config = new();
            Configuration configure = new();
            configure.Dictionary.Add("MainMenuOption1", "1)  Add a simple goal.");
            configure.Dictionary.Add("MainMenuOption2", "2)  Add an eternal goal.");
            configure.Dictionary.Add("MainMenuOption3", "3)  Add a checklist goal.");
            configure.Dictionary.Add("MainMenuOption4", "4)  Reuse completed goal.");
            configure.Dictionary.Add("MainMenuOption5", "5)  List current goals.");
            configure.Dictionary.Add("MainMenuOption6", "6)  List all goals.");
            configure.Dictionary.Add("MainMenuOption7", "7)  Save goals.");
            configure.Dictionary.Add("MainMenuOption8", "8)  Load goals.");
            configure.Dictionary.Add("MainMenuOption9", "9)  Report Event.");
            configure.Dictionary.Add("MainMenuOptionQ", "Press Enter to quit!");
            configure.Dictionary.Add("Prompt", ">  ");
            configure.Dictionary.Add("AddSimpleGoalMessage", "\nAdd simple goal!");
            configure.Dictionary.Add("AddEternalGoalMessage", "\nAdd eternal goal!");
            configure.Dictionary.Add("AddChecklistGoalMessage", "\nAdd checklist goal!");
            configure.Dictionary.Add("ReusecompletedMessage", "\nReuse Completed Goal!");
            configure.Dictionary.Add("ListCurrentGoalsMessage", "\nList current goals!");
            configure.Dictionary.Add("ListAllGoalsMessage", "\nList all goals!");
            configure.Dictionary.Add("SaveGoalsMessage", "\nSave goals.");
            configure.Dictionary.Add("LoadGoalsMessage", "\nLoad goals.");
            configure.Dictionary.Add("ReportEventMessage", "\nReport an event.");
            configure.Dictionary.Add("ScoreMessage", "\nYour score is {0}.\n");
            configure.Dictionary.Add("RequestGoalMessage", "Please enter the number of your goal.");
            configure.Dictionary.Add("AwardMessage", "\nCongratulations, you earned {0} points.");
            configure.Dictionary.Add("DefaultFilename", "Goals.json");
            configure.Dictionary.Add("RequestFilenameMessage", "Please enter the file name.");
            configure.Dictionary.Add("RequestNameMessage", "Please enter the name of your goal.");
            configure.Dictionary.Add("RequestDescriptionMessage", "Please enter the description of your goal.");
            configure.Dictionary.Add("RequestPointValueMessage", "Please enter the point value of your goal.");
            configure.Dictionary.Add("RequestRepeatPointValueMessage", "Please enter the point value for each completion of your goal.");
            configure.Dictionary.Add("RequestChecklistCompleteCountMessage", "Please enter the number times required to complete your overall goal.");
            configure.Dictionary.Add("RequestChecklistBonusPointValueMessage", "Please enter the bonus point value of your overall goal.");
            configure.Dictionary.Add("IncompleteSymbol", ' ');
            configure.Dictionary.Add("CompleteSymbol", 'X');
            configure.Dictionary.Add("SimpleGoalIndexedDisplayFormat", "{0})  [{1}] {2}({3})");
            configure.Dictionary.Add("SimpleGoalNonIndexedDisplayFormat", "[{0}] {1}({2})");
            configure.Dictionary.Add("ChecklistGoalIndexedDisplayFormat", "{0})  [{1}] {2}({3}) {4}/{5}");
            configure.Dictionary.Add("ChecklistGoalNonIndexedDisplayFormat", "[{0}] {1}({2}) {3}/{4}");
            XmlSerializer serializer = new(typeof(Configuration));
            Stream fs = new FileStream(ConfigurationFilename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            serializer.Serialize(writer, configure);
            writer.Close();
            String xml = File.ReadAllText(ConfigurationFilename);
            StringBuilder stringBuilder = new StringBuilder();
            XElement element = XElement.Parse(xml);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }
            String newXml = stringBuilder.ToString();
            File.WriteAllText(ConfigurationFilename, newXml);
        }
        public Configuration ReadConfiguration()
        {
            //File.Delete(ConfigurationFilename);
            if(!Path.Exists(ConfigurationFilename)) BuildDefaultConfiguration();
            Configuration configureIn;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
            using (Stream reader = new FileStream(ConfigurationFilename, FileMode.Open))
            {
                configureIn = (Configuration)xmlSerializer.Deserialize(reader);
            }

            return configureIn;
        }
        public void DisplayMainMenu()
        {
            Goals.DisplayScore();
            String[] menuKeys = new String[] { "MainMenuOption1", "MainMenuOption2", "MainMenuOption3", "MainMenuOption4", "MainMenuOption5", "MainMenuOption6", "MainMenuOption7", "MainMenuOption8", "MainMenuOption9", "MainMenuOptionQ" };
            foreach (String key in menuKeys)
            {
                Console.WriteLine(Configuration.Dictionary[key]);
            }
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
                    ReuseCompletedGoal();
                    break;
                case 5:
                    ListCurrentGoals();
                    break;
                case 6:
                    ListAllGoals();
                    break;
                case 7:
                    SaveGoals();
                    break;
                case 8:
                    LoadGoals();
                    break;
                case 9:
                    ReportEvent();
                    break;
                default:
                    return true;
            }
            return true;
        }
        public void AddSimpleGoal()
        {
            Console.WriteLine(Configuration.Dictionary["AddSimpleGoalMessage"]);
            Goals.AddSimpleGoal();
        }
        public void AddEternalGoal()
        {
            Console.WriteLine(Configuration.Dictionary["AddEternalGoalMessage"]);
            Goals.AddEternalGoal();
        }
        public void AddChecklistGoal()
        {
            Console.WriteLine(Configuration.Dictionary["AddChecklistGoalMessage"]);
            Goals.AddChecklistGoal();
        }
        public void ReuseCompletedGoal()
        {
            Console.WriteLine(Configuration.Dictionary["ReusecompletedMessage"]);
            Goals.ReuseCompletedGoal();
        }
        public void ListCurrentGoals()
        {
            Console.WriteLine(Configuration.Dictionary["ListCurrentGoalsMessage"]);
            Goals.ListCurrent();
        }
        public void ListAllGoals()
        {
            Console.WriteLine(Configuration.Dictionary["ListAllGoalsMessage"]);
            Goals.ListAll();
        }
        public void SaveGoals()
        {
            Console.WriteLine(Configuration.Dictionary["SaveGoalsMessage"]);
            Goals.SaveGoals();
        }
        public void LoadGoals()
        {
            Console.WriteLine(Configuration.Dictionary["LoadGoalsMessage"]);
            Goals.LoadGoals();
        }
        public void ReportEvent()
        {
            Console.WriteLine(Configuration.Dictionary["ReportEventMessage"]);
            Goals.Report();
        }
    }
}