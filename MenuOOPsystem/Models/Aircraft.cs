using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Aircraft
    {

        public int aircraftId { get; set; } // system generated
        public string model { get; set; } // user input  ( Aircraft model name (e.g. Boeing 737, Airbus A320))
        public int totalSeats { get; set; } //Calculated
        public bool isOperational { get; set; } // Calculated
     
    }
}
