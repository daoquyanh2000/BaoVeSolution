using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Base;
using BaoVeSolution.WebApplication.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoVeSolution.WebApplication.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Index(FormCollection fc)
        {
            var userVm = new User();
            userVm.UserName = fc["UserName"].ToString();
            userVm.Password = fc["Password"].ToString();
            User user = db.Users.Where(u => u.UserName == userVm.UserName && u.Password == userVm.Password).FirstOrDefault();
            if (user != null)
            {
                if (user.State == State.Active)
                {
                    Session["UserName"] = user.UserName;
                    Session["UserID"] = user.Id;
                    return Json(new
                    {
                        status = true,
                        icon = "success",
                        heading = "Thành công",
                        message = "Đăng nhập thành công!"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        heading = "Có lỗi",
                        icon = "warning",
                        message = "Tài khoản đăng nhập đã bị khóa!"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    heading = "Có lỗi",
                    icon = "error",
                    message = "Tài khoản không tồn tại hoặc sai thông tin đăng nhập!"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}