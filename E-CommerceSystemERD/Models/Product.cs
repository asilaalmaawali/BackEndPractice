using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD.Models
{
    internal class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public DateTime createdAt { get; set; }  
        public bool isAvailable { get; set; } 

    }
}
