using E_CommerceSystemERD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystemERD
{
    internal class ECommerceContext : DbContext  // to inherits from DbContext to connect the models with the database
    {
        // Registers and manages all model records in the database
        public DbSet<Category> Categories { get; set; }  // Register , Stores and manages Category records
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
