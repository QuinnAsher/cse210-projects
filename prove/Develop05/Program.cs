namespace Develop05;

class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.RunProgram();
        
        // The commented out code is for debugging and testing
        // Goal checkListGoal = new CheckListGoal("Visit the Temple", "I want to visit the temple 3 times this year", 20,
        //     1000, 3);
        //
        // checkListGoal.RecordEvent();
        // checkListGoal.RecordEvent();
        // checkListGoal.RecordEvent();
        // checkListGoal.RecordEvent();
        // checkListGoal.RecordEvent();
        //
        // GoalManager goalManager = new GoalManager();
        // goalManager.AddGoals(checkListGoal);
        // Console.WriteLine(goalManager.UserScore());
        // goalManager.DisplayGoal();

    }
}