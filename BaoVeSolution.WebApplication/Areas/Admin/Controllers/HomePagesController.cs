using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    public class HomePagesController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: Admin/HomePages
        public ActionResult Index()
        {
            HomePage homePage = db.HomePages.Find(1);
            if (homePage == null)
            {
                return HttpNotFound();
            }
            return View(homePage);
        }

        // GET: Admin/HomePages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePage homePage = db.HomePages.Find(id);
            if (homePage == null)
            {
                return HttpNotFound();
            }
            return View(homePage);
        }

        // POST: Admin/HomePages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YearsExperience,Project,Award,Employees,State")] HomePage homePage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homePage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homePage);
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