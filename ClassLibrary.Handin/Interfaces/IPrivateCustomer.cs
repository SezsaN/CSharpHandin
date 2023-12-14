namespace ClassLibrary.Handin.Interfaces;

public interface IPrivateCustomer : ICustomer
{
    string FirstName { get; set; }
    string LastName { get; set; }
}
