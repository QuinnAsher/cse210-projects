using System; // Add this line for System.Linq
using ConsoleTables;
using FinalProject;

class Something { }  // You might need a class definition for Something

class Program
{
    static void Main(string[] args)
    {
        // var table = new ConsoleTable("one", "two", "three");
        // table.AddRow(1, 2, 3)
        //     .AddRow("this line should be longer", "yes it is", "oh");
        //
        // table.Write();
        // Console.WriteLine();
        //
        // var rows = Enumerable.Repeat(new Something(), 10);
        //
        // ConsoleTable
        //    .From<Something>(rows)
        //     .Configure(o => o.NumberAlignment = Alignment.Right)
        //     .Write(Format.Alternative);
        //
        // Console.ReadKey();

        var passwordHash = new PasswordManager("Chongfilawas");
        var hashPassword = passwordHash.HashPassword();
        var hashInputPassword = passwordHash.HashInputPassword("Chongfilawas");
        Console.WriteLine(hashPassword + " " + hashInputPassword);
        Console.WriteLine(passwordHash.CompareHashedPassword("Chongfilawas"));
    }
}
