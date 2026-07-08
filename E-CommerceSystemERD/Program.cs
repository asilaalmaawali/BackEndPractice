using E_CommerceSystemERD.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;

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

        public static void ProductReview()
        {

            Console.WriteLine("===== Add Product Review =====");

            Console.WriteLine("Available Users: ");

            List<User> users = context.Users.ToList(); // get all users records from the database and stores them in a list

            foreach (User u in users)  // to view all the users
            {

                Console.WriteLine(u.UserId + " - " + u.FullName);

            }

            Console.Write("Enter user ID: ");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Available Products: ");

            List<Product> products = context.Products.ToList();  // get all products records from the database and stores them in a list



            foreach (Product p in products)  // to view all the products
            {

                Console.WriteLine(p.ProductId + " - " + p.ProductName);

            }

            Console.Write("Enter product ID: ");
            int ProductId = int.Parse(Console.ReadLine());

            Console.Write("Enter rating from 1 to 5: ");
            int rating = int.Parse(Console.ReadLine());

            if (rating < 1 || rating > 5)   //(Range for rating from 1 to 5)
            {
                Console.WriteLine("Rating must be between 1 and 5");
                return;
            }

            Console.Write("Enter comment (optional, press Enter to skip): ");  // its optinal can be null
            string comment = Console.ReadLine();

            Review review = new Review{
            
            UserId = userId,
            ProductId = ProductId,
            Rating = rating,
            Comment = comment,
            ReviewDate = DateTime.Now 

            };

            
            context.Reviews.Add(review); // Adds the new review to the database
            context.SaveChanges(); // Saves changes in the database
        }

        public static void UpdateProduct()
        {

            Console.WriteLine("===== Update Product =====");

            Console.Write("Enter product ID: ");
            int productId = int.Parse(Console.ReadLine());

            Product product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null) {
                Console.WriteLine("Product not found");
                return;
            }
            // before update

            Console.WriteLine(" === Current infrormation ===");
            Console.WriteLine("Current Product: " + product.ProductName);
            Console.WriteLine("Current Price: " + product.Price);
            Console.WriteLine("Current Availability: " + product.isAvailable);

            Console.Write("Enter updated price : ");
            decimal Updatedprice;
            decimal.TryParse(Console.ReadLine(), out Updatedprice);

            if (Updatedprice <= 0)  // validation should be more than 0
            {
                Console.WriteLine("Price must be greater than 0");
                return;
            }

            Console.Write("Is the product available? (true/false): ");
            bool newAvailability = bool.Parse(Console.ReadLine());

            product.Price = Updatedprice; // Updates the product price
            product.isAvailable = newAvailability; // Updates the product availability status

            context.SaveChanges(); // Saves the updated product data in the database // EF Core detects the change and sends an UPDATE

            Console.WriteLine("Product updated successfully");


        }

        public static void CancelOrder()
        {

            Console.WriteLine(" === Cancel an Order ===");

            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());

            Order order = context.Orders.FirstOrDefault(o => o.OrderId == o.OrderId); //  Fetch the order by ID using FirstOrDefault()

            if (order == null)
            {
                Console.WriteLine("Order not found");
                return;
            }

            if (order.Status == "Cancelled")
            {
                Console.WriteLine("This order is already cancelled");
                return;
            }

            // Load all OrderItems for that order from context.ProductOrder
            List<ProductOrder> orderItems = context.ProductOrders.Where(po => po.OrderID == orderId)
                                                                 .ToList();

            foreach (ProductOrder item in orderItems)
            {
                Product product = context.Products.FirstOrDefault(p => p.ProductId == item.ProductId); // Finds the product

                if (product != null)
                {
                    product.StockQuantity += item.quantity; // Restores the product stock quantity
                }
            }

            order.Status = "Cancelled"; // Changes the order status to Cancelled

            context.SaveChanges(); // Saves the updated order status and restored stock in the database

            Console.WriteLine("Order cancelled successfully");
        }







        public static void DeleteReview()
        {

            Console.WriteLine("===== Delete a Review =====");

            Console.Write("Enter Review ID: ");
            int ReviewId = int.Parse(Console.ReadLine());

            Review review = context.Reviews.FirstOrDefault(r => r.ReviewId == ReviewId);

            if (review != null)
            {
                context.Reviews.Remove(review);
                context.SaveChanges();
                Console.WriteLine("Review deleted successfully");
            }
            else
            {
                Console.WriteLine("Review not found");
            }

        }

        public static void ViewAllProduct()
        {

            Console.WriteLine("=====  View All Products  =====");

            List<Product> products = context.Products.ToList(); //// Gets all products from the database

            foreach (Product p in products)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Product ID: " + p.ProductId);
                Console.WriteLine("Product Name: " + p.ProductName);
                Console.WriteLine("Price: " + p.Price);
                Console.WriteLine("Stock Quantity: " + p.StockQuantity);
                Console.WriteLine("Available: " + p.isAvailable);
            }

            if (products.Count == 0) // to know if there no product display there is no product
            {
                Console.WriteLine("No products found");
                return;
            }
        }
        public static void FilterProducts()
        {


            Console.WriteLine("===== Filter Products by Category and Price Range =====");

            Console.Write("Enter Category ID: ");
            int CategoryId = int.Parse(Console.ReadLine());

            Console.Write("Enter minimum price: ");
            decimal minPrice;
            decimal.TryParse(Console.ReadLine(), out minPrice);

            Console.Write("Enter maximum price: ");
            decimal maxPrice;
            decimal.TryParse(Console.ReadLine(), out maxPrice);

            // filter the priduct by searching for ID and 
            List<Product> products = context.Products.Where(p => CategoryId == CategoryId && p.Price >= minPrice && p.Price <= maxPrice) // filters products by category id and price range
                                                     .OrderBy(p => p.Price)  // orders products by price from lowest to highest by price ascending
                                                     .ToList(); // converts the filtered products into a list



            Console.WriteLine("===== Filtered Products =====");

            foreach (Product p in products) // Displays the filtered and sorted products
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Product ID: " + p.ProductId);
                Console.WriteLine("Product Name: " + p.ProductName);
                Console.WriteLine("Price: " + p.Price);
                Console.WriteLine("Stock Quantity: " + p.StockQuantity);
                Console.WriteLine("Available: " + p.isAvailable);


            }


        }


        public static void PlaceOrder()
        {

            Console.WriteLine("===== Place an Order =====");
            // One user can place many orders But each order belongs to one user , for that we need to see users and link one to order
            //we display users first because the system needs to know which customer is placing the order.
            List<User> users = context.Users.ToList();

            Console.WriteLine("Available Users:");
            foreach (User u in users)
            {
                Console.WriteLine(u.UserId + " - " + u.FullName);
            }

            Console.Write("Enter User ID: ");
            int UserID = int.Parse(Console.ReadLine());

            User SelectedUser = context.Users.FirstOrDefault(u => u.UserId == UserID); // Finds the selected user by UserId

            if (SelectedUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Order order = new Order  // if there is User ID then store this database
            {
                UserId = UserID,
                OrderDate = DateTime.Now,
                TotalAmount = 0
            };

            // do this first to get Order ID:
            context.Orders.Add(order); // Adds the order first to get OrderId
            context.SaveChanges(); // Saves the order and generates OrderId

            decimal totalAmount = 0;
            bool AddMultipleProduct = true;

            while (AddMultipleProduct)
            {
                Console.WriteLine("Available Products:");

                List<Product> products = context.Products.ToList();  // to get all products

                foreach (Product product in products)
                {
                    Console.WriteLine(product.ProductId + " - " + product.ProductName +
                                      " | Price: " + product.Price +
                                      " | Stock: " + product.StockQuantity);
                }

                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Product selectedProduct = context.Products.FirstOrDefault(p => p.ProductId == productId);

                if (selectedProduct == null)
                {
                    Console.WriteLine("Product not found");
                    continue;
                }


                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be more than 0.");
                    continue;
                }

                if (quantity > selectedProduct.StockQuantity)
                {
                    Console.WriteLine("Not enough stock available.");
                    continue;
                }

                ProductOrder orderItem = new ProductOrder
                {
                    OrderID = order.OrderId,
                    ProductId = selectedProduct.ProductId,
                    quantity = quantity,
                    UnitPrice = selectedProduct.Price
                };

                context.ProductOrders.Add(orderItem); // Adds product details to the bridge table

                selectedProduct.StockQuantity -= quantity; // Reduces product stock quantity

                totalAmount += selectedProduct.Price * quantity; // Adds item total to order total

                Console.Write("Do you want to add another product? (yes/no): ");
                string AddMore = Console.ReadLine().ToLower();


                if (AddMore != "yes")  // if say no so will stopped and AddMultipleProduct be false
                {
                    AddMultipleProduct = false;
                }

                order.TotalAmount = totalAmount; // Updates the final order total
                context.SaveChanges(); // Saves all order changes(order items, stock changes, and total amount) to the database

     
            }
            //should be out the loop
            Console.WriteLine("Order placed successfully");
            Console.WriteLine("Order ID: " + order.OrderId);
            Console.WriteLine("Total Amount: " + order.TotalAmount);

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
                Console.WriteLine(" 7.  Delete a Review");
                Console.WriteLine(" 8.  View All Products ");
                Console.WriteLine(" 9.  Filter Products by Category and Price Range ");
                Console.WriteLine(" 0. Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:  // 01 Register a New User
                        RegisterUser();
                        break;
                    case 2: // 02 Add a New Product to a Category
                        AddProduct();
                        break;
                    case 3:  // 03 Place an Order
                        PlaceOrder();
                        break;
                    case 4:    // 04 Write a Product Review
                        ProductReview();
                        break;
                    case 5:  // 05 Update Product Price and Availability
                        UpdateProduct();
                        break;
                    case 6: //06 Cancel an Order
                        CancelOrder();
                        break;

                    case 7: // 07 Delete a Review
                        DeleteReview();
                        break;
                    case 8: // 08 View All Products (Get All)
                        ViewAllProduct();
                        break;
                    case 9: //09 Filter Products by Category and Price Range
                        FilterProducts();
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
                    return;
                }
            }
        }
    }
}
