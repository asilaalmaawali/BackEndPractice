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
        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Order Order { get; set; } // navigation property  // becuase we do bridge class so it come now ( order 1 to productorder M)

        public Product Product { get; set; } // navigation property // becuase we do bridge class so it come now ( OrderItem M to Product 1)




    }
}
