using static FinalProject.ObjectCreator;
using static FinalProject.Generator;

namespace FinalProject;

public class Program
{
    private static void Main(string[] args)
    {
        //create a bank object to manage customers
        //  Bank bank = new Bank();
        //
        //  // this initialize a customer account and create an account
        //  var dateOfBirth = new DateTime(2015, 09, 03);
        //  var divine = new Customer("Divine", "1234", "Federal Lowcost", "pauldivineagionoja@gmail.com", "08847373393847",
        //      dateOfBirth, "current");
        //  var daniel = new Customer("Daniel", "1234", "Federal Lowcost", "pauldivineagionoja@yahoo.com", "08847373393847",
        //      dateOfBirth, "current");
        //  
        //  
        //  // access the accounts
        //  Account divineAccount = divine.GetCustomerAccount;
        //  Account danielAccount = daniel.GetCustomerAccount;
        //  
        //
        // // add the customers to the bank
        // bank.AddCustomers(divine);
        // bank.AddCustomers(daniel);
        //
        //
        //  // perform some transactions with customer divine
        //  bank.MakeDeposit(divineAccount.GetAccountNumber, 20000);
        //  bank.MakeWithdrawal(divineAccount.GetAccountNumber, 4500);
        //  bank.MakeTransfer(divineAccount.GetAccountNumber, 2000.65m, danielAccount.GetAccountNumber);
        //  
        //  // perfrom some transactions with customer daniel
        //  bank.MakeDeposit(danielAccount.GetAccountNumber, 4000);
        //  bank.MakeTransfer(danielAccount.GetAccountNumber, 1000, divineAccount.GetAccountNumber);
        //   
        // // display transaction history
        // bank.DisplayTransactionHistory(divineAccount.GetAccountNumber);
        // bank.DisplayTransactionHistory(danielAccount.GetAccountNumber);
        //
        // // save all the data
        // SaveTransaction(divineAccount, "divineT");
        // SaveTransaction(danielAccount, "danielT");
        //
        // SaveAccount(divine, "divineA");
        // SaveAccount(daniel, "danielA");
        //
        // SaveCustomer(bank, divine.GetCustomerId, "divineC");
        // SaveCustomer(bank, daniel.GetCustomerId, "danielC");

        // now load the data
        // Bank loadBank = new Bank();
        // LoadCustomer(loadBank, "divineC");
        // LoadCustomer(loadBank, "danielC");
        //
        // // assign a customer object
        // Customer divine1 = loadBank.GetCustomersList[0];
        // Customer daniel1 = loadBank.GetCustomersList[1];
        //
        // // load the customer account
        // LoadAccount(divine1, "divineA");
        // LoadAccount(daniel1, "divineA");
        //
        // // // assign account to their variable
        // Account divine1Account = loadBank.GetCustomersList[0].GetCustomerAccount;
        //                           
        // Account daniel1Account = loadBank.GetCustomersList[1].GetCustomerAccount;
        //
        //
        // // load the account Transaction
        // LoadTransaction(divine1Account, "divineT");
        // LoadTransaction(daniel1Account, "danielT");
        //
        // Console.WriteLine(loadBank.GetCustomersList.Count);
        // loadBank.GetCustomersList[0].GetCustomerAccount.DisplayAlertHistory();
        // Dictionary<long, Customer>


        var consoleInterface = new ConsoleInterface();
        try
        {
            Console.WriteLine(consoleInterface.GetUserName);
            consoleInterface.CreateCustomer();
            Console.WriteLine(consoleInterface.GetUserName);
        }

        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}