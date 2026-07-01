using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } // sytem generated
        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; } //user input
        [MaxLength(1000)]
        public string? Description { get; set; } //user input
        [Required]
        [Range(0, double.MaxValue)] 
        public decimal Price { get; set; } //user input
        [Required]
        [Range(0, double.MaxValue)]
        public int StockQuantity { get; set; } = 0; //user input
        [MaxLength(300)]
        public string? ImageUrl { get; set; } //user input
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; } // from list // forign key
        [Required]
        public DateTime createdAt { get; set; }   // sytem generated
        public bool isAvailable { get; set; } = true; // as default

    }
}
