namespace FinalProject;

public class CustomerDetails
{
    private string _address;
    private string _emailAddress;
    private string _phoneNumber;
    private DateTime _dateOfBirth;
    


    public CustomerDetails(string address, string emailAddress, string phoneNumber, DateTime dateOfBirth)
    {
        _address = address;
        _emailAddress = emailAddress;
        _phoneNumber = phoneNumber;
        _dateOfBirth = dateOfBirth;
    }
    
    
}