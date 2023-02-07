using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiFranceTest.Bal.Models;
using TuiFranceTest.Bal.IServices;

using TuiFranceTest.Dal;
using TuiFranceTest.Models;
using System.Data.Entity.Migrations;

namespace TuiFranceTest.Bal.Services
{
    public class FlightService : IFlightService
    {
        private readonly TuiFranceTestContext _context;
        private readonly IMapper _mapper;

        public FlightService(TuiFranceTestContext Context, IMapper mapper)
        {

            _context = Context;
            _mapper = mapper;
        }

        public IEnumerable<BusinessFlight> GetAllFlights()
        {
            var flights = _context.Flights.AsNoTracking().Include(f => f.DepartureAirport).Include(f => f.ArrivalAirport).AsEnumerable();
            IEnumerable<BusinessFlight> bFlights = _mapper.Map<IEnumerable<Flight>, IEnumerable<BusinessFlight>>(flights);
            return bFlights;
        }

        public BusinessFlight GetFlightById(int id)
        {
            if (id != 0)
            {
                var flight = _context.Flights.AsNoTracking().SingleOrDefault(f => f.Id == id);
                if (flight != null)
                    return _mapper.Map<Flight, BusinessFlight>(flight);
            }
            return null;
        }

        public bool CreateFlight(BusinessFlight flight)
        {
            bool created = false;
                if (flight != null)
                {
                    if (flight.DepartureAirportIataCode == flight.ArrivalAirportIataCode)
                        throw new Exception("DuplicateAirports");

                    var dbFlight = _mapper.Map<BusinessFlight, Flight>(flight);
                    _context.Flights.Add(dbFlight);
                    _context.SaveChanges();
                    created = true;
                }
            return created;
        }

        public async Task<bool> DeleteFlight(int flightId)
        {
            bool deleted = false;
            var flight = await _context.Flights.SingleOrDefaultAsync(f => f.Id == flightId);
            if (flight != null) 
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
                deleted = true;
            }
            return deleted;

        }

        public bool EditFlight(BusinessFlight flight)
        {
            bool updated = false;

            var dataFlight = _context.Flights.AsNoTracking().SingleOrDefault(f => f.Id == flight.Id);
                if (dataFlight != null)
                {
                    if (flight.DepartureAirportIataCode == flight.ArrivalAirportIataCode)
                        throw new Exception("DuplicateAirports");

                    var newDataFlight = _mapper.Map<BusinessFlight, Flight>(flight);
                    _context.Flights.AddOrUpdate(newDataFlight);
                    _context.SaveChanges();
                    updated = true;
                }

            return updated;
        }
    }
}
