using System.Text;

namespace FinalProject;

public class SingleCrTransaction : Transaction
{
    public SingleCrTransaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes,
        long foreignKey) :
        base(amount, accountNumber, accountBalance, transactionDes)
    {
        _transactionType = "CR";
    }


    public SingleCrTransaction(string[] data) : base(data)
    {
        _transactionType = "CR";
    }

    public override string GetStringRepresentation()
    {
        return
            //{_transactionId}|{_transactionType}|{_amount}|{_accountNumber}|{_accountBalance}|{_transactiondDateTime}|{_transactionDes}
            $"{nameof(SingleCrTransaction)}+{_transactionId}|{_transactionType}|{_amount}|{_accountNumber}|{_accountBalance}|{_transactionDate}|{_transactionDes}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {_transactionType}\nAvail Bal:\n${_accountBalance}\nDes:\n{_transactionDes}\nDate:\n{_transactionDate}";
    }


    public override string GetHtmlRepresentation()
    {
        var htmlBuilder = new StringBuilder();

        // Add the style attribute to the div element and specify the style properties as a string
        htmlBuilder.AppendLine(
            "<div style='box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04); background-color: #f2f2f2; padding: 2rem; display: flex; width: 40rem; height: 40rem; margin-inline: auto; border-radius: 1rem;'>");
        htmlBuilder.AppendLine("<div>");
        htmlBuilder.AppendLine($"<p><b>Account:</b>    {_accountNumber}</p>");
        htmlBuilder.AppendLine($"<p style=\"color: green\"><b>Amount:</b>    ${_amount} {_transactionType}</p>");
        htmlBuilder.AppendLine($"<p><b>Available Balance:</b>   ${_accountBalance}</p>");
        htmlBuilder.AppendLine($"<p><b>Description:</b>    {_transactionDes}</p>");
        htmlBuilder.AppendLine($"<p><b>Time:</b>    {_transactionDate}</p>");
        htmlBuilder.AppendLine("</div>");
        htmlBuilder.AppendLine("</div>");
        return htmlBuilder.ToString();
    }
}