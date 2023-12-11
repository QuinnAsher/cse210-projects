using static FinalProject.ObjectCreator;
using static FinalProject.Generator;

namespace FinalProject;

public class Program
{
    private static void Main(string[] args)
    {
        
        // create a bank object
        Bank bank = new Bank();
        LoadBank(bank, "customers_data");
        foreach (Customer c in bank.GetCustomersList)
        {
            Console.WriteLine(c.GetCustomerName);
        }
        // an account by number
        // Account obadiah = bank.GetAccountByNumber(9388145530);
        //
        // obadiah.Deposit(20000);

        // SaveTransaction(obadiah);
        // obadiah.DisplayAlertHistory();
        //
        // Account divine = bank.GetAccountByNumber(6754226566);
        //
        // // make transfer betwen customers
        // obadiah.Deposit(20000);
        // obadiah.Transfer(divine, 5000);
        
        // Console.WriteLine(bank.GetCustomersList.Count);
        // Console.WriteLine(obadiah.GetTransactionHistory[0].GetStringRepresentation());
        // foreach (var VARIABLE in bank.GetCustomersList)
        // {
        //     VARIABLE.GetCustomerAccount.DisplayAlertHistory();
        // }
        
        

        var consoleInterface = new ConsoleInterface();
        try
        {
            Console.WriteLine(consoleInterface.GetUserName);
            // consoleInterface.CreateCustomer();
            Console.WriteLine(consoleInterface.GetUserName);
        }

        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}