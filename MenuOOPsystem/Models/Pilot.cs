using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem.Models
{
    internal class Pilot
    {
        public int pilotId { get; set; } // system generated
        public string pilotName { get; set; } // user input
        public string pilotPhone { get; set; } // user input
        public string licenseNumber { get; set; } // user input
        public int flightHours { get; set; } // Calculated
        public bool isAvailable { get; set; } // Calculated
    }
}
