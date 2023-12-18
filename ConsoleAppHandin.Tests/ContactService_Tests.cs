using ClassLibrary.Handin.Interfaces;
using ClassLibrary.Handin.Services;

namespace ConsoleAppHandin.Tests;

public class ContactService_Tests
{
    [Fact]
    public void GetAllContactsFromListShould_GetAllContactsInContactList_ThenReturnListOfContacts()
    {
        // Arrange
        IContactService contactService = new ContactService();

        // Act
        var result = contactService.GetAllContactsFromList();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<IContact>>(result);
 
    }
}
