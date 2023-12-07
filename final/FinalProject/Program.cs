using static FinalProject.Generator;

namespace FinalProject;

public class Program
{
    private static void Main(string[] args)
    {
    //     Account sender = new CurrentAccount("Divine", GenerateAccountNumber());
    //     Account receiver = new SavingsAccount("John", GenerateAccountNumber());
    //     
    //     sender.Deposit(10000);
    //     sender.Transfer(receiver, 5000);
    //     
    //     foreach (Transaction t in receiver.GetTransactionHistory)
    //     {
    //         Console.WriteLine(t.TransactionAlert());
    //         Console.WriteLine(new string('-', 100));
    //         
    //     }
    //     
    //     Console.WriteLine(new string('-', 150));
    //     
    //     foreach (Transaction t in sender.GetTransactionHistory)
    //     {
    //         Console.WriteLine(t.TransactionAlert());
    //         Console.WriteLine(new string('-', 100));
    //     }
    //     
    //     ObjectCreator.SaveTransaction(sender,"sender");
    //     ObjectCreator.SaveTransaction(receiver, "receiver");

        Account receiver = new SavingsAccount("John", GenerateAccountNumber());
        ObjectCreator.LoadTransaction(receiver, "receiver");
        receiver.DisplayAlertHistory();
        
        Account sender = new CurrentAccount("Divine", GenerateAccountNumber());
        ObjectCreator.LoadTransaction(sender, "sender");
        sender.DisplayAlertHistory();
        
        
        
    }
}