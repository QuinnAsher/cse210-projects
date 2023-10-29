namespace Develop03;


public class Program
{
    static void Main(string[] args)
    {
        Scripture scripture;
        ScriptureLibraryLoader libraryLoader;
        Reference reference;

        Console.WriteLine();
        Console.WriteLine("Welcome to the Scripture Memorizer Program");
        Console.WriteLine();
        Console.WriteLine("What do you want to do?\n1. Add scripture to the Scripture Library\n2. Run the Memorizer Program");
        Console.WriteLine();
        

        string userChoice = Console.ReadLine();
        // validate user input
        do
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Enter 1 or 2 to continue");
            Console.WriteLine();
            Console.WriteLine(
                "What do you want to do?\n1. Add scripture to the Scripture Library\n2. Run the Memorizer Program");
            userChoice = Console.ReadLine();
        } while (userChoice != "1" && userChoice != "2");

        int parsedUserChoice = int.Parse(userChoice);
           
        {
           
        }
        // use switch case to handle user choice appropriately
        switch (parsedUserChoice)
        {
            case 1:
            {
                while (true)
                {
                    Console.Clear(); // Clear the console at the start of a new entry
                    ConsoleKeyInfo keyInfo;
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
                        SaveScriptureToFile saveToFile = new SaveScriptureToFile(book, chapter, startVerse, endVerse, text);
                        saveToFile.WriteToFile();  // write to the file
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid input. Please provide book, chapter, start verse, end verse, and text separated by commas.");
                    }
                    
                    //TODO: create a while loop to handle user input
                    
                    Console.WriteLine("Press any key to continue adding scriptures or 'n' to quit.");
                    
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.KeyChar == 'n')
                    {
                        Console.WriteLine("Thank you for using the Scripture Memorizer.");
                        break;
                    }

                }
                
                break;
            }
            
            case 2:  //TODO: make the program keep running even after the user finishes memorizing the scripture
            {
                scripture = new Scripture(true);
                int hiddenCount = 0;
                ConsoleKeyInfo keyInfo;
                Random random = new Random();

                while (hiddenCount < scripture.LengthOfWordList)
                {
                    Console.Clear();
                    Console.WriteLine(scripture.RenderedText());
                    Console.WriteLine();
                    Console.WriteLine("Press any key to reveal the next word or 'n' to quit.");

                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.KeyChar == 'n')
                    {
                        Console.WriteLine("Thank you for using the Scripture Memorizer.");
                        break;
                    }

                    int wordsToHide = random.Next(1, 4);
                    for (int i = 0; i < wordsToHide && hiddenCount < scripture.LengthOfWordList; i++)
                    {
                        scripture.HideWord();
                        hiddenCount++;
                    }
                }

                if (hiddenCount == scripture.LengthOfWordList)
                {
                    Console.Clear();
                    Console.WriteLine(scripture.RenderedText());
                    Console.WriteLine("You've successfully memorized the scripture. Congratulations!");
                    
                    //debugging
                    // Console.WriteLine($"word count:{scripture.LengthOfWordList}- hiddencount:{hiddenCount}");
                }

                break;
            }


        }
    }
}