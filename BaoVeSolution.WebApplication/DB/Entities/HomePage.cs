using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class HomePage
    {
        public int Id { get; set; }

        [Display(Name = "Số năm kinh nghiệm")]
        public int YearsExperience { get; set; }

        [Display(Name = "Số dự án đã hoàn thành")]
        public int Project { get; set; }

        [Display(Name = "Số giải thưởng")]
        public int Award { get; set; }

        [Display(Name = "Số nhân viên")]
        public int Employees { get; set; }
    }
}