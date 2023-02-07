using System.ComponentModel.DataAnnotations;
using System.Device.Location;

namespace TuiFranceTest.Bal.Models
{
    public class BusinessAirport
    {
        [Display(Name = nameof(Resources.BusinessAirport.IataCode), ResourceType = typeof(Resources.BusinessAirport))]
        public string IataCode { get; set; }

        [Display(Name = nameof(Resources.BusinessAirport.Name), ResourceType = typeof(Resources.BusinessAirport))]
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinate Location
        {
            get { return new GeoCoordinate(Latitude, Longitude); }
        }

        public BusinessAirport() { }

    }
}
