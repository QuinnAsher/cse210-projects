using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();

        int number = PromptUserNumber();

        int numberSquare = SquareNumber(number);
        
        DisplayResult(name, numberSquare);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program");
    }

    static string PromptUserName()
    {
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();
        return userName;
    }
    
    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number?");
        string userResponse = Console.ReadLine();
       int userResponseInt = int.Parse(userResponse);
       return userResponseInt;
       // Console.WriteLine($"Your favorite number is {userResponseInt}");
    }

    static int SquareNumber(int number)
    {
        int numberSquare = number * number;
        return numberSquare;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"Your name is {name}");
        Console.WriteLine($"The number squared is {square}");
    }
}