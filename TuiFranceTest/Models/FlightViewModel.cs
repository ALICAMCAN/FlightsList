using System.Collections.Generic;
using System.Web.Mvc;
using TuiFranceTest.Models;
namespace TuiFranceTest
{
    public class FlightViewModel
    {
        public string Name { get; set; }
        public Airport DepartureAirport { get; set; }
        public IEnumerable<SelectListItem> AirportsList { get; set; }
        public Airport ArrivalAirport { get; set; }
        public decimal DistanceBetweenDepartureAndArrival { get; set; }
    }
}