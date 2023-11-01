namespace Develop03;


public class Scripture
{
    private string _scriptureText;
    private List<string> _scriptureWordsList;
    private List<Word> _wordsLIst;
    private Reference _reference;
    // private bool _useDefault;
    // learnt something about readonly. The fields below don't require modifications
    readonly Random _random = new Random();
    readonly List<int> _assignedIndex = new List<int>();
    
     public Scripture()
     {
        ScriptureLibraryLoader libraryLoader = new ScriptureLibraryLoader();
         libraryLoader.LoadScripture();
         Tuple<Reference, string> referenceAndText = libraryLoader.GetReferenceAndScriptureText();

            
         if (referenceAndText != null)
         {
             _reference = referenceAndText.Item1;
             _scriptureText = referenceAndText.Item2;
             
             _scriptureWordsList = new List<string>(_scriptureText.Split().ToList());
         }
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


    public int LengthOfWordList
    {
        get
        {
            return _wordsLIst.Count;
        }
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
        int randomIndex;

        if (_assignedIndex.Count == _wordsLIst.Count)
        {
            _assignedIndex.Clear(); // Clear the list if all words have been assigned
        }

        do
        {
            randomIndex = _random.Next(_wordsLIst.Count);
        } while (_assignedIndex.Contains(randomIndex));

        _assignedIndex.Add(randomIndex);
        return randomIndex;
    }
    
    
    public void HideWord()
    {
        int index = RandomIndex();
    
        if (index >= 0 && index < _wordsLIst.Count)
        {
            Word word = _wordsLIst[index];
        
            // check visibility of the word
            bool isHidden = word.GetVisibility;
            if (!isHidden) // word is not hidden
            {
                word.WordPropery = new string('_', word.WordPropery.Length);
                word.Hide();  // isHidden is now true
            }
        }
    }

    
    // TODO: create a ShowWord() method for better interactivity
    
    private string WordListToSentence()
    {
        string toSentence = "";
        foreach (Word word in _wordsLIst)
        {
            toSentence += word.WordPropery;
            toSentence += " ";  // concatenate a space after each word
        }
        return toSentence;
    }

    public string RenderedText()
    {
        string text = $"{_reference.FormatReference()} {WordListToSentence()}";
        return text;
    }
}