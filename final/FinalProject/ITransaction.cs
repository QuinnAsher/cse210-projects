namespace FinalProject;

public interface ITransaction
{
    public string GetTransactionId { get; }
    public string SetTransactionId { set; }
    public DateTime SetTransactionDate { set; }
    public string SetTransactionType { set; }
    public string TransactionToString();
    public string TransactionAlert();
}