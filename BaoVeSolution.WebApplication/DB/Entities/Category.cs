using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Category : BaseEntities
    {
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
    }
}