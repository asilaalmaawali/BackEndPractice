using E_CommerceSystemERD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace E_CommerceSystemERD
{
    internal class ECommerceContext : DbContext  // Inherits from DbContext to connect the models with the database.
    {

        public DbSet<Category> Categories { get; set; } // Registers and manages Category records in the database
        public DbSet<Order> Orders { get; set; } // Registers and manages Order records in the database
        public DbSet<Product> Products { get; set; } // Registers and manages Product records in the database
        public DbSet<ProductOrder> ProductOrders { get; set; } // Registers and manages ProductOrder records in the database
        public DbSet<Review> Reviews { get; set; } // Registers and manages Reviews records in the database
        public DbSet<User> Users { get; set; } // Registers and manages Users records in the database



        protected override void OnConfiguring(DbContextOptionsBuilder options)  // Configures the SQL Server database connection
        {
            options.UseSqlServer("Server=localhost;Database=ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True;");   // // Connects the ECommerce system to the SQL Server database
        }









    }
}
