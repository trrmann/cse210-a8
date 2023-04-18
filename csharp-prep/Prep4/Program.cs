using System;

/**
 * Learning Activity - C# Prep 4
 * Tracy R. Mann
 * CSE210-A8
 * Bro. Nathan Parrish
 * 4/18/2023
 * 
 * Assignment
 *      Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0.
 *      Once you have a list, have your program do the following:
 *   
 * Core Requirements
 *      Work through these core requirements step-by-step to complete the program. Please don't skip
 *   ahead and do the whole thing at once, because others on your team may benefit from building the
 *   program up slowly.
 *      1) Compute the sum, or total, of the numbers in the list.
 *      2) Compute the average of the numbers in the list.
 *      3) Find the maximum, or largest, number in the list.
 * 
 * Stretch Challenge
 *      1) Have the user enter both positive and negative numbers, then find the smallest positive
 *   number (the positive number that is closest to zero).
 *      2) Sort the numbers in the list and display the new, sorted list. Hint: There are C# libraries
 *   that can help you here, try searching the internet for them.
 */

class Program
{
    static void Main(string[] args)
    {
        // declare variables
        List<int> numbers = new List<int>();
        string rawNumber;
        double avg;
        int number, index, sum = 0;
        bool exit = false;
        // present instructions
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            // request input
            Console.Write("Enter number:  ");
            rawNumber = Console.ReadLine();
            // convert input
            number = int.Parse(rawNumber);
            if (number != 0) {
                numbers.Add(number);
            } else
            {
                exit = true;
            }
        } while (!exit);
        for (index = 0; index < numbers.Count; index++)
        {
            sum += numbers[index];
        }
        // looked up casting at https://www.w3schools.com/cs/cs_type_casting.php
        avg = (double)sum / (double)numbers.Count;
        // report output
        Console.WriteLine($"The sum is:  {sum}");
        Console.WriteLine($"The average is:  {avg}");
    }
}