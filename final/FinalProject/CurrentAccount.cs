namespace FinalProject;

public class CurrentAccount : Account
{
    private readonly decimal _overdraftLimit;
    private readonly decimal _paymentInterst;

    public CurrentAccount(string accountHolder, long accountNumber, string accountEmail, string foreignKey) : base(
        accountHolder,
        accountNumber, accountEmail, foreignKey)
    {
        _overdraftLimit = 0.2m;
        _paymentInterst = 0.1m;
    }

    public CurrentAccount(string[] textDAta) : base(textDAta)
    {
        _overdraftLimit = 0.2m;
    }

    public override string GetStringRepresentation()
    {
        return
            $"{nameof(CurrentAccount)}+{_accountHolder}|{_accountNumber}|{_accountBalance}|{_accountEmail}|{_creationDAte}|{_foreignKey}";
    }

    private decimal CalculateOverdraftLimit()
    {
        // This is a helper function to help calculate the
        // overdraft limit. This could not be calculated at
        // initialization because account balance is 0 then.
        return _overdraftLimit * GetAccountBalance;
    }

    public override void Withdraw(decimal amount)
    {
        try
        {
            if (amount <= GetAccountBalance)
            {
                _accountBalance -= amount;

                Transaction transaction =
                    new SingleDrTransaction(amount, GetAccountNumber, GetAccountBalance, "Withdrawal");
                _transactionsHistory.Add(transaction);
                WithdrawalCharge(amount);
            }

            else if (amount <= GetAccountBalance + CalculateOverdraftLimit())
            {
                _accountBalance -= amount;

                Transaction transaction =
                    new SingleDrTransaction(amount, GetAccountNumber, GetAccountBalance, "Withdrawal");
                _transactionsHistory.Add(transaction);

                // call the charge method
                WithdrawalCharge(amount);

                // calculate the amount that most be paid for overdraft
                var overdraft = CalculateOverdraftLimit() * _paymentInterst;

                Transaction overdraftTransaction =
                    new SingleCrTransaction(amount, GetAccountNumber, GetAccountBalance, "Overdraft Charge", _accountNumber);
                _transactionsHistory.Add(overdraftTransaction);
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

    public override void Transfer(Account receiverAccount, decimal amount)
    {
        try
        {
            if (amount <= CalculateOverdraftLimit() + GetAccountBalance)
            {
                // debit the sender's account
                _accountBalance -= amount;

                // credit the receiver's account
                // var newBalance = receiverAccount.GetAccountBalance;
                // newBalance += amount;
                receiverAccount.ReceiveAmount(amount);


                Transaction drTransaction =
                    new MultipleDrTransaction(amount, GetAccountNumber, _accountBalance, nameof(Transfer),
                        receiverAccount.GetAccountHolder, _accountNumber);
                AddTransaction(drTransaction);
                SendAlert(drTransaction, "quinTekc", "Deposit Charge Alert");

                TransferCharge(amount);

                Transaction crTransaction =
                    new MultipleCrTransaction(amount, receiverAccount.GetAccountNumber,
                        receiverAccount.GetAccountBalance, nameof(Transfer), GetAccountHolder);
                receiverAccount.AddTransaction(crTransaction);
                SendAlert(crTransaction, "quinTekc", "Deposit Charge Alert");

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

    protected override void DepositCharge(decimal amount)
    {
        if (amount <= 100)
        {
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
            _accountBalance -= 1.5m;
            Transaction transaction =
                new SingleDrTransaction(1.5m, _accountNumber, _accountBalance, "Deposit Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Deposit Charge Alert");
        }

        else
        {
            _accountBalance -= 5;
            Transaction transaction =
                new SingleDrTransaction(5m, _accountNumber, _accountBalance, "Deposit Charge");
            _transactionsHistory.Add(transaction);
            SendAlert(transaction, "quinTekc", "Deposit Charge Alert");
        }
    }
}