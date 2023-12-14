using ClassLibrary.Handin.Interfaces;
using ClassLibrary.Handin.Models;

public class BusinessCustomer : IBusinessCustomer
{
    public string CompanyName { get; set; } = null!;
    public string OrganizationalNumber { get; set; } = null!;
    public IPrivateCustomer ContactPerson { get; set; } = new PrivateCustomer();
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}   