using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Category : BaseEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string slug { get; set; }
        public int ParentId { get; set; }

    }
}
