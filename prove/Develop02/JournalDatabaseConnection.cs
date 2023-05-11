using Microsoft.Data.Sqlite;
public class JournalDatabaseConnection
{
    static private string _DB_FILENAME = "Journal.db";
    static public string DbFilename
    {
        get
        {
            return _DB_FILENAME;
        }
        protected set
        {
            _DB_FILENAME = value;
        }
    }
    static private string _DB_MODE = "ReadWriteCreate";
    static public string DbMode
    {
        get
        {
            return _DB_MODE;
        }
        protected set
        {
            _DB_MODE = value;
        }
    }
    static private string _DB_CACHE = "Private";
    static public string DbCache
    {
        get
        {
            return _DB_CACHE;
        }
        protected set
        {
            _DB_CACHE = value;
        }
    }
    static private string _DB_USEFK = "True";
    static public string DbUseForiegnKey
    {
        get
        {
            return _DB_USEFK;
        }
        protected set
        {
            _DB_USEFK = value;
        }
    }
    static private string _DB_DEF_TIMEOUT = "60";
    static public string DbDefaultTimeout
    {
        get
        {
            return _DB_DEF_TIMEOUT;
        }
        protected set
        {
            _DB_DEF_TIMEOUT = value;
        }
    }
    private bool _init;
    private Encryption _encryption;
    public JournalDatabaseConnection(bool doesPromptDatExist, Encryption encryption)
    {
        IsInit = (!IsDBDefined || !AreDBPromptsDefined || !doesPromptDatExist);
        if (encryption is null)
        {
            Encryption = new Encryption();
        }
        else
        {
            Encryption = encryption;
        }
    }
    public Encryption Encryption
    {
        get
        {
            return _encryption;
        }
        set
        {
            _encryption = value;
        }
    }
    public bool IsInit
    {
        get
        {
            return _init;
        }
        set
        {
            _init = value;
        }
    }
    static public string GetDBConnectionString()
    {
        SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
        connStringBuilder.Add("Filename", DbFilename);
        connStringBuilder.Add("Mode", DbMode);
        connStringBuilder.Add("Cache", DbCache);
        connStringBuilder.Add("Foreign Keys", DbUseForiegnKey);
        connStringBuilder.Add("Default Timeout", DbDefaultTimeout);
        return connStringBuilder.ToString();
    }
    static public SqliteConnection GetDBConnection(string connectionString)
    {
        return new SqliteConnection(connectionString);
    }
    static public List<Object> GetDBQueryObjectList(string query, int resultColCount)
    {
        List<Object> results = new List<Object>();
        using (SqliteConnection connection = GetDBConnection(GetDBConnectionString()))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = query;
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object[] values = new object[resultColCount];
                        int count = reader.GetValues(values);
                        results.Add(values);
                    };
                }
            }
        }
        return results;
    }
    static public Boolean IsDBDefined
    {
        get
        {
            string result = "";
            foreach (object[] element in GetDBQueryObjectList("SELECT count(*) FROM sqlite_schema;", 1))
            {
                foreach (object value in element)
                {
                    result += value.ToString();
                }
            }
            return (int.Parse(result) > 3);
        }
    }
    static public List<string> DefineDB()
    {
        List<string> results = new List<string>();
        string result = "";
        string sql = @"DROP VIEW IF EXISTS [EntriesView];";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        results.Add(result);
        result = "";
        sql = @"DROP TABLE IF EXISTS [Entries];";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        results.Add(result);
        result = "";
        sql = @"DROP TABLE IF EXISTS [Prompts];";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        results.Add(result);
        result = "";
        sql = @"CREATE TABLE [Prompts] (
                [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                [Value] TEXT NOT NULL,
                [TimesUsed] INTEGER DEFAULT 0,
                [LastUsed] datetime DEFAULT (datetime('0001-01-01 00:00:00')) );";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        results.Add(result);
        result = "";
        sql = @"CREATE TABLE [Entries] (
                [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                [Date] datetime DEFAULT (datetime()) ,
                [PromptID] INTEGER NOT NULL,
                [Response] TEXT NOT NULL,
                FOREIGN KEY(PromptID) REFERENCES prompts(id));";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        results.Add(result);
        result = "";
        sql = @"CREATE VIEW IF NOT EXISTS [EntriesView] (
                    [ID],
                    [Date],
                    [Prompt],
                    [Response],
                    [PromptID],
                    [TimesUsedPrompt],
                    [LastUsedPrompt]) AS
                SELECT [Entries].[Id],
                    [Entries].[Date],
                    [Prompts].[Value],
                    [Entries].[Response],
                    [Entries].[PromptID],
                    [Prompts].[TimesUsed],
                    [Prompts].[LastUsed]
                FROM [Entries]
                LEFT OUTER JOIN [Prompts]
                ON [Entries].[PromptID] = [Prompts].[ID];";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        return results;
    }
    static public Boolean AreDBPromptsDefined
    {
        get
        {
            string result = "";
            foreach (object[] element in GetDBQueryObjectList("SELECT count(*) FROM [Prompts];", 1))
            {
                foreach (object value in element)
                {
                    result += value.ToString();
                }
            }
            return (int.Parse(result) > 4);
        }
    }
    static public List<string> DefineDBPrompts(Encryption encryption, List<Prompt> prompts)
    {
        List<string> results = new List<string>();
        string result;
        foreach (Prompt prompt in prompts)
        {
            //Console.WriteLine(prompt.Value(encryption));
            result = "";
            string sql = $@"INSERT INTO prompts (
                                [Value],
                                [timesused],
                                [lastused])
                            VALUES(
                                '{prompt.Value}',
                                {prompt.TimesUsedInt(encryption)},
                                datetime('{prompt.LastUsedDate(encryption).ToString("yyyy-MM-dd HH:mm:ss")}'));";//0001-01-01 00:00:00
            foreach (object[] element in GetDBQueryObjectList(sql, 1))
            {
                foreach (object value in element)
                {
                    result += value.ToString();
                }
            }
            results.Add(result);
        }
        return results;
    }
    static public List<Prompt> ReadDBPrompts(Encryption encryption)
    {
        List<Prompt> prompts = new List<Prompt>();
        string sql = $@"SELECT [Value],
                                [timesused],
                                [lastused] FROM prompts;";
        foreach (object[] element in GetDBQueryObjectList(sql, 3))
        {
            string value = (string)element[0];
            int timesUsed = int.Parse(element[1].ToString());
            DateTime lastUsed;
            if (element[2] is System.DBNull)
            {
                lastUsed = DateTime.Parse("0001-01-01 00:00:00");
            }
            else
            {
                lastUsed = DateTime.Parse(element[2].ToString());
            }
            Prompt tmpPrompt = new Prompt(encryption, value, lastUsed, timesUsed);
            Prompt prompt = new Prompt(value, tmpPrompt.LastUsed, tmpPrompt.TimesUsed);
            prompts.Add(prompt);
        }
        return prompts;
    }
    static public List<string> UpdateDBPrompts(Encryption encryption, List<Prompt> prompts)
    {
        List<string> results = new List<string>();
        string result;
        foreach (Prompt prompt in prompts)
        {
            result = "";
            string sql = $@"UPDATE prompts 
                            SET [timesused] = {prompt.TimesUsedInt(encryption)},
                                [lastused] = datetime('{prompt.LastUsedDate(encryption).ToString("yyyy-MM-dd HH:mm:ss")}')
                            WHERE [Value] = '{prompt.Value}';";
            foreach (object[] element in GetDBQueryObjectList(sql, 1))
            {
                foreach (object value in element)
                {
                    result += value.ToString();
                }
            }
            results.Add(result);
        }
        return results;
    }
    static public Prompt GetEntryPrompt(Encryption encryption)
    {
        List<Prompt> prompts = ReadDBPrompts(encryption);
        Prompt prompt;
        Random random = new Random();
        DateTime dateTime = DateTime.Now, today = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0, dateTime.Kind);
        List<Prompt> availablePrompts = new List<Prompt>();
        List<int> counts = new List<int>();
        int sum, count, maxUsableCount, min = -1, max = 0, minAvailablePrompts = 2;
        foreach (Prompt element in prompts)
        {
            //Console.WriteLine(element.Value(encryption));
            if (min == -1) { min = element.TimesUsedInt(encryption); };
            if (element.TimesUsedInt(encryption) > max) { max = element.TimesUsedInt(encryption); };
            if (element.TimesUsedInt(encryption) < min) { min = element.TimesUsedInt(encryption); };
            if (element.TimesUsedInt(encryption) >= counts.Count())
            {
                do
                {
                    counts.Add(0);
                } while (counts.Count <= element.TimesUsedInt(encryption));
            };
            counts[element.TimesUsedInt(encryption)]++;
        }
        sum = 0;
        maxUsableCount = max;
        for (count = min; count < max; count++)
        {
            sum += counts[count];
            maxUsableCount = count;
            if (sum >= minAvailablePrompts)
            {
                break;
            }
        }
        foreach (Prompt element in prompts)
        {
            if (DateTime.Compare(element.LastUsedDate(encryption), today) < 0
                && element.TimesUsedInt(encryption) >= min
                && element.TimesUsedInt(encryption) <= maxUsableCount)
            {
                availablePrompts.Add(element);
            }
        }
        if (availablePrompts.Count == 0)
        {
            prompt = new Prompt(encryption, "What would you like to write in your journal?", DateTime.Parse("0001-01-01 00:00:00"));
        }
        else
        {
            prompt = availablePrompts[random.Next(availablePrompts.Count)];
        }
        return prompt;
    }
    static public List<string> AddDBJournalEntry(Encryption encryption, Entry entry)
    {
        List<string> results = new List<string>();
        string result;
        result = "";
        string sql = $@"SELECT [ID] FROM [prompts] WHERE value = '{entry.PromptValue}';";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        int promptID = int.Parse(result);
        sql = $@"INSERT INTO Entries (
                [Date],
                [PromptID],
                [Response])
            VALUES(
                datetime('{entry.OpenDateTime(encryption).ToString("yyyy-MM-dd HH:mm:ss")}'),
                {promptID},
                '{entry.Response}');";//0001-01-01 00:00:00
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        results.Add(result);
        return results;
    }
    static public List<Entry> ReadDBEnties(Encryption encryption)
    {
        List<Entry> entries = new List<Entry>();
        string sql = $@"SELECT [ID],
                        [Date],
                        [Prompt],
                        [Response],
                        [PromptID],
                        [TimesUsedPrompt],
                        [LastUsedPrompt]
                    FROM entriesview;";
        foreach (object[] element in GetDBQueryObjectList(sql, 7))
        {
            DateTime date = DateTime.Parse(element[1].ToString());
            string response = element[3].ToString();
            string value = (string)element[2];
            int timesUsed = int.Parse(element[5].ToString());
            DateTime lastused;
            if (element[6] is System.DBNull)
            {
                lastused = DateTime.Parse("0001-01-01 00:00:00");
            }
            else
            {
                lastused = DateTime.Parse(element[6].ToString());
            }
            Prompt prompt = new Prompt(encryption, value, lastused, timesUsed);
            prompt.Value = value;
            Entry entry = new Entry(encryption, date, prompt, response);
            entry.Response = response;
            entries.Add(entry);
        }
        return entries;
    }
    static public List<string> TruncateDBEnties()
    {
        List<string> results = new List<string>();
        string result;
        string sql = $@"DELETE FROM entries;";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            result = "";
            foreach (object x in element)
            {
                result += x.ToString();
            }
            results.Add(result);
        }
        sql = $@"UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'entries';";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            result = "";
            foreach (object x in element)
            {
                result += x.ToString();
            }
            results.Add(result);
        }
        sql = $@"VACUUM;";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            result = "";
            foreach (object x in element)
            {
                result += x.ToString();
            }
            results.Add(result);
        }
        return results;
    }
}