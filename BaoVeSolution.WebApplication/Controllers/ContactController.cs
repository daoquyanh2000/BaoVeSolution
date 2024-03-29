﻿using BaoVeSolution.WebApplication.DB;
using System.Linq;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class ContactController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: Contact
        public ActionResult Index()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            return View(layout);
        }
    }
}