namespace Develop05;

class Program
{
    static void Main(string[] args)
    {
        Goal simpleGoal = new SimpleGoal("Sacrament talk", "give a take when ask", 100);
        int point = simpleGoal.RecordEvent();
        // Console.WriteLine(simpleGoal.IsComplete());
        // Console.WriteLine(point);
        // Console.WriteLine(simpleGoal.GoalInfo());
        //
        Goal eternalGoal = new EternalGoal("Study scriptures", "Study the scriptures for at least 10 minutes", 50);
        int eternalPoint = eternalGoal.RecordEvent();
        // Console.WriteLine(eternalGoal.IsComplete());
        // Console.WriteLine(eternalPoint);
        // Console.WriteLine(eternalGoal.FormattedGoalInformation());
        //
        Goal checkListGoal = new CheckListGoal("Temple visiting", "Visit the temple 3 times", 50, 500, 3);
        checkListGoal.RecordEvent();
        // checkListGoal.RecordEvent();
        // // checkListGoal.RecordEvent();
        GoalManager goalManager = new GoalManager();
        
        
        goalManager.AddGoals(simpleGoal);
        goalManager.AddGoals(eternalGoal);
        goalManager.AddGoals(checkListGoal);
        goalManager.SaveGoalToFile();
        goalManager.LoadGoalFromFile();
        goalManager.DisplayGoal();

        // goalList.SaveGoalToFile();
        // goalList.LoadGoalFromFile();
        // goalList.CreateGoal();
        

    }
}