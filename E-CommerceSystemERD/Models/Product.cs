using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    [Table("Products")]
    internal class Product
    {
        [Key]
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
        [Range(typeof(decimal), "0", "100000")] // Range validation for decimal values , i need to mention "type of" because the range most uses with double si i need to specify that i want type of decimal
        public int StockQuantity { get; set; } = 0; //user input
        [MaxLength(300)]
        public string? ImageUrl { get; set; } //user input
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; } // from list // forign key
        public Category Category { get; set; } // navigation property  // for one

        [Required]
        public DateTime createdAt { get; set; }   // sytem generated
        public bool isAvailable { get; set; } = true; // as default

       

        public ICollection<Review> Reviews { get; set; } //navigation property // for many  // relation : Product - Review

        public ICollection<ProductOrder> ProductOrder { get; set; } //navigation property  // we need to do list from ProductOrder here.  // becuase we do bridge class so it come now ( OrderItem M to Product 1)

    }
}
