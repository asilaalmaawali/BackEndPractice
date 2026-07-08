using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    [Table("ProductOrder")]
    internal class ProductOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductOrderId { get; set; }              // system generated


        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; } // navigation property  // becuase we do bridge class so it come now ( order 1 to productorder M)
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; } // navigation property // becuase we do bridge class so it come now ( OrderItem M to Product 1)

        [Required]
        [Range(1, 999)]
        public int quantity { get; set; }                 // user input //  relationship attribute

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }            // calculated 
    }
}
