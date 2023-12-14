using ClassLibrary.Handin.Interfaces;
using ClassLibrary.Handin.Models;
using ClassLibrary.Handin.Services;

namespace ConsoleAppHandin.Services;

public interface IMenuService
{
    void ShowMainMenu();


}

internal class MenuService : IMenuService
{

    private readonly IContactService _contacts = new ContactService();
    private void ShowAddContactMenu()
    {
        IContact contact = new Contact();

        DisplayMenuTitle("ADD CONTACT");
        Console.Write("Enter first name: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Enter last name: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Enter phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;
        Console.Write("Enter email address: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Enter address: ");
        contact.Address = Console.ReadLine()!;

        _contacts.AddContactToList(contact);
    }

    private void ShowAllContactsMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowDeleteContactMenu()
    {
        throw new NotImplementedException();
    }

    private void ShowExitMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit the application? (y/n)");
        var option = Console.ReadLine();

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(0);
            
        }
        else
        {
            Console.WriteLine("Returning to menu options window, please press any key...");
        }
       
    }

    public void ShowMainMenu()
    {
        while(true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Search Contact");
            Console.WriteLine("3. Show All Contacts");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option: ");
            var option = Console.ReadLine();
            
            switch(option)
            {
                case "1":
                    ShowAddContactMenu();
                    break;
                case "2":
                    ShowSearchContactMenu();
                    break;
                case "3":
                    ShowAllContactsMenu();
                    break;
                case "4":
                    ShowDeleteContactMenu();
                    break;
                case "5":
                    ShowExitMenu();
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
            
            Console.ReadKey();
        }
    }

    private void ShowSearchContactMenu()
    {
        throw new NotImplementedException();
    }




    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"## {title} ##");
        Console.WriteLine();
    }
}
