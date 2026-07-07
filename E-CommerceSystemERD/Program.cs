using E_CommerceSystemERD.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystemERD
{
    internal class Program
    {

        public static ECommerceContext context = new ECommerceContext();
        public static void RegisterUser()
        {

            Console.WriteLine("===== Register New User =====");

            Console.Write("Enter user name: ");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("User name cannot be empty"); 
                return;
            }

            Console.Write("Enter email: ");
            string email = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty");
                return;
            }

            if (!email.Contains("@") || !email.EndsWith(".com"))  // here to validate should cantain this format
            {
                Console.WriteLine("Email must contain @ and end with .com");
                return;
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password cannot be empty");
                return;
            }

            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters");
                return;
            }

            if (!password.Any(char.IsDigit))  // here to validate should have at least one number
            {
                Console.WriteLine("Password must contain at least one number");
                return;
            }

            string passwordHash = password;  //  // In a real system this would be hashed — stored as plain text here for demo


            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine("Full name cannot be empty");
                return;
            }

            if (fullName.Length < 3)
            {
                Console.WriteLine("Full name must be at least 3 characters");
                return;
            }

            Console.Write("Enter phone number (optional, press Enter to skip): ");  // it optional can be null
            string phone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(phone))  // if not null
            {

                if (!phone.StartsWith("+968") || phone.Length != 12 || !phone.Substring(4).All(char.IsDigit))  // it should start with (+968) and follow with 8 digits and be all number (.All(char.IsDigit))
                {
                    Console.WriteLine("Phone number must start with +968 followed by 8 digits");
                    return;
                }


            }


            Console.Write("Enter address (optional, press Enter to skip): ");
            string address = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(address) && address.Length < 4)
            {
                Console.WriteLine("Address must be at least 4 characters.");
                return;
            }

            // int userId = context.Users.Count() + 1; // Not needed
            // no need to do ID because database will create the UserId automatically when we save.

            User user = new User
            {
                UserName = name,
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash,
                PhoneNumber = phone,
                Address = address,
                RegistrationDate = DateTime.Now,
                IsActive = true
            };

            context.Users.Add(user); // Adds the user to the database
            context.SaveChanges(); // Saves and generates UserId automatically

            Console.WriteLine("User registered successfully");
            Console.WriteLine("New User ID: " + user.UserId);


        }

        public static void AddProduct()
        {
            Console.WriteLine("===== Add New Product =====");

            List<Category> categories = context.Categories.ToList();  // get all category records from the database and stores them in a list

            Console.WriteLine("Available Categories:");  // to see available categories
            foreach (Category category in categories)
            {
                Console.WriteLine(category.CategoryId + " - " + category.CategoryName);
            }


            Console.Write("Enter category ID: ");
            int categoryId;
            int.TryParse(Console.ReadLine(), out categoryId);
   

            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter product description: ");
            string description = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price;
            decimal.TryParse(Console.ReadLine(), out price);

            Console.Write("Enter stock quantity: ");


            int stockQuantity = int.Parse(Console.ReadLine());


            Product product = new Product
            {
                ProductName = productName,
                Description = description,
                Price = price,
                StockQuantity = stockQuantity,
                CategoryId = categoryId,
                createdAt = DateTime.Now,
                isAvailable = true
            };

            // no need to do ID here 
            context.Products.Add(product); // Adds the new product to the database
            context.SaveChanges(); // Saves changes and generates ProductId automatically

            Console.WriteLine("Product added successfully");
            Console.WriteLine("New Product ID: " + product.ProductId);



        }




            static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("   E-Commerce System   ");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1.  Register a New User");
                Console.WriteLine(" 2.  Add a New Product to a Category");
                Console.WriteLine(" 3.  Place an Order");
                Console.WriteLine(" 4.  Write a Product Review");
                Console.WriteLine(" 5.  Update Product Price and Availability");
                Console.WriteLine(" 6.  Cancel an Order");
                Console.WriteLine(" 0. Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                    case 5:
                       
                        break;
                    case 6:
                        
                        break;
                    case 0:
                        exit = true; break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
