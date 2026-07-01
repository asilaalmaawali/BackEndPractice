using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class User
    {
        public int UserId { get; set; }  // sytem generated
        public string UserName { get; set; } // user input
        public string Email { get; set; } // user input
        public string PasswordHash { get; set; } //user input
        public string FullName { get; set; } //user input
        public string PhoneNumber { get; set; }  //user input
        public string Address { get; set; }  //user input
        public DateTime RegistrationDate { get; set; } // sytem generated
        public bool IsActive { get; set; } // as default

    }
}
