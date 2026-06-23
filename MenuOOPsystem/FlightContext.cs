using System;
using System.Collections.Generic;
using System.Text;

namespace MenuOOPsystem
{
    internal class FlightContext         // declare and store alllist here
    {

        public List<Passenger> Passengers { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Aircraft> Aircrafts { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
