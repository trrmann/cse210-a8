public class Application
{
    private Boolean _isRunning;
    private Journal _journal;

    public Application()
    {
        Journal = new Journal();
        IsRunning = false;
        InitializationVector = new byte[16] { 
            181, 170, 227, 47,
            70, 234, 190, 180,
            143, 252, 163, 166,
            227, 21, 142, 97 };
        SecretKey = new byte[32] {
            13, 210, 225, 128,
            200, 251, 63, 126,
            195, 152, 238, 104,
            104, 126, 147, 246,
            191, 43, 97, 205,
            91, 162, 96, 89,
            94, 218, 9, 94,
            120, 145, 197, 77 };
    }
    public Journal Journal
    {
        get
        {
            return _journal;
        }
        set
        {
            _journal = value;
        }
    }
    public Boolean IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
        }
    }
    public JournalDatabaseConnection Database
    {
        get
        {
            return Journal.Database;
        }
        set
        {
            Journal.Database = value;
        }
    }
    public Encryption Encryption
    {
        get
        {
            return Database.Encryption;
        }
        set
        {
            Database.Encryption = value;
        }
    }
    public byte[] InitializationVector
    {
        get
        {
            return Encryption.AES.IV;
        }
        set
        {
            Encryption.SetAes(value, SecretKey);
        }
    }
    public byte[] SecretKey
    {
        get
        {
            return Encryption.AES.Key;
        }
        set
        {
            Encryption.SetAes(InitializationVector, value);
        }
    }
    public JournalFile File
    {
        get
        {
            return Journal.File;
        }
        set
        {
            Journal.File = value;
        }
    }
    public void Run()
    {
        IsRunning = true;
        while (IsRunning)
        {
            DisplayMenu();
            IsRunning = EvaluateMenu(ReadMenu());
        };
        Exit();
    }
    public void DisplayMenu()
    {
        foreach (string entry in new string[] { "1)  Add Journal entry.",
            "2)  Display Journal.",
            "3)  Load journal.",
            "4)  Save journal.",
            "5)  Get a new Public/Private Encryption Key pair.",
            "6)  Exit."})
        {
            Console.WriteLine(entry);
        }
        Console.Write(">  ");
    }
    public string ReadMenu()
    {
        return Console.ReadLine();
    }
    public Boolean EvaluateMenu(string Response)
    {
        switch (Response)
        {
            case "1":
                File.LoadEntryPrompts(Database);
                File.UpdatePromptData(Encryption, Journal.AddJournalEntry(Journal.PromptForEntry(JournalDatabaseConnection.GetEntryPrompt(Encryption)), Journal.ReadResponse()));
                return true;
            case "2":
                Journal.Display();
                return true;
            case "3":
                File.LoadEntryPrompts(Database);
                File.PromptForFilename();
                File.LoadEntries(Journal, Journal.ReadResponse());
                return true;
            case "4":
                File.PromptForFilename();
                File.SaveEntries(Journal, Journal.ReadResponse());
                return true;
            case "5":
                Encryption.DisplayPublicPrivateKeyPair();
                return true;
            case "6":
                return false;
            default:
                return true;
        }
    }
    public void Exit()
    {
        Console.WriteLine("Thank you for using the Journal Program.");
    }
}