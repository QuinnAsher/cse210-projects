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
            Console.WriteLine();
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
                    Console.WriteLine("Invalid input.\n1. Add Scripture\n2. Memorize Scripture\n3. Exit");
                    Console.WriteLine();
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
                        Console.WriteLine("Enter the book, chapter, start verse, end verse, and text separated by a comma.\nJohn,3,16,0,For God.......");

                        string userInput = Console.ReadLine();

                        // convert userInput into a list
                        List<string> userInputToList = new List<string>(userInput.Split().ToList());

                        if (userInputToList.Count > 4) // Change the condition to check for all required values
                        {
                            // extract the data passed in by the user
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
                            Console.WriteLine("Press Enter to continue or 'n' to go to the main menu");
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            if (keyInfo.KeyChar == 'n')
                            {
                                break;
                            }
                            // If Enter is pressed, continue the loop, giving the user another chance to input data.
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

                        while (hiddenCount < scripture.LengthOfWordList)
                        {
                            Console.Clear();
                            Console.WriteLine(scripture.RenderedText());
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue hiding the next word or 'n' to quit");
                            
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                            if (keyInfo.KeyChar == 'n')
                            {
                                Console.WriteLine("See you soon");
                                shouldContinue = false;
                                break;
                            }
                            else if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                int numberOfWordsToHide = random.Next(1, 4);
                                for (int i = 0; i < numberOfWordsToHide && hiddenCount < scripture.LengthOfWordList; i++)
                                {
                                    scripture.HideWord();
                                    hiddenCount += 1;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input. Press Enter to continue or 'n' to quit");
                            }

                            if (hiddenCount == scripture.LengthOfWordList)
                            {
                                Console.Clear();
                                Console.WriteLine(scripture.RenderedText());
                                Console.WriteLine("You have successfully completed a session. Press Enter to continue or 'n' to quit");

                                while (true)
                                {
                                    ConsoleKeyInfo key = Console.ReadKey(true);
                                    if (key.KeyChar == 'n')
                                    {
                                        Console.WriteLine("See you soon");
                                        shouldContinue = false;
                                        break;
                                    }
                                    else if (key.Key == ConsoleKey.Enter)
                                    {
                                        break;  // breaks out of the outer loop
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("Invalid input. Press Enter to continue or 'n' to quit");
                                    }
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