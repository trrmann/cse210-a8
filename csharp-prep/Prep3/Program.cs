using System;

/**
 * Learning Activity - C# Prep 3
 * Tracy R. Mann
 * CSE210-A8
 * Bro. Nathan Parrish
 * 4/17/2023
 * 
 * Overview
 *      In the Guess My Number game the computer picks a magic number, and then the user tries to guess it.
 *   After each guess, the computer tells the user to guess "higher" or "lower" until they guess the magic
 *   number.
 *   
 *      This assignment is a little tricky, because it brings together many of the concepts you've learned
 *   in this course including loops and if statements.
 *   
 * Core Requirements
 *      1) Work through these core requirements step-by-step to complete the program. Please don't skip ahead
 *   and do the whole thing at once, because many people benefit from seeing the program built up step by step.
 *   
 *      Start by asking the user for the magic number. (In future steps, we will change this to have the computer
 *   generate a random number, but to get started, we'll just let the user decide what it is.)
 *   
 *      Ask the user for a guess.
 *   
 *      Using an if statement, determine if the user needs to guess higher or lower next time, or tell them
 *   if they guessed it.
 *   
 *      At this point, you won't have any loops
 *      
 *      2) Add a loop that keeps looping as long as the guess does not match the magic number.
 *      
 *      At this point, the user should be able to keep playing until they get the correct answer.
 *      
 *      3) Instead of having the user supply the magic number, generate a random number from 1 to 100.
 *      
 *      Play the game and make sure it works!
 * 
 * Stretch Challenge
 *      1) Keep track of how many guesses the user has made and inform them of it at the end of the game.
 *      
 *      2) After the game is over, ask the user if they want to play again. Then, loop back and play the
 *   whole game again and continue this loop as long as they keep saying "yes"
 */

class Program
{
    static void Main(string[] args)
    {
        // declare variables
        Random randomGenerator = new Random();
        string rawMagic, rawGuess;
        int magic, guess, counter=0;
        bool done = false;
        // request input
        //Console.Write("What is the magic number? ");
        //rawMagic = Console.ReadLine();
        // convert input
        //magic = int.Parse(rawMagic);
        // get random number
        magic = randomGenerator.Next(1, 100);
        do
        {
            // request input
            Console.Write("What is your guess? ");
            rawGuess = Console.ReadLine();
            // convert input
            guess = int.Parse(rawGuess);
            // report output
            if (guess > magic) {
                Console.WriteLine("Lower");
            } else if (guess < magic) {
                Console.WriteLine("Higher");
            } else {
                Console.WriteLine($"You guessed it in {counter+1} tries!");
                done = true;
            }
            counter++;
        } while (!done);
    }
}