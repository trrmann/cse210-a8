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
 * 4/29/2023
 * v1.1
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
 *  Stretch Requirements
 *    1)  Add option to save and load JSON format.
 *    2)  Read configuration for the application in JSON format from config file.
 *    3)  Add checks for file extension assitance:  .csv for CSV file and .json for JSON file.
 *    4)  Add counter for prompt questions used.
 *    5)  Add last date used for prompt questions.
 *    6)  Add distribution balancer for random selection of prompt questions.
 *    7)  Add freeform prompt when all prompts have been used in the same day.
 *   
 * What user inputs does it have?
 *      1)  menu prompt response.
 *      2)  entry prompt response.
 *      3)  save/load filename prompt response.
 *      4)  save/load file format prompt response.
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
 *      4)  file format menu:
 *              1)  CSV.
 *              2)  JSON.
 *              >
 *      5)  report saving file.
 *              saving to file...
 *      6)  report loading file.
 *              loading from file...
 *      7)  display journal entries.
 *              Journal:
 *              
 *                  {date} prompt: {prompt}
 *                  {response}
 *                  
 *                  {date} prompt: {prompt}
 *                  {response}
 *                  ...
 *      8)  exit message
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
 *              get entry prompt for entry
 *              prompt for entry
 *              read response
 *              add a new journal entry
 *              display all journal entries
 *              prompt for filename
 *              prompt for file format
 *              save journal entries
 *              load journal entries
 *      Prompt:
 *          Responsibilty:
 *              to hold information about the available prompts for jornal entries.
 *          State:
 *              value string
 *              timesUsed int
 *              lastUsed DateTime
 *          Behaviors:
 *              display prompt
 *              parse json
 *              write json
 *      Entry:
 *          Resonsibility:
 *              to hold and display information about an individual event.
 *          State:
 *              date Date
 *              prompt String
 *              response String
 *          Behaviors:
 *              display entry
 *              parse csv
 *              write csv
 *              parse json
 *              write json
 *          
 *      Notes:
 *          I found the json format notes on stack overflow:  https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-7-0
 */