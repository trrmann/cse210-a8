using System;
using static System.Net.Mime.MediaTypeNames;

public class Application
{
    public Journal _journal = new Journal();
    public Boolean _isRunning = false;

    public void Run()
    {
        _isRunning = true;
        while (_isRunning)
        {
            DisplayMenu();
            _isRunning = EvaluateMenu(ReadMenu());
        };
        Exit();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1)  Add Journal entry.");
        Console.WriteLine("2)  Display journal.");
        Console.WriteLine("3)  Load journal.");
        Console.WriteLine("4)  Save journal.");
        Console.WriteLine("5)  Exit.");
        Console.Write(">  ");
    }

    public string ReadMenu()
    {
        return Console.ReadLine();
    }

    public Boolean EvaluateMenu(string Response)
    {
        string prompt;
        switch (Response)
        {
            case "1":
                prompt = _journal.PromptForEntry(_journal.GetEntryPrompts());
                _journal.AddJournalEntry(prompt, _journal.ReadEntryResponse());
                return true;
            case "2":
                _journal.Display();
                return true;
            case "3":
                _journal.PromptForFilename();
                _journal.LoadEntries(_journal.ReadFilenamePrompt());
                return true;
            case "4":
                _journal.PromptForFilename();
                _journal.SaveEntries(_journal.ReadFilenamePrompt());
                return true;
            case "5":
                return false;
            default:
                return true;
        }
    }

    public void Exit()
    {
        Console.WriteLine("Thank you for using the Journal Program.");
    }
}