using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Product
    {

        public int ProductId { get; set; } // sytem generated
        public string ProductName { get; set; } //user input
        public string Description { get; set; } //user input
        public decimal Price { get; set; } //user input
        public int StockQuantity { get; set; } //user input
        public string ImageUrl { get; set; } //user input
        public int CategoryId { get; set; } // from list // forign key
        public DateTime createdAt { get; set; }   // sytem generated
        public bool isAvailable { get; set; }  // as default

    }
}
