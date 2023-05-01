using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using System.Collections;
public class Journal
{
    public bool _json_init = !DoesJSONConfigExist();
    public bool _db_init = !IsDBDefined() || !AreDBPromptsDefined() || !DoesJSONConfigExist();
    static public string _JSON_CONFIG_FILE = "journalConfiguration.json";
    static public string _DB_FILENAME = "Journal.db";
    static public string _DB_MODE = "ReadWriteCreate";
    static public string _DB_CACHE = "Private";
    static public string _DB_USEFK = "True";
    static public string _DB_DEF_TIMEOUT = "60";
    static public string GetDBConnectionString()
    {
        SqliteConnectionStringBuilder connStringBuilder = new SqliteConnectionStringBuilder();
        connStringBuilder.Add("Filename", _DB_FILENAME);
        connStringBuilder.Add("Mode", _DB_MODE);
        connStringBuilder.Add("Cache", _DB_CACHE);
        connStringBuilder.Add("Foreign Keys", _DB_USEFK);
        connStringBuilder.Add("Default Timeout", _DB_DEF_TIMEOUT);
        return connStringBuilder.ToString();
    }
    static public SqliteConnection GetDBConnection(string connectionString)
    {
        return new SqliteConnection(connectionString);
    }
    static public List<Object> GetDBQueryObjectList(string query, int resultColCount)
    {
        List<Object> results = new List<Object> ();
        using (SqliteConnection connection = GetDBConnection(GetDBConnectionString()))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = query;
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read()) {
                        object[] values = new object[resultColCount];
                        int count = reader.GetValues(values);
                        results.Add(values);
                    };
                }
            }
        }
        return results;
    }
    static public bool IsDBDefined()
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
    static public List<string> DefineDB()
    {
        List<string> results = new List<string> ();
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
                LEFT OUTER JOIN [Prompts];";
        foreach (object[] element in GetDBQueryObjectList(sql, 1))
        {
            foreach (object value in element)
            {
                result += value.ToString();
            }
        }
        return results;
    }
    static public bool AreDBPromptsDefined()
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
    static public List<string> DefineDBPrompts(List<Prompt> prompts)
    {
        List<string> results = new List<string>();
        string result;
        foreach (Prompt prompt in prompts)
        {
            result = "";
            string sql = $@"INSERT INTO prompts (
                                [Value],
                                [timesused],
                                [lastused])
                            VALUES(
                                '{prompt._value}',
                                {prompt._timesUsed},
                                datetime('{prompt._lastUsed.ToString("yyyy-MM-dd HH:mm:ss")}'));";//0001-01-01 00:00:00
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
    static public List<Prompt> ReadDBPrompts()
    {
        List<Prompt> prompts = new List<Prompt>();
        string sql = $@"SELECT [Value],
                                [timesused],
                                [lastused] FROM prompts;";
        foreach (object[] element in GetDBQueryObjectList(sql, 3))
        {
            Prompt prompt = new Prompt();
            prompt._value = (string)element[0];
            prompt._timesUsed = int.Parse(element[1].ToString());
            if (element[2] is System.DBNull) {
                prompt._lastUsed = DateTime.Parse("0001-01-01 00:00:00");
            }
            else
            {
                prompt._lastUsed = DateTime.Parse(element[2].ToString());
            }
            prompts.Add(prompt);
        }
        return prompts;
    }
    static public List<string> UpdateDBPrompts(List<Prompt> prompts)
    {
        List<string> results = new List<string>();
        string result;
        foreach (Prompt prompt in prompts)
        {
            result = "";
            string sql = $@"UPDATE prompts 
                            SET [timesused] = {prompt._timesUsed},
                                [lastused] = datetime('{prompt._lastUsed.ToString("yyyy-MM-dd HH:mm:ss")}')
                            WHERE [Value] = '{prompt._value}';";
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
    static public bool DoesJSONConfigExist()
    {
        return File.Exists(_JSON_CONFIG_FILE);
    }
    public void LoadEntryPrompts()
    {
        string jsonString;
        Prompt prompt;
        List<Prompt> prompts = new List<Prompt>();
        //Console.WriteLine($"current path:  {Path.GetFullPath(this._JSON_CONFIG_FILE)}");
        if (this._json_init)
        {
            prompt = new Prompt();
            prompt._value = "Who was the most interesting person I interacted with today ?";
            prompts.Add(prompt);
            prompt = new Prompt();
            prompt._value = "What was the best part of my day?";
            prompts.Add(prompt);
            prompt = new Prompt();
            prompt._value = "How did I see the hand of the Lord in my life today ?";
            prompts.Add(prompt);
            prompt = new Prompt();
            prompt._value = "What was the strongest emotion I felt today?";
            prompts.Add(prompt);
            prompt = new Prompt();
            prompt._value = "If I had one thing I could do over today, what would it be?";
            prompts.Add(prompt);
            prompt = new Prompt();
            prompt._value = "What would you like to write in your journal?";
            prompts.Add(prompt);
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(prompts, options);
            File.WriteAllText(_JSON_CONFIG_FILE, jsonString);
        }
        if (this._db_init)
        {
            List<string> results = DefineDB();
        }
        jsonString = File.ReadAllText(_JSON_CONFIG_FILE);
        prompts = JsonSerializer.Deserialize<List<Prompt>>(jsonString);
        if (!AreDBPromptsDefined())
        {
            List<string> result = DefineDBPrompts(prompts);
        } else
        {
            // need to test id this is json recovery to DB or not
            // if not then
            prompts = ReadDBPrompts();
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(prompts, options);
            File.WriteAllText(_JSON_CONFIG_FILE, jsonString);
            // if yes then
            List<string> result = UpdateDBPrompts(prompts);
        }
        _json_init = !DoesJSONConfigExist();
        _db_init = !IsDBDefined() || !AreDBPromptsDefined() || !DoesJSONConfigExist();
}
public Prompt GetEntryPrompt()
    {
        List<Prompt> prompts = ReadDBPrompts();
        Prompt prompt;
        Random random = new Random();
        DateTime dateTime = DateTime.Now, today = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0, dateTime.Kind);
        List<Prompt> availablePrompts = new List<Prompt>();
        List<int> counts = new List<int>();
        int sum, count, maxUsableCount, min = -1, max = 0, minAvailablePrompts = 2;
        foreach (Prompt element in prompts)
        {
            if (min == -1) { min = element._timesUsed; };
            if (element._timesUsed > max) { max = element._timesUsed; };
            if (element._timesUsed < min) { min = element._timesUsed; };
            if (element._timesUsed >= counts.Count()) {
                do
                {
                    counts.Add(0);
                } while (counts.Count <= element._timesUsed);
            };
            counts[element._timesUsed]++;
        }
        sum = 0;
        maxUsableCount = max;
        for (count = min; count<max; count++)
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
            if (DateTime.Compare(element._lastUsed,today)<0
                && element._timesUsed >= min
                && element._timesUsed <= maxUsableCount)
            {
                availablePrompts.Add(element);
            }
        }
        if (availablePrompts.Count ==0 )
        {
            prompt = new Prompt();
            prompt._value = "What would you like to write in your journal?";
        }
        else
        {
            prompt = availablePrompts[random.Next(availablePrompts.Count)];
        }
        return prompt;
    }
    public Prompt PromptForEntry(Prompt prompt)
    {
        prompt.Display();
        return prompt;
    }
    public string ReadResponse()
    {
        return Console.ReadLine();
    }
    public Prompt AddJournalEntry(Prompt prompt, string response)
    {
        DateTime dateTime = DateTime.Now;
        Entry entry = new Entry();
        entry._date = dateTime;
        entry._prompt = prompt;
        entry._response = response;
        AddDBJournalEntry(entry);
        entry._prompt._timesUsed++;
        entry._prompt._lastUsed = DateTime.Now;
        return entry._prompt;
    }
    public List<string> AddDBJournalEntry(Entry entry) {
        List<string> results = new List<string>();
        string result;
        result = "";
        string sql = $@"SELECT [ID] FROM [prompts] WHERE value = '{entry._prompt._value}';";
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
                datetime('{entry._date.ToString("yyyy-MM-dd HH:mm:ss")}'),
                {promptID},
                '{entry._response}');";//0001-01-01 00:00:00
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
    public void UpdatePromptData(Prompt prompt)
    {
        List<Prompt> prompts = ReadDBPrompts();
        foreach (Prompt pmpt in prompts)
        {
            if(pmpt._value == prompt._value)
            {
                pmpt._timesUsed = prompt._timesUsed;
                pmpt._lastUsed = prompt._lastUsed;
            }
        }
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(prompts, options);
        File.WriteAllText(_JSON_CONFIG_FILE, jsonString);
        UpdateDBPrompts(prompts);
    }
    static public List<Entry> ReadDBEnties()
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
            Entry entry = new Entry();
            entry._date = DateTime.Parse(element[1].ToString());
            entry._response = element[3].ToString();
            Prompt prompt = new Prompt();
            prompt._value = (string)element[2];
            prompt._timesUsed = int.Parse(element[5].ToString());
            entry._prompt = prompt;
            if (element[6] is System.DBNull)
            {
                prompt._lastUsed = DateTime.Parse("0001-01-01 00:00:00");
            }
            else
            {
                prompt._lastUsed = DateTime.Parse(element[6].ToString());
            }
            entries.Add(entry);
        }
        return entries;
    }
    public void Display()
    {
        if (this._db_init)
        {
            List<string> results = DefineDB();
        }
        _db_init = !IsDBDefined() || !AreDBPromptsDefined() || !DoesJSONConfigExist();
        Console.WriteLine("Journal:");
        ReadDBEnties().ForEach(entry => {entry.Display();});
        Console.WriteLine();
    }
    public void PromptForFilename()
    {
        Console.WriteLine("Please enter the filename:");
        Console.Write(">  ");
    }
    public string EvaluateFileFormat(string filename)
    {
        string[] parts = filename.Split(".");
        string ext = parts[parts.Count() - 1], format = ext;
        bool valid = false;
        switch (ext)
        {
            case "csv":
                break;
            case "json":
                break;
            default:
                do
                {
                    PromptForFileFormat();
                    switch (ReadResponse())
                    {
                        case "1":
                            format = "csv";
                            valid = true;
                            break;
                        case "2":
                            format = "json";
                            valid = true;
                            break;
                    };
                } while (!valid);
                break;
        }
        return format;
    }
    public void PromptForFileFormat()
    {
        Console.WriteLine("1)  CSV");
        Console.WriteLine("2)  JSON");
        Console.Write(">  ");
    }
    static public List<string> TruncateDBEnties()
    {
        List<string> results = new List<string>();
        string result;
        string sql = $@"DELETE FROM entries;
                        UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'entries';
                        VACUUM;";
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
    public void LoadEntries(string filename)
    {
        // change to database
        Console.WriteLine("loading from file...");
        switch (EvaluateFileFormat(filename))
        {
            case "csv":
                TruncateDBEnties();
                string[] lines = System.IO.File.ReadAllLines(filename);
                if(IsCSV(lines))
                {
                    bool header = false;
                    foreach (string line in lines)
                    {
                        if (line.Contains("\"Date\"") 
                            && line.Contains("\"Prompt\"")
                            && line.Contains("\"Times\"")
                            && line.Contains("\"Last\"")
                            && line.Contains("\"Response\""))
                        {
                            header = true;
                        } else if (header)
                        {
                            Entry entry = new Entry();
                            entry.ParseCSV(line);
                            AddDBJournalEntry(entry);
                        }
                    }
                } else
                {
                    Console.WriteLine("Unable to read file as CSV.");
                }
                break;
            case "json":
                string jsonString = File.ReadAllText(filename);
                if (IsJSON(jsonString))
                {
                    SetJSON(File.ReadAllText(filename));
                } else
                {
                    Console.WriteLine("Unable to read file as JSON.");
                }
                break;
            default:
                break;
        }
    }
    public bool IsCSV(string[] data)
    {
        if (data == null) return false;
        if (data.Length == 0) return false;
        if (data[0].Contains(",")
            && data[0].Contains("\"Date\"")
            && data[0].Contains("\"Prompt\"")
            && data[0].Contains("\"Times\"")
            && data[0].Contains("\"Last\"")
            && data[0].Contains("\"Response\""))
        {
            return true;
        };
        return false;
    }
    public bool IsJSON(string data)
    {
        if (data == null) return false;
        if (data[0].CompareTo('[') == 0
            && data[data.Count() - 1].CompareTo(']') == 0
            && data.Contains("_date")
            && data.Contains("_prompt")
            && data.Contains("_value")
            && data.Contains("_timesUsed")
            && data.Contains("_lastUsed")
            && data.Contains("_response"))
        {
            return true;
        };
        return false;
    }
    public void SaveEntries(string filename)
    {
        Console.WriteLine("saving to file...");
        switch (EvaluateFileFormat(filename))
        {
            case "csv":
                using (StreamWriter output = new StreamWriter(filename))
                {
                    output.WriteLine($"\"Date\",\"Prompt\",\"Times\",\"Last\",\"Response\"");
                    foreach (Entry entry in ReadDBEnties()) {
                        entry.WriteCSV(output);
                    };
                }
                break;
            case "json":
                File.WriteAllText(filename, GetJSON());
                break;
            default:
                break;
        }
    }
    public string GetJSON()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(ReadDBEnties(), options);
    }
    public void SetJSON(string input)
    {
        List<Entry> entries = JsonSerializer.Deserialize<List<Entry>>(input);
        TruncateDBEnties();
        foreach (Entry entry in entries)
        {
            AddDBJournalEntry(entry);
        };
    }
}