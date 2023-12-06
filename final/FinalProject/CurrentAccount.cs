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
                ITransaction transaction = new SingleDrTransaction(amount, GetAccountNumber, GetAccountBalance);
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
                _accBalance-= amount;

                // credit the receiver's account
                decimal newBalance = receiverAccount.GetAccountBalance;
                newBalance += amount;
                
                receiverAccount.SetAccountBalance(newBalance);

                
                ITransaction drTransaction =
                    new MultipleDrTransaction(amount, GetAccountNumber, _accBalance, receiverAccount.GetAccountHolder);
                AddTransaction(drTransaction);

                ITransaction crTransaction =
                    new MultipleCrTransaction(amount, receiverAccount.GetAccountNumber,
                        receiverAccount.GetAccountBalance, GetAccountHolder);
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