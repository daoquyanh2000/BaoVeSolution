using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class LayoutController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: Layouts
        public ActionResult Carousel()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            return View(layout);
        }

        public ActionResult Header()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            ViewBag.Category = db.Categories.ToList();
            return View(layout);
        }

        public ActionResult Footer()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            return View(layout);
        }

        public ActionResult PageHeader()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
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