namespace Develop04;

public class Menu : Activity
{
     public Menu()
     {
          
     }

     public void RunMenu()
     {
         bool endProgram = false;  // determines when to end the program

         while (!endProgram)
         {
             Console.Clear();
             Console.Write("\nMenu options: \n    1. Start Breathing Activity\n    2. Start Reflecting Activity\n    3. " +
                           "Start Listening Activity\n    4. Quit\nSelect a choice from the Menu: ");
             
             ConsoleKey selectedKey;

             while (true)
             {
                 ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                 selectedKey = keyInfo.Key;

                 if (selectedKey >= ConsoleKey.D1 && selectedKey <= ConsoleKey.D4)
                 {
                     break;
                 }

                 else
                 {
                     Console.Clear();
                     Console.WriteLine();
                     Console.Write("\nInvalid input. Enter a valid option");
                     Console.Write("\nMenu options: \n    1. Start Breathing Activity\n    2. Start Reflecting Activity\n    3. " +
                                   "Start Listening Activity\n    4. Quit\nSelect a choice from the Menu: ");
                 }
             }
             
             // use a switch cast to run the program based on the selected ey

             switch (selectedKey)
             {
                 case ConsoleKey.D1:
                 {
                     BreathingActivity breathingActivity = new BreathingActivity();
                     
                     break;
                 }
             }
         }
     }
}