using static FinalProject.Generator;

namespace FinalProject;

public class Program
{
    private static void Main(string[] args)
    {
    // Account sender = new CurrentAccount("Divine", GenerateAccountNumber());
    // Account receiver = new SavingsAccount("John", GenerateAccountNumber());
    //
    // sender.Deposit(10000);
    // sender.Transfer(receiver, 5000);
    //
    // foreach (Transaction t in receiver.GetTransactionHistory)
    // {
    //     Console.WriteLine(t.TransactionAlert());
    //     Console.WriteLine(new string('-', 100));
    //     
    // }
    //
    // Console.WriteLine(new string('-', 150));
    //
    // foreach (Transaction t in sender.GetTransactionHistory)
    // {
    //     Console.WriteLine(t.TransactionAlert());
    //     Console.WriteLine(new string('-', 100));
    // }
    //
    // ObjectCreator.SaveTransaction(sender,"sender");
    // ObjectCreator.SaveTransaction(receiver, "receiver");

        // Account receiver = new SavingsAccount("John", GenerateAccountNumber());
        // ObjectCreator.LoadTransaction(receiver, "receiver");
        // receiver.DisplayAlertHistory();
        //
        // Account sender = new CurrentAccount("Divine", GenerateAccountNumber());
        // ObjectCreator.LoadTransaction(sender, "sender");
        // sender.DisplayAlertHistory();


        // create a customer account
        Customer divine = new Customer("Divine", "div");
        divine.CreateAccount("savings");
        
        // make some transactions
        divine.GetCustomerAccount[0].Deposit(10000);
        divine.GetCustomerAccount[0].Withdraw(3000);
        
        // create another customer account
        Customer daniel = new Customer("Daniel", "dano");
        daniel.CreateAccount("savings");
        
        // transfer from divine account to daniel account
        divine.GetCustomerAccount[0].Transfer(daniel.GetCustomerAccount[0],2000);

        divine.GetCustomerAccount[0].DisplayAlertHistory();
        daniel.GetCustomerAccount[0].DisplayAlertHistory();
    }
}