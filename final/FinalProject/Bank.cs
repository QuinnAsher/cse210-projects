namespace FinalProject;

public class Bank
{
    private readonly List<Customer> _customers = new();
    
    public void AddCustomers(Customer customer)
    {
        _customers.Add(customer);
    }

    public List<Customer> GetCustomers => _customers;
    
    private Account GetAccountByNumber(long accountNumber)
    {
        foreach (Customer customer in _customers)
        {
            Account account = customer.GetCustomerAccount.FirstOrDefault(a => a.GetAccountNumber == accountNumber);
            if (account != null)
            {
                return account;
            }
        }
        return null;
    }


    public Account FindCustomerByName(string holderName)
    {
        foreach (Customer customer in _customers)
        {
            Account account =
                customer.GetCustomerAccount.FirstOrDefault(a => a.GetAccountHolder.Split(" ")[0] == holderName);
            return account;
        }

        return null;
    }
    
    
    public void MakeTransfer(long senderAccountNumber, decimal amount, long receiverAccountNumber)
    {
        Account sender = GetAccountByNumber(senderAccountNumber);
        if (sender == null)
        {
            throw new InvalidAccountException("Sender account does not exist.");
        }

        Account receiver = GetAccountByNumber(receiverAccountNumber);
        if (receiver == null)
        {
            throw new InvalidAccountException("Receiver account does not exist.");
        }

        sender.Transfer(receiver, amount);
    }

    
    public void MakeWithdrawal(long accountNumber, decimal amount)
    {
        Account account = GetAccountByNumber(accountNumber);
        if (account == null)
        {
            throw new InvalidAccountException("Account with provided number does not exist.");
        }

        account.Withdraw(amount);
    }

    
    public void MakeDeposit(long accountNumber, decimal amount)
    {
        Account account = GetAccountByNumber(accountNumber);
        if (account == null)
        {
            throw new InvalidAccountException("Account with provided number does not exist.");
        }

        account.Deposit(amount);
    }


    public void DisplayTransactionHistory(long accountNumber)
    {
        Account account = GetAccountByNumber(accountNumber);
        if (account == null)
        {
            throw new InvalidAccountException("Account with provided number does not exist.");
        }

        account.DisplayAlertHistory();
    }

    
    private class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }

}
    