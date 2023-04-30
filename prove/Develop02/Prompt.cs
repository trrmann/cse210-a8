using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Prompt
{
    [JsonInclude]
    public string _value;
    [JsonInclude]
    public int _timesUsed = 0;
    [JsonInclude]
    public DateTime _lastUsed;

    public void Display()
    {
        Console.WriteLine(this._value);
        Console.Write(">  ");
    }

    public string GetJSON()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(this, options);
    }

    public void SetJSON(string input)
    {
        Prompt prompt = JsonSerializer.Deserialize<Prompt>(input);
        this._value = prompt._value;
        this._timesUsed = prompt._timesUsed;
        this._lastUsed = prompt._lastUsed;
    }
}