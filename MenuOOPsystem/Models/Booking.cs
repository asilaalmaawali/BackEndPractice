using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Booking
    {
        public int bookingId { get; set; } // system generated
        public int passengerId { get; set; } // from passengers list
        public int flightId { get; set; } // from flights list
        public string seatNumber { get; set; } // system generated       Seat label assigned at booking (e.g. 14A)
        public string bookingDate { get; set; } // 
        public decimal totalPrice { get; set; } // Calculated 
        public string status { get; set; } //                       Booking status: Confirmed | Cancelled



    }
}
