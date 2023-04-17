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
        // declare string vaiables
        String first, last;
        // output question for first name
        Console.Write("What is your first name? ");
        // store input to question for first name
        first = Console.ReadLine();
        // output question for last name
        Console.Write("What is yout Last name? ");
        // store input to question for last name
        last = Console.ReadLine();
        // output response as required:  "Your name is last-name, first-name, last-name"
        Console.WriteLine($"\nYour name is {last}, {first} {last}.");
    }
}