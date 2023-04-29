using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Danh mục chứa")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày sửa")]
        public DateTime? DateModified { get; set; }

        [Required]
        [Display(Name = "Tên tin tức")]
        public string Title { get; set; }

        [Display(Name = "Ảnh")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Thông tin ngắn")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        /*        [Display(Name = "Người tạo")]
                public string UserCreated { get; set; }

                [Display(Name = "Người Sửa")]
                public string UserModified { get; set; }*/

        [Display(Name = "Trạng thái bài viết")]
        public BlogState BlogState { get; set; }

        //user create and update
        public int? UserCreateId { get; set; }

        [ForeignKey(nameof(UserCreateId))]
        public User UserCreate { get; set; }

        public int? UserUpdateId { get; set; }

        [ForeignKey(nameof(UserUpdateId))]
        public User UserUpdate { get; set; }
    }

    public enum BlogState
    {
        [Display(Name = "Hạn chế")]
        Inactive,

        [Display(Name = "Đang chờ duyệt")]
        Pending,

        [Display(Name = "Đang hoạt động")]
        Active
    }
}