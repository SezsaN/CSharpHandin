namespace ClassLibrary.Handin.Interfaces;

public interface IBusinessCustomer : ICustomer
{
    string CompanyName { get; set; }
    string OrganizationalNumber { get; set; }
    IPrivateCustomer ContactPerson { get; set; }
  
}
