namespace Develop02
{
    // a Journal class for adding, displaying, saving and laoding entries
    public class Journal
    {
        public List<Entry> _entryList = new List<Entry>();
    
        // public Journal()
        // {
        //     _entryList = new List<Entry>();
        // }
    
    
        // a method to add an entry to the entry list
        public void AddEntry(string prompt, string userInput)
        {
        
            Entry newEntry = new Entry(prompt, userInput);
            _entryList.Add(newEntry);
        }
    
    
        // a method to display the entries to the console
        public void DisplayEntries()
        {
            foreach (Entry entry in _entryList)
            {
                Console.WriteLine();
                Console.WriteLine(entry.FormattedEntry());
            }
        }
    
        // a method to save entries to a file
        public void SaveEntries(string fileName="journal.txt")
        {
            SaveLoadOrDeleteFile saveLoad = new SaveLoadOrDeleteFile(_entryList);
            saveLoad.SaveToFile(fileName);
        }
    
    
        // a method to load from a file
        public void LoadEntries(string fileName="journal.txt")
        {
            SaveLoadOrDeleteFile load = new SaveLoadOrDeleteFile(_entryList);
            load.LoadFromFile(fileName);
        }

        public void DeleteEntries(string fileName)
        {
            SaveLoadOrDeleteFile delete = new SaveLoadOrDeleteFile(_entryList);
            delete.DeleteFile(fileName);
        }
    }    
}
