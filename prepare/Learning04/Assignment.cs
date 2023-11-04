namespace Learning04;

public class Assignmnent
{
    private string _studentName;
    private string _topic;

    public Assignmnent(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }


    public string GetName()
    {
        return _studentName;
    }
    
    public string GetSummary()
    {
        string summary = $"{_studentName} - {_topic}";
        return summary;
    }

    
}