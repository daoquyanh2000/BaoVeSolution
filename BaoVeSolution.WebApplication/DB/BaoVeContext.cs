using BaoVeSolution.WebApplication.DB.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BaoVeSolution.WebApplication.DB
{
    public class BaoVeContext : System.Data.Entity.DbContext
    {
        public BaoVeContext() : base("BaoVeSolutionDocker")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}