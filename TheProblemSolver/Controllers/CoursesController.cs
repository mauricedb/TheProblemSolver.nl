using System.Web.Mvc;

namespace TheProblemSolver.Controllers
{
#if !DEBUG
    [OutputCache(Duration = 15 * 60)]
#endif
    public class CoursesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult React()
        {
            return View();
        }

        public ActionResult Angular()
        {
            return View();
        }

        public ActionResult TypeScriptForReactDevelopers()
        {
            return View();
        }
    }
}