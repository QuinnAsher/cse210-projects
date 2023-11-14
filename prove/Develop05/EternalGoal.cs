namespace Develop05;

public class EternalGoal : Goal
{
    private int _point;


    public EternalGoal(string name, string description, int point) : base(name, description)
    {
        GoalName = name;
        GoalDescription = description;
        _point = point;
    }


    public override bool IsComplete()
    {
        return false;  // Eternal goals can never be completed
    }


    public override int RecordEvent()
    {
        BasePoint += _point;
        return BasePoint;
    }
}