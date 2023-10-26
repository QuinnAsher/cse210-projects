namespace Develop03;

public class Word
{
    private string _scriptureText;
    private List<string> _wordList;


    public Word()
    {
        _scriptureText = "For God so loved the world, that he gave his only begotten Son, " +
                         "that whosoever believeth in him should not perish, but have everlasting life.";
        _wordList = _scriptureText.Split().ToList();  // converts the scripture text to a list of words
    }

    public Word(string scriptureText)
    {
        _scriptureText = scriptureText;
        _wordList = _scriptureText.Split().ToList();  // converts the scripture text to a list of words
    }


    private int RandomIndex()
    {
        Random random = new Random();
        List<int> assignedIndex = new List<int>();  // this empty list will hold index assigned by the random object
        int wordLen = _wordList.Count;
        int randomIndex = random.Next(wordLen);
        
        // making sure that a randomIndex cannot be the same in one session
        while (assignedIndex.Contains(randomIndex))
        {
            randomIndex = random.Next(wordLen);

            // all the index has been assigned
            if (assignedIndex.Count == _wordList.Count)
            {
                assignedIndex = new List<int>();
            }
        }
        assignedIndex.Add(randomIndex);
        return randomIndex;
    }


    public string GetWord()
    {
        int index = RandomIndex();
        string randomWord = _wordList[index];
        return randomWord;
    }
    
    public bool IsHidden(string word)
    {
        return !_wordList.Contains(word);
    }
}