using BaoVeSolution.WebApplication.DB.Base;
using System.ComponentModel.DataAnnotations;

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

        public int UserCreateId { get; set; }
        public int UserUpdateId { get; set; }
    }
}