namespace Develop05;

class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.RunProgram();

        Goal simpleGoal = new SimpleGoal("Sacrament Talk", "Give a sacrament talk when asked", 100);
        Goal eternalGoal = new EternalGoal("Study Scriptures", "Study the scriptures daily", 100);
        Goal checkListGoal = new CheckListGoal("Visit the Temple", "Visit the temple 3 times", 100, 500, 3);

        GoalManager goalManager = new GoalManager();
        //
        // // goalManager.AddGoals(simpleGoal);
        // // goalManager.AddGoals(eternalGoal);
        // // goalManager.AddGoals(checkListGoal);
        //
        // goalManager.DisplayGoal();
        // // goalManager.SaveGoalToFile("unique");
        // // goalManager.LoadGoalFromFile("unique");
        // goalManager.LoadGoalFromFile("unique");
        goalManager.DisplayGoal();

    }
}