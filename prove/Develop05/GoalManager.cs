namespace Develop05;

public class GoalManager
{
    private List<Goal> _goalList = new ();
    
    
    public List<Goal> GetGoalList()
    {
        return _goalList;
    }
    
    public void AddGoals(Goal goal)
    {
        // This method takes an instantiated goal object as a parameter
        // and adds it to the list of goals
        _goalList.Add(goal);
    }

    public void DisplayGoal()
    {
        foreach (Goal goal in _goalList)
        {
            Console.WriteLine(goal.GoalInfo());
        }
    }

    private int UserScore()
    {
        int score = 0;
        foreach (Goal goal in _goalList)
        {
           score += goal.GetUserScore();
        }

        return score;
    }

    public void SaveGoalToFile(string filePath="goal")
    {
        if (Path.HasExtension(filePath) && Path.GetExtension(filePath) != ".txt"  || !Path.HasExtension(filePath))
        {
            filePath = Path.ChangeExtension(filePath, ".txt");
        }

        StreamWriter writer = new StreamWriter(filePath);
        using (writer)
        {
            writer.WriteLine(UserScore());
            foreach (Goal goal in _goalList)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }


    public void LoadGoalFromFile(string filePath="goal")
    {
        if (Path.HasExtension(filePath) && Path.GetExtension(filePath) != ".txt" || !Path.HasExtension(filePath))
        {
            filePath = Path.ChangeExtension(filePath, ".txt");
        }

        string[] lines = File.ReadAllLines(filePath);


        string part = lines[0];
        int points = int.Parse(part);
        
        
        Console.WriteLine(points);
        
        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(":");
            string goalType = parts[0];
            string goalInfo = parts[1];
            
            // because when the load method will be called, the _goalList will be empty
            // so there will be no duplicate goals arising from appending goals objects
            Goal goal = CreateGoal(goalType, goalInfo);
            _goalList.Add(goal);

        }
    }

    
    private Goal CreateGoal(string goalType, string goalInfo)
    {
        switch (goalType)
        {
            case "SimpleGoal":
            {
                string[] parts = goalInfo.Split("|");

                string name = parts[0];
                string description = parts[1];
                int point = int.Parse(parts[2]);
                bool isCompleted = bool.Parse(parts[3]);
                Goal simpleGoal = new SimpleGoal(name, description, point);
                
                // record an event if is completed is true. This will automatically
                // give add the point
                if (isCompleted)
                {
                    simpleGoal.RecordEvent();
                }
                
                return simpleGoal;
            }

            case "CheckListGoal":
            {
                string[] parts = goalInfo.Split("|");
            
                string name = parts[0];
                string description = parts[1];
                int point = int.Parse(parts[2]);
                int bonus = int.Parse(parts[3]);
                int targetCount = int.Parse(parts[4]);
                int currentCount = int.Parse(parts[5]);

                Goal checkListGoal = new CheckListGoal(name, description, point, bonus, targetCount);

                for (int i = 0; i < currentCount; ++i)
                {
                    checkListGoal.RecordEvent();
                }
                
                return checkListGoal;
            }

            case "EternalGoal":
            {
                string[] parts = goalInfo.Split("|");

                string name = parts[0];
                string description = parts[1];
                int point = int.Parse(parts[2]);

                return new EternalGoal(name, description, point);
            }
            
            default:
                return null;
        }
    }
}
