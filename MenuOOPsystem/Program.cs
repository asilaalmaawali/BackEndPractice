using Microsoft.Win32;

namespace MenuOOPsystem
{
    internal class Program
    {
        //system storage


        public static FlightContext context = new FlightContext      // to add actual storage 
        {
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>(),
            Aircrafts = new List<Aircraft>(),
            Flights = new List<Flight>(),
            Bookings = new List<Booking>()
        };



        static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("   Flight Management System   ");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1. Register a Passenger");
                Console.WriteLine(" 2. Add an Aircraft");
                Console.WriteLine(" 3. Register a Pilot");
                Console.WriteLine(" 4. View All Flights");
                Console.WriteLine(" 5. Schedule a Flight");
                Console.WriteLine(" 6. Book a Flight");
                Console.WriteLine(" 7. Cancel a Booking");
                Console.WriteLine(" 8. Depart a Flight");
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
                    case 7: 
                        break;
                    case 8:
                        break;
                    case 9: 
                        break;
                    case 10: 
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
