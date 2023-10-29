// namespace Develop03;
//
// public class ScriptureLibrary
// {
//     private List<Dictionary<Reference, string>> _libraryList;
//     private Dictionary<Reference, string> _scriptureDict;
//     private SaveScriptureToFile _scriptureToFileInfo;
//     private Reference _reference;
//
//     public ScriptureLibrary()
//     {
//         _libraryList = new List<Dictionary<Reference, string>>();
//         _scriptureDict = new Dictionary<Reference, string>();
//         _scriptureToFileInfo = new SaveScriptureToFile();
//     }
//
//     public void printlib()
//     {
//         foreach (var each in _libraryList)
//         {
//             foreach (var VARIABLE in _scriptureDict)
//             {
//                 Console.WriteLine($"{VARIABLE.Key} {VARIABLE.Value}");
//             }
//         }
//     }
//     public void AddToLibraryList()//Reference reference, string scriptureText)
//     {
//         // scriptureDict.Add(reference, scriptureText);
//         
//         // A scripture dictionary with a key as reference and a value of scripture text
//         // scriptureDict[reference] = scriptureText;
//
//         string book = _scriptureToFileInfo.BookProperty;
//         int chapter = _scriptureToFileInfo.ChapterProperty;
//         int startVerse = _scriptureToFileInfo.StartVersePropery;
//         int endVerse = _scriptureToFileInfo.EndVerseProperty;
//         string scriptureText = _scriptureToFileInfo.ScriptureTextProperty;
//         
//         // Initialize a Reference object
//         _reference = new Reference(book, chapter, startVerse, endVerse);
//         
//         // create a dict with reference and scripture text as key and value respectively
//         _scriptureDict[_reference] = scriptureText;
//         
//         // add the scriptureDict to the scripture library list
//         _libraryList.Add(_scriptureDict);
//     }
//
//     public Tuple<Reference, string> ReferenceAndScriptureText()
//     {
//         Random random = new Random();
//         int index = random.Next(_libraryList.Count);
//         // select a random scripture from the list of scriptures dictionary
//         Dictionary<Reference, string> selectedScripture = _libraryList[index];
//         KeyValuePair<Reference, string> keyValuePair = selectedScripture.Single();
//
//         return Tuple.Create(keyValuePair.Key, keyValuePair.Value);  // create a tuple containing a scripture reference and text
//     }
//
//     public int LenOfLibrary()
//     {
//         return _libraryList.Count;
//     }
// }