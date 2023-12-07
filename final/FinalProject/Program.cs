namespace FinalProject;

internal class Something
{
} // You might need a class definition for Something

public class Program
{
    private static void Main(string[] args)
    {
        // Account sender = new CurrentAccount("Divine");
        // Account receiver = new SavingsAccount("John");
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

        // Account receiver = new SavingsAccount("John");
        // ObjectCreator.LoadTransaction(receiver, "receiver");
        // receiver.DisplayAlertHistory();

        Account sender = new CurrentAccount("Divine");
        ObjectCreator.LoadTransaction(sender, "sender");
        sender.DisplayAlertHistory();
    }
}