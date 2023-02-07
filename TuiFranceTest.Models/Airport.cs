using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuiFranceTest.Models
{
    /// <summary>
    /// Get or set an Airport
    /// </summary>
    public class Airport
    {
        [Key]
        //[StringLength(3, MinimumLength = 3)]
        [Required]
        [Display(Name = nameof(Resources.Airport.IataCode), ResourceType = typeof(Resources.Airport))]
        public string IataCode { get; set; }

        [Required]
        [Display(Name = nameof(Resources.Airport.Name), ResourceType = typeof(Resources.Airport))]
        public string Name { get; set; }

        [Display(Name = nameof(Resources.Airport.Latitude), ResourceType = typeof(Resources.Airport))]
        public double Latitude { get; set; }

        [Display(Name = nameof(Resources.Airport.Longitude), ResourceType = typeof(Resources.Airport))]
        public double Longitude { get; set; }

        [Display(Name = nameof(Resources.Airport.DepartureFlights), ResourceType = typeof(Resources.Airport))]
        public virtual ICollection<Flight> DepartureFlights { get; set; }

        [Display(Name = nameof(Resources.Airport.ArrivalFlights), ResourceType = typeof(Resources.Airport))]
        public virtual ICollection<Flight> ArrivalFlights { get; set; }

    }
}
