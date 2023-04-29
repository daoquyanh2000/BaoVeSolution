using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tên danh mục cha")]
        public int ParentId { get; set; }

        [Display(Name = "Tên đường dẫn")]
        public string Slug { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public ICollection<Blog> Blogs{ get; set; }
        [Display(Name = "Trạng thái danh mục")]
        public CategoryState CategoryState { get; set; }

        //user create and update
        public int? UserCreateId { get; set; }
        [ForeignKey(nameof(UserCreateId))]
        public User UserCreate { get; set; }
        public int? UserUpdateId { get; set; }
        [ForeignKey(nameof(UserUpdateId))]
        public User UserUpdate { get; set; }

        //date create and update
        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Ngày sửa")]
        public DateTime? DateModified { get; set; }
    }
    public enum CategoryState
    {
        [Display(Name = "Hạn chế")]
        Inactive,
        [Display(Name = "Đang chờ duyệt")]
        Pending,

        [Display(Name = "Đang hoạt động")]
        Active
    }
}