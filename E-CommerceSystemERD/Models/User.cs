using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

    }
}
