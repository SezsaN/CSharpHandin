namespace ClassLibrary.Handin.Interfaces;

public interface ICustomerService
{

    /// <summary>
    /// Adds a customer to the list of customers
    /// </summary>
    /// <param name="customer">a customer of type ICustomer</param>
    /// <returns>Return true if successful, or false if it fails or customer already exists.</returns>
    /// 
    bool AddCustomerToList(ICustomer customer);
    IEnumerable<ICustomer> GetCustomersFromList();
    ICustomer GetCustomerFromList(string email);
}
