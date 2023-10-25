namespace Develop03;

public class Word
{
    private string _scriptureText;
    public List<string> _wordList;

    public Word()
    {
        _scriptureText = "For God so loved the world, that he gave his only begotten Son," +
                         "that whosoever believeth in him should not perish, but have everlasting life.";
        _wordList = _scriptureText.Split().ToList();  // creates an array of substrings seperated by a comma
        
    }

    public Word(string scriptureText)
    {
        _scriptureText = scriptureText;
        _wordList = _scriptureText.Split().ToList();  // creates an array of substrings seperated by a comma

    }

    private int RandomIndex()
    {
        // This function generates a unique random index
        List<int> assignedIndex = new List<int>();
        Random random = new Random();
        int wordLength = _wordList.Count;
        int randomIndex = random.Next(wordLength);
        // return randomIndex;

        while (assignedIndex.Contains(randomIndex))
        {
            randomIndex = random.Next(wordLength);

            if (assignedIndex.Count == wordLength)
            {
                assignedIndex = new List<int>();
            }
        }
        
        if (assignedIndex.Count == wordLength)
        {
            assignedIndex = new List<int>();
        }

        return randomIndex;

    }

    public string GetWord()
    {
        string givenWord = _wordList[RandomIndex()];
        return givenWord;
    }  
}