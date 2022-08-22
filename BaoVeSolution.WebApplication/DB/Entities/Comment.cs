using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Comment : BaseEntities
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ParentId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
