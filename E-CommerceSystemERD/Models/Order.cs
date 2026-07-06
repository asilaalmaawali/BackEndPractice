using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    [Table("Orders")]
    internal class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId  { get; set; } // system generated
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; } // from list // forign key
        public User User { get; set; } // navigation property

        [Required]
        public DateTime OrderDate { get; set; } // system generated
        [Required]
        [Range(typeof(decimal), "0", "100000")] // Range validation for decimal values , i need to mention "type of" because the range most uses with double si i need to specify that i want type of decimal
        public decimal TotalAmount { get; set; } // calculated
        [Required]
        [MaxLength(30)]
        public string Status { get; set; } = "Pending"; //user input
        [Required]
        [MaxLength(300)]
        public string ShippingAddress { get; set; } //user input
        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } //user input

        public ICollection<ProductOrder> ProductOrder { get; set; } //navigation property  // we need to do list from ProductOrder

    }
}
