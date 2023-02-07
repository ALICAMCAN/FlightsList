using System.Collections.Generic;
using TuiFranceTest.Bal.Models;

namespace TuiFranceTest.Bal.IServices
{
    public interface IAirportService
    {
        IEnumerable<BusinessAirport> GetAllAirports();
    }
}
