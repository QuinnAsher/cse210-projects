namespace Develop03;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference()
    {
        _book = "John";
        _chapter = 3;
        _startVerse = 16;
        _endVerse = 20;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
    }

    
    // Gettere and setters
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


    public int ChapterPropery
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


    public int StartVersePropery
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


    public int EndVersePropeety
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

