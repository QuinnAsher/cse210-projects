namespace Develop03;

public class Scripture
{
     private string _scriptureText;
     private Reference _reference;
     private Word word;

     public Scripture()
     {
          _scriptureText = "For God so loved the world, that he gave his only begotten Son, " +
                           "that whosoever believeth in him should not perish, but have everlasting life.";
          word = new Word();
     }

     public Scripture(string scriptureText)
     {
         _scriptureText = scriptureText;
         word = new Word(_scriptureText);
     }


     public void HideWords()
     {
         string verseWord = word.GetWord();
         
         // check if the word is in the verse
         
     }
}
