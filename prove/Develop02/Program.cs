using System;

class Program
{
    static Application application = new Application();
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop02 World!");
        application.Run();
    }
}

/**
 * Journal Design
 * Tracy Mann
 * CSE210
 * Bro. Parrish
 * Section A8
 * 4/28/2023
 * v1.0
 * 
 * What does the program do?
 *      For this assignment you will write a program to help people record the events
 *   of their day by supplying prompts and then saving their responses along with the
 *   question and the date to a file.
 *   
 *   Functional Requirements
 *      This program must contain the following features:
 *    1)  Write a new entry - Show the user a random prompt (from a list that you create),
 *    and save their response, the prompt, and the date as an Entry.
 *    2)  Display the journal - Iterate through all entries in the journal and display
 *    them to the screen.
 *    3)  Save the journal to a file - Prompt the user for a filename and then save the
 *    current journal (the complete list of entries) to that file location.
 *    4)  Load the journal from a file - Prompt the user for a filename and then load the
 *    journal (a complete list of entries) from that file. This should replace any entries
 *    currently stored the journal.
 *    5)  Provide a menu that allows the user choose these options
 *    6)  Your list of prompts must contain at least five different prompts. Make sure to
 *    add your own prompts to the list, but the following are examples to help get you started:
 *          Who was the most interesting person I interacted with today?
 *          What was the best part of my day?
 *          How did I see the hand of the Lord in my life today?
 *          What was the strongest emotion I felt today?
 *          If I had one thing I could do over today, what would it be?
 *    7)  Your interface should generally follow the pattern shown in the class video demo.
 *   Design Requirements
 *      In addition, your program must:
 *    1)  Contain classes for the major components in the program.
 *    2)  Contain at least two classes in addition to the Program class.
 *    3)  Demonstrate the principle of abstraction by using member variables and methods
 *    appropriately.
 *   
 * What user inputs does it have?
 *      1)  menu prompt response.
 *      2)  entry prompt response.
 *      3)  save/load filename prompt response.
 * What output does it produce?
 *      1)  display menu:
 *              1)  Add Journal entry.
 *              2)  Display journal.
 *              3)  Load journal.
 *              4)  Save journal.
 *              5)  Exit.
 *              >
 *      2)  display random entry prompt.
 *              Who was the most interesting person I interacted with today?
 *              >
 *              What was the best part of my day?
 *              >
 *              How did I see the hand of the Lord in my life today?
 *              >
 *              What was the strongest emotion I felt today?
 *              >
 *              If I had one thing I could do over today, what would it be?
 *              >
 *      3)  request filename prompt.
 *              please enter the filename:
 *              >
 *      4)  report saving file.
 *              saving to file...
 *      5)  report loading file.
 *              loading from file...
 *      6)  display journal entries.
 *              Journal:
 *              
 *                  {date} prompt: {prompt}
 *                  {response}
 *                  
 *                  {date} prompt: {prompt}
 *                  {response}
 *                  ...
 *      5)  exit message
 *              Thank you for using the Journal Program.
 * How does the program end?
 *      The user will select the exit option from the menu.
 * Class Diagrams:
 *      Application:
 *          Responsibiilty:
 *              to hold the journal information and manage operations performed on the information.
 *          State:
 *              journal Journal
 *              is running Boolean
 *          Behaviors:
 *              run application
 *              display menu
 *              read menu response
 *              evaluate menu response into journal/application behavior
 *              exit
 *      Journal:
 *          Resonsibility:
 *              to add, hold and display journal entries.
 *          State:
 *              entries List<Entry>
 *          Behaviors:
 *              get entry prompts
 *              prompt for entry
 *              read response
 *              add a new journal entry
 *              display all journal entries
 *              prompt for filename
 *              save journal entries
 *              load journal entries
 *      Entry:
 *          Resonsibility:
 *              to hold and display information about an individual event.
 *          State:
 *              date Date
 *              prompt String
 *              response String
 *          Behaviors:
 *              display entry
 *          
 */