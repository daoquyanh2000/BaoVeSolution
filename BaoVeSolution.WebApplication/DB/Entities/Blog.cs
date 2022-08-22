using BaoVeSolution.WebApplication.DB.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class Blog : BaseEntities
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public string Description { get; set; }
    }

}