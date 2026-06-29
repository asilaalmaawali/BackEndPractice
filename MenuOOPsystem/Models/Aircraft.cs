using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Aircraft
    {

        public int AircraftId { get; set; } // system generated
        public string Model { get; set; } // user input  ( Aircraft model name (e.g. Boeing 737, Airbus A320))
        public int TotalSeats { get; set; } //Calculated
        public bool IsOperational { get; set; } // as default
     
    }
}
