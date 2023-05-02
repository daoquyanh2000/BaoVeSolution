using BaoVeSolution.WebApplication.DB;
using BaoVeSolution.WebApplication.DB.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BaoVeSolution.WebApplication.Controllers
{
    public class CommentsController : Controller
    {
        private BaoVeContext db = new BaoVeContext();

        [HttpGet]
        public PartialViewResult CommentPartial(int blogId)
        {
            var comments = db.Comments
                .Where(c => c.BlogId == blogId)
                .OrderByDescending(x => x.DateCreated)
                .ToList();
            ViewBag.blogId = blogId;
            return PartialView("~/Views/Shared/_CommentPartial.cshtml", comments);
        }
        [HttpPost]
        public ActionResult AddNewComment(Comment comment)
        {
            var message = string.Join(" | ", ModelState.Values
                                          .SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage));
            if (comment.Email == null || !IsValidEmail(comment.Email))
            {
                return Json(new
                {
                    icon = "warning",
                    heading = "Thất bại",
                    message = "Email của bạn không đúng định dạng!"
                }, JsonRequestBehavior.AllowGet);
            }
            if (ModelState.IsValid)
            {
                comment.DateCreated = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
                return Json(new
                {
                    status = true,
                    icon = "success",
                    heading = "Thành công",
                    message = "Gửi bình luận thành công!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    heading = "Có lỗi",
                    icon = "error",
                    message = "Gửi bình luận thật bại, bạn phải điền đủ thông tin!"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public ActionResult ReplyPartial(int commentId)
        {
            ViewBag.commentId = commentId;
            return PartialView("~/Views/Shared/_ReplyPartial.cshtml", commentId);
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