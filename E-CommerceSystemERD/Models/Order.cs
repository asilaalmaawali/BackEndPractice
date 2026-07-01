using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Order
    {

        public int OrderId  { get; set; } // system generated
        public int UserId { get; set; } // from list // forign key
        public DateTime OrderDate { get; set; } // system generated
        public decimal TotalAmount { get; set; } // calculated
        public string Status { get; set; } //user input
        public string ShippingAddress { get; set; } //user input
        public string PaymentMethod { get; set; } //user input
    }
}
