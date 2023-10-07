using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
       
        // create a bool flag to end the game when needed
        bool endOfGame = false;
        
        // make a variable to keep track of guesses
        int guessCount = 0;
        
        // initialize the while loop to start the game
        while (! endOfGame)
        {
         // create a variable for the magic number
         int magicNumber = randomGenerator.Next(1, 11);
         
         // ask the player to guess a magic number
         Console.WriteLine("Guess a number");
         string guessStr = Console.ReadLine();
         
         int guess = int.Parse(guessStr);
         guessCount += 1;
         
         
         // use a while loop to validate the users guess

         if (guess == magicNumber)
         {
             Console.WriteLine($"You guess correctly! It took you {guessCount} guess(es)");
             
             // ask the user if they want to play again
             Console.WriteLine("Do you want to play again? Enter n to quit or any letter to continue");
             string userchoice = Console.ReadLine();
             if (userchoice == "n");

             {
                 Console.WriteLine("Thanks for playing my game.");
                 endOfGame = true;
             }
         }
         
         // this line means the player has not guessed correctly, so use a while loop to give them a chance to play again
         while (guess != magicNumber)
         {
             if (guess < magicNumber)
             {
                 Console.WriteLine("Higher");
             }
             
             else if (guess > magicNumber)
             {
                 Console.WriteLine("Lower");
             }
             
             // ask the player to guess a magic number
             Console.WriteLine("Guess again");
             guessStr = Console.ReadLine();
         
             guess = int.Parse(guessStr);
             guessCount += 1;
             
             // check whether guess count has reached 10. if so end the game
             if (guessCount == 10)
             {
                 Console.WriteLine("You have exceeded the allowed attempt. Enter n to exit or any letter to continue");
                 string userChoice = Console.ReadLine();

                 if (userChoice == "n")
                 { 
                     Console.WriteLine("Thanks for playing my game");
                     endOfGame = true;
                     break;
                 }

                 else
                 {
                     break;
                 }
             }
         }
         
         
        }
    }  
    
        
}


