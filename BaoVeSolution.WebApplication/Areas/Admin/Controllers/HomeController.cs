using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}