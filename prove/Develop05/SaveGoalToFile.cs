namespace Develop05;

public class SaveGoalToFile
{
    private string _filePath;
    private List<Goal> _goalList;


    public  SaveGoalToFile(GoalList goalList, string filePath="goal")
    {
        _goalList = new List<Goal>();
        _goalList = goalList.GetGoalList();
        
        if (Path.HasExtension(filePath) && Path.GetExtension(filePath) != ".txt"  || !Path.HasExtension(filePath))
        {
            _filePath = Path.ChangeExtension(filePath, ".txt");
        }
        
        else
        {
            _filePath = filePath;
        }
    }


    public void SaveToFile()
    {
        StreamWriter writer = new StreamWriter(_filePath);
        using (writer)
        {
            
            foreach (Goal goal in _goalList)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    
}