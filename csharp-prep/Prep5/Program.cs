using System;

/**
 * Learning Activity - C# Prep 5
 * Tracy R. Mann
 * CSE210-A8
 * Bro. Nathan Parrish
 * 4/18/2023
 * 
 * Assignment Instructions
 *      For this assignment, write a C# program that has several simple functions:
 *      
 *      DisplayWelcome - Displays the message, "Welcome to the Program!"
 *      PromptUserName - Asks for and returns the user's name (as a string)
 *      PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
 *      SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
 *      DisplayResult - Accepts the user's name and the squared number and displays them.
 *      
 *      Your Main function should then call each of these functions saving the return values and passing
 *   data to them as necessary.
 */

class Program
{
    // Displays the message, "Welcome to the Program!"
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks for and returns the user's name (as a string)
    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Accepts an integer as a parameter and returns that number squared(as an integer)
    static int SquareNumber(int number) {
        return (number * number);
    }

    // Accepts the user's name and the squared number and displays them.
    static void DisplayResult(string name, int squaredNumber) {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        // declare variables
        string name;
        int number, squaredNumber;
        // request input
        name = PromptUserName();
        number = PromptUserNumber();
        // convert input
        squaredNumber = SquareNumber(number);
        // report output
        DisplayResult(name, squaredNumber);
    }
}