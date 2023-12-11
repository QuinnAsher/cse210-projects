using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalProject;

using static Generator;
using static ObjectCreator;
using static PasswordManager;

public class ConsoleInterface
{
    private int _otp;
    private int _otpToCompareTo;
    private string _userName;
    private Bank _bank;
    
    public ConsoleInterface()
    {
        _otp = GenerateOtp();
        _otpToCompareTo = _otp;
        _bank = new Bank();
    }

    public string GetUserName => _userName;
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

        bool isValidOtp = false;
        int retries = 3;

        while (!isValidOtp && retries > 0)
        {
            Console.WriteLine($"Enter the OTP sent to your email address: debugging {_otp}");
            try
            {
                int enteredOtp = int.Parse(Console.ReadLine());

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
            // Create customer
            var customer = new Customer(customerName, password, address, emailAddress, phoneNumber, dateOfBirth, accType);
            
            // add the customer to the bank class
            _bank.AddCustomers(customer);
            
            // create a username
            GenerateUserName(customerName);
            
            // now save this customer to the bank Data base
            SaveCustomer(_bank, customer.GetCustomerId, _userName);
            
            Console.WriteLine($"Account created successfully! Account type: {accType}");
            
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
            EmailMaker email = new EmailMaker("quintekc@gmail.com", emailAddress, "Account Verification",
                EmailBody(customerName, _otp), "smtp.gmail.com", 587, "hovqwgdwhjasersb");
    
            // Await the SendMail method
            await email.SendMail("quinTekc-Support", customerName);
        }
    }


    /**************************************************************************************************************/
    // helper functions to aid in account creations
    /**************************************************************************************************************/

    private string EmailBody(string name, int otp)
    {
        // Create a StringBuilder object to build the HTML string
        var sb = new StringBuilder();

        // Append the HTML elements to the StringBuilder
        sb.Append("<div style=\"width: 1300px; display: flex; align-items: center; justify-content: center;\">");
        sb.Append(
            "<div style=\"box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04); padding: 2rem; width: 20rem; height: 20rem;\">");
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
        if (password.Length < 10)
        {
            Console.WriteLine("Password must be at least 10 characters long.");
            return false;
        }

        var hasNumber = false;

        foreach (var t in password)
            if (char.IsDigit(t))
            {
                hasNumber = true;
                break;
            }

        if (!hasNumber)
        {
            Console.WriteLine("Password must contain at least one number.");
            return false;
        }

        return true;
    }


    private string GetValidConfirmationPassword(string password)
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

    private DateTime GetValidDateOfBirth()
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


    private int GetValidAccountType()
    {
        int accountType;
        do
        {
            Console.WriteLine("Choose your account type:\n1. Savings\n2. Current");
            accountType = int.Parse(Console.ReadLine());
        } while (accountType != 1 && accountType != 2);

        return accountType;
    }


    private bool IsValidEmail(string emailAddress)
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


    private bool IsValidPhoneNumber(string phoneNumber)
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
        string[] userName = name.Split(" ");
        Random random = new Random();

        int num = random.Next(100,999);
        _userName = $"{userName[0].ToLower()}{num}";
    }
    /**************************************************************************************************************/
    // helper functions to aid in account creations
    /**************************************************************************************************************/
    
    /**************************************************************************************************************/
    // Login section
    /**************************************************************************************************************/

    public void Login(string userName, string password)
    {
        // communicate with the bank
    }
    
    /**************************************************************************************************************/
    // Login section
    /**************************************************************************************************************/


}