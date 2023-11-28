namespace FinalProject;

public class Transaction
{
    private string _transactionId;
    private DateTime _transactiondDateTime;
    private decimal _amount;
    private long _accountTo;
    private long _accountFrom;


    private Transaction(decimal amount, long accountTo, long accountFrom)
    {
        _transactionId = Generator.GenerateTransactionId();
        _transactiondDateTime = new DateTime();
        _amount = amount;
        _accountTo = accountTo;
        _accountFrom = accountFrom;
    }

    private Transaction(decimal amount, long accountFrom)
    {
        _transactionId = Generator.GenerateTransactionId();
        _transactiondDateTime = new DateTime();
        _amount = amount;
        _accountFrom = accountFrom;
    }

    public string TransactionToString()
    {
        return $"";
    }
}