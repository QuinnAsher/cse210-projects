namespace Learning04;

public class WritingAssignment : Assignmnent
{
    private string _title { set; get; }

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }


    public string GEtWritingInformation()
    {
        string studentName = GetName();
        string writingInformation = $"{_title} by {studentName}";
        return writingInformation;
    }
}
