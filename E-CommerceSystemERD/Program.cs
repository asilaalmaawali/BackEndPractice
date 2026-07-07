namespace E_CommerceSystemERD
{
    internal class Program
    {
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
