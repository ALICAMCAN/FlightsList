using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;
using TuiFranceTest.Models;

namespace TuiFranceTest.Models
{
    public  class AirportViewModel
    {
        public string IataCode { get; set; }

        public string Name { get; set; }

        public IEnumerable<Flight> DepartureFlights { get; set; }
        public IEnumerable<Flight> ArrivalFlights { get; set; }
    }
}