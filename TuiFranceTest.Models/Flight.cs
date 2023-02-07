using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiFranceTest.Models
{
    /// <summary>
    /// Get or set a flight
    /// </summary>
    public class Flight: IEntity
    {
        [Key, Column(Order = 0)] 
        public int Id { get; set; }

        [Column(Order = 1)]
        [StringLength(150, MinimumLength = 1)]
        [Display(Name = nameof(Resources.Flight.Name), ResourceType = typeof(Resources.Flight))]
        public string Name { get; set; }

        [ForeignKey("DepartureAirport"),Column("DepartureAirportIataCode",Order = 2)]
        public string DepartureAirportIataCode { get; set; }
        [ForeignKey("ArrivalAirport"), Column("ArrivalAirportIataCode", Order = 3)]
        public string ArrivalAirportIataCode { get; set; }


        [Display(Name = nameof(Resources.Flight.DepartureAirport), ResourceType = typeof(Resources.Flight))]
        public virtual Airport DepartureAirport { get; set; }

        [Display(Name = nameof(Resources.Flight.ArrivalAirport), ResourceType = typeof(Resources.Flight))]
        public virtual Airport ArrivalAirport { get; set; }
    }
}
