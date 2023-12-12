// using static FinalProject.PasswordManager;
using static FinalProject.Generator;

namespace FinalProject;

public class Customer
{
    private readonly string _customerId;
    private readonly long _accountNumber;
    private string _customerName;
    private string _password;
    private string _address;
    private string _emailAddress;
    private string _phoneNumber;
    private DateTime _dateOfBirth;
    private string _accontType;
    private Account _account;
    private string _userName;

    public Customer(string customerName, string password, string address, string emailAddress, string phoneNumber,
        DateTime dateOfBirth, string accountType, string userName)
    {
        _customerId = GenerateId();
        _accountNumber = GenerateAccountNumber();
        _customerName = customerName;
        _password = HashPassword(password);
        _address = address;
        _emailAddress = emailAddress;
        _phoneNumber = phoneNumber;
        _dateOfBirth = dateOfBirth;
        _accontType = accountType;
        _userName = userName;
        _account = CreateAccount(_accontType);
    }

    public Customer(string[] textData)
    {
        _customerId = textData[0];
        _customerName = textData[1];
        _accountNumber = long.Parse(textData[2]);
        _password = textData[3];
        _address = textData[4];
        _emailAddress = textData[5];
        _phoneNumber = textData[6];
        _dateOfBirth = DateTime.Parse(textData[7]);
        _accontType = textData[8];
        _userName = textData[9];
        _account = CreateAccount(_accontType);
    }


    public string GetStringRepresentation =>
        $"{_customerId}|{_customerName}|{_accountNumber}|{_password}|{_address}|{_emailAddress}|{_phoneNumber}|{_dateOfBirth}|{_accontType}|{_userName}";

    // Customer getters
    public string GetCustomerId => _customerId;
    public string GetUserName => _userName;

    public Account SetAccount
    {
        set => _account = value;
    }

    public bool HasAccount => _account != null;
    public string GetCustomerName => _customerName;
    public long GetAccountNumber => _accountNumber;
    public string GetHashedPassword => _password;
    public string GetEmailAddress => _emailAddress;
    public string GetPhoneNumber => _phoneNumber;
    public DateTime GetDateOfBirth => _dateOfBirth;

    // public Account GetAccount(int index)
    // {
    //     return _accountList[index];
    // }

    public Account GetCustomerAccount => _account;


    private Account CreateAccount(string accountType)
    {
        switch (accountType)
        {
            case "savings":

                return new SavingsAccount(_customerName, _accountNumber, _emailAddress, _customerId);


            case "current":
                return new CurrentAccount(_customerName, _accountNumber, _emailAddress, _customerId);
        }

        return null;
    }


    // public void DeleteAccount(int index, string password)
    // {
    //     // Validate password before proceeding
    //     if (!ValidatePassword(password)) throw new InvalidPasswordException("Invalid password provided.");
    //
    //     // Check account balance before deleting
    //     if (_account.GetAccountBalance < 0)
    //         throw new NegativeBalanceException("Account has a negative balance and cannot be deleted.");
    //     if (_account.GetAccountBalance > 0)
    //         throw new PositiveBalanceException(
    //             "Account has a positive balance and cannot be deleted. Please withdraw remaining funds before deleting.");
    //
    //     // Remove account from the list
    //     Console.WriteLine("Account deleted successfully.");
    // }

    private bool ValidatePassword(string password)
    {
        return HashPassword(password) == HashPassword(_password);
    }


    // methods for updating some customer info
    /******************************************************************************************************************/
    public void ResetPassword(string oldPassword, string newPassword)
    {
        if (!ValidatePassword(oldPassword)) throw new InvalidPasswordException("Invalid old password provided.");
        _password = HashPassword(newPassword);
    }


    public void ResetEmail(string password, string email, Account account)
    {
        if (!ValidatePassword(password)) throw new InvalidPasswordException("Invalid password provided.");

        _emailAddress = email;
        account.SetEmail = email;
    }


    public void ResetPhoneNumber(string password, string phoneNumber)
    {
        if (!ValidatePassword(password)) throw new InvalidPasswordException("Invalid password provided.");

        _phoneNumber = phoneNumber;
    }


    public void ResetName(string password, string newName)
    {
        if (!ValidatePassword(password)) throw new InvalidPasswordException("Invalid password provided.");

        _customerName = newName;
    }


    public void ResetAddress(string password, string newAddress)
    {
        if (!ValidatePassword(password)) throw new InvalidPasswordException("Invalid password provided.");

        _address = newAddress;
    }

    public void ResetDateOfBirth(string password, DateTime newDateOfBirth)
    {
        if (!ValidatePassword(password)) throw new InvalidPasswordException("Invalid password provided.");

        _dateOfBirth = newDateOfBirth;
    }
    /******************************************************************************************************************/


    // Custom Exceptions
    /******************************************************************************************************************/
    private class
        InvalidPasswordException : Exception
    {
        public
            InvalidPasswordException(string message) : base(message)
        {
        }
    }

    private class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string message) : base(message)
        {
        }
    }

    private class PositiveBalanceException : Exception
    {
        public PositiveBalanceException(string message) : base(message)
        {
        }
    }
    /******************************************************************************************************************/
}