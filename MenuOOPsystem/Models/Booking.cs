using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Booking
    {
        public int BookingId { get; set; } // system generated
        public int PassengerId { get; set; } // from passengers list
        public int FlightId { get; set; } // from flights list
        public string SeatNumber { get; set; } // system generated       Seat label assigned at booking (e.g. 14A)
        public string BookingDate { get; set; } //  system generated  
        public decimal TotalPrice { get; set; } // Calculated 
        public string Status { get; set; } //  by default                     Booking status: Confirmed | Cancelled



    }
}
