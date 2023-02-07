using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiFranceTest.Bal.Models;

namespace TuiFranceTest.Bal.IServices
{
    public interface IAirportService
    {
        IEnumerable<BusinessAirport> GetAllAirports();
    }
}
