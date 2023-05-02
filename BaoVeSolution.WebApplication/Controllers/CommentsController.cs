using BaoVeSolution.WebApplication.DB;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class CommentsController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        [HttpGet]
        public PartialViewResult GetComments(int blogId)
        {
            var comments = db.Comments.Where(c => c.BlogId == blogId).ToList();
            return PartialView("~/Views/Shared/_MyComments.cshtml", comments);
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