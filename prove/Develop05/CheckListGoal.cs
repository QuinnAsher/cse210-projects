namespace Develop05;

public class CheckListGoal : Goal
{
    private int _currentCount;  //
    private int _targetCount;
    private int _bonus;
    
    
    public CheckListGoal(string name, string description, int point, int targetCount, int bonus) : base(name, description)
    {
        GoalName = name;
        GoalDescription = description;
        GoalPoint = point;
        _bonus = bonus;
        _currentCount = 0;
        _targetCount = targetCount;
    }


    public override bool IsComplete()
    {
        // when the target count is equal to the current count the 
        // activity is completed
        return _currentCount == _targetCount;
    }

    public override int RecordEvent()
    {
        BasePoint += GoalPoint;
        _currentCount++;

        if (_currentCount == _targetCount)
        {
            BasePoint += _bonus;
        }

        return BasePoint;
    }
}