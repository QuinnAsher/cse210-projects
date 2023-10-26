namespace Develop03;


public class Program
{
    static void Main(string[] args)
    {
        Reference reference = new();
        Word word = new();
        Console.WriteLine(reference.FormatReference());

        Scripture scripture = new Scripture();

        foreach (var i in scripture._wordsLIst)
        {
            // Console.WriteLine(i._word);
        }

        Console.WriteLine(scripture.GetRenderedText());
        
    }
}