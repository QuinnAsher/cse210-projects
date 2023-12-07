namespace FinalProject;

public class SingleDrTransaction : Transaction
{
    public SingleDrTransaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes) :
        base(amount, accountNumber,
            accountBalance, transactionDes)
    {
        _transactionType = "DR";
    }

    public override string TransactionToString()
    {
        return
            $"{nameof(SingleDrTransaction)}+{_transactionType}|{_transactionId}|{_amount}|{_accountNumber}|{_accountBalance}|{_transactiondDateTime}|{_transactionDes}";
    }


    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {_transactionType}\nAvail Bal:\n${_accountBalance}\nDes:\n{_transactionDes}\nDate:\n{_transactiondDateTime}";
    }
}