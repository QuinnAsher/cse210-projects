namespace Develop05;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int point) : base(name, description, point)
    {
        GoalName = name;
        GoalDescription = description;
        GoalPoint = point;
    }

    
    public override bool IsComplete()
    {
        return false;  // Eternal goals can never be completed
    }
    
    public override int RecordEvent()
    {
        BasePoint += GoalPoint;
        return BasePoint;
    }
    public override string GoalInfo()
    {
        return $"[ ] {GoalName} ({GoalDescription})";
    }
    
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GoalName}|{GoalDescription}|{BasePoint}";
    }
}