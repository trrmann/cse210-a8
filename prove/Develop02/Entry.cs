using System;

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
}