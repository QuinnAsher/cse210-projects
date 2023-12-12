using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalProject;

using static Generator;
using static ObjectCreator;
// using static PasswordManager;

public class UserInterface
{
    private int _otp;
    private int _otpToCompareTo;
    private string _userName;
    private Bank _bank;
    private bool _isLoggedIn;

    public UserInterface(Bank bank)
    {
        _otp = GenerateOtp();
        _otpToCompareTo = _otp;
        _bank = bank;
    }

    public string GetUserName => _userName;
    public bool GetLoginStatus => _isLoggedIn;

    public void CreateCustomer()
    {
        // Prompt and validate user information
        var customerName = GetValidStringInput("Enter your full name");
        var password = GetValidPassword();
        var confirmPassword = GetValidConfirmationPassword(password);
        var address = GetValidStringInput("Enter your address");
        var emailAddress = GetValidEmailAddress();
        var phoneNumber = GetValidPhoneNumber();
        var dateOfBirth = GetValidDateOfBirth();

        // Select and validate account type
        var accountType = GetValidAccountType();
        string accType;
        switch (accountType)
        {
            case 1:
                accType = "savings";
                break;
            case 2:
                accType = "current";
                break;
            default:
                throw new InvalidOperationException("Invalid account type selected");
        }

        // Send OTP email
        SendOtp();

        var isValidOtp = false;
        var retries = 3;

        while (!isValidOtp && retries > 0)
        {
            Console.WriteLine($"Enter the OTP sent to your email address:");
            try
            {
                var enteredOtp = int.Parse(Console.ReadLine());

                if (enteredOtp == _otpToCompareTo)
                {
                    isValidOtp = true;
                }
                else
                {
                    Console.WriteLine($"Invalid OTP. Please try again. You have {retries - 1} attempts remaining.");
                    retries--;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        if (isValidOtp)
        {
            // create a username
            GenerateUserName(customerName);

            // Create customer
            var customer = new Customer(customerName, password, address, emailAddress, phoneNumber, dateOfBirth,
                accType, _userName);

            // add the customer to the bank class
            _bank.AddCustomers(customer);

            // now save this customer to the bank Data base
            SaveCustomer(_bank, customer.GetCustomerId, "customers_data");

            Console.WriteLine($"Account created successfully! Account type: {accType.ToUpper()} ACCOUNT");

            // save this information in the bank database
        }
        else
        {
            Console.WriteLine("Maximum number of attempts reached. Please try again later.");
        }

        return;

        // Make the sendOtp method async and return a Task
        async void SendOtp()
        {
            // Create an EmailMaker object with the parameters
            var email = new EmailMaker("quintekc@gmail.com", emailAddress, "Account Verification",
                EmailBody(customerName, _otp), "smtp.gmail.com", 587, "hovqwgdwhjasersb");

            // Await the SendMail method
            await email.SendMail("quinTekc-Support", customerName);
        }
    }


    /**************************************************************************************************************/
    // helper functions to aid in account creations
    /**************************************************************************************************************/

    private static string EmailBody(string name, int otp)
    {
        // Create a StringBuilder object to build the HTML string
        var sb = new StringBuilder();

        // Append the HTML elements to the StringBuilder
        sb.Append("<div style=\"width: 1300px; display: flex; align-items: center; justify-content: center;\">");
        sb.Append(
            "<div style=\"box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04); margin-inline:auto; padding: 2rem; width: 20rem; height: 20rem;\">");
        sb.Append("<div style=\"line-height: 1.5;\">");
        sb.Append($"<p style=\"margin-top: 2rem\">Dear {name}</p>");
        sb.Append(
            $"<p>Welcome to quinTekc! To get started, use the following One-Time Password (OTP):<br /><strong style=\"color: brown; font-weight: bold\">OTP: {otp}</strong></p>");
        sb.Append(
            "<p>Use this OTP within the next 1 minute to log in securely. If you didn't request this OTP or have any concerns, please contact our support team.</p>");
        sb.Append("We're excited to have you on board with quinTekc!");
        sb.Append("<p>Warm regards, <br />quinTekc Client Assistance</p>");
        sb.Append("</div>");
        sb.Append("</div>");
        sb.Append("</div>");

        // Format the HTML string with the name and the OTP values
        var html = string.Format(sb.ToString(), name, otp);

        // Return the HTML string
        return html;
    }

    private string GetValidStringInput(string prompt)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    private string GetValidPassword()
    {
        string password;
        do
        {
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();
        } while (!PasswordValidate(password));

        return password;
    }


    private bool PasswordValidate(string password)
    {
        if (password.Length < 8)
        {
            Console.WriteLine("Password must be at least 8 characters long.");
            return false;
        }

        var hasNumber = password.Any(char.IsDigit);

        if (hasNumber) return true;
        Console.WriteLine("Password must contain at least one number.");
        return false;

    }


    private static string GetValidConfirmationPassword(string password)
    {
        string confirmPassword;
        do
        {
            Console.WriteLine("Confirm your password:");
            confirmPassword = Console.ReadLine();
            if (confirmPassword != password) Console.WriteLine("Passwords do not match. Please try again.");
        } while (confirmPassword != password);

        return confirmPassword;
    }


    private string GetValidEmailAddress()
    {
        string emailAddress;
        do
        {
            Console.WriteLine("Enter a valid email address:");
            emailAddress = Console.ReadLine();
        } while (!IsValidEmail(emailAddress));

        return emailAddress;
    }


    private string GetValidPhoneNumber()
    {
        string phoneNumber;
        do
        {
            Console.WriteLine("Enter your phone number:");
            phoneNumber = Console.ReadLine();
        } while (!IsValidPhoneNumber(phoneNumber));

        return phoneNumber;
    }

    private static DateTime GetValidDateOfBirth()
    {
        DateTime dateOfBirth;
        string dateOfBirthStr;

        do
        {
            Console.WriteLine("Enter your date of birth (YYYY-MM-DD):");
            dateOfBirthStr = Console.ReadLine();

            // Validate date format
            if (!DateTime.TryParseExact(dateOfBirthStr, "yyyy-MM-dd", null, DateTimeStyles.None, out dateOfBirth))
                Console.WriteLine("Invalid date format. Please enter your date of birth in YYYY-MM-DD.");
            // Optionally, validate date range here
            // ...
        } while (!DateTime.TryParseExact(dateOfBirthStr, "yyyy-MM-dd", null, DateTimeStyles.None, out dateOfBirth));

        return dateOfBirth;
    }


    private static int GetValidAccountType()
    {
        int accountType;
        do
        {
            Console.WriteLine("Choose your account type:\n1. Savings\n2. Current");
            accountType = int.Parse(Console.ReadLine());
        } while (accountType != 1 && accountType != 2);

        return accountType;
    }


    private  static bool IsValidEmail(string emailAddress)
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(emailAddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }


    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length < 10)
        {
            Console.WriteLine("Phone number must be at least 10 digits long.");
            return false;
        }

        foreach (var c in phoneNumber)
            if (!char.IsDigit(c))
            {
                Console.WriteLine("Phone number can only contain digits.");
                return false;
            }

        return true;
    }


    private void GenerateUserName(string name)
    {
        var userName = name.Split(" ");
        var random = new Random();

        var num = random.Next(100, 999);
        _userName = $"{userName[0].ToLower()}{num}";
    }
    /**************************************************************************************************************/
    // helper functions to aid in account creations
    /**************************************************************************************************************/

    /**************************************************************************************************************/
    // Login and Logoutsection
    /**************************************************************************************************************/

    public void Login(string userName, string password)
    {
        bool VerifyUserCredentials()
        {
            Customer customer = _bank.GetCustomerByUserName(userName);

            if (customer == null)
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }

            bool isPasswordMatch = customer.GetHashedPassword == HashPassword(password);

            if (!isPasswordMatch)
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }

            return true;
        }

