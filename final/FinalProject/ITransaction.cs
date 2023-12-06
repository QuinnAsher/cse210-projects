namespace FinalProject;

public interface ITransaction
{
    public string TransactionType { get; }
    public string TransactionToString();
    public string TransactionAlert();
}