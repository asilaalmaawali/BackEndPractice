using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Passenger
    {

        public int passengerId { get; set; } // system generated
        public string passengerName { get; set; } // user input
        public string passengerEmail { get; set; } //  user input
        public string passengerPhone { get; set; } // user input
        public string passportNumber { get; set; } // user input     //  Passport / national ID number — must be unique per passenger
        public string nationality { get; set; } // user input



    }
}
