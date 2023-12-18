namespace ClassLibrary.Handin.Interfaces;

public interface IContactService
{

    /// <summary>
    /// Add contact to list
    /// </summary>
    /// <param name="contact"></param>
    /// <returns>A contact in list</returns>

    bool AddContactToList(IContact contact);

    /// <summary>
    /// Get all contacts from list
    /// </summary>
    /// <returns>gets all contacts from list</returns>
    IEnumerable<IContact> GetAllContactsFromList();

    /// <summary>
    /// Get a contact from list
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    IContact GetContactFromList(string email);

    /// <summary>
    /// Delete a contact from list
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    IContact DeleteContactFromList(string email);
}
