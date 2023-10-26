using System;
using Develop03;



class Program
{
    static void Main(string[] args)
    {
        // Create a Scripture object
        Scripture scripture = new Scripture();

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to reveal the scripture or type 'quit' to exit.");

        // Continue revealing the scripture until it's fully hidden or the user quits
        while (true)
        {
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            

            scripture.HideWords();
            Console.WriteLine(scripture.GetVisibleText());
        }
    }
}

