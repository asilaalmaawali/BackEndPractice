using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Pilot
    {
        public int PilotId { get; set; } // system generated
        public string PilotName { get; set; } // user input
        public string PilotPhone { get; set; } // user input
        public string LicenseNumber { get; set; } // user input
        public double FlightHours { get; set; } // Calculated
        public bool IsAvailable { get; set; } // by default
    }
}
