using System.Web.Mvc;

namespace TuiFranceTest.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult HttpBadRequest()
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }
    }
}