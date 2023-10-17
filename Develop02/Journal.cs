namespace Develop02;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Journal
{
    public List<Entry> _entryList = new();
    
    // a method to add entry
    public void AddEntry(string prompt, string userInput)
    {
        Entry newEntry = new Entry(prompt, userInput);
        // add the new entry to the entry list
        _entryList.Add(newEntry);
    }
    
    // a method to the display the entries to the console
    public void DisplayEntries()
    {
        foreach (Entry entry in _entryList)  // iterate all the entries in _entries list
        {
            // Console.WriteLine(_entryList.Count); // for debugging
            string entryFormat = entry.FormattedEntry();
            Console.WriteLine(entryFormat);
        }
    }
    
    // a method to save an entry to a file
    public void SaveEntries()
    {
        // use the entry list
        SaveToFile saveFile = new(_entryList);
        saveFile.SaveEntries();
        

    }
}
