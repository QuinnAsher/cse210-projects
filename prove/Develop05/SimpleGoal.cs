namespace Develop05;

public class SimpleGoal : Goal
{
    private int _point;
    
    public SimpleGoal(string name, string description, int point) : base(name, description)
    {
        GoalName = name;
        GoalDescription = description;
        _point = point;
    }

    public override bool IsComplete()
    {
        return BasePoint >= _point;  // isCompleted should return true when a point has been earned
    }

    public override int RecordEvent()
    {
        // This method will add a point to the based point and make 
        // the IsComplete Method return true
        BasePoint += _point;
        return BasePoint;
    }
}