using System.Security.Cryptography.X509Certificates;

namespace Develop05;

public class GoalManager
{
    private List<Goal> _goalList = new ();
    
    
    public int LenOfGoalList()
    {
        return _goalList.Count;
    }
    
    public void AddGoals(Goal goal)
    {
        // This method takes an instantiated goal object as a parameter
        // and adds it to the list of goals
        _goalList.Add(goal);
    }

    public void DisplayGoal()
    {
        for (int i = 0; i < _goalList.Count; i++)
        {
            Goal goal = _goalList[i];
            Console.WriteLine($"{i + 1}. {goal.GoalInfo()}");
        }
    }

    public void DisplayIncompleteGoals()
    {
        /// <summary>
        /// Selectively displays goals that are not yet completed, ensuring that users
        /// are presented with only ongoing goals. By excluding completed goals from the display,
        /// prevents users from checking in completed goals. While users can view
        /// their progress on completed goals, no additional points are awarded for re-recording them.
        /// </summary>

        for (int i = 0; i < _goalList.Count; i++)
        {
            Goal goal = _goalList[i];
            if ((goal is SimpleGoal || goal is CheckListGoal) && !goal.IsComplete() || goal is EternalGoal)
            {
                Console.WriteLine($"    {i + 1}. {goal.GetGoalName()}");
            }
        }
        //TODO; make sure that a goal can not be checked after completion
    }
    public int UserScore()
    {
        int score = 0;
        foreach (Goal goal in _goalList)
        {
           score += goal.GetUserScore();
        }

        return score;
    }


    public void InvokeGoalEvent(int goalIndex)
    {
        GoalToRecord(goalIndex).RecordEvent();
    }

    public Goal GoalToRecord(int goalIndex)
    {
        Goal goalToRecord = _goalList[goalIndex - 1];
        return goalToRecord;
    }


    public void RemoveGoal(int goalIndex)
    {
        _goalList.RemoveAt(goalIndex - 1);
    }

    public void RemoveGoalMsg(int goalIndex)
    {
        Goal removedGoal = _goalList[goalIndex - 1];
        ;
        if (removedGoal is SimpleGoal)
        {
            Console.WriteLine($"You have successfully removed a Simple Goal: {removedGoal.GetGoalName()}");
        }
        
        else if (removedGoal is CheckListGoal)
        {
            Console.WriteLine($"You have successfully removed a Checklist Goal: {removedGoal.GetGoalName()}");
        }
        
        else if(removedGoal is EternalGoal)
        {
            Console.WriteLine($"You have successfully removed an Eternal Goal: {removedGoal.GetGoalName()}");
        }
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
            // writer.WriteLine(UserScore());
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
        
        
        // string part = lines[0];
        // int points = int.Parse(part);
        //
        // The points obtained from 'part = lines[0]' can alternatively be obtained using 
        // the 'userScore' method when loading Goal objects. Currently, this line is commented out 
        // as I explore a more efficient approach. However, using 'userScore' is only effective when 
        // the '_goalList' has been populated.
        
        // Console.WriteLine(points);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            string goalType = parts[0];
            string goalInfo = parts[1];
            
            // we can use the _goalList to store the loaded objects because when the load
            //method will be called, the _goalList will be empty so there will be no
            //duplicate goals arising from appending goals objects, except if a user load the same file more
            // than once in a session. //TODO: find a better way to solve the problem if the user loads a file more than once.
            // a solution is to create a new goalList, but this will mean that I'll have to manage two goalList
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
                
                // record an event if isCompleted is true. This will automatically
                // add the corresponding point
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
                int targetCount = int.Parse(parts[5]);
                int currentCount = int.Parse(parts[4]);

                Goal checkListGoal = new CheckListGoal(name, description, point, bonus, targetCount);
                for (int i = 0; i < currentCount; i++)
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
                int basePoint = int.Parse(parts[3]);

                Goal eternalGoal = new EternalGoal(name, description, point);
                
                for (int i = 0; i < basePoint / point; i++)
                {
                    // For Eternal goals, which are never marked as completed, 
                    //  simulate recording events to retrieve the saved score.
                    // The number of events recorded is determined by dividing the accumulated 
                    // points (basePoint) by the points obtained in each individual event.
                    
                    eternalGoal.RecordEvent();
                }

                return eternalGoal;
            }
            
            default:
                return null;
        }
    }
}
