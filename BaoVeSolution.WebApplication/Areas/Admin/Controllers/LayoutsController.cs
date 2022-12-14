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

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    public class LayoutsController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

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
        public ActionResult Edit([Bind(Include = "Id,Address,PhoneNumber,Email,Description,OpenTime,CloseTime")] Layout layout)
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