namespace FinalProject;

public class SavingsAccount : Account
{
    private readonly decimal _interestRAte;
    private readonly DateTime _startTime;
    private readonly DateTime _endTime;
    private readonly Dictionary<Transaction, decimal> _interestCache;

    public SavingsAccount(string accountHolder, long accountNumber, string accountEmail, string customerId) : base(
        accountHolder, accountNumber, accountEmail, customerId)
    {
        _interestRAte = 0.05m; // 5%
        _startTime = DateTime.Now;
        _endTime = _startTime.AddMonths(-1); // This should be set to negative for testing
        _interestCache = new Dictionary<Transaction, decimal>();
    }

    public SavingsAccount(string[] textDAta) : base(textDAta)
    {
        _interestRAte = 0.05m;
        _startTime = DateTime.Parse(textDAta[6]);
        _endTime = DateTime.Parse(textDAta[7]);
        _interestCache = new Dictionary<Transaction, decimal>();
    }

    public override string GetStringRepresentation()
    {
        return
            $"{nameof(SavingsAccount)}+{_accountHolder}|{_accountNumber}|{_accountBalance}|{_accountEmail}|{_creationDAte}|{_foreignKey}|{_startTime}|{_endTime}";
    }

    public Dictionary<Transaction, decimal> GetCachedInterest => _interestCache;

    private decimal CalculateInterest(Transaction transaction)
    {
        // Track the latest CR. Transaction
        var latestCrDate = DateTime.MinValue;

        if (transaction.GetTransactionType == "CR")
            // update the latest transaction date
            latestCrDate = transaction.GetTransactionDate;

        // Check if any debit transaction happens after the credit transaction
        var hasDebitTransactionAfterCr =
            _transactionsHistory.Any(t => t.GetTransactionType == "DR" && t.GetTransactionDate > latestCrDate);

        // check for maturity and calculate interest if no DR. Transaction after CR. T
        if (!hasDebitTransactionAfterCr && transaction.GetTransactionDate >= _endTime)
        {
            var interest = _interestRAte * transaction.GetTransactionAmount;
            return interest;
        }

        return 0m;
    }

    public override void AddInterest()
    {
        // made a copy of the transaction history to avoid modification
        // while iteration

        var tempTransactions = new List<Transaction>(_transactionsHistory);
        // add interest to corresponding transactions
        foreach (var t in tempTransactions)
        {
            if (!_interestCache.TryGetValue(t, out var cachedInterest))
            {
                // this code runs when the TryGetValue method returns false
                cachedInterest = CalculateInterest(t);
                _interestCache[t] = cachedInterest;
            }

            _accountBalance += cachedInterest;
            if (cachedInterest > 0)
            {
                Transaction interestTransaction =
                    new SingleCrTransaction(cachedInterest, _accountNumber, _accountBalance, "Earned Interest",
                        _accountNumber);
                _transactionsHistory.Add(interestTransaction);
                SendAlert(interestTransaction, "quinTekc", "Earned Interest");
            }

            Console.WriteLine(cachedInterest > 0 ? "Interest Added successfully" : "No interest added.");
        }
    }
}