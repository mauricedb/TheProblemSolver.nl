using System.Web.Mvc;

namespace TheProblemSolver.Controllers
{
#if !DEBUG
    [OutputCache(Duration = 15 * 60)]
#endif
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}