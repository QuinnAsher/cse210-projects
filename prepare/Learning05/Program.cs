using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");
        Person p1 = new Person();
        p1._firstName = "Divine";
        p1._lastName = "Paul";
        p1._age = 30;

        Person p2 = new Person();
        p2._firstName = "Matthew";
        p2._lastName = "Onoja";
        p2._age = 77;
        
        
        List<Person> people = new List<Person>();

        // add p1 and p2 to the people's list
        people.Add(p1);
        people.Add(p2);
        foreach (Person person in people)
        {
            Console.WriteLine(person._age);
        }
        
        //call the save method
        SaveToFile(people);
    }
    
    // create a method to save a file
    static void SaveToFile(List<Person> people)
    {
        Console.WriteLine("Saving to file...");
        string filename = "people.txt";
        using (StreamWriter _outputFile = new StreamWriter(filename))
        {
            foreach (Person p in people)
            {
                _outputFile.WriteLine(p._age);
            }
        }
    }
}

class Person
{
    public string _firstName;
    public string _lastName;
    public int _age;
}

