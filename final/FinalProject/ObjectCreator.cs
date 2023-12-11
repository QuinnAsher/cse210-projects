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


    public static void SaveTransaction(Account account)
    {
        var filePath = EnsureValidExtension("transactions_data");

        var writer = new StreamWriter(filePath, true); // append to file TODO; there might be issue with appending to file
        using (writer)
        {
            foreach (var t in account.GetTransactionHistory)
            {
                bool transactionExit = File.ReadAllLines(filePath).Any(line => line.Contains(t.GetTransactionId));
                if (!transactionExit) continue; 
                writer.WriteLine(t.GetStringRepresentation());
            }
        }
    }

    private static void LoadTransaction(Account account)
    {
        var filePath = EnsureValidExtension("transactions_data");
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;

            var parts = line.Split("+");
            var transactionType = parts[0];
            var transactionDetails = parts[1];

            // create a Transaction Object
            var transaction = CreateTransaction(transactionType, transactionDetails);
            
            // get the foreign key to associate an account with a transaction
            if (!IsForeignKeyMatch(transaction) && !IsContainTransaction(transaction))
            {
                // load the transactions to the associated account
                account.AddTransaction(transaction);
            }
        }

        return;
        
        bool IsContainTransaction(Transaction transaction)
        {
            return account.GetTransactionHistory.Any(t => t.GetTransactionId == transaction.GetTransactionId);
        }

        bool IsForeignKeyMatch(Transaction transaction)
        {
            return account.GetAccountNumber == transaction.GetForeignKey;
        }
    }


    private enum TransactionTypes
    {
        SingleCrTransaction,
        SingleDrTransaction,
        MultipleCrTransaction,
        MultipleDrTransaction
    }

    private static Transaction CreateTransaction(string type, string details)
    {
        if (!Enum.TryParse(type, out TransactionTypes tType)) return null;
        switch (tType)
        {
            case TransactionTypes.SingleDrTransaction:
            {
                Transaction transaction = new SingleDrTransaction(details.Split("|"));
                return transaction;
            }

            case TransactionTypes.SingleCrTransaction:
            {
                Transaction transaction = new SingleCrTransaction(details.Split("|"));
                return transaction;
            }

            case TransactionTypes.MultipleDrTransaction:
            {
                Transaction transaction = new MultipleDrTransaction(details.Split("|"));
                return transaction;
            }

            case TransactionTypes.MultipleCrTransaction:
            {
                Transaction transaction = new MultipleCrTransaction(details.Split("|"));
                return transaction;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    private static void SaveAccount(Account account)
    {
        var filePath = EnsureValidExtension("accounts_data");

        var writer = new StreamWriter(filePath, true);

        using (writer)
        {
            writer.WriteLine(account.GetStringRepresentation());
        }
    }


    private static void LoadAccount(Customer customer)
    {
        var filePath = EnsureValidExtension("accounts_data");

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split("+");

            var accountType = parts[0];
            var accountDetails = parts[1];

            // Create an account object
            var account = CreateAccount(accountType, accountDetails);

            // This associates an account with a customer
            if (customer.GetCustomerId == account.GetForeignKey)
            {
                customer.SetAccount = account;
            }
           
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

        var writer = new StreamWriter(filePath, true);
        using (writer)
        {
            var customer = bank.GetCustomersList.FirstOrDefault(c => customerId == c.GetCustomerId);
            if (customer != null)
            {
                writer.WriteLine(customer.GetStringRepresentation);
                
                // save transaction and account
                SaveAccount(customer.GetCustomerAccount);
                SaveTransaction(customer.GetCustomerAccount);
            }
        }
    }

    private static Customer LoadCustomer(Bank bank, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var lines = File.ReadAllLines(filePath);

        Customer customer = null;
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;

            //create customer objects
            customer = new Customer(line.Split("|"));
            
            // load account and transactions to associate them to customer
            LoadAccount(customer);
            LoadTransaction(customer.GetCustomerAccount);

            // add customer to bank list
            if (!IsContainCustomer(customer)) bank.AddCustomers(customer);
        }

        return customer;

        bool IsContainCustomer(Customer cus)
        {
            return bank.GetCustomersList.Any(c => c.GetCustomerId == cus.GetCustomerId);
        }
    }


    public static void SaveBank(Bank bank, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var writer = new StreamWriter(filePath);

        using (writer)
        {
            writer.WriteLine(bank.ToString());
        }
    }

    public static void LoadBank(Bank bank, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        // read the file and split by line
        var fileContent = File.ReadAllText(filePath);
        var lines = fileContent.Split(Environment.NewLine);

        // iterate each line
        foreach (var line in lines)
        {
            // skip empty line
            if (string.IsNullOrEmpty(line)) continue;

            // call the LoadCustomer method
            Customer customer = LoadCustomer(bank, filePath);
        }
        
    }
}