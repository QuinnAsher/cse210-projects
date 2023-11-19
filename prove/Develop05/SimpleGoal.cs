using System.Xml;

namespace Develop05;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int point) : base(name, description, point)
    {
        GoalName = name;
        GoalDescription = description;
        GoalPoint = point;
    }



    public override bool IsComplete()
    {
        return BasePoint == GoalPoint;  // isCompleted should return true when a point has been earned
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            BasePoint += GoalPoint;
        }

        return BasePoint;
    }

    public override string GoalInfo()
    {
        if(IsComplete()) return $"[X] {GoalName} ({GoalDescription})";

        return $"[ ] {GoalName} ({GoalDescription})";
    }
    
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GoalName}|{GoalDescription}|{GoalPoint}|{IsComplete()}|{_uniqueId}";
    }
}