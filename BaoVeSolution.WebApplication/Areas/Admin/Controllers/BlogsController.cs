using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BlogsController : Controller
    {
        private BaoVeContext db = new BaoVeContext();
        private int pageSize = 3;
        private string pathFolder = "/Content/Blog/Image/";

        // GET: Admin/Blogs
        public ActionResult Index(int page = 1)
        {
            var blogs = db.Blogs.OrderByDescending(x => x.Id).ToList().ToPagedList(page, pageSize);
            var listParentCategory = db.Categories.ToList();
            Session["listParentCategory"] = listParentCategory;
            return View(blogs);
        }

        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            blog.BlogState = BlogState.Active;
            db.Entry(blog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            var listParentCategory = db.Categories.ToList();
            Session["listParentCategory"] = listParentCategory;
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            SetSelectListItem();
            return View();
        }

        [ValidateInput(false)]

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                //save image
                if (!Directory.Exists(pathFolder))
                {
                    Directory.CreateDirectory(Server.MapPath(pathFolder));
                }
                string pathImage = string.Empty;

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        pathImage = pathFolder + fileName;
                    }
                }
                blog.ImagePath = pathImage;
                if (Session["UserName"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                if((bool)Session["UserIsAdmin"] == false)
                    blog.BlogState = BlogState.Pending;

                blog.UserCreated = Session["UserName"].ToString();
                blog.DateCreated = DateTime.Now;
                blog.Guid = Guid.NewGuid();
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            SetSelectListItem();

            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [ValidateInput(false)]

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                //save image
                if (!Directory.Exists(pathFolder))
                {
                    Directory.CreateDirectory(Server.MapPath(pathFolder));
                }
                string pathImage = string.Empty;

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        //delete old image file
                        if (System.IO.File.Exists(Request.MapPath(blog.ImagePath)))
                        {
                            System.IO.File.Delete(Request.MapPath(blog.ImagePath));
                        }
                        var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        pathImage = pathFolder + fileName;
                    }
                    else
                    {
                        pathImage = blog.ImagePath;
                    }
                }
                if ((bool)Session["UserIsAdmin"] == false)
                    blog.BlogState = BlogState.Pending;

                blog.ImagePath = pathImage;
                blog.DateModified = DateTime.Now;
                blog.UserModified = Session["UserName"].ToString();
                db.Entry(blog).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Blog blog = db.Blogs.Find(id);
            var listParentCategory = db.Categories.ToList();
            Session["listParentCategory"] = listParentCategory;
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            //delete old image file
            if (System.IO.File.Exists(Request.MapPath(blog.ImagePath)))
            {
                System.IO.File.Delete(Request.MapPath(blog.ImagePath));
            }
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

        private void SetSelectListItem()
        {
            var selectListItems = db.Categories.Where(x => x.ParentId != 0)
                .OrderByDescending(x => x.Id)
                .ToList()
            .Select(x =>
            new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            Session["selectListItems"] = selectListItems;
        }
    }
}