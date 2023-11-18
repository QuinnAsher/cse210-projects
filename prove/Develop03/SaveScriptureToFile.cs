namespace Develop03;

public class SaveScriptureToFile
{
    private string _filePath;
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private string _scriptureText;
    private bool _fileExit;
    
   
   public SaveScriptureToFile(string book, int chapter, int startVerse, int endVerse, string scriptureText ,string filePath="scriptureData.csv")
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

   
   
    
    public void WriteToFile()
    {
        StreamWriter writer = new StreamWriter(_filePath, true);
        if (_fileExit)  // file exits so just append to the file
        {
            // a | is used as separator for the csv because the scripture text haas space and commas
            // so I have to use something that will not affect the code later
            using (writer)
            {
                writer.WriteLine($"{_book}|{_chapter}|{_endVerse}|{_endVerse}|{_scriptureText}");
            }
        }

        else
        {
            using (writer)
            {
                writer.WriteLine("Book|Chapter|Start Verse|End Verse;Scripture");
                writer.WriteLine($"{_book}|{_chapter}|{_endVerse}|{_endVerse}|{_scriptureText}");
            }
        }
    }
}

// TODO: create a separate class for handing Loading because of too much fields
