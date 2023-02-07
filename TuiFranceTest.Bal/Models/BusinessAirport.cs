using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TuiFranceTest.Bal.Models.Resources;

namespace TuiFranceTest.Bal.Models
{
    public class BusinessAirport
    {
        [Display(Name = nameof(Resources.BusinessAirport.IataCode), ResourceType = typeof(Resources.BusinessAirport))]
        public string IataCode { get; set; }

        [Display(Name = nameof(Resources.BusinessAirport.Name), ResourceType = typeof(Resources.BusinessAirport))]
        public string Name { get; set;}

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinate Location 
        {
            get { return new GeoCoordinate(Latitude, Longitude); } 
        }

        public BusinessAirport() { }

    }
}
