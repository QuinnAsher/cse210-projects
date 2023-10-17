using System;
using Develop03;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new();
        Console.WriteLine(reference.SingleReference());
        Console.WriteLine(reference.MultipleReference());

        Word word = new Word();
        Console.WriteLine(word.GetWord());
        Console.WriteLine(word._wordList.Count);

    }
}