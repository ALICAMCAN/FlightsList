using AutoMapper;
using System.Data.Entity;
using System.Web.Mvc;
using TuiFranceTest.Bal.IServices;
using TuiFranceTest.Bal.Services;
using TuiFranceTest.Dal;
using TuiFranceTest.Infrastructure;
using Unity;
using Unity.Mvc5;

namespace TuiFranceTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<DbContext, TuiFranceTestContext>();
            container.RegisterType<IAirportService, AirportService>();
            container.RegisterType<IFlightService, FlightService>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}