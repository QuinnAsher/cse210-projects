namespace FinalProject;

public class SingleCrTransaction : CrTransaction
{
    public SingleCrTransaction(decimal amount, long accountNumber, decimal accountBalance) : base(amount, accountNumber,
        accountBalance)
    {
    }

    public override string TransactionToString()
    {
        return $"{TransactionType}+{_transactionId}|{_amount}|{_accountNumber}|{_transactiondDateTime}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {TransactionType}\nAvail Bal:\n${_accountBalance}\nDate:\n{_transactiondDateTime}";
    }
}