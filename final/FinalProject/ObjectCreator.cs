namespace FinalProject;

public static class ObjectCreator
{
    private static string EnsureValidExtension(string filePath)
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
            // writer.WriteLine("type, tType,tID,amount,accNum,dateT,AName");
            foreach (var t in account.GetTransactionHistory) writer.WriteLine(t.TransactionToString());
        }
    }

    public static void LoadTransaction(Account account, string filePath)
    {
        filePath = EnsureValidExtension(filePath);
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split("+");
            var transactionType = parts[0];
            var transactionDetails = parts[1];

            // create a Transaction Object
            var transaction = CreateTransaction(transactionType, transactionDetails);

            // call the isContain method to make sure that duplicate Transactions are not added
            if (!IsContainTransaction(transaction))
                // Console.WriteLine("Transaction created successfully");
                account.AddTransaction(transaction);
        }

        return;

        bool IsContainTransaction(Transaction transaction)
        {
            return account.GetTransactionHistory.Any(t => t.GetTransactionId == transaction.GetTransactionId);
        }
    }


    private enum TransactionTypes
    {
        SingleCrTransaction,
        SingleDrTransaction,
        MultipleCrTransaction,
        MultipleDrTransaction,
    }

    private static Transaction CreateTransaction(string type, string details)
    {
        if (Enum.TryParse(type, out TransactionTypes tType))
            switch (tType)
            {
                case TransactionTypes.SingleDrTransaction:
                {
                    var parts = details.Split("|");
                    var transactionType = parts[0];
                    var transactionId = parts[1];
                    var amount = decimal.Parse(parts[2]);
                    var accountNumber = long.Parse(parts[3]);
                    var accountBalance = decimal.Parse(parts[4]);
                    var transactionDate = DateTime.Parse(parts[5]);
                    var transactionDes = parts[6];

                    // create a Transaction object
                    Transaction transaction =
                        new SingleDrTransaction(amount, accountNumber, accountBalance, transactionDes);

                    // set the object properties
                    transaction.SetTransactionId = transactionId;
                    transaction.SetTransactionType = transactionType;
                    transaction.SetTransactionDate = transactionDate;

                    // Console.WriteLine($"For debugging: {transaction.GetType().Name} created: ");
                    return transaction;
                }

                case TransactionTypes.SingleCrTransaction:
                {
                    var parts = details.Split("|");
                    var transactionType = parts[0];
                    var transactionId = parts[1];
                    var amount = decimal.Parse(parts[2]);
                    var accountNumber = long.Parse(parts[3]);
                    var accountBalance = decimal.Parse(parts[4]);
                    var transactionDate = DateTime.Parse(parts[5]);
                    var transactionDes = parts[6];

                    // create a Transaction object
                    Transaction transaction =
                        new SingleCrTransaction(amount, accountNumber, accountBalance, transactionDes);

                    // set the object properties
                    transaction.SetTransactionId = transactionId;
                    transaction.SetTransactionType = transactionType;
                    transaction.SetTransactionDate = transactionDate;

                    // Console.WriteLine($"For debugging: {transaction.GetType().Name} created: ");
                    return transaction;
                }

                case TransactionTypes.MultipleDrTransaction:
                {
                    var parts = details.Split("|");
                    var transactionType = parts[0];
                    var transactionId = parts[1];
                    var amount = decimal.Parse(parts[2]);
                    var accountNumber = long.Parse(parts[3]);
                    var accountBalance = decimal.Parse(parts[4]);
                    var transactionDate = DateTime.Parse(parts[5]);
                    var transactionDes = parts[6];
                    var receiver = parts[7];

                    // create a Transaction object
                    Transaction transaction =
                        new MultipleDrTransaction(amount, accountNumber, accountBalance, transactionDes, receiver);

                    // set the object properties
                    transaction.SetTransactionId = transactionId;
                    transaction.SetTransactionType = transactionType;
                    transaction.SetTransactionDate = transactionDate;

                    // Console.WriteLine($"For debugging: {transaction.GetType().Name} created: ");
                    return transaction;
                }

                case TransactionTypes.MultipleCrTransaction:
                {
                    var parts = details.Split("|");
                    var transactionType = parts[0];
                    var transactionId = parts[1];
                    var amount = decimal.Parse(parts[2]);
                    var accountNumber = long.Parse(parts[3]);
                    var accountBalance = decimal.Parse(parts[4]);
                    var transactionDate = DateTime.Parse(parts[5]);
                    var transactionDes = parts[6];
                    var sender = parts[7];

                    // create a Transaction object
                    Transaction transaction =
                        new MultipleCrTransaction(amount, accountNumber, accountBalance, transactionDes, sender);

                    // set the object properties
                    transaction.SetTransactionId = transactionId;
                    transaction.SetTransactionType = transactionType;
                    transaction.SetTransactionDate = transactionDate;

                    // Console.WriteLine($"For debugging: {transaction.GetType().Name} created: ");
                    return transaction;
                }
            }

        return null;
    }


    public static void SaveAccount(Customer customer, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var writer = new StreamWriter(filePath);

        using (writer)
        {
            writer.WriteLine(customer.GetCustomerAccount.GetStringRepresentation());
        }
    }


    public static void LoadAccount(Customer customer, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split("+");

            var accountType = parts[0];
            var accountDetails = parts[1];

            // Create an account object
            var account = CreateAccount(accountType, accountDetails);

            // This associates an account with a customer
            customer.SetAccount = account;
        }

        return;

        Account CreateAccount(string accountType, string accountDetails)
        {
            if (Enum.TryParse(accountType, out AccountType accType))
                switch (accType)
                {
                    case AccountType.SavingsAccount:
                    {
                        var parts = accountDetails.Split("|");
                        // create a an account object
                        return new SavingsAccount(parts);
                    }
                    case AccountType.CurrentAccount:
                    {
                        var parts = accountDetails.Split("|");
                        // create a an account object
                        return new CurrentAccount(parts);
                    }

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return null;
        }
    }

    private enum AccountType
    {
        SavingsAccount,
        CurrentAccount
    }


    public static void SaveCustomer(Bank bank, string customerId, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var writer = new StreamWriter(filePath);

        using (writer)
        {
            var customer = bank.GetCustomersList.FirstOrDefault(c => c.GetCustomerId == customerId);
            {
                if (customer != null) writer.WriteLine(customer.GetStringRepresentation);
            }
        }
    }

    public static void LoadCustomer(Bank bank, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split("|");

            //create customer objects
            var customer = new Customer(parts);

            // add customer to bank list
            if (!IsContainCustomer(customer)) bank.AddCustomers(customer);
        }

        bool IsContainCustomer(Customer customer)
        {
            return bank.GetCustomersList.Any(c => c.GetCustomerId == customer.GetCustomerId);
        }
    }


    public static void SaveBank(Bank bank, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        StreamWriter writer = new StreamWriter(filePath);

        using (writer)
        {
            writer.WriteLine(bank.ToString());
        }
    }

    public static void LoadBank(ConsoleInterface @interface, string filePath)
    {
        filePath = EnsureValidExtension(filePath);
        
        // create a bank object
        Bank bank = new Bank();
        
        // read the file and split by line
        string fileContent = File.ReadAllText(filePath);
        string[] lines = fileContent.Split(Environment.NewLine);
        
        // iterate each line
        foreach (string line in lines)
        {
            // skip empty line
            if (string.IsNullOrEmpty(line)) continue;
            
            // Create Customer object
            string[] customerData = line.Split("|");
            Customer customer = new Customer(customerData);
            
            // populate the bank with the customers objects
            bank.AddCustomers(customer);
        }
    }
}