using System.Text;

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


    public static void SaveAllTransactions(Bank bank)
    {
        var filePath = EnsureValidExtension("transactions_data");
        
        // Open the file in append mode
        var writer = new StreamWriter(filePath);
        using (writer)
        {
            foreach (var customer in bank.GetCustomersList)
            {
                // Get current customer's account and transaction history
                var customerAccount = customer.GetCustomerAccount;
                var accountTransactions = customerAccount.GetTransactionHistory;

                // Loop through each transaction and write its string representation
                foreach (var transaction in accountTransactions)
                {
                    writer.WriteLine(transaction.GetStringRepresentation());
                }
            }
        }
    }


    public static void LoadAllTransaction(Bank bank)
    {
        var filePath = EnsureValidExtension("transactions_data");
        var lines = File.ReadAllLines(filePath);
        
        // string[] lines = {
        //     "SingleCrTransaction+ee3ec440057a4d57b0abbb7557742caf|CR|1000|3468165618|1000|14/12/2023 20:43:57|Deposit",
        //     "SingleDrTransaction+555b7a9c01ff4614893efe5c7b648104|DR|1.5|3468165618|998.5|14/12/2023 20:43:57|Deposit Charge",
        // };
        // create a new dictionary object to associate account with transactions
        var transactionMap = new Dictionary<long, List<Transaction>>();
        foreach (var line in lines) 
        {
            //TODO: come and fix the bug that does not add the first transactions to the list;
            //: this issue might be caused by the logic of adding the first transaction from the
            // bank history
            try
            {
                 // if (string.IsNullOrEmpty(line)) continue;
                var parts = line.Split("+");
                {
                    var transactionType = parts[0];
                    var transactionDetails = parts[1];

                    // create a Transaction Object
                    var transaction = CreateTransaction(transactionType, transactionDetails);

                    // this condition checks for a key which is the account number, and if not found it creates a new
                    // key value pair(foreignKey: list<Transactions>) and add the current iterated transaction to the list
                    if (!transactionMap.TryGetValue(transaction.GetForeignKey, out var transactionsList))
                    {
                        transactionsList = new List<Transaction>();
                        transactionMap[transaction.GetForeignKey] = new List<Transaction>();
                        // transactionsList.Add(transaction);
                    }

                    transactionsList.Add(transaction);

                    // associating transactions with account

                    foreach (var account in bank.GetCustomersList.Select(c => c.GetCustomerAccount))
                    {
                        var transactions = transactionMap.GetValueOrDefault(account.GetAccountNumber);
                        if (transactions != null)
                        {
                            foreach (var t in transactions)
                            {
                                if (!IsContainTransaction(t, account)) account.AddTransaction(t);
                            }

                        }

                    }
                }
                //
                // else
                // {
                //     Console.WriteLine($"Error the length of the array is: {parts.Length}");
                // }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        return;

        bool IsContainTransaction(Transaction transaction, Account a)
        {
            return a.GetTransactionHistory.Any(t => t.GetTransactionId == transaction.GetTransactionId);
        }

        bool IsForeignKeyMatch(Transaction transaction, Account a)
        {
            return a.GetAccountNumber == transaction.GetForeignKey;
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


    public static void SaveAllAccounts(Bank bank)
    {
        try
        {
            var filePath = EnsureValidExtension("accounts_data");
            var writer = new StreamWriter(filePath);

            using (writer)
            {
                foreach (var c in bank.GetCustomersList)
                    writer.WriteLine(c.GetCustomerAccount.GetStringRepresentation());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public static void LoadAllAccounts(Bank bank)
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
            var customer =
                bank.GetCustomersList.FirstOrDefault(customer => customer.GetCustomerId == account.GetForeignKey);
            if (customer != null) customer.SetAccount = account;
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


    public static void SaveCustomer(Bank bank, string filePath)
    {
        filePath = EnsureValidExtension(filePath);

        var writer = new StreamWriter(filePath);
        using (writer)
        {
            // var customer = bank.GetCustomersList.FirstOrDefault(c => customerId == c.GetCustomerId);
            // if (customer != null) writer.WriteLine(customer.GetStringRepresentation);
            foreach (var customer in bank.GetCustomersList) writer.WriteLine(customer.GetStringRepresentation);
        }
    }

    public static Customer LoadCustomer(Bank bank, string filePath)
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
            // LoadAccount(bank);
            // LoadTransaction(bank);

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
            // if (string.IsNullOrEmpty(line)) continue;

            // call the LoadCustomer method
            var customer = LoadCustomer(bank, filePath);
        }
    }
}