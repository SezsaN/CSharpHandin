using ClassLibrary.Handin.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;


namespace ClassLibrary.Handin.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService = new FileService();
    private List<IContact> _contacts = [];
    private readonly string _filePath = @"C:\Education\handins\csharp\contacts.json";
    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        
        return false;
    }

    public IContact DeleteContactFromList(string email)
    {
        try
        {
            var contacts = GetAllContactsFromList();
            var contact = _contacts.FirstOrDefault(x => x.Email == email);

            if (contact != null)
            {
                _contacts.Remove(contact);
                SaveContactsToList(contacts);

            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - DeleteContactFromList:: " + ex.Message); }
        return null!;
    }

    public void SaveContactsToList(IEnumerable<IContact> contacts)
    {
        try
        {
            string json = JsonConvert.SerializeObject(contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            var result = _fileService.SaveContentToFile(_filePath, json);

            if (!result)
            {
                Debug.WriteLine("Failed to save contacts to file.");
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - DeleteContactFromList:: " + ex.Message); }
    }

    public IEnumerable<IContact> GetAllContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                 _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public IContact GetContactFromList(string email)
    {
        try
        {
            GetAllContactsFromList();

            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            if (contact != null)
            {
                return contact;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }
}
