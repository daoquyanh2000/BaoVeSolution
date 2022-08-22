using BaoVeSolution.WebApplication.DB;
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