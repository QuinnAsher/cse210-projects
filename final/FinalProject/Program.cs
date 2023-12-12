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

        // Account danielAccount = bank.GetAccountByNumber(4498921972);
        // Account janeAccount = bank.GetAccountByNumber(408965971);
        
        // janeAccount.Deposit(20000);
        // janeAccount.Withdraw(5000);
        //
        // janeAccount.Transfer(danielAccount, 500);
        // Console.ReadLine();
        
        
        
        foreach (Customer c in bank.GetCustomersList)
        {
            Console.WriteLine(c.GetCustomerAccount.GetAccountBalance);
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
        
        

        var consoleInterface = new UserInterface(bank);
        try
        {
            Console.WriteLine(consoleInterface.GetUserName);
            // consoleInterface.CreateCustomer();
            consoleInterface.Login("divine396", "Chongf1lawas");
            consoleInterface.PerformTransaction();
            Console.WriteLine(consoleInterface.GetUserName);
        }

        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}