using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    public class Categories1Controller : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: Admin/Categories1
        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.UserCreate).Include(c => c.UserUpdate);
            return View(categories.ToList());
        }

        // GET: Admin/Categories1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories1/Create
        public ActionResult Create()
        {
            ViewBag.UserCreateId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.UserUpdateId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Admin/Categories1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ParentId,Slug,Description,CategoryState,UserCreateId,UserUpdateId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserCreateId = new SelectList(db.Users, "Id", "UserName", category.UserCreateId);
            ViewBag.UserUpdateId = new SelectList(db.Users, "Id", "UserName", category.UserUpdateId);
            return View(category);
        }

        // GET: Admin/Categories1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserCreateId = new SelectList(db.Users, "Id", "UserName", category.UserCreateId);
            ViewBag.UserUpdateId = new SelectList(db.Users, "Id", "UserName", category.UserUpdateId);
            return View(category);
        }

        // POST: Admin/Categories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ParentId,Slug,Description,CategoryState,UserCreateId,UserUpdateId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserCreateId = new SelectList(db.Users, "Id", "UserName", category.UserCreateId);
            ViewBag.UserUpdateId = new SelectList(db.Users, "Id", "UserName", category.UserUpdateId);
            return View(category);
        }

        // GET: Admin/Categories1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
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