namespace Develop02;
// a class for saving and loading a file
public class SaveLoadOrDeleteFile
{
    public List<Entry> _entryList;
    public StreamWriter _outputFile;
    public StreamReader _readFile;
    public string _extention;

    public SaveLoadOrDeleteFile(List<Entry> entryList)
    {
        _entryList = entryList;
    }


    // a method for saving a file
    public void SaveToFile(string fileName)
    {
        if (!_extention.Contains(".txt"))
        {
            fileName = fileName + ".txt";
        }
        using (_outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entryList)
            {
                _outputFile.WriteLine($"Date: {entry._dateStamp} - {entry._prompt}\n{entry._userInput}\n");
            }
        }
    }
    
    // a method to load a file 
    public void LoadFromFile(string fileName)
    {
        Console.WriteLine();
        Console.WriteLine("Loading file.....");

        _extention = Path.GetExtension(fileName);
        if (!_extention.Contains(".txt"))
        {
            fileName = fileName + ".txt";
        }
        
        using (_readFile = new StreamReader(fileName))
        {
            string line;
            // read the line to the end of the file
            while ((line = _readFile.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
    
    
    // a method to delete a file
    public void DeleteFile(string fileName)
    {
        Console.WriteLine();
        Console.WriteLine("Deleting file.....");

        try
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting file:{e.Message}");
            throw;
        }
    }
}



