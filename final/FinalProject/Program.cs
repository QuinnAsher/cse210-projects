using static FinalProject.ObjectCreator;
using static FinalProject.Generator;

namespace FinalProject;

public class Program
{
    private static void Main(string[] args)
    {
        // create a bank object
        var bank = new Bank();
        
        // Console.WriteLine(bank.NumberOfCustomers);
        LoadBank(bank, "customers_data");
        LoadCustomer(bank, "customers_data");
        LoadAllAccounts(bank);
        LoadAllTransaction(bank);
        Console.WriteLine(bank.GetCustomersList.Count);
        
        try
        {
            UserInterface userInterface = new UserInterface(bank);
            // userInterface.CreateCustomer();
            // userInterface.Login("divine132" ,"Chongf1lawas");
            userInterface.Login("obadiah697" ,"Chongf1lawas");
            userInterface.PerformTransaction();
        }
        
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}