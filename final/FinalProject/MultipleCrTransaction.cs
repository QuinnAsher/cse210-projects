namespace FinalProject;

public class MultipleCrTransaction : Transaction
{
    private string _senderName;

    public MultipleCrTransaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes,
        string senderName) : base(
        amount,
        accountNumber, accountBalance, transactionDes)
    {
        _transactionType = "CR";
        _senderName = senderName;
    }


    public override string TransactionToString()
    {
        return
            $"{nameof(MultipleCrTransaction)}+{_transactionType}|{_transactionId}|{_amount}|{_accountNumber}|{_accountBalance}|{_transactiondDateTime}|{_transactionDes}|{_senderName}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {_transactionType}\nFrom:\n{_senderName}\nAvail Bal:\n${_accountBalance}\nDes:\n{_transactionDes}\nDate:\n{_transactiondDateTime}";
    }
}