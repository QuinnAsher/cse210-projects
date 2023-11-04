namespace Learning04;

public class MathAssignment : Assignmnent
{
    private string _textbookSection { set; get; }
    private string _problems { set; get; }


    public MathAssignment(string studentName, string topic,
        string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }


    public string GetHomeworkList()
    {
        string homeworkList = $"Section {_textbookSection} Problems {_problems}";
        return homeworkList;
    }
}