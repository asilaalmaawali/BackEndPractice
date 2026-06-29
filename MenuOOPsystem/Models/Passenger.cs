using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Passenger
    {

        public int PassengerId { get; set; } // system generated
        public string PassengerName { get; set; } // user input
        public string PassengerEmail { get; set; } //  user input
        public string PassengerPhone { get; set; } // user input
        public string PassportNumber { get; set; } // user input     //  Passport / national ID number — must be unique per passenger
        public string Nationality { get; set; } // user input



    }
}
