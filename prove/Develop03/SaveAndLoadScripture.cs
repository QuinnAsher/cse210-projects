namespace Develop03;

public class SaveAndLoadScripture
{
    private string _filePath;
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private string _scriptureText;
    private bool _fileExit;
    private Reference _reference;
    // private ScriptureLibrary _scriptureLibrary;

    
   public SaveAndLoadScripture()
   {
       _filePath = "scriptureData";
        _book = "John";
        _chapter = 3;
        _startVerse = 16;
        _endVerse = 0;
        _scriptureText =
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life.";
        
        // check for valid extension
        if (Path.HasExtension(_filePath) && Path.GetExtension(_filePath) != ".csv" || !Path.HasExtension(_filePath))
        {
            _filePath = Path.ChangeExtension(_filePath, ".csv");
        }
        
        _fileExit = File.Exists(_filePath);  // checks whether a file exit

   }
   
   
   public SaveAndLoadScripture(string filePath, string book, int chapter, int startVerse, int endVerse, string scriptureText)
   {
        
       _book = book;
       _chapter = chapter;
       _startVerse = startVerse;
       _endVerse = endVerse;
       _scriptureText = scriptureText;
        
       // check for valid extension
       if (Path.HasExtension(filePath) && Path.GetExtension(filePath) != ".csv" || !Path.HasExtension(filePath))
       {
           filePath = Path.ChangeExtension(filePath, ".csv");
       }
       _filePath = filePath;
       
       _fileExit = File.Exists(_filePath);  // checks whether a file exit
   }

   
   // class getters and setters  // for reminder, if this does not return the word from the file move it down
   public string BookProperty
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

   public int EndVerseProperty
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

   public string ScriptureTextProperty
   {
       get
       {
           return _scriptureText;
       }

       set
       {
           _scriptureText = value;
       }
   }
   
    
    public void WriteToFile()
    {
        StreamWriter writer = new StreamWriter(_filePath, true);
        if (_fileExit)  // file exits so just append to the file
        {
            // a colon is used as separator for the csv because the scripture text haas space and commas
            // so I have to use something that will not affect the code later
            using (writer)
            {
                writer.WriteLine($"{_book};{_chapter};{_endVerse};{_endVerse};{_scriptureText}");
            }
        }

        else
        {
            using (writer)
            {
                writer.WriteLine("Book,Chapter,Start Verse,End Verse,Scripture");
                writer.WriteLine($"{_book};{_chapter};{_endVerse};{_endVerse};{_scriptureText}");
            }
        }
    }

    public void LoadFromFile()
    {
        string[] lines = File.ReadAllLines(_filePath);

        // Reminder: in each loop, a reference and scripture will be added to the Scripture Library
        foreach (string line in lines.Skip(1))  // skips the first line which is the header of the csv
        {
            string[] parts = line.Split(";");
            _book = parts[0];
            _chapter = int.Parse(parts[1]);
            _startVerse = int.Parse(parts[2]);
            _endVerse= int.Parse(parts[3]);
            _scriptureText = parts[4];
            
            Reference reference = new Reference(_book, _chapter, _startVerse, _endVerse);
            Scripture scripture = new Scripture(reference, _scriptureText);
            
            // TODO: come back to this later and implement the scripture library tag
            // Initialize a scripture object
            // ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
            // Adds all the scriptures in from the ScriptureData csv to the scripture library list
            // scriptureLibrary.AddToLibraryList(reference, _scriptureText);


        }
    }
}

// TODO: create a separate class for handing Loading because of too much fields