namespace Develop02;

// a class for generating an entry
public class Entry
{
    public string _prompt;
    public string _userInput;
    public DateTime _dateStamp;

    public Entry(string prompt, string userInput)
    {
        _prompt = prompt;
        _userInput = userInput;
        _dateStamp = DateTime.Now;
    }

    public string FormattedEntry()
    {
        return $"Date: {_dateStamp} - {_prompt}\n{_userInput}";
    }
}
