using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    public class LayoutsController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        public ActionResult Footer()
        {
            var layout = db.Layouts.ToList().FirstOrDefault();
            return View(layout);
        }
        // GET: Admin/Layouts
        public ActionResult Index()
        {
            Layout layout = db.Layouts.Find(1);
            if (layout == null)
            {
                return HttpNotFound();
            }
            return View(layout);
        }

        // GET: Admin/Layouts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Layout layout = db.Layouts.Find(id);
            if (layout == null)
            {
                return HttpNotFound();
            }
            return View(layout);
        }

        // POST: Admin/Layouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Layout layout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(layout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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