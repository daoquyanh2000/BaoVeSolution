using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class BlogDetailController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: BlogDetails
        public ActionResult Index(int? id)
        {
            var blog = db.Blogs.Find(id);
            if (blog == null)
                return RedirectToAction("Index", "MainPage");
            var categories = db.Categories.Where(x => x.State == DB.Base.State.Active).ToList();
            ViewBag.categories = categories;

            var blogs = db.Blogs.OrderBy(x => x.DateCreated).Where(x => x.State == BlogState.Active).ToList();
            ViewBag.blogs = blogs;

            var layout = db.Layouts.ToList().FirstOrDefault();

            ViewBag.ApplicationName = layout.ApplicationName;

            ViewBag.CommentUrl = Request.Url.AbsoluteUri;
            return View(blog);
        }
    }
}