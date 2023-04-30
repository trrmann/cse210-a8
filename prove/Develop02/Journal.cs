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

public class Journal
{
    [JsonInclude]
    public List<Entry> _entries = new List<Entry>();
    [JsonInclude]
    public string _configurationFile = "journalConfiguration.json";

    public List<Prompt> GetEntryPrompts()
    {
        string jsonString;
        Prompt prompt;
        List<Prompt> prompts = new List<Prompt>();
        //Console.WriteLine($"current path:  {Path.GetFullPath(this._configurationFile)}");
        if (!File.Exists(this._configurationFile))
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
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(prompts, options);
            File.WriteAllText(this._configurationFile, jsonString);
        }
        jsonString = File.ReadAllText(this._configurationFile);
        prompts = JsonSerializer.Deserialize<List<Prompt>>(jsonString);
        return prompts;
    }

    public Prompt GetEntryPrompt(List<Prompt> prompts)
    {
        Prompt prompt;
        Random random = new Random();
        DateTime dateTime = DateTime.Now, today = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0, dateTime.Kind);
        List<Prompt> availablePrompts = new List<Prompt>();
        List<int> counts = new List<int>();
        int sum, count, maxUsableCount, max = 0, min = -1, minAvailablePrompts = 2;
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
        Console.WriteLine($"{min} - {maxUsableCount} - {max} - {sum}");
        foreach (Prompt element in prompts)
        {
            if (DateTime.Compare(element._lastUsed,today)<0
                && element._timesUsed >= min
                && element._timesUsed <= maxUsableCount)
            {
                Console.WriteLine($"{element._value} - {element._timesUsed} - {element._lastUsed}");
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
        _entries.Add(entry);
        entry._prompt._timesUsed++;
        entry._prompt._lastUsed = DateTime.Now;
        return entry._prompt;
    }

    public void UpdatePromptData(List<Prompt> prompts, Prompt prompt)
    {
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
        File.WriteAllText(this._configurationFile, jsonString);
    }

    public void Display()
    {
        Console.WriteLine("Journal:");
        _entries.ForEach(entry => {entry.Display();});
        Console.WriteLine();
    }

    public void PromptForFilename()
    {
        Console.WriteLine("Please enter the filename:");
        Console.Write(">  ");
    }

    public string evaluateFileFormat(string filename)
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

    public void LoadEntries(string filename)
    {
        Console.WriteLine("loading from file...");
        switch (evaluateFileFormat(filename))
        {
            case "csv":
                _entries.Clear();
                string[] lines = System.IO.File.ReadAllLines(filename);
                if(isCSV(lines))
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
                            _entries.Add(entry);
                        }
                    }
                } else
                {
                    Console.WriteLine("Unable to read file as CSV.");
                }
                break;
            case "json":
                string jsonString = File.ReadAllText(filename);
                if (isJSON(jsonString))
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

    public bool isCSV(string[] data)
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

    public bool isJSON(string data)
    {
        if (data == null) return false;
        if (data[0].CompareTo('{') == 0
            && data[data.Count() - 1].CompareTo('}') == 0
            && data.Contains("_entries")
            && data.Contains("_configurationFile")
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
        switch (evaluateFileFormat(filename))
        {
            case "csv":
                using (StreamWriter output = new StreamWriter(filename))
                {
                    output.WriteLine($"\"Date\",\"Prompt\",\"Times\",\"Last\",\"Response\"");
                    foreach (Entry entry in _entries) {
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
        return JsonSerializer.Serialize(this, options);
    }

    public void SetJSON(string input)
    {
        Journal? entry = JsonSerializer.Deserialize<Journal>(input);
        this._entries.Clear();
        foreach (Entry element in entry._entries)
        {
            this._entries.Add(element);
        };
    }

}