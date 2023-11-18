namespace Develop05;

public class Menu
{
   public void RunProgram()
   {
      GoalManager goalManager = new GoalManager();
      bool endProgram = false;
      
      while(!endProgram)
      {
         ConsoleKeyInfo keyInfo;
         ConsoleKey selectedKey;
         
         // Console.Clear();
         Console.WriteLine();
         Console.WriteLine($"You have {goalManager.UserScore()} points");
         
         Console.WriteLine();
         Console.WriteLine("Menu Options:");
         Console.WriteLine("    1. Create New Goal");
         Console.WriteLine("    2. List Goals");
         Console.WriteLine("    3. Save Goals");
         Console.WriteLine("    4. Load Goals");
         Console.WriteLine("    5. Record Event");
         Console.WriteLine("    6. Remove Goal");
         Console.WriteLine("    7. Quit");
         Console.Write("Select a choice from the menu: ");
         keyInfo = Console.ReadKey();
         selectedKey = keyInfo.Key;

         while (!(selectedKey >= ConsoleKey.D1 && selectedKey <= ConsoleKey.D7))
         {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Invalid Input. Choose From the menu options");
            // Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Remove Goal");
            Console.WriteLine("    7. Quit");
            Console.Write("Select a choice from the menu: ");
            keyInfo = Console.ReadKey();
            selectedKey = keyInfo.Key;
         }
         
         
         switch (selectedKey)
         {
            case ConsoleKey.D1:
            {
               Console.Clear();
               Console.WriteLine();
               Console.WriteLine("The types of Goals are:");
               Console.WriteLine("  1. Simple Goal");
               Console.WriteLine("  2. Eternal Goal");
               Console.WriteLine("  3. Checklist Goal");
               
               Console.Write("Which type of goal would you like to create?: ");
               keyInfo = Console.ReadKey();
               selectedKey = keyInfo.Key;
               
               while (!(keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D3))
               {
                  Console.WriteLine();
                  Console.Write("Invalid input. Enter 1, 2 or 3  to continue ");
                  keyInfo = Console.ReadKey();
                  selectedKey = keyInfo.Key;
                  //TODO: this loop does not work, come and fix it later
               }

               switch (selectedKey)
               {
                  case ConsoleKey.D1:
                  {
                     Console.Clear();
                     Console.WriteLine();
                     Console.Write("What is the name of your goal? ");
                     string goalName = Console.ReadLine();
                     
                     Console.Write("What is the description of your goal? ");
                     string goalDescription = Console.ReadLine();
                     
                     Console.Write("How many points do you want associated with this goal? ");
                     int goalPoint = int.Parse(Console.ReadLine());
                     
                     // create a simple goal
                     Goal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoint);
                     goalManager.AddGoals(simpleGoal);
                     break;
                  }

                  case ConsoleKey.D2:
                  {
                     Console.WriteLine();
                     Console.Write("What is the name of your goal? ");
                     string goalName = Console.ReadLine();
                     
                     Console.Write("What is the description of your goal? ");
                     string goalDescription = Console.ReadLine();
                     
                     Console.Write("How many points do you want associated with this goal? ");
                     int goalPoint = int.Parse(Console.ReadLine());
                     
                     Goal simpleGoal = new EternalGoal(goalName, goalDescription, goalPoint);
                     goalManager.AddGoals(simpleGoal);
                     break;
                  }

                  case ConsoleKey.D3:
                  {
                     Console.WriteLine();
                     Console.Write("What is the name of your goal? ");
                     string goalName = Console.ReadLine();
                     
                     Console.Write("What is the description of your goal? ");
                     string goalDescription = Console.ReadLine();
                     
                     Console.Write("How many points do you want associated with this goal? ");
                     int goalPoint = int.Parse(Console.ReadLine());
                     
                     Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                     int targetCount = int.Parse(Console.ReadLine());
                     
                     Console.Write("What is the bonus for accomplishing it that many times? ");
                     int bonus = int.Parse(Console.ReadLine());
                     
                     Goal checkListGoal = new CheckListGoal(goalName, goalDescription, goalPoint, bonus, targetCount);
                     goalManager.AddGoals(checkListGoal);
                     break;
                  }
               }
               break;
            }

            case ConsoleKey.D2:
            {
               Console.Clear();
               Console.WriteLine();
               if (goalManager.LenOfGoalList() == 0)
               {
                  Console.WriteLine();
                  Console.WriteLine("There are no goals to List. Please add goals.");
                  break;
               }
               goalManager.DisplayGoal();
               break;
            }

            case ConsoleKey.D3:
            {
               Console.Clear();
               
               if (goalManager.LenOfGoalList() == 0)
               {
                  Console.WriteLine();
                  Console.WriteLine("There are no goals to save. Please add goals first.");
                  break;
               }
               
               Console.WriteLine();
               Console.Write("Do you want to save to the default location? Enter y / n ");
               keyInfo = Console.ReadKey();

               while (keyInfo.KeyChar != 'n' && keyInfo.KeyChar != 'y')
               {
                  Console.Clear();
                  Console.WriteLine();
                  Console.Write("Invalid input. Enter 'n' or 'y' to continue ");
                  keyInfo = Console.ReadKey();
               }

               if (keyInfo.KeyChar == 'n')
               {
                  Console.WriteLine();
                  Console.Write("Enter the name of the file you want to save to: ");
                  string filePath = Console.ReadLine();
                  goalManager.SaveGoalToFile(filePath);
                  break;
               }
               goalManager.SaveGoalToFile();
               break;
            }

            case ConsoleKey.D4:
            {
               Console.Clear();
               Console.WriteLine();
               Console.Write("Do you want to Load from the default location? Enter y / n ");
               keyInfo = Console.ReadKey();

               while (keyInfo.KeyChar != 'n' && keyInfo.KeyChar != 'y')
               {
                  Console.WriteLine();
                  Console.Write("Invalid input. Enter 'n' or 'y' to continue");
                  keyInfo = Console.ReadKey();
               }

               if (keyInfo.KeyChar == 'n')
               {
                  Console.WriteLine();
                  Console.Write("Enter the name of the file you want to load from: ");
                  string filePath = Console.ReadLine();
                  goalManager.LoadGoalFromFile(filePath);
                  break;
               }
               
               goalManager.LoadGoalFromFile();
               
               if (goalManager.LenOfGoalList() == 0)
               {
                  Console.WriteLine();
                  Console.WriteLine("There are no goals in the file.");
               }
               break;
            }

            case ConsoleKey.D5:
            {
               Console.Clear();
               Console.WriteLine();
               if (goalManager.LenOfGoalList() == 0)
               {
                  Console.WriteLine();
                  Console.WriteLine("There are no goals to check in. Please add goals first.");
                  break;
               }
               
               Console.Write("The incomplete goals are ");
               Console.WriteLine();
               
               goalManager.DisplayIncompleteGoals();
               
               Console.Write("Which goal did you accomplish?\n ");
               string goalIndexStr = Console.ReadLine();
               int goalIndex;

               while (!int.TryParse(goalIndexStr, out goalIndex) || goalIndex <= 0 || goalIndex > goalManager.LenOfGoalList())
               {
                  Console.Clear();
                  Console.WriteLine("Invalid input. Enter a valid goal index to continue");
                  Console.WriteLine();
                  goalManager.DisplayGoal();
                  goalIndexStr = Console.ReadLine();
               }

               Goal goalToRecord = goalManager.GoalToRecord(goalIndex);
               
               if (goalToRecord.IsComplete() && goalToRecord is not EternalGoal)
               {
                  Console.WriteLine("Sorry, this goal has been completed, and can not award any more points.");
               }

               else
               {
                  goalManager.RecordGoalEvent(goalIndex);
                  goalToRecord.RecordEventMsg();
                  Console.WriteLine($"You now have {goalManager.UserScore()} points.");
               }
               break;
            }

            case ConsoleKey.D6:
            {
               Console.Clear();
               Console.WriteLine();
               
               if (goalManager.LenOfGoalList() == 0)
               {
                  Console.WriteLine();
                  Console.WriteLine("There are no goals to remove from. Please add or load goals first.");
                  break;
               }

               Console.Write("What which goal do you want to remove? ");

               Console.WriteLine();
               goalManager.DisplayGoal();

               string goalIndexStr = Console.ReadLine();
               int goalIndex;

               while (!int.TryParse(goalIndexStr, out goalIndex) || (goalIndex <= 0 || goalIndex > goalManager.LenOfGoalList()))
               {
                  Console.Clear();
                  Console.WriteLine("Invalid input. Enter a valid goal index to continue");
                  goalManager.DisplayGoal();
                  goalIndexStr = Console.ReadLine();
               }
               
               Console.Clear();
               goalManager.RemoveGoal(goalIndex);
               Console.WriteLine();
               Console.WriteLine("Goals left: ");
               goalManager.DisplayGoal();
               break;
            }
            
            case ConsoleKey.D7:
            {
               Console.Clear();
               Console.WriteLine("\nThank you for using the Eternal Quest Program. See you soon!");
               endProgram = true;
               break;
            }
         }
      }
   }
}