using ClassLibrary.Handin.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ClassLibrary.Handin.Services;

public class CustomerService : ICustomerService
{
    private readonly IFileServie _fileService = new FileService();
    private List<ICustomer> _customers = [];
    private readonly string _filePath = @"C:\Education\handins\csharp\contacts.json";



    public bool AddCustomerToList(ICustomer customer)
    {
        try
        {
            if (!_customers.Any(x => x.Email == customer.Email))
            {
                _customers.Add(customer);

                string json = JsonConvert.SerializeObject(customer, new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});
                var result = _fileService.SaveContentToFile(_filePath, json );
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public ICustomer GetCustomerFromList(string email)
    {
        try
        {
            GetCustomersFromList();

            var customer = _customers.FirstOrDefault(x => x.Email == email);
            if (customer != null)
            {
                return customer;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<ICustomer> GetCustomersFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _customers = JsonConvert.DeserializeObject<List<ICustomer>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _customers;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
