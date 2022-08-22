using BaoVeSolution.WebApplication.DB;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class BlogController : Controller
    {
        public const int PageSize = 9;
        private BaoVeContext db = new BaoVeContext();

        // GET:
        public ActionResult Index(int? id, int page = 1, string keyword = null)
        {
            keyword = keyword ?? "";
            if (id == null)
            {
                return RedirectToAction("Index", "MainPage");
            }
            else
            {
                var blogs = db.Blogs.Where(b => b.CategoryId == id).ToList();
                ViewBag.Category = db.Categories.Find(id);
                return View(blogs.ToPagedList(page, PageSize));
            }
        }
    }
}