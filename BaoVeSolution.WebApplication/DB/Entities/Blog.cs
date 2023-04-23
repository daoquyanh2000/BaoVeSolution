using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Blog : BaseEntities
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Danh mục chứa")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày sửa")]
        public DateTime DateModified { get; set; }

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

        [Display(Name = "Người tạo")]
        public string UserNameCreated { get; set; }

        [Display(Name = "Người Sửa")]
        public string UserNameModified { get; set; }

    }
}