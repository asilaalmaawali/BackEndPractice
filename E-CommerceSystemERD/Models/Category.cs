using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    [Index(nameof(CategoryName), IsUnique = true)]  // for unique , outside the class
    internal class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } // system generated
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } //user input
        
        [MaxLength(500)]
        public string? Description { get; set; } // user input  // string?  because it is optional.
        [MaxLength(300)]
        public string? ImageUrl { get; set; } // user input

    }
}
