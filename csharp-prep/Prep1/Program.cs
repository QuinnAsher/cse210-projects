// using system;

class program
{
    static void Main(string[] args)
    {
        // ask the user for there name
        Console.Write("What is your first name?");
        string first_name = Console.ReadLine();
        
        Console.Write("What is your second name? ");
        string last_name = Console.ReadLine();
        
        // display the output
        Console.WriteLine($"Your name is {last_name} {first_name}" +
                          $" {last_name}");
    }
    
}