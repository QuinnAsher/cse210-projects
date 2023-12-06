namespace FinalProject;

public abstract class Transaction
{
    protected string _transactionId;
    protected DateTime _transactiondDateTime;
    protected decimal _amount;
    protected long _accountNumberTo;
    protected long _accountNumberFrom;


    protected Transaction(decimal amount, long accountNumberTo, long accountNumberFrom)
    {
        _transactionId = Generator.GenerateTransactionId();
        _transactiondDateTime = DateTime.Now;
        _amount = amount;
        _accountNumberTo = accountNumberTo;
        _accountNumberFrom = accountNumberFrom;
    }

    protected Transaction(decimal amount, long accountNumberFrom)
    {
        _transactionId = Generator.GenerateTransactionId();
        _transactiondDateTime = DateTime.Now;
        _amount = amount;
        _accountNumberFrom = accountNumberFrom;
    }

    public abstract string TransactionToString();
}