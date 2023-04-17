using System;
using System.ComponentModel.Design;

/**
 * Learning Activity - C# Prep 2
 * Tracy R. Mann
 * CSE210-A8
 * Bro. Nathan Parrish
 * 4/17/2023
 * 
 * Assignment
 *      Start by completing the core requirements, then when that part
 *   is complete, if you have time, see if you can complete some of the
 *   stretch challenges as well.
 *   
 *      Please work through the requirements in order rather than jumping
 *   ahead to more complicated steps, to ensure that everyone is following
 *   the concepts.
 *   
 * Core Requirements
 *      Ask the user for their grade percentage, then write a series of
 *   if-elif-else statements to print out the appropriate letter grade.
 *   (At this point, you'll have a separate print statement for each grade
 *   letter in the appropriate block.)
 *   
 *      Assume that you must have at least a 70 to pass the class. After
 *   determining the letter grade and printing it out. Add a separate if
 *   statement to determine if the user passed the course, and if so display
 *   a message to congratulate them. If not, display a different message to
 *   encourage them for next time.
 *   
 *      Change your code from the first part, so that instead of printing the
 *   letter grade in the body of each if, elif, or else block, instead create
 *   a new variable called letter and then in each block, set this variable to
 *   the appropriate value. Finally, after the whole series of if-elif-else
 *   statements, have a single print statement that prints the letter grade once.
 *  
 * Stretch Challenge
 *      Add to your code the ability to include a "+" or "-" next to the letter
 *   grade, such as B+ or A-. For each grade, you'll know it is a "+" if the last
 *   digit is >= 7. You'll know it is a minus if the last digit is < 3 and otherwise
 *   it has no sign.
 *   
 *      After your logic to determine the grade letter, add another section to
 *   determine the sign. Save this sign into a variable. Then, display both the
 *   grade letter and the sign in one print statement.
 *   
 *   Hint: To get the last digit, you could divide the number by 10, and get the
 *     remainder. You might refer back to the preparation material for Lesson 03
 *     to see the operators and find the one that does division and gives you the
 *     remainder.
 *     
 *   At this point, don't worry about the exceptional cases of A+, F+, or F-.
 *   
 *   Recognize that there is no A+ grade, only A and A-. Add some additional logic
 *   to your program to detect this case and handle it correctly.
 *   
 *   Similarly, recognize that there is no F+ or F- grades, only F. Add additional
 *   logic to your program to detect these cases and handle them correctly.
 */

class Program
{
    static void Main(string[] args)
    {
        // declare string vaiables
        String rawPercent, article, letter, letterMod;
        // declare int vaiable
        int percent, tens, ones;
        // output question for grade percentage
        Console.Write("Please enter your grade percentage:  ");
        // store input to question for grade percentage
        rawPercent = Console.ReadLine();
        // store converted value from input to question for grade percentage
        percent = int.Parse(rawPercent);
        tens = (percent / 10);
        ones = (percent % 10);
        if (ones >= 7) {
            letterMod = "+";
        } else if(ones < 3) {
            letterMod = "-";
        } else {
            letterMod = "";
        }
        switch (tens)
        {
            case 6:
                article = "a";
                letter = "D";
                break;
            case 7:
                article = "a";
                letter = "C";
                break;
            case 8:
                article = "a";
                letter = "B";
                break;
            case 9:
                article = "an";
                letter = "A";
                if (letterMod == "+") {
                    letterMod = "";
                }
                break;
            case 10:
                article = "an";
                letter = "A";
                letterMod = "";
                break;
            default:
                article = "an";
                letter = "F";
                letterMod = "";
                break;
        }
        Console.WriteLine($"Your letter grade is {article} {letter}{letterMod}.");
        // test if passed the class
        if (percent >= 70)
        {
            Console.WriteLine("Concgratulations, you passed!");

        }
        // by default failed the class.
        else
        {
            Console.WriteLine("I'm sure you will do better next time!");
        }
    }
}