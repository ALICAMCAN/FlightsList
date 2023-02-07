using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiFranceTest.Models;

namespace TuiFranceTest.Dal
{
    public class TuiFranceTestDBInitializer : DropCreateDatabaseAlways<TuiFranceTestContext>
    {
        protected override void Seed(TuiFranceTestContext context)
        {
            SeedInitialData(context);
            base.Seed(context);
        }

        /// <summary>
        /// Seed InitialData
        /// </summary>
        /// <param name="context">TuiFranceTestContext</param>
        private void SeedInitialData(TuiFranceTestContext context)
        {
            if (!context.Airports.Any())
                SeedAirports(context);

            if (!context.Flights.Any() && context.Airports.Any())
                SeedFlights(context);
        }

        /// <summary>
        /// Seed Airports
        /// </summary>
        /// <param name="context">TuiFranceTestContext</param>
        private static void SeedAirports(TuiFranceTestContext context)
        {
            string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"bin\SeedData\airports_TuiTest.csv");
            try
            {
                var airports = from line in File.ReadAllLines(string.Format("{0}", path)).Skip(1)
                               let columns = line.Split(';')
                               select new Airport()
                               {
                                   IataCode = columns[3],
                                   Name = columns[0],
                                   Latitude = double.Parse(columns[1], CultureInfo.InvariantCulture),
                                   Longitude = double.Parse(columns[2], CultureInfo.InvariantCulture)
                               };
                context.Airports.AddRange(airports);
            }
            catch (Exception)
            {
                context.Airports.AddOrUpdate(
                    new Airport()
                    {
                        Name = "Paris - CDG",
                        IataCode = "CDG",
                        Latitude = 49.012798,
                        Longitude = 2.55
                    },
                    new Airport()
                    {
                        Name = "Paris - Orly",
                        IataCode = "ORY",
                        Latitude = 48.72333,
                        Longitude = 2.37944
                    },
                    new Airport()
                    {
                        Name = "Pointe à Pitre",
                        IataCode = "PTP",
                        Latitude = 16.265301,
                        Longitude = -61.531799
                    },
                    new Airport()
                    {
                        Name = "Fort de France",
                        IataCode = "FDF",
                        Latitude = 14.591,
                        Longitude = -61.003201
                    },
                    new Airport()
                    {
                        Name = "Saint-Denis",
                        IataCode = "RUN",
                        Latitude = -20.890087,
                        Longitude = 55.518894
                    },
                    new Airport()
                    {
                        Name = "Los Angeles",
                        IataCode = "LAX",
                        Latitude = 33.942501,
                        Longitude = -118.407997
                    },
                    new Airport()
                    {
                        Name = "Papeete",
                        IataCode = "PPT",
                        Latitude = -17.553699,
                        Longitude = -149.606995
                    },
                    new Airport()
                    {
                        Name = "Rouen",
                        IataCode = "URO",
                        Latitude = 49.386674,
                        Longitude = 1.183519
                    },
                    new Airport()
                    {
                        Name = "Lyon Saint-Exupéry",
                        IataCode = "LYS",
                        Latitude = 45.725556,
                        Longitude = 5.081111
                    },
                    new Airport()
                    {
                        Name = "Marseille",
                        IataCode = "MRS",
                        Latitude = 43.439271922,
                        Longitude = 5.22142410278
                    });
            }
            finally
            {
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Seed Flights
        /// </summary>
        /// <param name="context">TuiFranceTestContext</param>
        private static void SeedFlights(TuiFranceTestContext context)
        {
            var airports = context.Airports?.ToArray();

            //Create possible random pairs to generate corresponding flights 
            var rnd = new Random();
            List<Flight> flights = new List<Flight>();
            for (int i = 0; i < 30; i++)
            {
                int indexDeparture = rnd.Next(airports.Length - 1);
                int indexArrival = rnd.Next(airports.Length - 1);
                if (indexDeparture != indexArrival)
                {
                    Flight flightToAdd = SetNewFlight(airports[indexDeparture], airports[indexArrival]);
                    if (!flights.Any(f => f.DepartureAirport.IataCode == flightToAdd.DepartureAirport.IataCode && f.ArrivalAirport.IataCode == flightToAdd.ArrivalAirport.IataCode))
                        flights.Add(flightToAdd);
                }
            }
            context.Flights.AddRange(flights);
            context.SaveChanges();
        }

        /// <summary>
        /// Set new flight depending on Airports parameters
        /// </summary>
        /// <param name="from">Airport from</param>
        /// <param name="to">Airport to</param>
        /// <returns>Flight</returns>
        private static Flight SetNewFlight(Airport from, Airport to)
        {
            return new Flight()
            {
                DepartureAirport = from,
                ArrivalAirport = to,
                Name = String.Format("Vol {0} - {1}", from.Name, to.Name)
            };
        }
    }
}
