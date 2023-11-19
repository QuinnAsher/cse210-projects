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


    public void RecordGoalEvent(int goalIndex)
    {
        GoalToRecord(goalIndex).RecordEvent();
    }
    
    public Goal GoalToRecord(int goalIndex)
    {
        // This method retrieves the goal at the specified index for checking in.
        // The returned goal will be used to determine if it has already been completed,
        // preventing the check-in of goals that are already marked as complete.

        // Adjusting the index to match the zero-based index used in the list
        Goal goalToRecord = _goalList[goalIndex - 1];

        return goalToRecord;
    }



    public void RemoveGoal(int goalIndex)
    {
        Goal removedGoal = _goalList[goalIndex - 1];
        _goalList.Remove(removedGoal);

        if (removedGoal is SimpleGoal)
        {
            Console.WriteLine($"You have successfully removed a Simple Goal: '{removedGoal.GetGoalName()}'");
        }

        else if (removedGoal is CheckListGoal)
        {
            Console.WriteLine($"You have successfully removed a Checklist Goal: '{removedGoal.GetGoalName()}'");
        }

        else if (removedGoal is EternalGoal)
        {
            Console.WriteLine($"You have successfully removed an Eternal Goal: '{removedGoal.GetGoalName()}'");
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
            
            // Instead of creating a new list to store goals when loading from a file,
            // I utilize the existing '_goalList'. This decision is driven by the desire to maintain a
            // single source of data for goals, avoiding the complexity of managing multiple lists.


            // Note: When the load method is called, '_goalList' is initially empty, preventing duplicate goals.
            // However, in a scenario where the same file is loaded more than once in a session,
            // duplicate goals could arise. The implementation has been updated to address this issue,
            // ensuring that duplicate goals are now appropriately handled.
            Goal goal = CreateGoal(goalType, goalInfo);

            // Check if a goal with the same UniqueId already exists
            if (!IsContainGoal(goal))
            {
                _goalList.Add(goal);
            }
        }
    }
    
    
    
    private bool IsContainGoal(Goal goal)
    {
        // This method checks if a goal object with the same UniqueId already exists in the '_goalList'.
        // This is important when loading goals from a file to avoid adding duplicates.
        // It ensures that only unique goals objects are included in the list.
        foreach (Goal g in _goalList)
        {
            if(g.UniqueId == goal.UniqueId)
            {
                // Console.WriteLine($"for GUID debugging: {g.UniqueId}");
                return true;
            }
        }
        return false;
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
                string uniqueId = parts[4];
                
                Goal simpleGoal = new SimpleGoal(name, description, point);
                
                // set the unique Id
                simpleGoal.UniqueId = uniqueId;
                
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
                int currentCount = int.Parse(parts[4]);
                int targetCount = int.Parse(parts[5]);
                string uniqueId = parts[6];

                Goal checkListGoal = new CheckListGoal(name, description, point, bonus, targetCount);
                checkListGoal.UniqueId = uniqueId;
                
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
                string uniqueId = parts[4];

                Goal eternalGoal = new EternalGoal(name, description, point);
                eternalGoal.UniqueId = uniqueId;
                
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
