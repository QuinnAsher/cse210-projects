namespace Develop05;

public class CheckListGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;
    
    
    public CheckListGoal(string name, string description, int point, int bonus, int targetCount) : base(name, description, point)
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
        if (!IsComplete())
        {
            BasePoint += GoalPoint;
            _currentCount++;
        }
        

        if (IsComplete() && BasePoint < _bonus || BasePoint > _bonus) 
        {
            // Ensure that the bonus is added only when the goal is complete (IsComplete() == true)
            // and the BasePoint is below the specified bonus value (_bonus).
            // This prevents additional bonus points from being added when the goal is already completed.
            BasePoint += _bonus;
            
            // The '_bonus' is synchronized with 'BasePoint' to ensure the correctness of the following logic:
            // When checking if 'BasePoint' is greater than '_bonus', this update guarantees that the condition becomes false,
            // preventing adding '_bonus' when the Goal has been completed.
            _bonus = BasePoint;

        }
        
        return BasePoint;
    }
  
    public override string GoalInfo()
    {
        if(IsComplete()) return $"[X] {GoalName} ({GoalDescription})";

        return $"[ ] {GoalName} ({GoalDescription}) --- Currently " +
               $"Completed: {_currentCount}/{_targetCount}";

    }

    public override string GetStringRepresentation()
    {
        return $"CheckListGoal:{GoalName}|{GoalDescription}|{GoalPoint}|{_bonus}|{_currentCount}|{_targetCount}|{_uniqueId}";
    }
}