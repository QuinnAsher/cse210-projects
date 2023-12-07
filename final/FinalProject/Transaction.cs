namespace FinalProject;

public abstract class Transaction
{
    protected string _transactionId;
    protected DateTime _transactiondDateTime;
    protected decimal _amount;
    protected long _accountNumber;
    protected decimal _accountBalance;
    protected string _transactionType;
    protected string _transactionDes;

    protected Transaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes)
    {
        _amount = amount;
        _accountNumber = accountNumber;
        _accountBalance = accountBalance;
        _transactionId = Generator.GenerateTransactionId();
        _transactiondDateTime = DateTime.Now;
        _transactionDes = transactionDes;
    }


    public string GetTransactionId => _transactionId;

    public string SetTransactionId
    {
        set => _transactionId = value;
    }

    public DateTime SetTransactionDate
    {
        set => _transactiondDateTime = value;
    }

    public string SetTransactionType
    {
        set => _transactionType = value;
    }

    public string SetTransactionDes
    {
        set => _transactionDes = value;
    }

    public abstract string TransactionToString();
    public abstract string TransactionAlert();
}