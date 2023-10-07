// // using system;
//
// class program
// {
//     static void Main(string[] args)
//     {
//         // ask the user for there name
//         Console.Write("What is your first name?");
//         string first_name = Console.ReadLine();
//         
//         Console.Write("What is your second name? ");
//         string last_name = Console.ReadLine();
//         
//         // display the output
//         Console.WriteLine($"Your name is {last_name} {first_name}" +
//                           $" {last_name}");
//         if (first_name != last_name)
//         {
//             Console.WriteLine("The names are not the same");
//         }
//         else if (first_name == last_name)
//         {
//             Console.WriteLine("The names are the same");
//         }
//         else
//         {
//             Console.WriteLine("The names ");
//         }
//     }
//     
// }

// string valueInText = "79";
// int number = int.Parse(valueInText);

// display the result
Console.WriteLine("What is your favoirite number? ");
string userInput = Console.ReadLine();
int number = int.Parse(userInput);

if (number == 70)
{
    Console.Write($"{number} is my favorite number");
}
else
{
    Console.Write($"{number} is not my favorite number");
}