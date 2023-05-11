using System.Text.Json;
using System.Text.Json.Serialization;

public class Prompt
{
    private string _value;
    private string _timesUsed;
    private string _lastUsed;
    [JsonConstructor]
    public Prompt(string value, string lastUsed, string timesUsed)
    {
        Value = value;
        LastUsed = lastUsed;
        TimesUsed = timesUsed;
    }
    public Prompt(Encryption encryption, string value, string lastUsed, string timesUsed)
    {
        OpenValue(encryption, value);
        OpenLastUsed(encryption, lastUsed);
        OpenTimesUsed(encryption, timesUsed);
    }
    public Prompt(Encryption encryption, string value, DateTime lastUsed, int timesUsed = 0)
    {
        OpenValue(encryption, value);
        LastUsedDate(encryption, lastUsed);
        TimesUsedInt(encryption, timesUsed);
    }
    [JsonInclude]
    public string Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }
    public void OpenValue(Encryption encryption, string value)
    {
        Value = encryption.EncryptStringAES(value);
    }
    public string OpenValue(Encryption encryption)
    {
        return encryption.DecryptStringAES(Value);
    }
    [JsonInclude]
    public string LastUsed
    {
        get
        {
            return _lastUsed;
        }
        set
        {
            _lastUsed = value;
        }
    }
    public void OpenLastUsed(Encryption encryption, string lastUsed)
    {
        LastUsed = encryption.EncryptStringAES(lastUsed);
    }
    public string OpenLastUsed(Encryption encryption)
    {
        return encryption.DecryptStringAES(LastUsed);
    }
    public void LastUsedDate(Encryption encryption, DateTime lastUsed)
    {
        OpenLastUsed(encryption, lastUsed.ToString());
    }
    public DateTime LastUsedDate(Encryption encryption)
    {
        return DateTime.Parse(OpenLastUsed(encryption));
    }
    [JsonInclude]
    public string TimesUsed
    {
        get
        {
            return _timesUsed;
        }
        set
        {
            _timesUsed = value;
        }
    }
    public void OpenTimesUsed(Encryption encryption, string timesUsed)
    {
        TimesUsed = encryption.EncryptStringAES(timesUsed);
    }
    public string OpenTimesUsed(Encryption encryption)
    {
        return encryption.DecryptStringAES(TimesUsed);
    }
    public void TimesUsedInt(Encryption encryption, int timesUsed)
    {
        OpenTimesUsed(encryption, timesUsed.ToString());
    }
    public int TimesUsedInt(Encryption encryption)
    {
        return int.Parse(OpenTimesUsed(encryption));
    }
    public void Display(Encryption encryption)
    {
        Console.WriteLine(OpenValue(encryption));
        Console.Write(">  ");
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
            Prompt prompt = JsonSerializer.Deserialize<Prompt>(value);
            Value = prompt.Value;
            TimesUsed = prompt.TimesUsed;
            LastUsed = prompt.LastUsed;
        }
    }
    internal OpenPrompt ToOpenPrompt(Encryption encryption)
    {
        OpenPrompt openEntry = new OpenPrompt(encryption, Value, LastUsed, TimesUsed);
        return openEntry;
    }
    internal class OpenPrompt
    {
        private string _value;
        private int _timesUsed;
        private DateTime _lastUsed;
        public OpenPrompt(string value, string lastUsed, string timesUsed)
        {
            Value = value;
            LastUsedString(lastUsed);
            TimesUsedString(timesUsed);
        }
        public OpenPrompt(Encryption encryption, string cipheredValue, string cipheredLastUsed, string cipheredTimesUsed)
        {
            CipheredValue(encryption, cipheredValue);
            CipheredLastUsed(encryption, cipheredLastUsed);
            CipheredTimesUsed(encryption, cipheredTimesUsed);
        }
        [JsonConstructor]
        public OpenPrompt(string value, DateTime lastUsed, int timesUsed = 0)
        {
            Value = value;
            LastUsed = lastUsed;
            TimesUsed = timesUsed;
        }
        [JsonInclude]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public void CipheredValue(Encryption encryption, string cipheredValue)
        {
            Value = encryption.DecryptStringAES(cipheredValue);
        }
        public string CipheredValue(Encryption encryption)
        {
            return encryption.EncryptStringAES(Value);
        }
        [JsonInclude]
        public DateTime LastUsed
        {
            get
            {
                return _lastUsed;
            }
            set
            {
                _lastUsed = value;
            }
        }
        public void CipheredLastUsed(Encryption encryption, string cipheredLastUsed)
        {
            LastUsedString(encryption.DecryptStringAES(cipheredLastUsed));
        }
        public string CipheredLastUsed(Encryption encryption)
        {
            return encryption.EncryptStringAES(LastUsedString());
        }
        public void LastUsedString(string lastUsed)
        {
            LastUsed = DateTime.Parse(lastUsed);
        }
        public string LastUsedString()
        {
            return LastUsed.ToString();
        }
        [JsonInclude]
        public int TimesUsed
        {
            get
            {
                return _timesUsed;
            }
            set
            {
                _timesUsed = value;
            }
        }
        public void CipheredTimesUsed(Encryption encryption, string cipheredTimesUsed)
        {
            TimesUsedString(encryption.DecryptStringAES(cipheredTimesUsed));
        }
        public string CipheredTimesUsed(Encryption encryption)
        {
            return encryption.EncryptStringAES(TimesUsedString());
        }
        public void TimesUsedString(string timesUsed)
        {
            TimesUsed = int.Parse(timesUsed);
        }
        public string TimesUsedString()
        {
            return TimesUsed.ToString();
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
                OpenPrompt openPrompt = JsonSerializer.Deserialize<OpenPrompt>(value);
                Value = openPrompt.Value;
                TimesUsed = openPrompt.TimesUsed;
                LastUsed = openPrompt.LastUsed;
            }
        }
        public Prompt ToPrompt(Encryption encryption)
        {
            Prompt prompt = new Prompt(encryption, Value, LastUsed, TimesUsed);
            return prompt;
        }
    }
}