namespace FinalProject;

public class SavingsAccount : Account
{
    private decimal _interestRAte;
    private DateTime _startTime;
    private DateTime _endTime;
    private Dictionary<Transaction, decimal> _interestCache;
    public SavingsAccount(string accountHolder, long accountNumber) : base(accountHolder, accountNumber)
    {
        _interestRAte = 0.1m;
        _startTime = DateTime.Now;
        _endTime = _startTime.AddHours(2); // This can be changed for testing
        _interestCache = new Dictionary<Transaction, decimal>();
    }

    public override string GetStringRepresentation() => $"{nameof(CurrentAccount)}:{_accountHolder}|{_accountNumber}|{_accBalance}|{_creationDAte}";

    
    private decimal CalculateInterest(Transaction transaction)
    {
       // Track the latest CR. Transaction
       DateTime latestCrDate = DateTime.MinValue;

       if (transaction.GetTransactionType == "CR")
       {
           // update the latest transaction date
           latestCrDate = transaction.GetTransactionDate;
       }
       
       // Check if any debit transaction happens after the credit transaction
       bool hasDebitTransactionAfterCr =
           _transactionsHistory.Any(t => t.GetTransactionType == "DR" && t.GetTransactionDate > latestCrDate);

       // check for maturity and calculate interest if no DR. Transaction after CR. T
       if (!hasDebitTransactionAfterCr && transaction.GetTransactionDate >= _endTime)
       {
           decimal interest = _interestRAte * transaction.GetTransactionAmount;
           return interest;
       }

       return 0m;
    }
    public void AddInterest()
    {
        // add interest to corresponding transactions
        foreach (Transaction t in _transactionsHistory)
        {
            if (!_interestCache.TryGetValue(t, out decimal cashedInterest))
            {
                cashedInterest = CalculateInterest(t);
                _interestCache[t] = cashedInterest;
            }
            _accBalance += cashedInterest;
        }
    }
}