using static FinalProject.ObjectCreator;
using static FinalProject.Generator;

namespace FinalProject;

public class Program
{
    private static void Main(string[] args)
    {
        // //create a bank object to manage customers
        // Bank bank = new Bank();
        //
        // var dateOfBirth = new DateTime(2015, 09, 03);
        // var divine = new Customer("Divine", "1234", "Federal Lowcost", "pauldivineagionoja@gmail.com", "08847373393847",
        //     dateOfBirth);
        // var daniel = new Customer("Daniel", "1234", "Federal Lowcost", "pauldivineagionoja@yahoo.com", "08847373393847",
        //     dateOfBirth);
        //
        // // create account for each customer
        //  divine.CreateAccount("current");
        //  daniel.CreateAccount("savings");
        //  
        //  // access the accounts
        //  Account divineAccount = divine.GetAccount(0);
        //  Account danielAccount = daniel.GetAccount(0);
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
        //  // display transaction history
        //  bank.DisplayTransactionHistory(divineAccount.GetAccountNumber);
        //  bank.DisplayTransactionHistory(danielAccount.GetAccountNumber);
        //  
        //  // save all the data
        //  SaveTransaction(divineAccount, "divineT");
        //  SaveTransaction(danielAccount, "danielT");
        //  
        //  SaveAccount(divine, "divineA");
        //  SaveAccount(daniel, "danielA");
        //  
        //  SaveCustomer(bank, "divineC");
        //  SaveCustomer(bank, "danielC");
         
         // now load the data
         Bank loadBank = new Bank();
         LoadCustomer(loadBank, "divineC");
         LoadCustomer(loadBank, "danielC");

         Customer loadedDivine = null;
         Customer loadedDaniel = null;
         
         foreach (Customer c in loadBank.GetCustomers)
         {
             LoadAccount(c, "divineA");
             LoadAccount(c, "danielA");
         }
         
         
         foreach (Customer customer in loadedCustomers.Values)
         {
             // Load customer's accounts
             LoadAccount(customer, "divineA");
             LoadAccount(customer, "danielA");

             // Associate accounts with the loaded customer
             foreach (Account account in customer.GetCustomerAccount)
             {
                 LoadTransaction(account, "divineT");
                 LoadTransaction(account, "danielT");
             }
         }
         
    }
}