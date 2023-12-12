namespace FinalProject;

public abstract class Account
{
    protected decimal _accountBalance;
    protected string _accountHolder;
    protected long _accountNumber;
    protected DateTime _creationDAte;
    protected List<Transaction> _transactionsHistory;
    protected string _accountEmail;
    protected string _foreignKey;

    protected Account(string accountHolder, long accountNumber, string accountEmail, string foreignKey)
    {
        _accountNumber = accountNumber;
        _accountHolder = accountHolder;
        _accountBalance = 0;
        _accountEmail = accountEmail;
        _transactionsHistory = new List<Transaction>();
        _creationDAte = DateTime.Now;
        _foreignKey = foreignKey;
    }

    protected Account(string[] textDAta)
    {
        _accountHolder = textDAta[0];
        _accountNumber = long.Parse(textDAta[1]);
        _accountBalance = decimal.Parse(textDAta[2]);
        _accountEmail = textDAta[3];
        _creationDAte = DateTime.Parse(textDAta[4]);
        _foreignKey = textDAta[5];
        _transactionsHistory = new List<Transaction>();
    }

    // Account class properties for getting data
    public string GetEmail => _accountEmail;
    public string GetForeignKey => _foreignKey;

    public string SetEmail
    {
        set => _accountEmail = value;
    }

    public decimal GetAccountBalance => _accountBalance;
    public string GetAccountHolder => _accountHolder;
    public long GetAccountNumber => _accountNumber;
    public List<Transaction> GetTransactionHistory => _transactionsHistory;
    public DateTime GetCreationDateTime => _creationDAte;

    public async void SendAlert(Transaction transaction, string senderName, string subject)
    {
        var alert = new EmailMaker("quintekc@gmail.com", _accountEmail, subject,
            transaction.GetHtmlRepresentation(), "smtp.gmail.com", 587, "hovqwgdwhjasersb");
        await alert.SendMail(senderName, _accountHolder);
    }

    public abstract string GetStringRepresentation();

    public void AddTransaction(Transaction transaction)
    {
        _transactionsHistory.Add(transaction);
    }

    public virtual void AddInterest()
    {
    }

    public void ReceiveAmount(decimal amount)
    {
        // This method is a helper function that is meant to add an amount to a transferred
        // account.
        if (amount >= 10)
            _accountBalance += amount;

        else
            throw new InvalidTransferAmountException($"Amount most be greater or equal to $10");
    }

