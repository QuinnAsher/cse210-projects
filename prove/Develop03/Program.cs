using System;
using Develop03;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new();
        Console.WriteLine(reference.SingleReference());
        Console.WriteLine(reference.MultipleReference());
        
        Console.WriteLine(reference.BookPropery);
        reference.BookPropery = "David";
        Console.WriteLine(reference.BookPropery);

        Word word = new Word();
        for (int i = 0; i < 24; i++)
        {
            Console.WriteLine(word.GetWord());
        }

    }
}