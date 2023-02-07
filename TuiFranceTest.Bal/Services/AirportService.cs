using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiFranceTest.Bal.IServices;
using TuiFranceTest.Bal.Models;
using TuiFranceTest.Dal;
using TuiFranceTest.Models;

namespace TuiFranceTest.Bal.Services
{
    public  class AirportService : IAirportService
    {
        private readonly TuiFranceTestContext _context;
        private readonly IMapper _mapper;

        public AirportService(TuiFranceTestContext Context, IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;
        }

        public IEnumerable<BusinessAirport> GetAllAirports() 
        {
            var airports = _context.Airports.AsNoTracking().AsEnumerable();
            IEnumerable<BusinessAirport> bAirports = _mapper.Map<IEnumerable<Airport>, IEnumerable<BusinessAirport>>(airports);
            return bAirports;
        }
    }
}
