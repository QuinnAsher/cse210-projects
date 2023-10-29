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
                Console.WriteLine("Enter the book, chapter, start verse, end verse and text seperated by comma.\n" +
                                  "John,3,16,0");
                string userInput = Console.ReadLine();
                
                // convert the user input to a list
                List<string> scriptureInfo = new List<string>(userInput.Split(",").ToList());
                
                // extract the scripture info, assuming the user inputted the details accordingly
                string book = scriptureInfo[0];
                string text = scriptureInfo[1];
                int chapter = int.Parse(scriptureInfo[2]);
                int startVerse = int.Parse(scriptureInfo[3]);
                int endVerse = int.Parse(scriptureInfo[4]);
                
                // instantiate an object of saving to file
                saveToFile = new SaveScriptureToFile(book, chapter, startVerse, endVerse, text);
                break;
            }
        }
    }
}