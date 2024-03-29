﻿using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class MainPageController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        public ActionResult Index()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            var blogs = db.Blogs
                .Include(x => x.UserCreate)
                .Include(x => x.UserUpdate)
                .OrderBy(x => x.UserCreateId).Where(x => x.BlogState == BlogState.Active).Take(3).ToList();
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