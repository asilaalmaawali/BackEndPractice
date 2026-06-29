using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Flight
    {

        public int FlightId { get; set; } // system generated
        public string FlightCode { get; set; } // system generated
        public int AircraftId { get; set; } // from aircrafts list
        public int PilotId { get; set; } //  from pilots list
        public string origin { get; set; } //user input             Departure airport / city
        public string destination { get; set; } //user input        Arrival airport / city
        public string DepartureDate { get; set; } // user input
        public string DepartureTime { get; set; } // user input
        public double FlightDuration { get; set; } // Calculated
        public decimal TicketPrice { get; set; } // Calculated
        public int AvailableSeats { get; set; } // Calculated
        public string Status { get; set; } //  Flight status: Scheduled | Departed | Cancelled

       
    }
}
