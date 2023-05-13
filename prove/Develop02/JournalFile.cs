using System.Text.Json;
public class JournalFile
{
    static private string _PROMPT_DATA_FILE = "journal.dat";
    static public string PromptDataFile
    {
        get
        {
            return _PROMPT_DATA_FILE;
        }
        protected set
        {
            _PROMPT_DATA_FILE = value;
        }
    }
    static public Boolean DoesPromptDatExist
    {
        get
        {
            return File.Exists(PromptDataFile);
        }
    }
    public JournalFile()
    {
        PromptsJSONInit = !DoesPromptDatExist;
    }
    private Boolean _prompts_json_init;
    public Boolean PromptsJSONInit
    {
        get
        {
            return _prompts_json_init;
        }
        set
        {
            _prompts_json_init = value;
        }
    }
    public void LoadEntryPrompts(JournalDatabaseConnection database)
    {
        Encryption encryption = database.Encryption;
        string jsonString;
        Prompt prompt;
        List<Prompt> prompts = new List<Prompt>();
        //Console.WriteLine($"current path:  {Path.GetFullPath(this._PROMPT_DATA_FILE)}");
        if (PromptsJSONInit)
        {
            foreach (string element in new string[]{
                    "Who was the most interesting person I interacted with today?",
                    "What was the best part of my day?",
                    "How did I see the hand of the Lord in my life today?",
                    "What was the strongest emotion I felt today?",
                    "If I had one thing I could do over today, what would it be?",
                    "What did you do today to serve someone?",
                    "What did you ponder over in your scriptures today?",
                    "What Christ-like attribute did you emulate today and how?",
                    "How were you helped today and by who?",
                    "What outside event did you witness or ponder today?",
                    "What did you do today, that was enjoyable?",
                    "What did you learn today?",
                    "What did you improve in your life today?",
                    "What happened today that you didn't like and how could you manage it better?",
                    "What would you like to write in your journal?"})
            {
                prompt = new Prompt(encryption, element, DateTime.Parse("0001-01-01 00:00:00"));
                prompts.Add(prompt);
                //Console.WriteLine(prompt.Value(encryption));
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(prompts, options);
            File.WriteAllText(PromptDataFile, encryption.EncryptStringAES(jsonString));
        }
        if (database.IsInit)
        {
            List<string> results = JournalDatabaseConnection.DefineDB();
        }
        jsonString = encryption.DecryptStringAES(File.ReadAllText(PromptDataFile));
        prompts = JsonSerializer.Deserialize<List<Prompt>>(jsonString);
        if (!JournalDatabaseConnection.AreDBPromptsDefined)
        {
            List<string> result = JournalDatabaseConnection.DefineDBPrompts(encryption, prompts);
        }
        else
        {
            // need to test id this is json recovery to DB or not
            // if not then
            prompts = JournalDatabaseConnection.ReadDBPrompts(encryption);
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(prompts, options);
            File.WriteAllText(PromptDataFile, encryption.EncryptStringAES(jsonString));
            // if yes then
            List<string> result = JournalDatabaseConnection.UpdateDBPrompts(encryption, prompts);
        }
        PromptsJSONInit = !DoesPromptDatExist;
        database.IsInit = (!JournalDatabaseConnection.IsDBDefined || !JournalDatabaseConnection.AreDBPromptsDefined || !DoesPromptDatExist);
    }
    public void UpdatePromptData(Encryption encryption, Prompt prompt)
    {
        List<Prompt> prompts = JournalDatabaseConnection.ReadDBPrompts(encryption);
        foreach (Prompt pmpt in prompts)
        {
            if (pmpt.Value.CompareTo(prompt.Value) == 0)
            {
                pmpt.OpenTimesUsed(encryption, prompt.OpenTimesUsed(encryption));
                pmpt.OpenLastUsed(encryption, prompt.OpenLastUsed(encryption));
            }
        }
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(prompts, options);
        File.WriteAllText(PromptDataFile, encryption.EncryptStringAES(jsonString));
        JournalDatabaseConnection.UpdateDBPrompts(encryption, prompts);
    }
    public void PromptForFilename()
    {
        Console.WriteLine("Please enter the filename:");
        Console.Write(">  ");
    }
    public string EvaluateFileFormat(Journal journal, string filename)
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
                    switch (journal.ReadResponse())
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
    public void PromptForBaseFilename(string keyType)
    {
        Console.WriteLine($"Enter base filename for the {keyType} key:");
        Console.Write(">  ");
    }
    public void LoadEntries(Journal journal, string filename)
    {
        JournalDatabaseConnection database = journal.Database;
        Encryption encryption = database.Encryption;
        Boolean encrypted = GetAesEncryptedResponse(journal);
        PromptForBaseFilename("private");
        string baseFileName = journal.ReadResponse();
        string plainText = "";
        Console.WriteLine("loading from file...");
        try {
            if (baseFileName.CompareTo("") != 0)
            {
                plainText = DecryptFileRSA(encryption, filename, baseFileName);
            } else
            {
                plainText = File.ReadAllText(filename);
            }
            switch (EvaluateFileFormat(journal, filename))
            {
                case "csv":
                    JournalDatabaseConnection.TruncateDBEnties();
                    if (IsCSV(plainText))
                    {
                        try
                        {
                            SetCSV(encryption, plainText, encrypted);
                        }
                        catch (FormatException ex)
                        {
                            if(ex.Message.CompareTo("The input string '' was not in a correct format.")==0)
                            {
                                if(encrypted)
                                {
                                    Console.WriteLine("File is not backup encrypted!");
                                }
                                else
                                {
                                    Console.WriteLine("File is backup encrypted!");
                                }
                            }
                            else if(ex.Message.Contains("The string '")&&ex.Message.Contains("' was not recognized as a valid DateTime. There is an unknown word starting at index '"))
                            {
                                Console.WriteLine("File has a bad date entry!");
                                Console.WriteLine(ex.Message);
                            }
                            else if(ex.Message.CompareTo("The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.")==0)
                            {
                                Console.WriteLine("File is not backup encrypted!");
                            }
                            else
                            {
                                throw;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Prompt ")&&ex.Message.Contains(" not found!")) {
                                Console.WriteLine("File has a bad prompt entry!");
                                Console.WriteLine(ex.Message);
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unable to read file as CSV.");
                    }
                    break;
                case "json":
                    if (IsJSON(plainText))
                    {
                        try
                        {
                            SetJSON(encryption, plainText, encrypted);
                        }
                        catch (JsonException ex)
                        {
                            if (ex.Message.CompareTo("The JSON value could not be converted to Prompt. Path: $[0].Prompt.TimesUsed | LineNumber: 6 | BytePositionInLine: 20.")==0)
                            {
                                if (ex.InnerException.Message.CompareTo("Cannot get the value of a token type 'Number' as a string.")==0)
                                {
                                    Console.WriteLine("file is not backup encrypted!");
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            else if (ex.Message.CompareTo("The JSON value could not be converted to Entry+OpenEntry. Path: $[0].Date | LineNumber: 2 | BytePositionInLine: 58.")==0)
                            {
                                if (ex.InnerException.Message.CompareTo("The JSON value is not in a supported DateTime format.")==0)
                                {
                                    Console.WriteLine("file is backup encrypted!");
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            else if (ex.Message.Contains("The JSON value could not be converted to Entry+OpenEntry. Path: $[0].Date | LineNumber: 2 | BytePositionInLine:"))
                            {
                                if (ex.InnerException.Message.CompareTo("The JSON value is not in a supported DateTime format.")==0)
                                {
                                    Console.WriteLine("file entry has a bad date format!");
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Prompt ")&&ex.Message.Contains(" not found!")) {
                                Console.WriteLine("File has a bad prompt entry!");
                                Console.WriteLine(ex.Message);
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unable to read file as JSON.");
                    }
                    break;
                default:
                    break;
            }
            LoadEntryPrompts(database);
            List<Prompt> prompts = JournalDatabaseConnection.ReadDBPrompts(encryption);
            foreach (Prompt prompt in prompts)
            {
                prompt.TimesUsedInt(encryption, 0);
                prompt.LastUsedDate(encryption, DateTime.Parse("0001-01-01 00:00:00"));
            }
            foreach (Entry entry in JournalDatabaseConnection.ReadDBEnties(encryption))
            {
                string prompt_value = entry.PromptValue;
                foreach (Prompt prompt in prompts)
                {
                    if (prompt.Value.CompareTo(prompt_value) == 0)
                    {
                        if (DateTime.Compare(prompt.LastUsedDate(encryption), entry.OpenDateTime(encryption)) < 0)
                        {
                            prompt.LastUsedDate(encryption, entry.OpenDateTime(encryption));
                        }
                        prompt.TimesUsedInt(encryption, prompt.TimesUsedInt(encryption) + 1);
                    }
                }
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            string promptsJSONString = JsonSerializer.Serialize(prompts, options);
            File.WriteAllText(PromptDataFile, encryption.EncryptStringAES(promptsJSONString));
            JournalDatabaseConnection.UpdateDBPrompts(encryption, prompts);
        }
        catch (FormatException ex)
        {
            if(ex.Message.CompareTo("The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.")==0)
            {
                Console.WriteLine("Invalid private Key!");
            }
            else
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        catch (System.Security.Cryptography.CryptographicException ex)
        {
            if(ex.Message.CompareTo("The parameter is incorrect.")==0)
            {
                Console.WriteLine("Invalid private Key!");
            }
            else
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public bool IsCSV(string data)
    {
        if (data == null) return false;
        if (data.Length == 0) return false;
        if (data.Contains(",")
            && data.Contains("\"Date\"")
            && data.Contains("\"Prompt\"")
            && data.Contains("\"Times\"")
            && data.Contains("\"Last\"")
            && data.Contains("\"Response\""))
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
            && ((data.Contains("Date")
            && data.Contains("Prompt")
            && data.Contains("Value")
            && data.Contains("TimesUsed")
            && data.Contains("LastUsed")
            && data.Contains("Response"))
            || (data.Length == 2)))
        {
            return true;
        };
        return false;
    }
    public void SaveEntries(Journal journal, string filename)
    {
        Encryption encryption = journal.Database.Encryption;
        Boolean encrypted = GetAesEncryptedResponse(journal);
        PromptForBaseFilename("public");
        string baseFileName = journal.ReadResponse();
        Console.WriteLine("saving to file...");
        switch (EvaluateFileFormat(journal, filename))
        {
            case "csv":
                File.WriteAllText(filename, GetCSV(encryption, encrypted));
                break;
            case "json":
                File.WriteAllText(filename, GetJSON(encryption, encrypted));
                break;
            default:
                break;
        }
        String plainText = File.ReadAllText(filename);
        if (baseFileName.CompareTo("") != 0 && !(plainText is null))
        {
            EncryptFileRSA(plainText, encryption, filename, baseFileName);
        }
    }
    public string GetCSV(Encryption encryption, Boolean encrypted = false)
    {
        List<string> lines = new List<string>();
        lines.Add($"\"Date\",\"Prompt\",\"Times\",\"Last\",\"Response\"");
        foreach (Entry entry in JournalDatabaseConnection.ReadDBEnties(encryption))
        {
            lines.Add(entry.GetCSV(encryption, encrypted));
        };
        return string.Join("\n", lines.ToArray());
    }
    public void SetCSV(Encryption encryption, string input, Boolean encrypted = false)
    {
        bool header = false;
        string[] lines = input.Split("\n");
        foreach (string line in lines)
        {
            if (line.Contains("\"Date\"")
                && line.Contains("\"Prompt\"")
                && line.Contains("\"Times\"")
                && line.Contains("\"Last\"")
                && line.Contains("\"Response\""))
            {
                header = true;
            }
            else if (header)
            {
                Entry entry = new Entry("", null, "");
                entry.ParseCSV(line, encryption, encrypted);
                JournalDatabaseConnection.AddDBJournalEntry(encryption, entry);
            }
        }
    }
    public string GetJSON(Encryption encryption, Boolean encrypted = false)
    {
        if(encrypted)
        {
            List<Entry> entries = JournalDatabaseConnection.ReadDBEnties(encryption);
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(entries, options);
        }
        else
        {
            List<Entry> entries = JournalDatabaseConnection.ReadDBEnties(encryption);
            List<Entry.OpenEntry> openEntries = new List<Entry.OpenEntry>();
            foreach (Entry entry in entries)
            {
                openEntries.Add(entry.ToOpenEntry(encryption));
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(openEntries, options);
        }
    }
    public void SetJSON(Encryption encryption, string input, Boolean encrypted = false)
    {
        List<Entry> entries = new List<Entry>();
        if (encrypted)
        {
            entries = JsonSerializer.Deserialize<List<Entry>>(input);
        }
        else
        {
            List<Entry.OpenEntry> openEntries = JsonSerializer.Deserialize<List<Entry.OpenEntry>>(input);
            foreach (Entry.OpenEntry openEntry in openEntries)
            {
                entries.Add(openEntry.ToEntry(encryption));
            };
        }
        JournalDatabaseConnection.TruncateDBEnties();
        foreach (Entry entry in entries)
        {
            JournalDatabaseConnection.AddDBJournalEntry(encryption, entry);
        }
    }
    public void PromptAesEncryptedResponse()
    {
        Console.WriteLine("data encryption for backup(Y/N)");
        Console.Write(">:  ");
    }
    public Boolean GetAesEncryptedResponse(Journal journal)
    {
        while (true)
        {
            PromptAesEncryptedResponse();
            string response = journal.ReadResponse();
            switch (response)
            {
                case "y":
                case "Y":
                case "yes":
                case "YES":
                case "Yes:":
                    return true;
                case "n":
                case "N":
                case "no":
                case "NO":
                case "No":
                    return false;
            }
        }
    }
    public void EncryptFileRSA(String plainText, Encryption encryption, string plainTextFilename, string baseFileName)
    {
        String[] cipherTextLines = encryption.EncryptLargeStringRSA(plainText, baseFileName);
        File.WriteAllLines(plainTextFilename, cipherTextLines);
    }
    public string DecryptFileRSA(Encryption encryption, string cypherTextFilename, string baseFileName)
    {
        String[] cipherTextLines = File.ReadAllLines(cypherTextFilename);
        return encryption.DecryptLargeStringRSA(cipherTextLines, baseFileName);
    }
}