using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Entry
{
    [JsonInclude]
    public DateTime _date;
    [JsonInclude] 
    public Prompt _prompt;
    [JsonInclude] 
    public string _response;

    public void Display()
    {
        Console.WriteLine($"\n{_date}  prompt:  {_prompt._value}");
        Console.WriteLine($"{_response}");
    }

    public void WriteCSV(StreamWriter output)
    {
        output.WriteLine($"\"{_date.ToString()}\",\"{_prompt._value}\",\"{_prompt._timesUsed}\",\"{_prompt._lastUsed}\",\"{_response}\"");
    }

    public void ParseCSV(string input)
    {
        string[] parts = input.Split("\",\"");
        List<string> p0 = new List<string>(parts[0].Split("\""));
        p0.RemoveAt(0);
        string date_str = string.Join("\"", p0);
        this._date = DateTime.Parse(date_str);
        this._prompt = new Prompt();
        this._prompt._value = parts[1];
        this._prompt._timesUsed = int.Parse(parts[2]);
        this._prompt._lastUsed = DateTime.Parse(parts[3]);
        List<string> p4 = new List<string>(parts[4].Split("\""));
        p4.RemoveAt(p4.Count()-1);
        this._response = string.Join("\"", p4);
    }

    public string GetJSON()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(this, options);
    }

    public void SetJSON(string input)
    {
        Entry entry = JsonSerializer.Deserialize<Entry>(input);
        this._date = entry._date;
        this._prompt = entry._prompt;
        this._response = entry._response;
    }
}