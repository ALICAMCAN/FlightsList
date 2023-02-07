using AutoMapper;
using TuiFranceTest.Bal.Models;
using TuiFranceTest.Models;

namespace TuiFranceTest.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //airport
            CreateMap<Airport, BusinessAirport>();
            CreateMap<BusinessAirport, Airport>();
            //flight
            CreateMap<Flight, BusinessFlight>().ForMember(bf => bf.DistanceDepartureArrival, option => option.Ignore());
            //CreateMap<BusinessFlight, Flight>().ForMember(f => f.DepartureAirportIataCode, option => option.MapFrom(bf => bf.DepartureAirport.IataCode))
            //                                   .ForMember(f => f.ArrivalAirportIataCode, option => option.MapFrom(bf => bf.ArrivalAirport.IataCode));
            CreateMap<BusinessFlight, Flight>();

        }
    }
}
