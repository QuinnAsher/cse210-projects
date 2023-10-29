namespace Develop03;


public class Program
{
    static void Main(string[] args)
    {
        Scripture scripture;
        ScriptureLibraryLoader libraryLoader;
        SaveScriptureToFile saveToFile; // =new SaveScriptureToFile("John", 3, 4, 6, "Jesus Wept");
        Reference reference;
        // Word word;
        Random random;

        Console.WriteLine();
        Console.WriteLine("Welcome to the Scripture Memorizer Program");
        Console.WriteLine();
        Console.WriteLine("What do you want to do?\n1. Add scripture to the Scripture Library\n2. Run the Memorizer Program");

        string userChoice = Console.ReadLine();
        int parsedUserChoice = int.Parse(userChoice);
        
        // use switch case to handle user choice appropriately
        switch (parsedUserChoice)
        {
            case 1:
            {
                // Console.Write("Enter the book, chapter, start verse, end verse and text seperated by comma.\n" +
                //               "John,3,16,0,For God....... ");
                while (true)
                {
                    Console.Clear(); // Clear the console at the start of a new entry
                    Console.Write("Enter the book, chapter, start verse, end verse and text seperated by comma.\n" +
                    "John,3,16,0,For God....... ");
                    string userInput = Console.ReadLine();
                
                    // convert the user input to a list
                    List<string> scriptureInfo = new List<string>(userInput.Split(",").ToList());

                    if (scriptureInfo.Count > 4)
                    {
                        // extract the scripture info, assuming the user inputted the details accordingly
                        string book = scriptureInfo[0];
                        int chapter = int.Parse(scriptureInfo[1]);
                        int startVerse = int.Parse(scriptureInfo[2]);
                        int endVerse = int.Parse(scriptureInfo[3]);
                        string text = scriptureInfo[4];
                
                        // instantiate an object of saving to file
                        saveToFile = new SaveScriptureToFile(book, chapter, startVerse, endVerse, text);
                        saveToFile.WriteToFile();  // write to the file
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid input. Please provide book, chapter, start verse, end verse, and text separated by commas.");
                    }
                    
                    //TODO: create a while loop to handle user input
                    
                    Console.WriteLine("Press Enter to continue or any key to exit");
                    // string exit = Console.ReadLine();
                    
                    // the key info gets the type of key
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key != ConsoleKey.Enter)
                    {
                        break;  // end the loop when any key is entered
                    }

                    else
                    {
                        continue;
                    }
                    Console.Clear();  // clear the console
                }
                
                break;
            }

            case 2:
            {
                
                break;
            }
        }
    }
}