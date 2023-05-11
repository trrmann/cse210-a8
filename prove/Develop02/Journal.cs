public class Journal
{
    private JournalFile _file;
    private JournalDatabaseConnection _database;
    public Journal()
    {
        File = new JournalFile();
        Database = new JournalDatabaseConnection(JournalFile.DoesPromptDatExist, new Encryption());
    }
    public JournalFile File
    {
        get
        {
            return _file;
        }
        set
        {
            _file = value;
        }
    }
    public JournalDatabaseConnection Database
    {
        get
        {
            return _database;
        }
        set
        {
            _database = value;
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
    public Prompt PromptForEntry(Prompt prompt)
    {
        prompt.Display(Encryption);
        return prompt;
    }
    public string ReadResponse()
    {
        return Console.ReadLine();
    }
    public Prompt AddJournalEntry(Prompt prompt, string response)
    {
        Entry entry = new Entry(Encryption, DateTime.Now, prompt, response);
        JournalDatabaseConnection.AddDBJournalEntry(Encryption, entry);
        entry.TimesPromptUsedInt(Encryption, entry.TimesPromptUsedInt(Encryption) +1);
        entry.PromptLastUsedDate(Encryption, DateTime.Now);
        return entry.Prompt;
    }
    public void Display()
    {
        if (Database.IsInit)
        {
            List<string> results = JournalDatabaseConnection.DefineDB();
        }
        Database.IsInit = (!JournalDatabaseConnection.IsDBDefined || !JournalDatabaseConnection.AreDBPromptsDefined || !JournalFile.DoesPromptDatExist);
        Console.WriteLine("Journal:");
        JournalDatabaseConnection.ReadDBEnties(Encryption).ForEach(entry => {entry.Display(Encryption);});
        Console.WriteLine();
    }
}