using BaoVeSolution.WebApplication.DB.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class User 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên người dùng")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public State State { get; set; }

        [Display(Name = "Có phải admin")]
        [Required]
        public bool IsAdmin { get; set; }
        //[ForeignKey(nameof(Blog.Id))]
        public ICollection<Blog> Blogs { get; set; }
        //[ForeignKey(nameof(Category.Id))]
        public ICollection<Category> Categories { get; set; }
        //[ForeignKey(nameof(Comment.Id))]
        public ICollection<Comment> Comments { get; set; }
        //[ForeignKey(nameof(SubComment.Id))]
        public ICollection<SubComment> SubComments { get; set; }


    }
}