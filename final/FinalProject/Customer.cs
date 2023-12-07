using static FinalProject.Generator;

namespace FinalProject;

public class Customer
{
   private string _customerId;
   private long _accountNumber;
   private string _customerName;
   private string _password;
   private string _address;
   private string _emailAddress;
   private string _phoneNumber;
   private DateTime _dateOfBirth;
   private List<Account> _accountList;

   public Customer(string customerName, string password, CustomerDetails customerDetails)
   {
      _customerId = GenerateId();
      _accountNumber = GenerateAccountNumber();
      _customerName = customerName;
      _password = password;
      _accountList = new List<Account>();
   }



   public List<Account> GetCustomerAccount => _accountList;
   
   public string GetStringRepresentation() =>  $"{_customerId}|{_accountNumber}|{_customerName}|{HashPassword(_password)}";
   
   public void CreateAccount(string accountType )
   {
      switch (accountType)
      {
         case "savings":
            
            _accountList.Add(new SavingsAccount(_customerName, _accountNumber));
            break;
         
         case "current":
            _accountList.Add(new CurrentAccount(_customerName, _accountNumber));
            break;
      }

   }

   public void DeleteAccount(int index)
   {
      _accountList.RemoveAt(index);
   }
   
   public bool Login(string password)
   {
      return HashPassword(_password) == HashPassword(password);
   }
   
}