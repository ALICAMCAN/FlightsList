using System.Collections.Generic;
using System.Threading.Tasks;
using TuiFranceTest.Bal.Models;
using TuiFranceTest.Models;

namespace TuiFranceTest.Bal.IServices
{
    public interface IFlightService
    {
        IEnumerable<BusinessFlight> GetAllFlights();
        bool CreateFlight(BusinessFlight flight);
        bool EditFlight(BusinessFlight flight);
        Task<bool> DeleteFlight(int flightId);
        BusinessFlight GetFlightById(int id);

    }
}