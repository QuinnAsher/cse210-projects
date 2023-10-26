// using System;
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Enter your score");
//         string studentScoreStr = Console.ReadLine();
//         int studentScoreInt = int.Parse(studentScoreStr);
//         string gradeLetter = "";
//         // check the score to get the student grade
//         
//         // A grade
//         if (studentScoreInt >= 97)
//         {
//             gradeLetter = "A+";
//         }
//         
//         else if (studentScoreInt >= 93)
//         {
//             gradeLetter = "A-";
//         }
//         
//         else if (studentScoreInt >= 90)
//         {
//             gradeLetter = "A";
//         }
//         
//         // B grade
//         else if (studentScoreInt >= 87)
//         {
//             gradeLetter = "B+";
//         }
//         
//         else if (studentScoreInt >= 83)
//         {
//             gradeLetter = "B-";
//         }
//         
//         else if (studentScoreInt >= 80)
//         {
//             gradeLetter = "B";
//         }
//         
//         // C grade
//         else if (studentScoreInt >= 77)
//         {
//             gradeLetter = "C+";
//         }
//         
//         else if (studentScoreInt >= 73)
//         {
//             gradeLetter = "C-";
//         }
//         
//         else if (studentScoreInt >= 70)
//         {
//             gradeLetter = "C";
//         }
//         
//         // D grade
//         else if (studentScoreInt >= 67)
//         {
//             gradeLetter = "D+";
//         }
//         
//         else if (studentScoreInt >= 63)
//         {
//             gradeLetter = "D-";
//         }
//         
//         else if (studentScoreInt > 60)
//         {
//             gradeLetter = "D";
//         }
//         
//         // F grade
//         else
//         {
//             gradeLetter = "F";
//         }
//         
//         // display result
//         Console.Write($"Your grade is: {gradeLetter}");
//     }
// }



using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Show()
    {
        IsHidden = false;
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int Verse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int verse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        EndVerse = endVerse;
    }
}

class Scripture
{
    private List<Word> words;
    private Reference reference;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Count <= count)
        {
            foreach (Word word in visibleWords)
            {
                word.Hide();
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        return words.All(word => word.IsHidden);
    }

    public string GetRenderedText()
    {
        string renderedText = string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Text));
        return $"{reference.Book} {reference.Chapter}:{reference.Verse}-{reference.EndVerse}: {renderedText}";
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 random words
        }
    }
}
