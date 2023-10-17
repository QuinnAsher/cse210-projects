namespace Develop02;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        
        // Instantiate the classes to objects
        Journal journal = new();
        PromptGenerator promptGenerator = new();
        
        
        // show the user the prompt

            string randomPrompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine(randomPrompt);
        
            // get the users entry
            string userEntry = Console.ReadLine();
        
            Entry entry = new Entry(randomPrompt, userEntry);
        
            // add the user entry
            
            journal.AddEntry(randomPrompt, userEntry);
        
            
            bool endJournal = false;  // a flag for ending the program
            // show entry
            
            
            // Console.WriteLine("Welcome to your Journal Program");
        
            
        Console.WriteLine("Displaying the entries");
        journal.DisplayEntries();
        
        Console.WriteLine("Enter a filename to save your entries");
        // string filename = Console.ReadLine();
        journal.SaveEntries();
        // SaveToFile savingFile = new(filename, entry);
        
    }
}

