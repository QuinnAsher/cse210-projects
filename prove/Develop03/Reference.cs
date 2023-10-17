namespace Develop03;

public class Reference
{
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    public Reference()
    {
        _book = "John";
        _chapter = "3";
        _startVerse= "16";
        _endVerse = "20";
    }

    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }

    public string SingleReference()
    {
        string formattedReference = $"{_book} {_chapter}:{_startVerse}";
        return formattedReference;
    }

    public string MultipleReference()
    {
        string formattedReference = $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        return formattedReference;
    }
}

