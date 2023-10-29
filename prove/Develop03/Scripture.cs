namespace Develop03;


public class Scripture
{
    private string _scriptureText;
    private List<string> _scriptureWordsList;
    private List<Word> _wordsLIst;
    private Reference _reference;
    private bool _useDefault;
    private ScriptureLibraryLoader _libraryLoader;
    Random random = new Random();
    List<int> assignedIndex = new List<int>();
    
    
    // class constructors
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


     public Scripture(bool useDefault)
     {
         _libraryLoader = new ScriptureLibraryLoader();
         _libraryLoader.LoadScripture();
         Tuple<Reference, string> referenceAndText = _libraryLoader.GetReferenceAndScriptureText();

            
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

        if (assignedIndex.Count == _wordsLIst.Count)
        {
            assignedIndex.Clear(); // Clear the list if all words have been assigned
        }

        do
        {
            randomIndex = random.Next(_wordsLIst.Count);
        } while (assignedIndex.Contains(randomIndex));

        assignedIndex.Add(randomIndex);
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
    
    // public void Debugging()
    // {
    //         Console.WriteLine(RenderedText());
    // }
}