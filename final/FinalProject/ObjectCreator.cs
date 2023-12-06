namespace FinalProject;

public static class ObjectCreator
{
    public static string EnsureValidExtension(string filePath)
    {
        if (Path.HasExtension(filePath) && Path.GetExtension(filePath) != ".txt")
            filePath = Path.ChangeExtension(filePath, ".txt");
        else if (!Path.HasExtension(filePath)) filePath += ".txt";

        return filePath;
    }


    public static void SaveTransaction(Account account, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var writer = new StreamWriter(filePath);
        using (writer)
        {
            writer.WriteLine("tType,tID,amount,accNum,dateT,AName");
            foreach (var t in account.GetTransactionHistory)
            {
                writer.WriteLine(t.TransactionToString());
            }
        }
    }
}