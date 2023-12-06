namespace FinalProject;

internal class Something
{
} // You might need a class definition for Something

public class Program
{
    private static void Main(string[] args)
    {
        Account sender = new CurrentAccount("Divine");
        Account receiver = new SavingsAccount("John");
        
        sender.Deposit(10000);
        sender.Transfer(receiver, 5000);

        foreach (ITransaction t in receiver.GetTransactionHistory)
        {
            Console.WriteLine(t.TransactionAlert());
            Console.WriteLine(new string('-', 100));
            
        }
        
        // Console.WriteLine(new string('-', 150));
        
        foreach (ITransaction t in sender.GetTransactionHistory)
        {
            Console.WriteLine(t.TransactionAlert());
            Console.WriteLine(new string('-', 100));
        }
        
        ObjectCreator.SaveTransaction(sender,"sender");
        ObjectCreator.SaveTransaction(receiver, "receiver");
    }
}