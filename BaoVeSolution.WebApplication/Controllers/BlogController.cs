using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Base;
using BaoVeSolution.WebApplication.DB.Entities;
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
        public const int PageSize = 3;
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
                var category = db.Categories.Find(id);
                ViewBag.Category = category;

                if (category.ParentId == 0)
                {
                    var childCaterories = db.Categories.Where(x => x.ParentId == id).ToList();
                    var blogs = new List<Blog>();
                    foreach (var c in childCaterories)
                    {
                        var blog = db.Blogs.Where(x => x.CategoryId == c.Id).ToList();
                        blogs.AddRange(blog);
                    }
                    return View(blogs.OrderBy(x => x.DateCreated).Where(x => x.State == State.Active).ToPagedList(page, PageSize));
                }
                else
                {
                    var blogs = db.Blogs.Where(b => b.CategoryId == id).ToList();
                    return View(blogs.OrderByDescending(x => x.DateCreated).Where(x => x.State == State.Active).ToPagedList(page, PageSize));
                }
            }
        }
    }
}