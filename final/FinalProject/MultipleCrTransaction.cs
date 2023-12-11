using System.Text;

namespace FinalProject;

public class MultipleCrTransaction : Transaction
{
    private string _senderName;

    public MultipleCrTransaction(decimal amount, long accountNumber, decimal accountBalance, string transactionDes, string senderName)
        : base(
        amount, accountNumber, accountBalance, transactionDes)
    {
        _transactionType = "CR";
        _senderName = senderName;
    }

    public MultipleCrTransaction(string[] data) : base(data)
    {
        _transactionType = "CR";
        _senderName = data[8];
    }

    public override string GetStringRepresentation()
    {
        return
            $"{nameof(MultipleCrTransaction)}+{_transactionId}|{_transactionType}|{_amount}|{_accountNumber}|{_accountBalance}|{_transactionDate}|{_transactionDes}|{_senderName}";
    }

    public override string TransactionAlert()
    {
        return
            $"Acc:\n{_accountNumber}\nAmt:\n${_amount} {_transactionType}\nFrom:\n{_senderName}\nAvail Bal:\n${_accountBalance}\nDes:\n{_transactionDes}\nDate:\n{_transactionDate}";
    }


    public override string GetHtmlRepresentation()
    {
        var htmlBuilder = new StringBuilder();

        // Add the style attribute to the div element and specify the style properties as a string
        htmlBuilder.AppendLine(
            "<div style='box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04); background-color: #f2f2f2; padding: 2rem; display: flex; width: 30rem; height: 30rem; margin-inline: auto; border-radius: 1rem;'>");
        htmlBuilder.AppendLine("<div>");
        htmlBuilder.AppendLine($"<p><b>Account:</b>    {_accountNumber}</p>");
        htmlBuilder.AppendLine($"<p style=\"color: green\"><b>Amount:</b>    ${_amount} {_transactionType}</p>");
        htmlBuilder.AppendLine($"<p><b>TO:</b>    {_senderName}</p>");
        htmlBuilder.AppendLine($"<p><b>Available Balance:</b>   ${_accountBalance}</p>");
        htmlBuilder.AppendLine($"<p><b>Description:</b>    {_transactionDes}</p>");
        htmlBuilder.AppendLine($"<p><b>Time:</b>    {_transactionDate}</p>");
        htmlBuilder.AppendLine("</div>");
        htmlBuilder.AppendLine("</div>");
        return htmlBuilder.ToString();
    }
}