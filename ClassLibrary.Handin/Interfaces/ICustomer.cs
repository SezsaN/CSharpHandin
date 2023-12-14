namespace ClassLibrary.Handin.Interfaces;

public interface ICustomer
{
    Guid Id { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
}
