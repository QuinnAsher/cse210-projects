namespace FinalProject;

public class SavingsAccount : Account
{
    private double _interestRAte;


    public SavingsAccount(string accountHolder) : base(accountHolder)
    {
        _interestRAte = 0.1;
    }


    public decimal CalculateInterest()
    {
        var interest = Convert.ToDecimal(_interestRAte) * GetAccountBalance;
        return interest;
    }
}