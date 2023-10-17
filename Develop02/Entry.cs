namespace Develop02;

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
    
    // a method that formats the entry and returns a string
    public string FormattedEntry()
    {
         return $"Date: {_dateStamp} - {_prompt}\n{_userInput}";
    }
}
