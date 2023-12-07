namespace FinalProject;

public class MultipleDrTransaction : Transaction
{
    private string _receiverName;

    public MultipleDrTransaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes,
        string receiverName) :
        base(amount,
            accountNumber, accountBalance, transactionDes)
    {
        _transactionType = "DR";
        _receiverName = receiverName;
    }

    public override string TransactionToString()
    {
        return
            $"{nameof(MultipleDrTransaction)}+{_transactionType}|{_transactionId}|{_amount}|{_accountNumber}|{_accountBalance}|{_transactiondDateTime}|{_transactionDes}|{_receiverName}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {_transactionType}\nTo:\n{_receiverName}\nAvail Bal:\n${_accountBalance}\nDes:\n{_transactionDes}\nDate:\n{_transactiondDateTime}";
    }
}