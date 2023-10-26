namespace Develop03;


public class Scripture
{
    private string _scriptureText;
    private Reference _reference;
    private Word _word;
    private ScriptureGenerator _scriptureGenerator = new ScriptureGenerator();

    
    public Scripture()
    {
        // // Default scripture text
        // _scriptureText = "For God so loved the world, that he gave his only begotten Son, " +
        //                  "that whosoever believeth in him should not perish, but have everlasting life.";
        // _reference = new Reference(); // Default reference
        Tuple<Reference, string> randomScripture = _scriptureGenerator.GetRandomScripture();
        _reference = randomScripture.Item1;
        _scriptureText = randomScripture.Item2;
        _word = new Word(_scriptureText);
    }
    
    public Scripture(string scriptureText, Reference reference)
    {
        _scriptureText = scriptureText;
        _reference = reference;
        _word = new Word(_scriptureText);
    }

    public void HideWords()
    {
        // Get a random word from the Word class
        string verseWord = _word.GetWord();

        // Check if the word is in the scripture text
        if (_scriptureText.Contains(verseWord))
        {
            // Replace the word with asterisks to hide it
            _scriptureText = _scriptureText.Replace(verseWord, new string('_', verseWord.Length));
        }
    }

    public string GetVisibleText()
    {
        // Provide the current state of the scripture text
        return _scriptureText;
    }
}
