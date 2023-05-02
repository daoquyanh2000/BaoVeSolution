using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class BlogDetailController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: BlogDetails
        public ActionResult Index(int? id)
        {
            var blog = db.Blogs
                        .Include(x => x.UserCreate)
                        .Include(x => x.UserUpdate)
                        .SingleOrDefault(x => x.Id == id);
            if (blog == null)
                return RedirectToAction("Index", "MainPage");
            var categories = db.Categories.Where(x => x.CategoryState == CategoryState.Active).ToList();
            ViewBag.categories = categories;

            var blogs = db.Blogs.OrderBy(x => x.DateCreated).Where(x => x.BlogState == BlogState.Active).ToList();
            ViewBag.blogs = blogs;

            var layout = db.Layouts.ToList().FirstOrDefault();

            ViewBag.ApplicationName = layout.ApplicationName;

            ViewBag.CommentUrl = Request.Url.AbsoluteUri;
            return View(blog);
        }
    }
}