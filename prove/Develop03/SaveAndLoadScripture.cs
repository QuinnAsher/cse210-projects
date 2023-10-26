namespace Develop03;

public class SaveAndLoadScripture
{
    private string _filePath;
    private StreamWriter _writer;
    private StreamReader _reader;
    private bool _fileExit;
    private string _book;
    private string _chapter;
    private int _startVerse;
    private int _endVerse;
    private string _scriptureText;


   public SaveAndLoadScripture()
   {
       _filePath = "scriptureData.csv";
        _book = "John";
        _chapter = "3";
        _startVerse = 16;
        _endVerse = 0;
        _scriptureText =
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life.";

        _writer = new StreamWriter(_filePath);
        _reader = new StreamReader(_filePath);
        _fileExit = File.Exists(_filePath);
    }
   
    public SaveAndLoadScripture(string filePath, string book, string chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        // check for valid extension
        if (Path.HasExtension(filePath) && Path.GetExtension(filePath) != ".csv" || !Path.HasExtension(filePath))
        {
            filePath = Path.ChangeExtension(filePath, ".csv");
        }

        _filePath = filePath;
        _writer = new StreamWriter(_filePath);
    }

    public void WriteToFile()
    {
        // if (_fileExit)  // checks if the file exits
        // {
        //     using (_writer)
        //     {
        //         _writer.WriteLine($"{_book},{_chapter},{_startVerse},{_endVerse},\"{_scriptureText}\"");
        //     }
        // }
        
        // else
    
        _writer.WriteLine($"{_book},{_chapter},{_startVerse},{_endVerse},\"{_scriptureText}\"");
        _writer.WriteLine("Book,Chapter,Start Verse,End Verse,Scripture");
      
        
    }
}