    public void DisplayAlertHistory()
    {
        Console.WriteLine(new string('-', 100));
        for (var i = 0; i < _transactionsHistory.Count; i++)
        {
            var t = _transactionsHistory[i];
            Console.WriteLine($"{i + 1}. {t.TransactionAlert()}");
            Console.WriteLine(new string('-', 100));
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount >= 10)
            try
            {
                _accountBalance += amount;
                Transaction transaction = new SingleCrTransaction(amount, _accountNumber, _accountBalance, "Deposit", _accountNumber);
                _transactionsHistory.Add(transaction);

                //send an email
                SendAlert(transaction, "quinTekc", "Deposit Alert");

                DepositCharge(amount);
                // Console.ReadLine();
                //TODO: use the TransactionAlert method to send an email alert to the holder
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        else
            throw new InvalidDepositAmountException(
                $"Amount most be greater or equal to $10");
    }


    public virtual void Withdraw(decimal amount)
    {
        try
        {
            if (amount <= _accountBalance)
            {
                _accountBalance -= amount;


                Transaction transaction =
                    new SingleDrTransaction(amount, _accountNumber, _accountBalance, "Withdrawal");
                _transactionsHistory.Add(transaction);
                WithdrawalCharge(amount);
                //TODO: use the TransactionAlert method to send an email alert to the holder
            }


            else
            {
                throw new InsufficientFundsException(
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
            if (amount <= _accountBalance)
            {
                // debit the amount from sending account
                _accountBalance -= amount;

                // deposit the amount to to receiving account
                receiverAccount._accountBalance += amount;

                Transaction drTransaction =
                    new MultipleDrTransaction(amount, GetAccountNumber, _accountBalance, "Transfer",
                        receiverAccount.GetAccountHolder, _accountNumber);
                SendAlert(drTransaction, "quinTekc", "Transfer Charge");

                AddTransaction(drTransaction);
                TransferCharge(amount);

                Transaction crTransaction =
                    new MultipleCrTransaction(amount, receiverAccount.GetAccountNumber,
                        receiverAccount.GetAccountBalance, "Transfer", GetAccountHolder);
                SendAlert(crTransaction, "quinTekc", "Transfer Charge");

                receiverAccount.AddTransaction(crTransaction);
                receiverAccount.TransferCharge(amount);
            }

            else
            {
                throw new InsufficientFundsException(
                    $"Insufficient balance. Requested: ${amount}, Available: ${GetAccountBalance}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }

    public class InvalidDepositAmountException : Exception
    {
        public InvalidDepositAmountException(string message) : base(message)
        {
        }
    }


    public class InvalidTransferAmountException : Exception
    {
        public InvalidTransferAmountException(string message) : base(message)
        {
        }
    }


    protected virtual void DepositCharge(decimal amount)
    {
        if (amount <= 100)
        {
            // charge 1 dollar
            _accountBalance -= 0.5m;
            Transaction transaction =
                new SingleDrTransaction(0.5m, _accountNumber, _accountBalance, "Deposit Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Deposit Charge Alert");
        }

        else if (amount is > 100 and <= 500)
        {
            _accountBalance -= 1;
            Transaction transaction =
                new SingleDrTransaction(1m, _accountNumber, _accountBalance, "Deposit Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Deposit Charge Alert");
        }

        else if (amount is > 500 and <= 1000)
        {
            // charge 1 dollar
            _accountBalance -= 1.5m;
            Transaction transaction =
                new SingleDrTransaction(1.5m, _accountNumber, _accountBalance, "Deposit Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Deposit Charge Alert");
        }

        // else
        // {
        //     // charge 1 dollar
        //     _accBalance -= 5;
        //     Transaction transaction =
        //         new SingleDrTransaction(amount, _accountNumber, _accBalance, "Deposit Charge");
        // }
    }


    protected void WithdrawalCharge(decimal amount)
    {
        if (amount <= 100)
        {
            // charge 1 dollar
            _accountBalance -= 0.5m;
            Transaction transaction =
                new SingleDrTransaction(0.5m, _accountNumber, _accountBalance, "Withdrawal Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Withdrawal Charge Alert");
        }

        else if (amount is > 100 and <= 500)
        {
            _accountBalance -= 1;
            Transaction transaction =
                new SingleDrTransaction(1m, _accountNumber, _accountBalance, "Withdrawal Charge");
            SendAlert(transaction, "quinTekc", "Withdrawal Charge Alert");
        }

        else if (amount is > 500 and <= 1000)
        {
            // charge 1 dollar
            _accountBalance -= 1.5m;
            Transaction transaction =
                new SingleDrTransaction(1.5m, _accountNumber, _accountBalance, "Withdrawal Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Withdrawal Charge Alert");
        }

        else
        {
            // charge 1 dollar
            _accountBalance -= 5;
            Transaction transaction =
                new SingleDrTransaction(5m, _accountNumber, _accountBalance, "Withdrawal Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Withdrawal Charge Alert");
        }
    }


    public void TransferCharge(decimal amount)
    {
        if (amount <= 100)
        {
            // charge 1 dollar
            _accountBalance -= 0.25m;
            Transaction transaction =
                new SingleDrTransaction(0.25m, _accountNumber, _accountBalance, "Transfer Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Transfer Charge Alert");
        }

        else if (amount is > 100 and <= 500)
        {
            _accountBalance -= 0.5m;
            Transaction transaction =
                new SingleDrTransaction(0.5m, _accountNumber, _accountBalance, "Transfer Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Transfer Charge Alert");
        }

        else if (amount is > 500 and <= 1000)
        {
            _accountBalance -= 0.75m;
            Transaction transaction =
                new SingleDrTransaction(0.75m, _accountNumber, _accountBalance, "Transfer Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Transfer Charge Alert");
        }

        else
        {
            _accountBalance -= 2.5m;
            Transaction transaction =
                new SingleDrTransaction(2.5m, _accountNumber, _accountBalance, "Transfer Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Transfer Charge Alert");
        }
    }
}