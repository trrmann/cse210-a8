using System.Text.Json;
using System.Text.Json.Serialization;

public class Entry
{
    private string _date;
    private Prompt _prompt;
    private string _response;
    [JsonConstructor]
    public Entry(string date, Prompt prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
    public Entry(Encryption encryption, DateTime date, Prompt prompt, string response) {
        OpenDateTime(encryption, date);
        Prompt = prompt;
        OpenResponse(encryption, response);
    }
    public Entry(Encryption encryption, string date, Prompt prompt, string response)
    {
        OpenDate(encryption, date);
        Prompt = prompt;
        OpenResponse(encryption, response);
    }
    [JsonInclude]
    public string Date
    {
        get
        {
            return _date;
        }
        set
        {
            _date = value;
        }
    }
    public void OpenDateTime(Encryption encryption, DateTime date)
    {
        OpenDate(encryption, date.ToString());
    }
    public DateTime OpenDateTime(Encryption encryption)
    {
        return DateTime.Parse(OpenDate(encryption));
    }
    public void OpenDate(Encryption encryption, string date)
    {
        Date = encryption.EncryptStringAES(date);
    }
    public string OpenDate(Encryption encryption)
    {
        return encryption.DecryptStringAES(Date);
    }
    [JsonInclude]
    public Prompt Prompt
    {
        get
        {
            return _prompt;
        }
        set
        {
            _prompt = value;
        }
    }
    [JsonInclude]
    public string PromptValue
    {
        get
        {
            return Prompt.Value;
        }
        set
        {
            Prompt.Value = value;
        }
    }
    public void PromptOpenValue(Encryption encryption, string value)
    {
        Prompt.OpenValue(encryption, value);
    }
    public string PromptOpenValue(Encryption encryption)
    {
        return Prompt.OpenValue(encryption);
    }
    [JsonInclude]
    public string TimesPromptUsed
    {
        get
        {
            return Prompt.TimesUsed;
        }
        set
        {
            Prompt.TimesUsed = value;
        }
    }
    public void TimesPromptUsedInt(Encryption encryption, int timesUsed)
    {
        Prompt.TimesUsedInt(encryption, timesUsed);
    }
    public int TimesPromptUsedInt(Encryption encryption)
    {
        return Prompt.TimesUsedInt(encryption);
    }
    public void OpenTimesPromptUsed(Encryption encryption, string timesUsed)
    {
        Prompt.OpenTimesUsed(encryption, timesUsed);
    }
    public string OpenTimesPromptUsed(Encryption encryption)
    {
        return Prompt.OpenTimesUsed(encryption);
    }
    [JsonInclude]
    public string PromptLastUsed
    {
        get
        {
            return Prompt.LastUsed;
        }
        set
        {
            Prompt.LastUsed = value;
        }
    }
    public void PromptLastUsedDate(Encryption encryption, DateTime lastUsed)
    {
        Prompt.LastUsedDate(encryption, lastUsed);
    }
    public DateTime PromptLastUsedDate(Encryption encryption)
    {
        return Prompt.LastUsedDate(encryption);
    }
    public void OpenPromptLastUsed(Encryption encryption, string lastUsed)
    {
        Prompt.OpenLastUsed(encryption, lastUsed);
    }
    public string OpenPromptLastUsed(Encryption encryption)
    {
        return Prompt.OpenLastUsed(encryption);
    }
    [JsonInclude]
    public string Response
    {
        get
        {
            return _response;
        }
        set
        {
            _response = value;
        }
    }
    public void OpenResponse(Encryption encryption, string response)
    {
        Response = encryption.EncryptStringAES(response);
    }
    public string OpenResponse(Encryption encryption)
    {
        return encryption.DecryptStringAES(Response);
    }
    public void Display(Encryption encryption)
    {
        Console.WriteLine($"\n{OpenDate(encryption)}  prompt:  {PromptOpenValue(encryption)}");
        Console.WriteLine($"{OpenResponse(encryption)}");
    }
    public string GetCSV(Encryption encryption, Boolean encrypted)
    {
        if (encrypted)
        {
            return $"\"{Date}\",\"{PromptValue}\",\"{TimesPromptUsed}\",\"{PromptLastUsed}\",\"{Response}\"";
        }
        else
        {
            return $"\"{OpenDate(encryption)}\",\"{PromptOpenValue(encryption)}\",\"{OpenTimesPromptUsed(encryption)}\",\"{OpenPromptLastUsed(encryption)}\",\"{OpenResponse(encryption)}\"";
        }
    }
    public void ParseCSV(string input, Encryption encryption, Boolean encrypted)
    {
        string[] parts = input.Split("\",\"");
        if (encrypted) {
            List<string> p0 = new List<string>(parts[0].Split("\""));
            p0.RemoveAt(0);
            string date_str = string.Join("\"", p0);
            Date = date_str;
            Prompt = new Prompt(parts[1], parts[3], parts[2]);
            List<string> p4 = new List<string>(parts[4].Split("\""));
            p4.RemoveAt(p4.Count()-1);
            Response = string.Join("\"", p4);
        }
        else
        {
            List<string> p0 = new List<string>(parts[0].Split("\""));
            p0.RemoveAt(0);
            string date_str = string.Join("\"", p0);
            OpenDate(encryption, date_str);
            Prompt = new Prompt(encryption, parts[1], parts[3], parts[2]);
            List<string> p4 = new List<string>(parts[4].Split("\""));
            p4.RemoveAt(p4.Count() - 1);
            OpenResponse(encryption, string.Join("\"", p4));
        }
    }
    protected string JSON
    {
        get
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(this, options);
        }
        set
        {
            Entry entry = JsonSerializer.Deserialize<Entry>(value);
            Date = entry.Date;
            Prompt = entry.Prompt;
            Response = entry.Response;
        }
    }
    internal OpenEntry ToOpenEntry(Encryption encryption)
    {
        OpenEntry openEntry = new OpenEntry(encryption, Date, Prompt.ToOpenPrompt(encryption), Response);
        return openEntry;
    }
    internal class OpenEntry
    {
        private DateTime _date;
        private Prompt.OpenPrompt _prompt;
        private string _response;
        public OpenEntry(string date, Prompt.OpenPrompt prompt, string response)
        {
            DateString(date);
            Prompt = prompt;
            Response = response;
        }
        [JsonConstructor]
        public OpenEntry(DateTime date, Prompt.OpenPrompt prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }
        public OpenEntry(Encryption encryption, string date, Prompt.OpenPrompt prompt, string response)
        {
            CipheredDate(encryption, date);
            Prompt = prompt;
            CipheredResponse(encryption, response);
        }
        [JsonInclude]
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        public void DateString(string date)
        {
            Date = DateTime.Parse(date);
        }
        public string DateString()
        {
            return Date.ToString();
        }
        public void CipheredDate(Encryption encryption, string date)
        {
            DateString(encryption.DecryptStringAES(date));
        }
        public string CipheredDate(Encryption encryption)
        {
            return encryption.EncryptStringAES(DateString());
        }
        [JsonInclude]
        public Prompt.OpenPrompt Prompt
        {
            get
            {
                return _prompt;
            }
            set
            {
                _prompt = value;
            }
        }
        public string PromptValue
        {
            get
            {
                return Prompt.Value;
            }
            set
            {
                Prompt.Value = value;
            }
        }
        public void PromptCipheredValue(Encryption encryption, string value)
        {
            Prompt.CipheredValue(encryption, value);
        }
        public string PromptCipheredValue(Encryption encryption)
        {
            return Prompt.CipheredValue(encryption);
        }
        public int TimesPromptUsed
        {
            get
            {
                return Prompt.TimesUsed;
            }
            set
            {
                Prompt.TimesUsed = value;
            }
        }
        public void TimesPromptUsedString(string timesUsed)
        {
            Prompt.TimesUsedString(timesUsed);
        }
        public string TimesPromptUsedString()
        {
            return Prompt.TimesUsedString();
        }
        public void CipheredTimesPromptUsed(Encryption encryption, string timesUsed)
        {
            Prompt.CipheredTimesUsed(encryption, timesUsed);
        }
        public string CipheredTimesPromptUsed(Encryption encryption)
        {
            return Prompt.CipheredTimesUsed(encryption);
        }
        public DateTime PromptLastUsed
        {
            get
            {
                return Prompt.LastUsed;
            }
            set
            {
                Prompt.LastUsed = value;
            }
        }
        public void PromptLastUsedString(string lastUsed)
        {
            Prompt.LastUsedString(lastUsed);
        }
        public string PromptLastUsedString()
        {
            return Prompt.LastUsedString();
        }
        public void CipheredPromptLastUsed(Encryption encryption, string lastUsed)
        {
            Prompt.CipheredLastUsed(encryption, lastUsed);
        }
        public string CipheredPromptLastUsed(Encryption encryption)
        {
            return Prompt.CipheredLastUsed(encryption);
        }
        [JsonInclude]
        public string Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
            }
        }
        public void CipheredResponse(Encryption encryption, string response)
        {
            Response = encryption.DecryptStringAES(response);
        }
        public string CipheredResponse(Encryption encryption)
        {
            return encryption.EncryptStringAES(Response);
        }
        protected string JSON
        {
            get
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                return JsonSerializer.Serialize(this, options);
            }
            set
            {
                OpenEntry openEntry = JsonSerializer.Deserialize<OpenEntry>(value);
                Date = openEntry.Date;
                Prompt = openEntry.Prompt;
                Response = openEntry.Response;
            }
        }
        public Entry ToEntry(Encryption encryption)
        {
            Entry entry = new Entry(encryption, Date, Prompt.ToPrompt(encryption), Response);
            return entry;
        }
    }
}