using BaoVeSolution.WebApplication.DB;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class CommentsController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        [HttpGet]
        public PartialViewResult GetSubComments(int ComID)
        {
            return PartialView("~/Views/Shared/_MySubComments.cshtml", "");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}