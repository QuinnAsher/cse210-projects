namespace FinalProject;

public class Bank
{
    private readonly List<Account> _listOfAccounts;
    private readonly List<Customer> _listOfCustomers;
    private string _bankLocation;
    private string _bankName;


    public Bank(string bankName, string bankLocation)
    {
        _bankName = bankName;
        _bankLocation = bankLocation;
        _listOfAccounts = new List<Account>();
        _listOfCustomers = new List<Customer>();
    }


    public void OpenAccount(Account account, Customer customer)
    {
        try
        {
            _listOfAccounts.Add(account);
            _listOfCustomers.Add(customer);
            Console.WriteLine("Account: {{account.accN}} opened for customer: {Customer.} at " +
                              "{_bankName} of l");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }


    public void CloseAccount(Account account, Customer customer)
    {
        try
        {
            _listOfAccounts.Add(account);
            _listOfCustomers.Add(customer);
            Console.WriteLine("Account: {{account.accN}} closed for customer: {Customer.} at " +
                              "{_bankName} of l");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}