using System;
using System.IO;

public class Entry
{
    public DateTime _date;
    public string _prompt;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"\n{_date}  prompt:  {_prompt}");
        Console.WriteLine($"{_response}");
    }

    public void WriteCSV(StreamWriter output)
    {
        output.WriteLine($"{_date.ToString()},{_prompt},{_response}");
    }

    public void ParseCSV(string input)
    {
        string[] parts = input.Split(",");
        string date_str = parts[0];
        _date = DateTime.Parse(date_str);
        _prompt = parts[1];
        _response = parts[2];
    }
}