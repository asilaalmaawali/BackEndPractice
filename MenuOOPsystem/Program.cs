using MenuOOPsystem.Models;
using Microsoft.Win32;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
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



            if (!phone.StartsWith("+968") || phone.Length != 8)      // validation for phone start with (+968) and accept 8 digit
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
            bool passportExists = context.Passengers.Any(p => p.PassportNumber == passport);  // i want to verified specific data 

            if (passportExists== true)
            {
                Console.WriteLine("This passport number already exists.");
                return;
            }

            Console.Write("Enter Nationality: ");
            string Nationality = Console.ReadLine().Trim();  

            if (Nationality == "")
            {
                Console.WriteLine("Nationality cannot be empty");
                return;
            }

            int PassengerId = context.Passengers.Count + 1;     // // auto generated ID

            context.Passengers.Add(

                new Passenger
                {
                    PassengerId = PassengerId,
                    PassengerName = Name,
                    PassengerEmail = email,
                    PassengerPhone = phone,
                    PassportNumber = passport,
                    Nationality = Nationality,


                });

            Console.WriteLine("Passenger registered successfully");

            Console.WriteLine("Patient registered successfully. Assigned ID:  "+ PassengerId);


        }

        static void AddAircraft() {


            /* Add an Aircraft : When the airline buys a new aircraft, we save its details like model and total seats.The aircraft will be operational by default, 
             and the system gives it a new Aircraft ID.*/       

            Console.Write("Enter aircraft model: ");   // ex : Boeing 737 , Airbus A320 
            string Model = Console.ReadLine().Trim();

            if (Model == "")
            {
                Console.WriteLine("Aircraft model cannot be empty");
                return;
            }

            Console.Write("Enter total seats: ");
            int TotalSeats = int.Parse(Console.ReadLine().Trim());

            if (TotalSeats <= 0)   // if the total of seats less than zero it should appear this message
            {
                Console.WriteLine("Total seats must be greater than 0.");
                return;
            }

            int AircraftId = context.Aircrafts.Count + 1;    // auto generated ID



            context.Aircrafts.Add(
            
            new Aircraft
            {

                AircraftId = AircraftId,
                Model = Model,
                TotalSeats = TotalSeats,
                IsOperational = true // as default   , becuase When we add a new aircraft, it is available/ready for future flights by default.

            });

            Console.WriteLine("Aircraft added successfully");
            Console.WriteLine("Aircraft Model :  "+ Model + "  Total Seats: "+ TotalSeats + "  Assigned ID: " + AircraftId);  //output ex =>  Aircraft Model :  Boeing 737  Total Seats: 10  Assigned ID: 1 

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
            string LicenseNumber = Console.ReadLine().Trim();

            if (LicenseNumber == "")
            {
                Console.WriteLine("license number cannot be empty");
                return;
            }

            Console.Write("Enter flight hours: ");         // enter pilot’s old hours experience.
            int FlightHours = int.Parse(Console.ReadLine());

            if (FlightHours == null)
            {
                Console.WriteLine("flight hours cannot be empty");
                return;
            }

            if (FlightHours < 0)  // the hours cannot be negative
            {
                Console.WriteLine("Flight hours cannot be negative.");
                return;
            }


            int PilotId = context.Pilots.Count + 1;  // auto generated ID

            context.Pilots.Add(

                new Pilot {

                    PilotId = PilotId,
                    PilotName = name,
                    PilotPhone = phone,
                    LicenseNumber = LicenseNumber,
                    FlightHours = FlightHours,
                    IsAvailable = true      // as default because the pilot is free and ready to be assigned to a flight. they are not assigned to any flight yet.
                }

                );


            Console.WriteLine("Pilot registered successfully. Pilot ID:  " + PilotId);
             
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

                Console.WriteLine("                                    ");
                Console.WriteLine("Flight Code: " + f.FlightCode);
                Console.WriteLine("Origin: " + f.origin);
                Console.WriteLine("Destination: " + f.destination);
                Console.WriteLine("Departure Date: " + f.DepartureDate);
                Console.WriteLine("Departure Time: " + f.DepartureTime);
                Console.WriteLine("Available Seats: " + f.AvailableSeats);
                Console.WriteLine("Ticket Price: " + f.TicketPrice);
                Console.WriteLine("Status: " + f.Status);

            }
        }

        static void ScheduleFlight()
        {
            Console.Write("Enter aircraft ID: ");  
            int AircraftId = int.Parse(Console.ReadLine());

            Aircraft aircraft = context.Aircrafts.FirstOrDefault(a => a.AircraftId == AircraftId);   // use FirstOrDefault because the whole object data is needed to be used in the upcoming steps

            if (aircraft == null)
            {

                Console.WriteLine("aircraft not found");
                return;

            }

            if (aircraft.IsOperational == false)
            {
                Console.WriteLine("aircraft is not operational");
                return;

            }

            Console.Write("Enter Pilot Id ID: ");
            int PilotId = int.Parse(Console.ReadLine());

            Pilot pilot = context.Pilots.FirstOrDefault(p => p.PilotId == PilotId);  //Search inside the pilots list and get the pilot whose pilotId matches the entered pilotId

            if (pilot == null)
            {
                Console.WriteLine("pilot not found");
                return;
            }

            if (pilot.IsAvailable == false)  // not available
            {
                Console.WriteLine("Pilot is not available");
                return;
            }

            Console.Write("Enter origin: ");
            string origin = Console.ReadLine().Trim();

            if (origin == "")
            {
                Console.WriteLine("origin cannot be empty");
                return;
            }

            Console.Write("Enter destination:  ");
            string destination = Console.ReadLine().Trim();

            if (destination == "")
            {
                Console.WriteLine("Destination cannot be empty");
                return;
            }

            Console.Write("Enter departure date (dd/MM/yyyy):  ");  // must be 10 Character , and the (/) be in same position of format 
            string DepartureDate = Console.ReadLine().Trim();

            if (DepartureDate == "")
            {
                Console.WriteLine("Departure date cannot be empty");
                return;
            }

            if (DepartureDate.Length != 10 || DepartureDate[2] != '/' || DepartureDate[5] != '/')  // (/) should be in same places
            {
                Console.WriteLine("Invalid date format. re-type in this format=> dd/MM/yyyy ex: 24/06/2026");
                return;
            }

            Console.Write("Enter departure time: ");
            string DepartureTime = Console.ReadLine().Trim();

            if (DepartureTime == "")
            {
                Console.WriteLine("Departure time cannot be empty.");
                return;
            }

            if (DepartureTime.Length != 5 || DepartureTime[2] != ':')  // the length should must be 5 Character if not will catch them, departureTime[2] != ':' => means the third character must be " : "

            {
                Console.WriteLine("Invalid time format. re-type in this format=> HH:mm ex: 09:30");
                return;
            }

            Console.Write("Enter ticket price: ");
            decimal TicketPrice = decimal.Parse(Console.ReadLine());

            if (TicketPrice <= 0)   // the price should not be negative or equal zero
            {
                Console.WriteLine("Ticket price must be more than 0.");
                return;
            }

            int FlightId = context.Flights.Count + 1;  // auto ID generation

            string FlightCode = "OA-" + FlightId;


            context.Flights.Add(

                new Flight
                {
                    FlightId = FlightId,
                    FlightCode = FlightCode,
                    AircraftId = AircraftId,
                    PilotId = PilotId,
                    origin = origin,
                    destination = destination,
                    DepartureDate = DepartureDate,
                    DepartureTime = DepartureTime,
                    TicketPrice = TicketPrice,
                    AvailableSeats = aircraft.TotalSeats,
                    Status = "Scheduled"         // as default because the flight is created but has not departed or cancelled yet
                }

                );

            pilot.IsAvailable = false;  //  pilot is assigned, not free
           

            Console.WriteLine("Flight scheduled successfully.");
            Console.WriteLine("Flight ID: " + FlightId);
            Console.WriteLine("Flight Code: " + FlightCode);

        }


        static void BookFlight()
        {

            Console.WriteLine("Enter the Passenger ID");
            int PassengerId = int.Parse(Console.ReadLine());


            Passenger passenger = context.Passengers.FirstOrDefault(p => p.PassengerId == PassengerId);  // check passenger exsits

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            Console.Write("Enter destination: ");   // ask for destination
            string destination = Console.ReadLine().Trim();

            if (destination == "")
            {
                Console.WriteLine("Destination cannot be empty.");
                return;
            }


             // search for all flights and keep only the flights that the passenger can book.
            List<Flight> availableFlights = context.Flights.Where(f => f.destination .ToLower() == destination.ToLower()   // the flight destination must match what the user typed.
                                                            && f.Status == "Scheduled"  // show only flights that are scheduled
                                                            && f.AvailableSeats > 0)    // still have seats
                                                            .ToList();  // save the matching flights in a list called availableFlights.
           

            if (availableFlights.Count == 0)
            {
                Console.WriteLine("No scheduled flights available to this destination");
                return;
            }


            Console.WriteLine("==Available Flights==");

            foreach (Flight f in availableFlights)
            {
                Console.WriteLine($"ID: {f.FlightId} | Flight Code: {f.FlightCode} | Origin: {f.origin} | Destination: {f.destination} | Date: {f.DepartureDate} | Time: {f.DepartureTime} | Available Seats: {f.AvailableSeats} | Ticket Price: {f.TicketPrice}");
            }



            Console.WriteLine("Enter the Flight ID");


            int FlightId = int.Parse(Console.ReadLine());
            Flight flight = availableFlights.FirstOrDefault(f => f.FlightId == FlightId);  /// to check it matched the user input and use it for another steps

            if (flight == null)
            {
                Console.WriteLine("Invalid flight selection");
                return;
            }

            // to check that passenger cannot booked again same flight , ex: passenger ID try to booked two time same Flight Id the booking will be duplicated. 
            Booking existingBooking = context.Bookings.FirstOrDefault(b =>
                                     b.PassengerId == PassengerId &&
                                     b.FlightId == FlightId &&
                                     b.Status == "confirmed");
            //if this passenger already has a confirmed booking for this flight, stop and do not book again.
            if (existingBooking != null)  
            {
                Console.WriteLine("This passenger already booked this flight.");
                return;
            }


            if (flight.AvailableSeats <= 0)   //before creating booking i need to check if there is a available seats.
            {
                Console.WriteLine("No seats available for this flight");
                return;
            }
            int BookingId = context.Bookings.Count + 1;   // auto generated

            int SeatNumber = context.Bookings.Count(b => b.FlightId == FlightId) + 1;  //means only count bookings for the same flight the passenger selected.
            string seatLabel = "S" + SeatNumber;


            context.Bookings.Add(

                new Booking
                {
                    BookingId = BookingId,
                    PassengerId= PassengerId,
                    FlightId = FlightId,
                    SeatNumber = seatLabel,
                    TotalPrice = flight.TicketPrice,     // total price for the booking is taken from the flight's ticket price
                    Status = "confirmed"
                
                }

                );

           
            flight.AvailableSeats--;  // the flight's available seat count decreases by one

            Console.WriteLine("Booking created successfully");
            Console.WriteLine("Booking ID: " + BookingId);
            Console.WriteLine("Seat Number: " + seatLabel);
            Console.WriteLine("Total Price: " + flight.TicketPrice);


        }


        static void CancelBooking()
        {

            Console.Write("Enter booking ID: ");
            int BookingId = int.Parse(Console.ReadLine());

            Booking booking = context.Bookings.FirstOrDefault(b => b.BookingId == BookingId);  // to search for matching BookingId that entered by user

            if (booking == null)
            {
                Console.WriteLine("Booking not found yet");
                return;
            }

            if (booking.Status == "Cancelled")
            {
                Console.WriteLine("Booking is already cancelled");
                return;
            }

            Flight flight = context.Flights.FirstOrDefault(f => f.FlightId == booking.FlightId);  // get the flight linked to the booking

            if (flight == null)  // if it return null from linq this will appear
            {
                Console.WriteLine("Flight not found");
                return;
            }

            booking.Status = "Cancelled";  // update booking Status to "Cancelled"

            flight.AvailableSeats++;       // return the seat to the flight  // in ViewAllFlight will see 

            Console.WriteLine("Booking cancelled successfully");
            Console.WriteLine("seat returned to the flight"); 


        }

        static void DepartFlight()
        {
            Console.Write("Enter flight ID:  ");
            int FlightId = int.Parse(Console.ReadLine());

            Flight flight = context.Flights.FirstOrDefault(f => f.FlightId == FlightId);  // find the flight by ID


            if (flight == null)
            {
                Console.WriteLine("Flight not found");
                return;
            }

            if (flight.Status != "Scheduled")  //if flight not Scheduled
            {
                Console.WriteLine("Only scheduled flights can depart");
                return;
            }

            Pilot pilot = context.Pilots.FirstOrDefault(p => p.PilotId == flight.PilotId);  // find the pilot assigned to this flight


            if (pilot == null)
            {
                Console.WriteLine("Pilot not found");
                return;
            }

            Console.Write("Enter flight duration in hours: ");
            int flightDuration = int.Parse(Console.ReadLine());  // no need to add it proberty becuase i want just to calculate

            if (flightDuration <= 0)
            {
                Console.WriteLine("Flight duration must be more than 0 and not negative");
                return;
            }

            flight.Status = "Departed";  // change Status to "Departed"

            pilot.FlightHours += flightDuration; // to add it to the pilot's total flight hours

            Console.WriteLine("Flight departed successfully");
            Console.WriteLine("Pilot flight hours updated.    " + "  pilot's total flight hours:  " + pilot.FlightHours);
        }

        static void CancelFlight()
        {

            Console.Write("Enter flight ID: ");
            int FlightId = int.Parse(Console.ReadLine());

            Flight flight = context.Flights.FirstOrDefault(f => f.FlightId == FlightId);  //find the flight by ID


            if (flight == null)  // if return null after linq
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            if (flight.Status == "Cancelled")   // if already cancelled
            {
                Console.WriteLine("Flight is already cancelled");
                return;
            }

            if (flight.Status == "Departed") 
            {
                Console.WriteLine("Cannot cancel a departed flight");
                return;
            }

            flight.Status = "Cancelled";   // Change the flight Status to Cancelled

            //get all confirmed bookings for this flight
            List<Booking> flightBookings = context.Bookings
                                             .Where(b => b.FlightId == FlightId && b.Status == "confirmed")
                                             .ToList();
            

            foreach (Booking booking in flightBookings)  // Cancel each booking linked to this flight
            {
                booking.Status = "Cancelled";
              
            }


            Pilot pilot = context.Pilots.FirstOrDefault(p => p.PilotId == flight.PilotId); // find the pilot assigned to this flight

            if (pilot != null)
            {
                pilot.IsAvailable = true;   // Pilot becomes free again

            }

            Console.WriteLine("Flight cancelled successfully");
            Console.WriteLine("Number of affected bookings:  " + flightBookings.Count);  // reports how many bookings were affected


        }
        static void PassengerBookingHistory()
        {
            Console.Write("Enter passenger ID: ");
            int PassengerId = int.Parse(Console.ReadLine());

            Passenger passenger = context.Passengers.FirstOrDefault(p => p.PassengerId == PassengerId);

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            List<Booking> passengerBookings = context.Bookings.Where(b => b.PassengerId == PassengerId)  
                                                              .ToList();

            if (passengerBookings.Count == 0)
            {
                Console.WriteLine("No booking history for this passenger");
                return;
            }

            decimal totalSpent = 0; // Start the total from 0.

            Console.WriteLine("===== Passenger Booking History =====");

            foreach (Booking booking in passengerBookings)
            {
                Flight flight = context.Flights.FirstOrDefault(f => f.FlightId == booking.FlightId);  // find the flight connected to this booking. 

                if (flight != null)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Flight Code: " + flight.FlightCode);
                    Console.WriteLine("Origin: " + flight.origin);
                    Console.WriteLine("Destination: " + flight.destination);
                    Console.WriteLine("Departure Date: " + flight.DepartureDate);
                    Console.WriteLine("Seat Number: " + booking.SeatNumber);
                    Console.WriteLine("Price Paid: " + booking.TotalPrice);
                    Console.WriteLine("Booking Status: " + booking.Status);

                    if (booking.Status == "confirmed")
                    {
                        totalSpent += booking.TotalPrice;  // add this booking price to the total amount.
                    }
                }
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Total spent on confirmed bookings: " + totalSpent);
        
        }

        static void FlightRevenue_and_LoadFactorReport()
        {
            if (context.Flights.Count == 0)
            {
                Console.WriteLine("No flights found");
                return;
            }

            decimal allFlightsRevenue = 0;
            // show how much money each flight made and how full each flight is.

            Console.WriteLine("===== Flight Revenue Report =====");

            foreach (Flight f in context.Flights.OrderByDescending(f => context.Bookings.Where(b => b.FlightId == f.FlightId && b.Status == "confirmed").Sum(b => b.TotalPrice)))    // go flight by flight  //OrderByDescending to sort from highest revenue to lowest revenue
            {
                Aircraft aircraft = context.Aircrafts.FirstOrDefault(a => a.AircraftId == f.AircraftId);  // find the aircraft used by this flight.

                if (aircraft == null) // if aircraft does not found , skip this flight and go for the second flight
                {
                    Console.WriteLine("Aircraft not found for flight: " + f.FlightCode);
                    continue;  // do not stop the report just skip this flight and continue with rest.
                }




                int TotalSeats = aircraft.TotalSeats;  // i do it inside foreach becuase the aircraft created inside it


                int confirmedBookings = context.Bookings.Count(b =>b.FlightId == f.FlightId && b.Status == "confirmed"); //  Count only confirmed bookings for this flight

                decimal totalRevenue = context.Bookings.Where(b => b.FlightId == f.FlightId && b.Status == "confirmed").Sum(b => b.TotalPrice); //  Add the prices of confirmed bookings only

                decimal loadFactor = ((decimal)confirmedBookings / TotalSeats) * 100;  // Calculate how full the flight is

                allFlightsRevenue += totalRevenue;  // Add this flight revenue to all flights revenue   نجمع دخل هذه الرحله مع دخل كل الرحلات

                // Display flight report
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Flight Code: " + f.FlightCode);
                Console.WriteLine("Route: " + f.origin + " -> " + f.destination);
                Console.WriteLine("Confirmed Bookings: " + confirmedBookings);
                Console.WriteLine("Total Revenue: " + totalRevenue);  // this for each flight
                Console.WriteLine("Load Factor: " + loadFactor.ToString("F2") + "%");  // print only 2 decimal places becuase the number be very long without this format

            }
           

            // Display total revenue from all flights
            Console.WriteLine("--------------------------------");
            Console.WriteLine("All Flights Revenue: " + allFlightsRevenue);  // total flight revenue  مجموع الايرادات  // this for all flight
        }
            static void Main(string[] args)
        {


            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("   Flight Management System   ");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1.  Register a Passenger");
                Console.WriteLine(" 2.  Add an Aircraft");
                Console.WriteLine(" 3.  Register a Pilot");
                Console.WriteLine(" 4.  View All Flights");
                Console.WriteLine(" 5.  Schedule a Flight");
                Console.WriteLine(" 6.  Book a Flight");
                Console.WriteLine(" 7.  Cancel a Booking");
                Console.WriteLine(" 8.  Depart a Flight");
                Console.WriteLine(" 9.  Cancel a Flight");
                Console.WriteLine(" 10. Passenger Booking History");
                Console.WriteLine(" 11. Flight Revenue & Load Factor Report");
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
                        ScheduleFlight();
                        break;
                    case 6:
                        BookFlight();
                        break;
                    case 7:
                        CancelBooking();
                        break;
                    case 8:
                        DepartFlight();
                        break;
                    case 9:
                        CancelFlight();
                        break;
                    case 10:
                        PassengerBookingHistory();
                        break;
                    case 11:
                        FlightRevenue_and_LoadFactorReport(); // تقرير ايرادات الرحلات ومعامل الحموله
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

