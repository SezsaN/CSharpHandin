namespace ClassLibrary.Handin.Interfaces
{
    public interface IContact
    {
        /// <summary>
        /// Contact properties
        /// </summary>
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }

    }
}