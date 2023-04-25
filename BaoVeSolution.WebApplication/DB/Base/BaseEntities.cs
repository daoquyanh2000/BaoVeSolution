using BaoVeSolution.WebApplication.DB.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BaoVeSolution.WebApplication.DB.Base
{
    public class BaseEntities
    {
        [Required]
        [Display(Name = "Trạng thái")]
        public State State { get; set; }
    }

    public enum State
    {
        [Display(Name = "Hạn chế")]
        Inactive,

        [Display(Name = "Đang hoạt động")]
        Active
    }
}