namespace FinalProject;

public abstract class Account
{
    private decimal _accBalance;
    private string _accountHolder;
    private long _accountNumber;
    private DateTime _creationDAte;
    private List<Transaction> _transactionsHistory;

    protected Account(string accountHolder)
    {
        _accountNumber = Generator.GenerateAccountNumber();
        _accountHolder = accountHolder;
        _accBalance = 0;
        _transactionsHistory = new List<Transaction>();
        _creationDAte = new DateTime();
    }


    // Account class properties for getting data
    public decimal GetAccountBalance => _accBalance;
    public string GetAccountHolder => _accountHolder;
    public List<Transaction> GetTransactionHistory => _transactionsHistory;
    public DateTime GetCreationDateTime => _creationDAte;

    protected virtual void Deposit(decimal amount)
    {
        if (amount > 0)
            try
            {
                _accBalance += amount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        else
            Console.WriteLine("Insufficient funds");
    }


    protected virtual void Withdraw(decimal amount)
    {
        try
        {
            if (amount <= _accBalance)
                _accBalance -= amount;

            else
                Console.WriteLine("Insufficient funds");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }


    protected void Transfer(Account toAccount, decimal amount)
    {
        try
        {
            if (amount > _accBalance)
            {
                // withdraw the amount from sending account
                Withdraw(amount);

                // deposit the amount to to receiving account
                toAccount.Deposit(amount);
            }

            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}