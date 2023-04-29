using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        private int pageSize = 9;

        // GET: Admin/Categories

        public ActionResult Index(int page = 1)
        {
            var categories = db.Categories.Where(x => x.ParentId != 0)
                .Include(x => x.UserCreate)
                .Include(x => x.UserUpdate)
                .OrderByDescending(x => x.Id)
                .ToPagedList(page, pageSize);
            var listParentCategory = db.Categories.Where(x => x.ParentId == 0).ToList();
            Session["listParentCategory"] = listParentCategory;
            return View(categories);
        }
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            category.CategoryState = CategoryState.Active;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories
                .Include(x => x.UserCreate)
                .Include(x => x.UserUpdate)
                .SingleOrDefault(x => x.Id == id);
            var listParentCategory = db.Categories.Where(x => x.ParentId == 0).ToList();
            Session["listParentCategory"] = listParentCategory;
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            var selectListItems = db.Categories.Where(x => x.ParentId == 0).ToList()
            .Select(x =>
            new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            Session["selectListItems"] = selectListItems;

            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = ToUrlSlug(category.Name);

                if ((bool)Session["UserIsAdmin"] == false)
                    category.CategoryState = CategoryState.Pending;

                category.UserCreateId = (int)Session["UserId"];
                category.DateCreated = DateTime.Now;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            var selectListItems = db.Categories.Where(x => x.ParentId == 0).ToList()
            .Select(x =>
            new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });
            Session["selectListItems"] = selectListItems;
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

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = ToUrlSlug(category.Name);
                if ((bool)Session["UserIsAdmin"] == false)
                    category.CategoryState = CategoryState.Pending;

                category.UserUpdateId = (int)Session["UserId"];
                category.DateModified = DateTime.Now;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories
                .Include(x => x.UserCreate)
                .Include(x => x.UserUpdate)
                .SingleOrDefault(x => x.Id == id);
            var listParentCategory = db.Categories.Where(x => x.ParentId == 0).ToList();
            Session["listParentCategory"] = listParentCategory;
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public static string ToUrlSlug(string value)
        {
            //First to lower case
            value = value.ToLowerInvariant();

            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
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