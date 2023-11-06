namespace Develop04;

public class Menu : Activity
{
     public Menu()
     {
          
     }

     public void RunMenu()
     {
         bool endProgram = false; // determines when to end the program

         while (!endProgram)
         {
             Console.Clear();
             Console.WriteLine("Menu options:");
             Console.WriteLine("    1. Start Breathing Activity");
             Console.WriteLine("    2. Start Reflecting Activity");
             Console.WriteLine("    3. Start Listening Activity");
             Console.WriteLine("    4. Quit");
             Console.Write("Select a choice from the Menu: ");

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
                     Console.WriteLine("Invalid input. Enter one of the following options: ");
                     Console.WriteLine("Menu options:");
                     Console.WriteLine("    1. Start Breathing Activity");
                     Console.WriteLine("    2. Start Reflecting Activity");
                     Console.WriteLine("    3. Start Listening Activity");
                     Console.WriteLine("    4. Quit");
                     Console.Write("Select a choice from the Menu: ");
                 }
             }

             // use a switch cast to run the program based on the selected key
                 switch (selectedKey)
                 {
                     case ConsoleKey.D1:
                     {
                         while (true)
                         {
                             BreathingActivity breathingActivity = new BreathingActivity();
                             breathingActivity.RunActivity();
                             
                             Console.WriteLine();
                             Console.Write("Enter any key to continue the Breathing activity or 'n' to go to the main menu: ");
                             ConsoleKeyInfo endSession = Console.ReadKey(true);

                             if (endSession.KeyChar == 'n')
                             {
                                 break;
                             }
                         }
                         break;
                     }
                 }
             
         }
     }
}