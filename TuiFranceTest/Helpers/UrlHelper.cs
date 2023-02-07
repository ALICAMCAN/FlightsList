using System.Web.Mvc;
using TuiFranceTest.Controllers;

namespace TuiFranceTest.Infrastructure
{
    public static class UrlHelperExtension
    {
        public static string Flight(this UrlHelper helper)
        {
            return helper.Action(nameof(FlightController.Index), "Flight");
        }

        public static string AddFlight(this UrlHelper helper)
        {
            return helper.Action(nameof(FlightController.AddFlight), "Flight");
        }

        public static string EditFlight(this UrlHelper helper)
        {
            return helper.Action(nameof(FlightController.EditFlight), "Flight");
        }

        public static string DeleteFlight(this UrlHelper helper)
        {
            return helper.Action(nameof(FlightController.DeleteFlight), "Flight");
        }

        public static string FlightsList(this UrlHelper helper)
        {
            return helper.Action(nameof(FlightController.FlightsList), "Flight");
        }



    }
}
