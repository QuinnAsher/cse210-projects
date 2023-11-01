namespace Develop03;


public class Program
{
    static void Main(string[] args)
    {
        ScriptureLibraryLoader libraryLoader;
        Reference reference;
        
        Console.WriteLine();
        Console.WriteLine("Welcome to the Scripture Memorizer Program");
        Console.WriteLine();
        
        bool isEnded = false;  // determines when to end the program
        
        while (!isEnded)
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?\n1. Add Scripture\n2. Memorize Scripture\n3. Exit");
            int userChoiceInt = 0;  // a temporal variable to store the user choice
            
            while (userChoiceInt != 1 & userChoiceInt != 2 & userChoiceInt != 3)  // loop ends when user enters 1, 2 or 3
            {
                try
                {
                    string userChoice = Console.ReadLine();
                    userChoiceInt = int.Parse(userChoice);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Enter 1 or 2 to continue.");
                }
            }
            
            // use a switch case to set the program flow
            switch (userChoiceInt)
            {
                case 1:
                {
                    while (true)
                    {
                        Console.Clear();  // clears the console before any other thing is displayed
                        Console.WriteLine("Enter the book, chapter, start verse, end verse and text seperated by comma.\nJohn,3,16,0,For God.......");

                        string userInput = Console.ReadLine();
                        
                        // convert userInput into a list
                        List<string> userInputToList = new List<string>(userInput.Split().ToList());

                        if (userInputToList.Count > 3)
                        {
                            // extract the data passed in my the user
                            string book = userInputToList[0];
                            int chapter = int.Parse(userInputToList[1]);
                            int startVerse = int.Parse(userInputToList[2]);
                            int endVerse = int.Parse(userInputToList[3]);
                            string text = userInputToList[4];
                        
                            // instantiate an object to save to file
                            SaveScriptureToFile saveScripture = new SaveScriptureToFile(book, chapter, startVerse, endVerse, text);
                            saveScripture.WriteToFile();  // write to file
                        }

                        else
                        {
                            Console.WriteLine("Invalid input. Please provide book, chapter, start verse, end verse, and text separated by commas.");
                            continue;  // TODO; find the reason why the continue statement 
                        }
                        
                        // end the loop based on the input of the user
                        Console.WriteLine("Enter any key to continue adding scripture, or 'n' to go to the main menu");
                        // Console.Clear();
                        
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.KeyChar == 'n')
                        {
                            break;
                        }
                    }
                    break;
                }

                case 2:
                {
                    //TODO: fix the bug that does not allow the user to end the program while the scripture memorizer is still running
                    bool shouldContinue = true;  // game flag to determine when to end the program
                    while (shouldContinue)  
                    {
                        Scripture scripture = new Scripture();
                        int hiddenCount = 0;
                        Random random = new Random();

                        
                        while (hiddenCount < scripture.LengthOfWordList)  // the loop runs until all words are hidden or user enters n
                        {
                            //TODO: find a way to make sure that the same scripture is not displayed in the same session
                            Console.Clear();
                            Console.WriteLine("Press any key to continue hide the next word or 'n' to quit");
                            Console.WriteLine(scripture.RenderedText());
                            Console.WriteLine();

                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            
                            if (keyInfo.KeyChar == 'n')
                            {
                                Console.WriteLine("Thank you for using the Scripture Memorizer Program! See you soon.");
                                // shouldContinue = true;  // ends the outer while loop
                                break;
                            }

                            int hideWordCount = random.Next(1, 4);
                            for (int i = 0; i < hideWordCount && hiddenCount < scripture.LengthOfWordList; i++)
                            {
                                scripture.HideWord();
                                hiddenCount += 1;
                            }

                            if (hiddenCount == scripture.LengthOfWordList)
                            {
                                Console.Clear();
                                Console.WriteLine(scripture.RenderedText());
                                Console.WriteLine("You have successfully completed a session. Enter n to quit or any key" +
                                                  "to run another session");
                                ConsoleKeyInfo key = Console.ReadKey();
                                if (key.KeyChar == 'n')
                                {
                                    shouldContinue = false;
                                    Console.WriteLine("See you soon");
                                }

                            }
                        }
                    }
                    break;
                }

                case 3:
                {
                    if (userChoiceInt == 3)
                    {
                        Console.WriteLine("Thank you for using the Scripture Memorizer app. See you soon!");
                        isEnded = true;
                    }
                    break;
                }
            }

        }

    }
}