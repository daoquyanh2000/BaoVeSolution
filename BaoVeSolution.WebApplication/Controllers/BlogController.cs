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
        public const int PageSize = 1;
        private BaoVeContext db = new BaoVeContext();

        // GET:
        public ActionResult Index(int? categoryId, int page = 1, string keyword = null)
        {
            keyword = keyword ?? "";
            if (categoryId == null)
            {
                return RedirectToAction("Index", "MainPage");
            }
            else
            {
                var blogs = db.Blogs.Where(b => b.CategoryId == categoryId).ToList();
                ViewBag.Category = db.Categories.Find(categoryId);
                return View(blogs.ToPagedList(page, PageSize));
            }
        }
    }
}