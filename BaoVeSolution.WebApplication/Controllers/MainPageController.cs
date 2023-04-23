using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class MainPageController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        public ActionResult Index()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            var blogs = db.Blogs.OrderBy(x => x.UserNameCreated).Where(x => x.State == State.Active).Take(3).ToList();
            ViewBag.blogs = blogs;
            ViewBag.Home = db.HomePages.ToList().FirstOrDefault();
            return View(layout);
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