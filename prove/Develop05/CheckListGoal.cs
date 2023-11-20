namespace Develop05;

public class CheckListGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;
    private int _count;
    
    
    public CheckListGoal(string name, string description, int point, int bonus, int targetCount) : base(name, description, point)
    {
        GoalName = name;
        GoalDescription = description;
        GoalPoint = point;
        _bonus = bonus;
        _currentCount = 0;
        _targetCount = targetCount;
        _count = 0;
    }
    
    public override bool IsComplete()
    {
        // when the target count is equal to the current count the 
        // activity is completed
        return _currentCount == _targetCount;
    }

    private int IsCompleteCount()
    {
        if (IsComplete())
        {
            // Increment the count when IsComplete() is true.
            // Note: The positioning of the ++ operator affects when the increment takes place.
            // If placed before the variable (_count++), it increments before returning the value,
            // while if placed after the variable (_count), it increments after returning the current value.
            // TODO: Investigate and document why the position of the ++ operator affects the behavior of IsCompleteCount().
            return ++_count;
        }

        // Return the current count when IsComplete() is false.
        return _count;
    }


    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            BasePoint += GoalPoint;
            _currentCount++;
        }
        

        // if (IsComplete() && BasePoint < _bonus || IsComplete() && BasePoint > _bonus) 
        // {
        //     // Ensure that the bonus is added only when the goal is complete (IsComplete() == true)
        //     // and the BasePoint is below the specified bonus value (_bonus).
        //     // This prevents additional bonus points from being added when the goal is already completed.
        //     BasePoint += _bonus;
        //     // Console.WriteLine($"Total Point is: {BasePoint}");
        //     
        //     // The '_bonus' is synchronized with 'BasePoint' to ensure the correctness of the following logic:
        //     // When checking if 'BasePoint' is greater than '_bonus', this update guarantees that the condition becomes false,
        //     // preventing adding '_bonus' when the Goal has been completed.
        //     _bonus = BasePoint;
        //
        // }

        if (IsCompleteCount() == 1)
        {
            // The condition commented out was not calculating the bonus when the bonus is equal to the
            // potential accumulated points when the goal is completed. To address this, a helper
            // method, IsCompleteCount(), was introduced to keep track of how many times IsComplete() is true.
            // When IsComplete() is true for the first time, the count is 1, ensuring that the bonus is added only once.
            BasePoint += _bonus;
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