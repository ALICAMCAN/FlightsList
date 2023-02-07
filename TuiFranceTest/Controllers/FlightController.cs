using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TuiFranceTest.Bal.IServices;
using TuiFranceTest.Bal.Models;

namespace TuiFranceTest.Controllers
{
    public class FlightController : BaseController
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;

        public FlightController(IFlightService flightService, IAirportService airportService)
        {
            _flightService = flightService;
            _airportService = airportService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FlightsList()
        {
            var flights = _flightService.GetAllFlights();

            return PartialView("_FlightList", flights.AsEnumerable());
        }

        [HttpGet]
        public ActionResult AddFlight()
        {
            BusinessFlight model = new BusinessFlight();
            ViewBag.AirportsList = _airportService.GetAllAirports().Select(x => new SelectListItem { Value = x.IataCode, Text = String.Format("{0} - {1}", x.IataCode, x.Name) });
            return PartialView("_AddFlight", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFlight(BusinessFlight flight)
        {
            try
            {
                if (String.IsNullOrEmpty(flight.Name))
                    ModelState.AddModelError("Name", "Nom de vol obligatoire");
                if (ModelState.IsValid)
                    if (_flightService.CreateFlight(flight))
                        return Json(new { success = true });
            }
            catch (Exception e)
            {
                if (e.Message == "DuplicateAirports")
                    ModelState.AddModelError("DepartureAirportIataCode", "L'aéroport de départ est égal à l'aéroport d'arrivée");
                else
                    ModelState.AddModelError("Name", e.Message);
            }
            ViewBag.AirportsList = _airportService.GetAllAirports().Select(x => new SelectListItem { Value = x.IataCode, Text = String.Format("{0} - {1}", x.IataCode, x.Name) });
            return PartialView("_AddFlight", flight);
        }

        [HttpGet]
        public ActionResult EditFlight(int flightId)
        {
            var flight = _flightService.GetFlightById(flightId);
            ViewBag.AirportsList = _airportService.GetAllAirports().Select(x => new SelectListItem { Value = x.IataCode, Text = String.Format("{0} - {1}", x.IataCode, x.Name) });

            return PartialView("_EditFlight", flight);
        }

        [HttpPost]
        public ActionResult EditFlight(BusinessFlight flight)
        {
            try
            {
                if (String.IsNullOrEmpty(flight.Name))
                    ModelState.AddModelError("Name", "Nom de vol obligatoire");
                if (ModelState.IsValid)
                    if (_flightService.EditFlight(flight))
                        return Json(new { success = true });
            }
            catch (Exception e)
            {
                if (e.Message == "DuplicateAirports")
                    ModelState.AddModelError("DepartureAirportIataCode", "L'aéroport de départ est égal à l'aéroport d'arrivée");
                else
                    ModelState.AddModelError("Name", e.Message);
            }
            ViewBag.AirportsList = _airportService.GetAllAirports().Select(x => new SelectListItem { Value = x.IataCode, Text = String.Format("{0} - {1}", x.IataCode, x.Name) });
            return PartialView("_EditFlight", flight);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFlight(int flightId)
        {
            if (flightId != 0)
            {
                try
                {
                    await _flightService.DeleteFlight(flightId);
                    return Json(new { success = true });

                }
                catch (Exception e)
                {
                    return Json(new { success = true, error = e.Message }, JsonRequestBehavior.AllowGet);

                }

            }
            else
                return Json(new { success = false, error = "Vol invalide" });

        }
    }
}