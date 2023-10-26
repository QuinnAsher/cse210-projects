namespace Develop03;


public class Scripture
{
    private string _scriptureText;
    private List<string> _scriptureWordsList;
    public List<Word> _wordsLIst;
    private Reference _reference;
    
    
    //class constructors
    public Scripture()
    {
        _reference = new Reference();  // default reference
        _scriptureText =  "For God so loved the world, that he gave his only begotten Son, " +
                      "that whosoever believeth in him should not perish, but have everlasting life.";
        
        // convert scripture text to a list of words
        _scriptureWordsList = new List<string>(_scriptureText.Split().ToList());
        _wordsLIst = new List<Word>();
        AddScriptureWords();  // adds all scripture text words to a list of Word objects
    }

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        _scriptureText = scriptureText;
        
        // convert scripture text to a list of words
        _scriptureWordsList = new List<string>(scriptureText.Split().ToList());
        _wordsLIst = new List<Word>();
        AddScriptureWords();  // adds all scripture text words to a list of Word objects
    }

    private void AddWord(string word)
    {
        // This method adds a new word object to the Word list
        Word newWord = new Word(word);
        _wordsLIst.Add(newWord);
    }

    private void AddScriptureWords()
    {
        // This method adds all the words from the _scriptureWordsList to the _wordsList
        foreach (string word in _scriptureWordsList)
        {
            AddWord(word);
        }
    }

    private int RandomIndex()
    {
        Random random = new Random();
        int randomIndex = random.Next(_wordsLIst.Count);
        return randomIndex;
    }
    
    
    public void HideWords()
    {
        Word word = _wordsLIst[RandomIndex()];
        
        // check visibility of the word
        bool isHidden = word.GetVisibility;
        if (!isHidden) // word is not hidden
        {
            word.WordPropery = new string('_', word.WordPropery.Length);
            word.Hide();  // isHidden is now true
        }

    }
    
    public string GetRenderedText()
    {
        string renderedText = $"{_reference.FormatReference()} {_scriptureText}";
        return renderedText;
    }

    public void Debugging()
    {
        foreach (Word word in _wordsLIst)
        {
            Console.WriteLine(word);
        }
    }
}