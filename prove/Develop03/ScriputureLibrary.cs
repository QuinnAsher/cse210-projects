// namespace Develop03;
//
// public class ScriptureLibrary
// {
//     private List<Dictionary<Reference, string>> _libraryList;
//     private Dictionary<Reference, string> scriptureDict;
//
//     public ScriptureLibrary()
//     {
//         _libraryList = new List<Dictionary<Reference, string>>();
//         scriptureDict = new Dictionary<Reference, string>();
//     }
//
//     public void AddToLibraryList(Reference reference, string scriptureText)
//     {
//         // scriptureDict.Add(reference, scriptureText);
//         
//         // A scripture dictionary with a key as reference and a value of scripture text
//         scriptureDict[reference] = scriptureText;
//         _libraryList.Add(scriptureDict);
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
// }