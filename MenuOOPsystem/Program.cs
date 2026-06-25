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

            Console.Write("Enter flight hours: ");         // enter pilot’s old hours experience.
            int flightHours = int.Parse(Console.ReadLine());

            if (flightHours == null)
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

                Console.WriteLine("                                    ");
                Console.WriteLine("Flight Code: " + f.flightCode);
                Console.WriteLine("Origin: " + f.origin);
                Console.WriteLine("Destination: " + f.destination);
                Console.WriteLine("Departure Date: " + f.departureDate);
                Console.WriteLine("Departure Time: " + f.departureTime);
                Console.WriteLine("Available Seats: " + f.availableSeats);
                Console.WriteLine("Ticket Price: " + f.ticketPrice);
                Console.WriteLine("Status: " + f.status);

            }
        }

        static void ScheduleFlight()
        {
            Console.Write("Enter aircraft ID: ");  
            int aircraftId = int.Parse(Console.ReadLine());

            Aircraft aircraft = context.Aircrafts.FirstOrDefault(a => a.aircraftId == aircraftId);   // use FirstOrDefault because the whole object data is needed to be used in the upcoming steps

            if (aircraft == null)
            {

                Console.WriteLine("aircraft not found");
                return;

            }

            if (aircraft.isOperational == false)
            {
                Console.WriteLine("aircraft is not operational");
                return;

            }

            Console.Write("Enter Pilot Id ID: ");
            int pilotId = int.Parse(Console.ReadLine());

            Pilot pilot = context.Pilots.FirstOrDefault(p => p.pilotId == pilotId);  //Search inside the pilots list and get the pilot whose pilotId matches the entered pilotId

            if (pilot == null)
            {
                Console.WriteLine("pilot not found");
                return;
            }

            if (pilot.isAvailable == false)  // not available
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
            string departureDate = Console.ReadLine().Trim();

            if (departureDate == "")
            {
                Console.WriteLine("Departure date cannot be empty");
                return;
            }

            if (departureDate.Length != 10 || departureDate[2] != '/' || departureDate[5] != '/')  // (/) should be in same places
            {
                Console.WriteLine("Invalid date format. re-type in this format=> dd/MM/yyyy ex: 24/06/2026");
                return;
            }

            Console.Write("Enter departure time: ");
            string departureTime = Console.ReadLine().Trim();

            if (departureTime == "")
            {
                Console.WriteLine("Departure time cannot be empty.");
                return;
            }

            if (departureTime.Length != 5 || departureTime[2] != ':')  // the length should must be 5 Character if not will catch them, departureTime[2] != ':' => means the third character must be " : "

            {
                Console.WriteLine("Invalid time format. re-type in this format=> HH:mm ex: 09:30");
                return;
            }

            Console.Write("Enter ticket price: ");
            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            if (ticketPrice <= 0)   // the price should not be negative or equal zero
            {
                Console.WriteLine("Ticket price must be more than 0.");
                return;
            }

            int flightId = context.Flights.Count + 1;  // auto ID generation

            string flightCode = "OA-" + flightId;


            context.Flights.Add(

                new Flight
                {
                    flightId = flightId,
                    flightCode = flightCode,
                    aircraftId = aircraftId,
                    pilotId = pilotId,
                    origin = origin,
                    destination = destination,
                    departureDate = departureDate,
                    departureTime = departureTime,
                    ticketPrice = ticketPrice,
                    availableSeats = aircraft.totalSeats,
                    status = "Scheduled"         // as default because the flight is created but has not departed or cancelled yet
                }

                );

            pilot.isAvailable = false;  //  pilot is assigned, not free
           

            Console.WriteLine("Flight scheduled successfully.");
            Console.WriteLine("Flight ID: " + flightId);
            Console.WriteLine("Flight Code: " + flightCode);

        }


        static void BookFlight()
        {

            Console.WriteLine("Enter the Passenger ID");
            int passengerID = int.Parse(Console.ReadLine());


            Passenger passenger = context.Passengers.FirstOrDefault(p => p.passengerId == passengerID);  // check passenger exsits

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
                                                            && f.status == "Scheduled"  // show only flights that are scheduled
                                                            && f.availableSeats > 0)    // still have seats
                                                            .ToList();  // save the matching flights in a list called availableFlights.
           

            if (availableFlights.Count == 0)
            {
                Console.WriteLine("No scheduled flights available to this destination");
                return;
            }


            Console.WriteLine("==Available Flights==");

            foreach (Flight f in availableFlights)
            {
                Console.WriteLine($"ID: {f.flightId} | Flight Code: {f.flightCode} | Origin: {f.origin} | Destination: {f.destination} | Date: {f.departureDate} | Time: {f.departureTime} | Available Seats: {f.availableSeats} | Ticket Price: {f.ticketPrice}");
            }



            Console.WriteLine("Enter the Flight ID");


            int flightID = int.Parse(Console.ReadLine());
            Flight flight = availableFlights.FirstOrDefault(f => f.flightId == flightID);  /// to check it matched the user input and use it for another steps

            if (flight == null)
            {
                Console.WriteLine("Invalid flight selection");
                return;
            }

            // to check that passenger cannot booked again same flight , ex: passenger ID try to booked two time same Flight Id the booking will be duplicated. 
            Booking existingBooking = context.Bookings.FirstOrDefault(b =>
                                     b.passengerId == passengerID &&
                                     b.flightId == flightID &&
                                     b.status == "confirmed");
            //if this passenger already has a confirmed booking for this flight, stop and do not book again.
            if (existingBooking != null)  
            {
                Console.WriteLine("This passenger already booked this flight.");
                return;
            }


            if (flight.availableSeats <= 0)   //before creating booking i need to check if there is a available seats.
            {
                Console.WriteLine("No seats available for this flight");
                return;
            }
            int bookingId = context.Bookings.Count + 1;   // auto generated

            int seatNumber = context.Bookings.Count(b => b.flightId == flightID) + 1;  //means only count bookings for the same flight the passenger selected.
            string seatLabel = "S" + seatNumber;


            context.Bookings.Add(

                new Booking
                { 
                    bookingId = bookingId,
                    passengerId=passengerID,
                    flightId = flightID,
                    seatNumber = seatLabel,     
                    totalPrice = flight.ticketPrice,     // total price for the booking is taken from the flight's ticket price
                    status = "confirmed"
                
                }

                );

           
            flight.availableSeats--;  // the flight's available seat count decreases by one

            Console.WriteLine("Booking created successfully");
            Console.WriteLine("Booking ID: " + bookingId);
            Console.WriteLine("Seat Number: " + seatLabel);
            Console.WriteLine("Total Price: " + flight.ticketPrice);


        }


        static void CancelBooking()
        {

            Console.Write("Enter booking ID: ");
            int bookingID = int.Parse(Console.ReadLine());

            Booking booking = context.Bookings.FirstOrDefault(b => b.bookingId == bookingID);  // to search for matching bookingId that entered by user

            if (booking == null)
            {
                Console.WriteLine("Booking not found yet");
                return;
            }

            if (booking.status == "Cancelled")
            {
                Console.WriteLine("Booking is already cancelled");
                return;
            }

            Flight flight = context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);  // get the flight linked to the booking

            if (flight == null)  // if it return null from linq this will appear
            {
                Console.WriteLine("Flight not found");
                return;
            }

            booking.status = "Cancelled";  // update booking status to "Cancelled"

            flight.availableSeats++;       // return the seat to the flight  // in ViewAllFlight will see 

            Console.WriteLine("Booking cancelled successfully");
            Console.WriteLine("seat returned to the flight"); 


        }

        static void DepartFlight()
        {
            Console.Write("Enter flight ID:  ");
            int flightId = int.Parse(Console.ReadLine());

            Flight flight = context.Flights.FirstOrDefault(f => f.flightId == flightId);  // find the flight by ID


            if (flight == null)
            {
                Console.WriteLine("Flight not found");
                return;
            }

            if (flight.status != "Scheduled")  //if flight not Scheduled
            {
                Console.WriteLine("Only scheduled flights can depart");
                return;
            }

            Pilot pilot = context.Pilots.FirstOrDefault(p => p.pilotId == flight.pilotId);  // find the pilot assigned to this flight


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

            flight.status = "Departed";  // change status to "Departed"

            pilot.flightHours += flightDuration; // to add it to the pilot's total flight hours

            Console.WriteLine("Flight departed successfully");
            Console.WriteLine("Pilot flight hours updated.    " + "  pilot's total flight hours:  " + pilot.flightHours);
        }

        static void CancelFlight()
        {

            Console.Write("Enter flight ID: ");
            int flightId = int.Parse(Console.ReadLine());

            Flight flight = context.Flights.FirstOrDefault(f => f.flightId == flightId);  //find the flight by ID


            if (flight == null)  // if return null after linq
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            if (flight.status == "Cancelled")   // if already cancelled
            {
                Console.WriteLine("Flight is already cancelled");
                return;
            }

            if (flight.status == "Departed") 
            {
                Console.WriteLine("Cannot cancel a departed flight");
                return;
            }

            flight.status = "Cancelled";   // Change the flight status to Cancelled

            //get all confirmed bookings for this flight
            List<Booking> flightBookings = context.Bookings
                                             .Where(b => b.flightId == flightId && b.status == "confirmed")
                                             .ToList();
            

            foreach (Booking booking in flightBookings)  // Cancel each booking linked to this flight
            {
                booking.status = "Cancelled";
              
            }


            Pilot pilot = context.Pilots.FirstOrDefault(p => p.pilotId == flight.pilotId); // find the pilot assigned to this flight

            if (pilot != null)
            {
                pilot.isAvailable = true;   // Pilot becomes free again

            }

            Console.WriteLine("Flight cancelled successfully");
            Console.WriteLine("Number of affected bookings:  " + flightBookings.Count);  // reports how many bookings were affected


        }
        static void PassengerBookingHistory()
        {
            Console.Write("Enter passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            Passenger passenger = context.Passengers.FirstOrDefault(p => p.passengerId == passengerId);

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            List<Booking> passengerBookings = context.Bookings.Where(b => b.passengerId == passengerId)  
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
                Flight flight = context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);  // find the flight connected to this booking. 

                if (flight != null)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Flight Code: " + flight.flightCode);
                    Console.WriteLine("Origin: " + flight.origin);
                    Console.WriteLine("Destination: " + flight.destination);
                    Console.WriteLine("Departure Date: " + flight.departureDate);
                    Console.WriteLine("Seat Number: " + booking.seatNumber);
                    Console.WriteLine("Price Paid: " + booking.totalPrice);
                    Console.WriteLine("Booking Status: " + booking.status);

                    if (booking.status == "confirmed")
                    {
                        totalSpent += booking.totalPrice;  // add this booking price to the total amount.
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

            foreach (Flight f in context.Flights.OrderByDescending(f => context.Bookings.Where(b => b.flightId == f.flightId && b.status == "confirmed").Sum(b => b.totalPrice)))    // go flight by flight  //OrderByDescending to sort from highest revenue to lowest revenue
            {
                Aircraft aircraft = context.Aircrafts.FirstOrDefault(a => a.aircraftId == f.aircraftId);  // find the aircraft used by this flight.

                if (aircraft == null) // if aircraft does not found , skip this flight and go for the second flight
                {
                    Console.WriteLine("Aircraft not found for flight: " + f.flightCode);
                    continue;  // do not stop the report just skip this flight and continue with rest.
                }




                int totalSeats = aircraft.totalSeats;  // i do it inside foreach becuase the aircraft created inside it


                int confirmedBookings = context.Bookings.Count(b =>b.flightId == f.flightId && b.status == "confirmed"); //  Count only confirmed bookings for this flight

                decimal totalRevenue = context.Bookings.Where(b => b.flightId == f.flightId && b.status == "confirmed").Sum(b => b.totalPrice); //  Add the prices of confirmed bookings only

                decimal loadFactor = ((decimal)confirmedBookings / totalSeats) * 100;  // Calculate how full the flight is

                allFlightsRevenue += totalRevenue;  // Add this flight revenue to all flights revenue   نجمع دخل هذه الرحله مع دخل كل الرحلات

                // Display flight report
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Flight Code: " + f.flightCode);
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