        // set the username
        _userName = userName;
        _isLoggedIn = VerifyUserCredentials();
    }


    public void LogOut()
    {
        if (_isLoggedIn)
        {
            _isLoggedIn = false;
        }
    }

    /**************************************************************************************************************/
    // Login and Logout section
    /**************************************************************************************************************/
    
    
    /**************************************************************************************************************/
    // Perform Transactions Sections
    /**************************************************************************************************************/

   public void PerformTransaction()
{
    if (_isLoggedIn)
    {
        Console.WriteLine("Enter a number that corresponds with the Transaction you want to perform:");
        Console.WriteLine("1.   Deposit");
        Console.WriteLine("2.   Withdrawal");
        Console.WriteLine("3.   Transfer");
        Console.Write(">");

        int userAction;
        bool validInput = int.TryParse(Console.ReadLine(), out userAction);

        while (!validInput)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write(">");
            validInput = int.TryParse(Console.ReadLine(), out userAction);
        }

        // Retrieve the current user account
        Account account = _bank.GetCustomerByUserName(_userName).GetCustomerAccount;

        switch (userAction)
        {
            case 1:
                try
                {
                    Console.Write("Enter deposit amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    account.Deposit(amount);
                    Console.WriteLine($"Successfully deposited {amount}.");
                    SaveTransaction(account);
                }
                catch (Account.InsufficientFundsException e)
                {
                    Console.WriteLine(e.Message);
                    HandleError(account);
                }
                catch (Account.InvalidDepositAmountException e)
                {
                    Console.WriteLine(e.Message);
                    HandleError(account);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unexpected error occurred: {e.Message}");
                    HandleError(account);
                }
                break;
            case 2:
                try
                {
                    Console.Write("Enter withdrawal amount: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    account.Withdraw(amount);
                    SaveTransaction(account);
                    Console.WriteLine($"Successfully withdrawn {amount}.");
                }
                catch (Account.InsufficientFundsException e)
                {
                    Console.WriteLine(e.Message);
                    HandleError(account);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unexpected error occurred: {e.Message}");
                    HandleError(account);
                }
                break;
            case 3:
                try
                {
                    Console.Write("Enter recipient account number: ");
                    long recipientAccountNumber = long.Parse(Console.ReadLine());

                    Account recipientAccount =_bank.GetAccountByNumber(recipientAccountNumber);
                    if (recipientAccount == null)
                    {
                        Console.WriteLine("Account not found.");
                        HandleError(account);
                    }
                    else
                    {
                        Console.Write("Enter transfer amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        account.Transfer(recipientAccount, amount);
                        SaveTransaction(account);
                        SaveTransaction(recipientAccount);
                        Console.WriteLine($"Successfully transferred {amount} to account {recipientAccountNumber}.");
                    }
                }
                catch (Account.InsufficientFundsException e)
                {
                    Console.WriteLine(e.Message);
                    HandleError(account);
                }
                catch (Account.InvalidTransferAmountException e)
                {
                    Console.WriteLine(e.Message);
                    HandleError(account);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unexpected error occurred: {e.Message}");
                    HandleError(account);
                }
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }
    
    else
    {
        Console.WriteLine("You are not authorized to access this section.");
    }
}

private void HandleError(Account currentAccount)
{
    Console.WriteLine("Would you like to:");
    Console.WriteLine("1. Try again");
    Console.WriteLine("2. Go back to main menu");
    Console.WriteLine("3. Quit");
    Console.Write(">");

    int userChoice;
    bool validChoice = int.TryParse(Console.ReadLine(), out userChoice);

    while (!validChoice || userChoice < 1 || userChoice > 3)
    {
        Console.WriteLine("Invalid input. Please enter a number from 1 to 3.");
        Console.Write(">");
        validChoice = int.TryParse(Console.ReadLine(), out userChoice);
    }

    switch (userChoice)
    {
        case 1:
            PerformTransaction();
            break;
        case 2:
            // Display main menu
            break;
        case 3:
            // Quit the
            break;
    }
}
 
    /**************************************************************************************************************/
    // Perform Transaction Sections
    /**************************************************************************************************************/
}