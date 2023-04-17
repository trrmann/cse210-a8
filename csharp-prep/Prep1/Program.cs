using System;

/**
 * Learning Activity - C# Prep 1
 * Tracy R. Mann
 * CSE210-A8
 * Bro. Nathan Parrish
 * 4/17/2023
 * 
 * Assignment
 *      Prompt the user for their first name. Then, prompt them for their
 *   last name. Display the text back all on one line saying,
 *   "Your name is last-name, first-name, last-name" as shown:
 */

class Program
{
    static void Main(string[] args)
    {
        // declare variables
        string first, last;
        // request input
        Console.Write("What is your first name? ");
        first = Console.ReadLine();
        Console.Write("What is your last name? ");
        last = Console.ReadLine();
        // report output
        Console.WriteLine($"Your Name is {last}, {first} {last}.");
    }
}