namespace FinalProject;

public class MultipleCrTransaction : CrTransaction
{
    private string _senderName;

    public MultipleCrTransaction(decimal amount, long accountNumber, decimal accountBalance, string senderName) : base(
        amount,
        accountNumber, accountBalance)
    {
        _senderName = senderName;
    }


    public override string TransactionToString()
    {
        return $"{TransactionType}+{_transactionId}|{_amount}|{_accountNumber}|{_transactiondDateTime}|{_senderName}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {TransactionType}\nFrom:\n{_senderName}\nAvail Bal:\n${_accountBalance}\nDate:\n{_transactiondDateTime}";
    }
}