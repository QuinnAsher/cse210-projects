namespace FinalProject;

public class CurrentAccount : Account
{
    private readonly decimal _overdraftLimit;

    public CurrentAccount(string accountHolder) : base(accountHolder)
    {
        _overdraftLimit = 0.2m;
    }


    private decimal CalculateOverdraftLimit()
    {
        // This is a helper function to help calculate the
        // overdraft limit. This could not be calculated at
        // initialization because account balance is 0 then.
        return _overdraftLimit * GetAccountBalance;
    }

    public override void Withdraw(decimal amount)
    {
        try
        {
            if (amount <= CalculateOverdraftLimit() + GetAccountBalance)
            {
                _accBalance -= amount;
                Transaction transaction =
                    new SingleDrTransaction(amount, GetAccountNumber, GetAccountBalance, "Withdraw");
                _transactionsHistory.Add(transaction);
            }

            else
            {
                throw new InvalidOperationException(
                    $"Insufficient balance. Requested: ${amount}, Available: ${GetAccountBalance}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override void Transfer(Account receiverAccount, decimal amount)
    {
        try
        {
            if (amount <= CalculateOverdraftLimit() + GetAccountBalance)
            {
                // debit the sender's account
                _accBalance -= amount;

                // credit the receiver's account
                var newBalance = receiverAccount.GetAccountBalance;
                newBalance += amount;

                receiverAccount.SetAccountBalance(newBalance);


                Transaction drTransaction =
                    new MultipleDrTransaction(amount, GetAccountNumber, _accBalance, "Transfer",
                        receiverAccount.GetAccountHolder);
                AddTransaction(drTransaction);

                Transaction crTransaction =
                    new MultipleCrTransaction(amount, receiverAccount.GetAccountNumber,
                        receiverAccount.GetAccountBalance, "Transfer", GetAccountHolder);
                receiverAccount.AddTransaction(crTransaction);
            }

            else
            {
                throw new InvalidOperationException(
                    $"Insufficient balance. Requested: ${amount}, Available: ${GetAccountBalance}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}