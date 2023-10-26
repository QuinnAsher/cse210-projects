namespace Develop03;


public class Word
{
    private string _word;
    private bool _isHidden;
    
    
    // Class constructors
    public Word()  // default constructor
    {
        _word = "God";
        _isHidden = false;
    }

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }
    
    
    // class getter
    public bool GetVisibility
    {
        get
        {
            return _isHidden;
        }

        set
        {
            _isHidden = value;
        }

    }

    public string WordPropery
    {
        get
        {
            return _word;
        }

        set
        {
            _word = value;
        }
    }
    
    // class methods to make visibility false or true
    public void Show()
    {
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }
    
}
