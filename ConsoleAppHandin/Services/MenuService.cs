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

        Console.WriteLine();
        Console.WriteLine("Contact added press any key to return to menu...");
    }

    private void ShowAllContactsMenu()
    {
        DisplayMenuTitle("All Contacts in the list");
        var res = _contacts.GetAllContactsFromList();

        if (res != null)
        {
            foreach (var contact in res)
            {
                Console.WriteLine($"First Name: {contact.FirstName}");
                Console.WriteLine($"Last Name: {contact.LastName}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No contacts in the list");
        }

        Console.WriteLine("Press any key to return to menu...");
    }

    private void ShowDeleteContactMenu()
    {
        DisplayMenuTitle("Delete a contact by entering the contacts emailadress");

        Console.Write("Enter email address: ");
        var email = Console.ReadLine();

        if (email != null)
        {
               var res = _contacts.DeleteContactFromList(email);

            if (res != null)
            {
                Console.WriteLine($"First Name: {res.FirstName}");
                Console.WriteLine($"Last Name: {res.LastName}");
                Console.WriteLine($"Phone Number: {res.PhoneNumber}");
                Console.WriteLine($"Email: {res.Email}");
                Console.WriteLine($"Address: {res.Address}");
                Console.WriteLine();
                Console.WriteLine("Contact deleted press any key to return to menu...");
               
            }
            else
            {
                Console.WriteLine("Contact not found press any key to return to menu...");

            }   

            

        }


    }

    private void ShowExitMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit the application? (y/n)");
        var option = Console.ReadLine()!;

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
            Console.WriteLine("4. Delete Contact By Email");
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
        DisplayMenuTitle("Search a contact by entering the contacts emailadress");

        Console.Write("Enter email address: ");
        var email = Console.ReadLine();

        if (email != null)
        {
            var res = _contacts.GetContactFromList(email);

            if (res != null)
            {
                Console.WriteLine($"First Name: {res.FirstName}");
                Console.WriteLine($"Last Name: {res.LastName}");
                Console.WriteLine($"Phone Number: {res.PhoneNumber}");
                Console.WriteLine($"Email: {res.Email}");
                Console.WriteLine($"Address: {res.Address}");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Contact not found press any key to return to menu...");

            }

           
        }

        
    }




    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"## {title} ##");
        Console.WriteLine();
    }
}
