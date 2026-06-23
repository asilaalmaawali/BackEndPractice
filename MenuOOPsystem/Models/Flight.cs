using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Flight
    {

        public int flightId { get; set; } // system generated
        public string flightCode { get; set; } // system generated
        public int aircraftId { get; set; } // from aircrafts list
        public int pilotId { get; set; } //  from pilots list
        public string origin { get; set; } //user input             Departure airport / city
        public string destination { get; set; } //user input        Arrival airport / city
        public string departureDate { get; set; } // 
        public string departureTime { get; set; } // 
        public decimal ticketPrice { get; set; } // Calculated
        public int availableSeats { get; set; } // Calculated
        public string status { get; set; } //  Flight status: Scheduled | Departed | Cancelled
    }
}
