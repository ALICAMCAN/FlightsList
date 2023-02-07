using System.Collections.Generic;

namespace TuiFranceTest.Models
{
    public class AirportViewModel
    {
        public string IataCode { get; set; }

        public string Name { get; set; }

        public IEnumerable<Flight> DepartureFlights { get; set; }
        public IEnumerable<Flight> ArrivalFlights { get; set; }
    }
}