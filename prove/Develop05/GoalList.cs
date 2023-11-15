namespace Develop05;

public class GoalList
{
    private List<Goal> _goals = new List<Goal>();

    public void AddGoals(Goal goal)
    {
        // This method takes an instantiated goal object as a parameter
        // and adds it to the list of goals
        _goals.Add(goal);
    }

    public void DisplayGoal()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GoalInfo());
            // Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public List<Goal> GetGoalList()
    {
        return _goals;
    }
}