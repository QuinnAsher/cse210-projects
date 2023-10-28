namespace Develop03;

public class ScriptureLibraryLoader
{
    private string _filePath;
    private bool _isExit;
    private Dictionary<Reference, string> _scriptureDict;

    public ScriptureLibraryLoader(string filePath = "scriptureData.csv")
    {
        _scriptureDict = new Dictionary<Reference, string>();
        _filePath = filePath;
        _isExit = File.Exists(_filePath);
        //TODO: make a method that creates a new file and writes a default scripture
    }
    
    public void LoadScripture()
    {
        try
        {
            if (_isExit) // the fie exits because File.Exit returned true
            {
                string[] lines = File.ReadAllLines(_filePath);

                // iterate through the lines
                foreach (string line in lines.Skip(1)) // skip the first line of the file
                {
                    string[] part = line.Split("|");

                    // assign the values read from the file
                    string book = part[0];
                    int chapter = int.Parse(part[1]);
                    int startVerse = int.Parse(part[2]);
                    int endVerse = int.Parse(part[3]);
                    string scriptureText = part[4];

                    //NOTE: If the list is not updated, check the code below

                    // instantiate and create a Reference object
                    Reference reference = new Reference(book, chapter, startVerse, endVerse);

                    // call the AddToLibraryList to add the library
                    _scriptureDict.Add(reference, scriptureText);
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
        //TODO: make a way to allow the user to pick the index of the dictionary. Maybe I can set an optional param.
        //TODO: but for this to be possible I need to display the dictionary to the user so they can make their choice
        Random random = new Random();

        if (_scriptureDict.Count > 0)
        {
            int index = random.Next(_scriptureDict.Count);
            Dictionary<Reference, string> selectedScripture = _scriptureDict;

            if (selectedScripture.Count > 0)
            {
                KeyValuePair<Reference, string> keyValuePair = selectedScripture.ElementAt(index);

                return Tuple.Create(keyValuePair.Key, keyValuePair.Value);
            }
        }

        // Handle the case where there's no data or an error occurs.
        return Tuple.Create<Reference, string>(null, null);
    }
}

