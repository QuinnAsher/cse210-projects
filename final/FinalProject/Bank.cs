using System.Text;

namespace FinalProject;

public class Bank
{
    private readonly List<Customer> _customersList = new();


    public Bank()
    {
    }
    
    
    public List<Customer> GetCustomersList => _customersList;

    public void AddCustomers(Customer customer)
    {
        _customersList.Add(customer);
    }

    public int NumberOfCustomers => GetCustomersList.Count;

    public override string ToString()
    {
        var builder = new StringBuilder();
        foreach (var customer in _customersList) builder.AppendLine(customer.GetStringRepresentation);
        return builder.ToString();
    }


    public Account GetAccountByNumber(long accountNumber)
    {
        foreach (var customer in _customersList)
            if (customer.HasAccount)
            {
                var account = customer.GetCustomerAccount;
                if (account.GetAccountNumber == accountNumber) return account;
            }
            else
            {
                throw new InvalidAccountException("Account with provided number does not exit");
            }
        return null;
    }

    public Customer GetCustomerByUserName(string userName)
    {
        foreach (Customer customer in _customersList)
        {
            return _customersList.FirstOrDefault(c => customer.GetUserName == userName);
        }
        return null;
    }

    public Account FindCustomerByName(string holderName)
    {
        foreach (var customer in _customersList)
            if (customer.HasAccount)
            {
                var account = customer.GetCustomerAccount;
                if (account.GetAccountHolder.ToLower() == holderName.ToLower()) return account;
            }

        return null;
    }


    public void MakeTransfer(long senderAccountNumber, decimal amount, long receiverAccountNumber)
    {
        var sender = GetAccountByNumber(senderAccountNumber);
        if (sender == null) throw new InvalidAccountException("Sender account does not exist.");

        var receiver = GetAccountByNumber(receiverAccountNumber);
        if (receiver == null) throw new InvalidAccountException("Receiver account does not exist.");

        sender.Transfer(receiver, amount);
    }


    public void MakeWithdrawal(long accountNumber, decimal amount)
    {
        var account = GetAccountByNumber(accountNumber);
        if (account == null) throw new InvalidAccountException("Account with provided number does not exist.");

        account.Withdraw(amount);
    }


    public void MakeDeposit(long accountNumber, decimal amount)
    {
        var account = GetAccountByNumber(accountNumber);
        if (account == null) throw new InvalidAccountException("Account with provided number does not exist.");

        account.Deposit(amount);
    }


    public void DisplayTransactionHistory(long accountNumber)
    {
        var account = GetAccountByNumber(accountNumber);
        if (account == null) throw new InvalidAccountException("Account with provided number does not exist.");

        account.DisplayAlertHistory();
    }


    private class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }
}