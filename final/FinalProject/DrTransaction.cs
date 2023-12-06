namespace FinalProject;

public abstract class DrTransaction : ITransaction
{
    protected string _transactionId;
    protected DateTime _transactiondDateTime;
    protected decimal _amount;
    protected long _accountNumber;
    protected decimal _accountBalance;

    protected DrTransaction(decimal amount, long accountNumber, decimal accountBalance)
    {
        _amount = amount;
        _accountNumber = accountNumber;
        _accountBalance = accountBalance;
        _transactionId = Generator.GenerateTransactionId();
        _transactiondDateTime = DateTime.Now;
    }


    public string TransactionType => "Dr";
    public abstract string TransactionToString();
    public abstract string TransactionAlert();
}