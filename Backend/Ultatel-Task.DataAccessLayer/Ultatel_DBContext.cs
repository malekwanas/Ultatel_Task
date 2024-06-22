using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ultatel_Task.Models;

namespace Ultatel_Task.DataAccessLayer
{
    public class Ultatel_DBContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply global query filter for soft delete
            modelBuilder.Entity<Student>().HasQueryFilter(s => !s.IsDeleted);
        }

        public Ultatel_DBContext(DbContextOptions<Ultatel_DBContext> options) : base(options) { }
    }
}
