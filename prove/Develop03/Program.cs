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

        SaveAndLoadScripture write = new SaveAndLoadScripture();
        write.WriteToFile();
        write.LoadFromFile();
        
        scripture.HideWords();scripture.HideWords();scripture.HideWords();scripture.HideWords();scripture.HideWords();scripture.HideWords();
        Console.WriteLine(scripture.RenderedText());

        // ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        // Tuple<Reference, string> result = scriptureLibrary.ReferenceAndScriptureText();
        //
        // Reference _reference;
        // string _text;
        //
        // if (result != null)
        // {
        //     _reference = result.Item1;
        //     _text = result.Item2;
        //     
        // }
        //
        // Reference newReference = new Reference()


        // scripture.Debugging();
    }
}