namespace Develop02;
class Program
{
    static void Main(string[] arg)
    {
        // initialze variables 
        int userChoiceInt;
        string userInput;
        string randomPrompt;
        
        // make objects of the classes
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        
        
        

        do
        {
            Console.WriteLine("Please select one of the options:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Delete\n6. Quit");
            Console.Write("What would you like to do? ");
            string userChoiceStr = Console.ReadLine();
            
            userChoiceInt = int.Parse(userChoiceStr);

            // use a switch statement to appropriately handle user choice
            switch (userChoiceInt)
            {
                case 1:
                {
                    // prompt the user for a journal entry
                    randomPrompt = promptGenerator.GetRamdomPrompt();
                    Console.WriteLine(randomPrompt);
                    Console.Write("> ");
                    userInput = Console.ReadLine();
                    // Console.WriteLine();
                    
                    // add the entry to the entry list
                    journal.AddEntry(randomPrompt, userInput);
                    break;
                }

                case 2:
                {
                    // call the display method from the Journal class
                    journal.DisplayEntries();
                    break;
                }

                case 3:
                {
                    // ask the user for the file name and them call the LoadEntries method
                    Console.WriteLine("Enter the name of the file you would like to Load (eg: journal.txt)");
                    string fileName = Console.ReadLine();
                    journal.LoadEntries(fileName);
                    break;
                }

                case 4:
                {
                    // ask the user for the file name and them call the SaveEntries method
                    Console.WriteLine("Enter the name of the file you would like to save your journal (eg: ournal)" +
                                      ".txt");
                    string fileName = Console.ReadLine();
                    journal.SaveEntries(fileName);
                    break;
                }

                case 5:
                {
                    // ask the user for the file to delete and call the Delete method
                    Console.WriteLine("Enter the name of the file your would like to delete (eg: journal.txt)");
                    string fileName = Console.ReadLine();
                    journal.DeleteEntries(fileName);
                    break;
                }
                
                default:
                    Console.WriteLine("Your choice is invalid. Please select a number from 1 to 5.");
                    break;
            }
            Console.WriteLine("");
        } while (userChoiceInt != 6);  // ends the loop when the user enters quit
        Console.WriteLine("Thanks you for using my Journal Program. See you soon!");
    }
}
