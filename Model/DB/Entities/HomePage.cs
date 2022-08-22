using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class HomePage : BaseEntities
    {
        public int Id { get; set; }
        public int YearsExperience { get; set; }
        public int Project { get; set; }
        public int Award { get; set; }
        public int Employees { get; set; }
    }
}
