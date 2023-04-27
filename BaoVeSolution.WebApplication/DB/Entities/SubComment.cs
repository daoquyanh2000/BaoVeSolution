using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class SubComment : BaseEntities
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        public int ParentId{ get; set; }
        [ForeignKey("ParentId")]
        public Comment ParentComment{ get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
    }
}