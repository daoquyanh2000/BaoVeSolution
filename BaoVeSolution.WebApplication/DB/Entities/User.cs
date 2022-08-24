using BaoVeSolution.WebApplication.DB.Base;
using System.ComponentModel.DataAnnotations;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class User : BaseEntities
    {
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
    }
}