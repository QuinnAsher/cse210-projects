namespace Develop03;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;


    // Class Constructors
    public Reference()  // default intance
    {
        _book = "John";
        _chapter = 3;
        _startVerse = 16;
        _endVerse = 0;
    }
    
    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }
    
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    
    // Class getters and setters
    public string BookPropery
    {
        get
        {
            return _book;
        }

        set
        {
            _book = value;
        }
    }


    public int ChapterProperty
    {
        get
        {
            return _chapter;
        }

        set
        {
            _chapter = value;
        }
    }

    public int StartVerseProperty
    {
        get
        {
            return _startVerse;
        }

        set
        {
            _startVerse = value;
        }
    }

    public int EndVersePropery
    {
        get
        {
            return _endVerse;
        }

        set
        {
            _endVerse = value;
        }
    }
    
    
    // Class method
    public string FormatReference()
    {
        string formattedReference;
        if (_endVerse > 0)
        {
            formattedReference = $"{_book} {_chapter} - {_startVerse}:{_endVerse}";
        }

        else
        {
            formattedReference = $"{_book} {_chapter} - {_startVerse}";
        }

        return formattedReference;
    }
}