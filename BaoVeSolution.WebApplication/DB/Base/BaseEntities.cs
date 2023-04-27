using BaoVeSolution.WebApplication.DB.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoVeSolution.WebApplication.DB.Base
{
    public class BaseEntities
    {
        [Required]
        [Display(Name = "Trạng thái")]
        public State State { get; set; }
        public int? UserCreateId { get; set; }
        [ForeignKey(nameof(UserCreateId))]
        public User UserCreate { get; set; }
        public int? UserUpdateId { get; set; }
        [ForeignKey(nameof(UserUpdateId))]
        public User UserUpdate { get; set; }
    }

    public enum State
    {
        [Display(Name = "Hạn chế")]
        Inactive,

        [Display(Name = "Đang hoạt động")]
        Active
    }
}