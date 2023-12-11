using System.Text;

namespace FinalProject;

public abstract class Transaction
{
    protected string _transactionId;
    protected DateTime _transactionDate;
    protected decimal _amount;
    protected long _accountNumber;
    protected decimal _accountBalance;
    protected string _transactionType;
    protected string _transactionDes;

    protected Transaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes)
    {
        _amount = amount;
        _accountNumber = accountNumber;
        _accountBalance = accountBalance;
        _transactionId = Generator.GenerateId();
        _transactionDate = DateTime.Now;
        _transactionDes = transactionDes;
    }


    protected Transaction(string[] data)
    {
        _amount = decimal.Parse(data[2]);
        _transactionType = data[1];
        _accountNumber = long.Parse(data[3]);
        _accountBalance = decimal.Parse(data[4]);
        _transactionId = data[1];
        _transactionDate = DateTime.Parse(data[5]);
        _transactionDes = data[6];
    }


    public string GetTransactionId => _transactionId;
    public DateTime GetTransactionDate => _transactionDate;
    public string GetTransactionType => _transactionType;
    public decimal GetTransactionAmount => _amount;
    public long GetForeignKey => _accountNumber;

    // public string SetTransactionId
    // {
    //     set => _transactionId = value;
    // }
    //
    // public DateTime SetTransactionDate
    // {
    //     set => _transactiondDateTime = value;
    // }
    //
    // public string SetTransactionType
    // {
    //     set => _transactionType = value;
    // }
    //
    // public string SetTransactionDes
    // {
    //     set => _transactionDes = value;
    // }


    public abstract string GetHtmlRepresentation();


    public abstract string GetStringRepresentation();
    public abstract string TransactionAlert();
}