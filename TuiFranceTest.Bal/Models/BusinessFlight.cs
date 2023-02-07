using System;
using System.ComponentModel.DataAnnotations;

namespace TuiFranceTest.Bal.Models
{
    public class BusinessFlight
    {
        public int Id { get; set; }
        [Display(Name = nameof(Resources.BusinessFlight.DepartureAirport), ResourceType = typeof(Resources.BusinessFlight))]
        public BusinessAirport DepartureAirport { get; set; }
        [Display(Name = nameof(Resources.BusinessFlight.ArrivalAirport), ResourceType = typeof(Resources.BusinessFlight))]
        public BusinessAirport ArrivalAirport { get; set; }
        [Display(Name = nameof(Resources.BusinessFlight.Name), ResourceType = typeof(Resources.BusinessFlight))]
        public string Name { get; set; }

        [Display(Name = nameof(Resources.BusinessFlight.DepartureAirport), ResourceType = typeof(Resources.BusinessFlight))]
        public string DepartureAirportIataCode { get; set; }

        [Display(Name = nameof(Resources.BusinessFlight.ArrivalAirport), ResourceType = typeof(Resources.BusinessFlight))]
        public string ArrivalAirportIataCode { get; set; }

        public BusinessFlight() { }

        [Display(Name = nameof(Resources.BusinessFlight.Distance), ResourceType = typeof(Resources.BusinessFlight))]
        public double DistanceDepartureArrival
        {
            get
            {
                var meters = DepartureAirport?.Location.GetDistanceTo(ArrivalAirport?.Location) ?? 0;
                return ToKm(meters);
            }
        }

        private double ToKm(double m)
        {
            return Math.Round(m / 1000);
        }
    }
}
