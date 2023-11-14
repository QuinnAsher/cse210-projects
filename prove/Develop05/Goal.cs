namespace Develop05;

public abstract class Goal
{
    private string _goalName;
    private string _goalDescription;
    private int _basePoint;

    protected Goal(string name, string description)
    {
        _goalName = name;
        _goalDescription = description;
        _basePoint = 0;

    }
    

    protected string GoalName
    {
        get => _goalName;
        set => _goalName = value;
    }

    protected string GoalDescription
    {
        get => _goalDescription;
        set => _goalDescription = value;
    }

    protected int BasePoint
    {
        get => _basePoint;
        set => _basePoint = value;
    }


    // public string isCompletMsg()
    // {
    //     if (IsComplete()) return $"Congratulation you have earned {_basePoint}";
    //
    // }
    public abstract int RecordEvent();

    public abstract bool IsComplete();
}