namespace FinalProject;

public class MultipleDrTransaction : DrTransaction
{
    private string _receiverName;

    public MultipleDrTransaction(decimal amount, long accountNumber, decimal accountBalance, string receiverName) :
        base(amount,
            accountNumber, accountBalance)
    {
        _receiverName = receiverName;
    }

    public override string TransactionToString()
    {
        return $"{TransactionType}+{_transactionId}|{_amount}|{_accountNumber}|{_transactiondDateTime}|{_receiverName}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {TransactionType}\nTo:\n{_receiverName}\nAvail Bal:\n${_accountBalance}\nDate:\n{_transactiondDateTime}";
    }
}