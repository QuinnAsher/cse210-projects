// using System;
// using sandbox;
//
// namespace sandbox // Replace "YourNamespace" with your desired namespace name
// {
//     public class Person
//     {
//         public string _givenName = "";
//         public string _familyName = "";
//
//         public Person()
//         {
//         }
//
//         public void ShowEasternName()
//         {
//             Console.WriteLine($"{_familyName}, {_givenName}");
//         }
//
//         public void ShowWesternName()
//         {
//             Console.WriteLine($"{_givenName}, {_familyName}");
//         }
//     }
//
//
//     
// }
//
// List<Entry> entryList = new List<Entry>();
// Console.WriteLine("Welcome to the Journal Program!");
// bool isJournaling = true;
// while (isJournaling)
// {
//     string prompt =
//         "Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do? ";
//
//     Console.Write(prompt);
//     string userEntry = Console.ReadLine();
//     int userSelection = Convert.ToInt32(userEntry);
//
//     switch (userSelection)
//     {
//         case 1:
//             PromptGenerator promptGenerator = new PromptGenerator();
//             string randomPrompt = promptGenerator.GetRandomPrompt();
//             Console.WriteLine(randomPrompt);
//             Console.Write("> ");
//             string userAnswer = Console.ReadLine();
//             Entry newEntry = new Entry(randomPrompt, userAnswer);
//             entryList.Add(newEntry);
//             break;
//         case 2:
//             Console.WriteLine("Display");
//             break;
//         case 3:
//             Console.WriteLine("Load");
//             break;
//         case 4:
//             Console.WriteLine("Save");
//             break;
//         case 5:
//             isJournaling = false;
//             break;
//         default:
//             Console.WriteLine("Your choice is invalid. Please select a number from 1 to 5.");
//             break;
//     };
//     Console.WriteLine();
