﻿using ClassLibrary.Handin.Interfaces;

namespace ClassLibrary.Handin.Models
{
    public class Contact : IContact
    {
        /// <summary>
        /// Contact properties set to null
        /// </summary>
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
