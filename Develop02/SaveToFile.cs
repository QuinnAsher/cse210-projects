using Develop02;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class SaveToFile
{
    public List<Entry> _entries;
    public string _fileName;
    public StreamWriter _outputFile;
    
    // class constructor
    public SaveToFile(List<Entry> entries)
    {
        _entries = entries;
        // _fileName = fileName;
        // _outputFile = new StreamWriter(_fileName);
    }
    
    // a method to save to file
    public void SaveEntries()
    {
        Console.WriteLine("Saving to file........");
        using (_outputFile = new StreamWriter("journal.txt"))
        {
            foreach (Entry entry in _entries)
            {
                _outputFile.WriteLine($"Date: {entry._dateStamp} - {entry._prompt}\n{entry._userInput}");
                _outputFile.WriteLine("Debugging");
            }
        }
    }
}


