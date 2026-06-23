using MenuOOPsystem.Models;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Xml.Linq;

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

        static void RegisterPassenger()
        {

            Console.Write("Enter passenger name: ");
            string Name = Console.ReadLine().Trim();  // It removes spaces from the beginning and end.

            Console.Write("Enter passenger email: ");
            string email = Console.ReadLine().Trim();

            if (!email.Contains("@"))   // email validation should contain @
            {
                Console.WriteLine("Invalid email. Email must contain @");
                return;
            }

            Console.Write("Enter passenger phone:");
            string phone = Console.ReadLine().Trim();

            if (!phone.StartsWith("+968"))      // validation for phone
            {
                Console.WriteLine("Invalid phone number. Please re-type phone must start with +968");
                return;
            }

            Console.Write("Enter passport number: ");
            string passport = Console.ReadLine().Trim();

            if (passport == "")
            {
                Console.WriteLine("Passport number cannot be empty");
                return;
            }

            // to validate if passport exists  or not , should be unique
            bool passportExists = context.Passengers.Any(p => p.passportNumber == passport);  // i want to verified specific data 

            if (passportExists== true)
            {
                Console.WriteLine("This passport number already exists.");
                return;
            }

            Console.Write("Enter nationality: ");
            string nationality = Console.ReadLine().Trim();  

            if (nationality == "")
            {
                Console.WriteLine("Nationality cannot be empty");
                return;
            }

            int passengerId = context.Passengers.Count + 1;     // // auto generated ID

            context.Passengers.Add(

                new Passenger
                {
                    passengerId = passengerId,
                    passengerName = Name,
                    passengerEmail = email,
                    passengerPhone = phone,
                    passportNumber = passport,
                    nationality = nationality,


                });

            Console.WriteLine("Passenger registered successfully");

            Console.WriteLine("Patient registered successfully. Assigned ID:  "+passengerId);


        }

        static void AddAircraft() {


            /* Add an Aircraft : When the airline buys a new aircraft, we save its details like model and total seats.The aircraft will be operational by default, 
             and the system gives it a new Aircraft ID.*/       

            Console.Write("Enter aircraft model: ");   // ex : Boeing 737 , Airbus A320 
            string model = Console.ReadLine().Trim();

            if (model == "")
            {
                Console.WriteLine("Aircraft model cannot be empty");
                return;
            }

            Console.Write("Enter total seats: ");
            int totalSeats = int.Parse(Console.ReadLine().Trim());

            if (totalSeats <= 0)   // if the total of seats less than zero it should appear this message
            {
                Console.WriteLine("Total seats must be greater than 0.");
                return;
            }

            int aircraftId = context.Aircrafts.Count + 1;    // auto generated ID



            context.Aircrafts.Add(
            
            new Aircraft
            {

                aircraftId = aircraftId,
                model = model,
                totalSeats = totalSeats,
                isOperational = true // as default   , becuase When we add a new aircraft, it is available/ready for future flights by default.

            });

            Console.WriteLine("Aircraft added successfully");
            Console.WriteLine("Aircraft Model :  "+ model + "  Total Seats: "+totalSeats +"  Assigned ID: " + aircraftId );  //output ex =>  Aircraft Model :  Boeing 737  Total Seats: 10  Assigned ID: 1 

        }

        static void RegisterPilot()
        {

            Console.Write("Enter pilot name: ");
            string name = Console.ReadLine().Trim();

            if (name == "")
            {
                Console.WriteLine("pilot name cannot be empty");
                return;
            }
            Console.Write("Enter pilot phone: ");
            string phone = Console.ReadLine().Trim();

            if (!phone.StartsWith("+968"))      // validation for phone
            {
                Console.WriteLine("Invalid phone number. Please re-type phone must start with +968");
                return;
            }


            Console.Write("Enter license number: ");
            string licenseNumber = Console.ReadLine().Trim();

            if (licenseNumber == "")
            {
                Console.WriteLine("license number cannot be empty");
                return;
            }

            Console.Write("Enter flight hours: ");
            int flightHours = int.Parse(Console.ReadLine());

            if (licenseNumber == "")
            {
                Console.WriteLine("flight hours cannot be empty");
                return;
            }

            if (flightHours < 0)  // the hours cannot be negative
            {
                Console.WriteLine("Flight hours cannot be negative.");
                return;
            }


            int pilotId = context.Pilots.Count + 1;  // auto generated ID

            context.Pilots.Add(

                new Pilot {

                    pilotId = pilotId,
                    pilotName = name,
                    pilotPhone = phone,
                    licenseNumber = licenseNumber,
                    flightHours = flightHours,
                    isAvailable = true      // as default because the pilot is free and ready to be assigned to a flight. they are not assigned to any flight yet.
                }

                );


            Console.WriteLine("Pilot registered successfully. Pilot ID:  " + pilotId);
             
        }

        static void ViewAllFlights()
        {

            if (context.Flights.Count == 0)  // if there is no flight , there is nothing to view
            {
                Console.WriteLine("No flights found yet");
                return;
            }

            Console.WriteLine("===== All Flights =====");

            foreach (Flight f in context.Flights)
            {

              

                Console.WriteLine($"ID: {f.flightId}  |  Flight Code: {f.flightCode}  |  origin: {f.origin}" +
              $"  |  destination: {f.destination}  |  departure date: {f.departureDate}" +
              $"  |   departure time: {f.departureTime}  |  available seats: {f.availableSeats}" +
              $"  |  ticket price: {f.ticketPrice}|  current status: {f.status}");
            }



        }



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
                        RegisterPassenger();
                         break;
                    case 2:
                        AddAircraft();
                        break;
                    case 3:
                        RegisterPilot();
                        break;
                    case 4:
                        ViewAllFlights();
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
