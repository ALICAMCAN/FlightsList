using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using System.Xml.Linq;
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