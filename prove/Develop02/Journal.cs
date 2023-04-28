using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public List<string> GetEntryPrompts()
    {
        List<string> prompts = new List<string>();
        prompts.Add("Who was the most interesting person I interacted with today ?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today ?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
        return prompts;
    }

    public string PromptForEntry(List<string> prompts)
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write(">  ");
        return prompt;
    }

    public string ReadResponse()
    {
        return Console.ReadLine();
    }

    public void AddJournalEntry(string prompt, string response)
    {
        DateTime dateTime = DateTime.Now;
        Entry entry = new Entry();
        entry._date = dateTime;
        entry._prompt = prompt;
        entry._response = response;
        _entries.Add(entry);
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

    public void LoadEntries(string filename)
    {
        _entries.Clear();
        Console.WriteLine("loading from file...");
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Entry entry = new Entry();
            string[] parts = line.Split(",");
            string date_str = parts[0];
            entry._date = DateTime.Parse(date_str);
            entry._prompt = parts[1];
            entry._response = parts[2];
            _entries.Add(entry);
        }
    }

    public void SaveEntries(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            Console.WriteLine("saving to file...");
            foreach (Entry entry in _entries) {
                output.WriteLine($"{entry._date.ToString()},{entry._prompt},{entry._response}");
            };
        }
    }
}