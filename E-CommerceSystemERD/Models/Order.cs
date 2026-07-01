using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Order
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId  { get; set; } // system generated
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; } // from list // forign key
        [Required]
        public DateTime OrderDate { get; set; } // system generated
        [Required]
        [Range(0, double.MaxValue)]
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
        public User User { get; set; } // navigation property

    }
}
