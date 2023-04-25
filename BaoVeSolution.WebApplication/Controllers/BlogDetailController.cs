using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var categories = db.Categories.Where(x => x.State == State.Active).ToList();
            ViewBag.categories = categories;

            var blogs = db.Blogs.OrderBy(x => x.DateCreated).Where(x => x.State == State.Active).ToList();
            ViewBag.blogs = blogs;

            var layout = db.Layouts.ToList().FirstOrDefault();

            ViewBag.ApplicationName = layout.ApplicationName;

            var blog = db.Blogs.Find(id);
            return View(blog);
        }
    }
}