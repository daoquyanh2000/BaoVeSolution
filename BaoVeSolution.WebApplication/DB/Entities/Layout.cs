using System;
using System.ComponentModel.DataAnnotations;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Layout
    {
        public long Id { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Mô tả")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Giờ mở cửa")]
        public string OpenTime { get; set; }

        [Display(Name = "Giờ Đóng cửa")]
        public string CloseTime { get; set; }
    }
}