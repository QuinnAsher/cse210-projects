namespace FinalProject;

public abstract class Account
{
    protected decimal _accBalance;
    private string _accountHolder;
    private long _accountNumber;
    private DateTime _creationDAte;
    protected List<Transaction> _transactionsHistory;

    protected Account(string accountHolder)
    {
        _accountNumber = Generator.GenerateAccountNumber();
        _accountHolder = accountHolder;
        _accBalance = 0;
        _transactionsHistory = new List<Transaction>();
        _creationDAte = DateTime.Now;
    }


    // Account class properties for getting data
    public decimal GetAccountBalance => _accBalance;
    public string GetAccountHolder => _accountHolder;
    public long GetAccountNumber => _accountNumber;
    public List<Transaction> GetTransactionHistory => _transactionsHistory;
    public DateTime GetCreationDateTime => _creationDAte;

    public void AddTransaction(Transaction transaction)
    {
        _transactionsHistory.Add(transaction);
    }

    public void  SetAccountBalance(decimal newBalance)
    {
        _accBalance = newBalance;
    }

    public void DisplayAlertHistory()
    {
        Console.WriteLine(new string('-', 100));
        for(int i = 0; i < _transactionsHistory.Count; i++)
        {
            Transaction t = _transactionsHistory[i];
            Console.WriteLine($"{i + 1}. {t.TransactionAlert()}");
            Console.WriteLine(new string('-' ,100));
        }
    }
    public void Deposit(decimal amount)
    {
        if (amount >= 100)
            try
            {
                _accBalance += amount;
                Transaction transaction = new SingleCrTransaction(amount, _accountNumber, _accBalance, "Deposit");
                _transactionsHistory.Add(transaction);
                //TODO: use the TransactionAlert method to send an email alert to the holder
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        else
        {
            throw new InvalidOperationException(
                $"Insufficient balance. Requested: ${amount}, Available: ${GetAccountBalance}");
        }
    }


    public virtual void Withdraw(decimal amount)
    {
        try
        {
            if (amount <= _accBalance)
            {
                _accBalance -= amount;


                Transaction transaction = new SingleDrTransaction(amount, _accountNumber, _accBalance, "Withdraw");
                _transactionsHistory.Add(transaction);
                //TODO: use the TransactionAlert method to send an email alert to the holder
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


    public virtual void Transfer(Account receiverAccount, decimal amount)
    {
        try
        {
            if (amount <= _accBalance)
            {
                // debit the amount from sending account
                _accBalance -= amount;

                // deposit the amount to to receiving account
                receiverAccount._accBalance-= amount;

                Transaction drTransaction =
                    new MultipleDrTransaction(amount, GetAccountNumber, _accBalance, "Transfer", receiverAccount.GetAccountHolder);
                AddTransaction(drTransaction);

                Transaction crTransaction =
                    new MultipleCrTransaction(amount, receiverAccount.GetAccountNumber,
                        receiverAccount.GetAccountBalance, "Transfer",GetAccountHolder);
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