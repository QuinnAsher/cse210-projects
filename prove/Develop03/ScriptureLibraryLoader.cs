namespace Develop03;

public class ScriptureLibraryLoader
{
    private string _filePath;
    private string _book;
    private bool _isExit;
    private List<Dictionary<Reference, string>> _libraryList;
    private Dictionary<Reference, string> _scriptureDict;
    // private Reference _reference;

    public ScriptureLibraryLoader(string filePath="scriptureData.csv")
    {
        _libraryList = new List<Dictionary<Reference, string>>();
        _scriptureDict = new Dictionary<Reference, string>();
        _filePath = filePath;
        _isExit = File.Exists(_filePath);
    }


    public void AddToLibraryList(Reference reference, string scriptureText)
    {
        // create a dict with reference and text key and value respectively
        _scriptureDict[reference] = scriptureText;
        
        // add the scriptureDict to the scripture list
        _libraryList.Add(_scriptureDict);

    }

    public void LoadScripture()
    {
        try
        {
            if (_isExit)  // the fie exits because File.Exit returned true
            {
                string[] lines = File.ReadAllLines(_filePath);
                
                // iterate through the lines
                foreach (string line in lines.Skip(1))  // skip the first line of the file
                {
                    string[] part = line.Split(";");
                    
                    // assign the values read from the file
                    string book = part[0];
                    int chapter = int.Parse(part[1]);
                    int startVerse = int.Parse(part[2]);
                    int endVerse = int.Parse(part[3]);
                    string scriptureText = part[5];
                    
                    //NOTE: If the list is not updated, check the code below
                    
                    // instantiate and create a Reference object
                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    
                    // call the AddToLibraryList to add the library
                    AddToLibraryList(reference, scriptureText);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public Tuple<Reference, string> GetReferenceAndScriptureText()
    {
        Random random = new Random();
        int index = random.Next(_libraryList.Count);
        
        // select a random scripture from the list of scripture dictionary
        Dictionary<Reference, string> selectedScripture = _libraryList[index];
        KeyValuePair<Reference, string> keyValuePair = selectedScripture.Single();

        return Tuple.Create(keyValuePair.Key, keyValuePair.Value);  // creates a tuple containing a scripture reference and text
    }
}