namespace MenuOOPsystem
{
    internal class Program
    {
        //system storage


        public static FlightContext context = new FlightContext      // to add actual storage 
        {
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>(),
            Aircrafts = new List<Aircraft>(),
            Flights = new List<Flight>(),
            Bookings = new List<Booking>()
        };


















        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
