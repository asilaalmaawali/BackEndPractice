using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    [Table("Users")]
    [Index(nameof(UserName), IsUnique = true)]  // for unique , outside the class
    [Index(nameof(Email), IsUnique = true)]  // for unique , outside the class
    internal class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }  // sytem generated
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } // user input
        [Required]
        [MaxLength(150)]
        public string Email { get; set; } // user input
        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } //user input
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } //user input
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }  //user input
        [MaxLength(300)]
        public string? Address { get; set; }  //user input
        [Required]
        public DateTime RegistrationDate { get; set; } // sytem generated
        public bool IsActive { get; set; } = true; // as default

        public ICollection<Order> Orders { get; set; } //navigation property // for many

        public ICollection<Review> Reviews { get; set; } //navigation property
    }
}
