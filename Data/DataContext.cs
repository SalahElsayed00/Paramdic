using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paramdic.Models;

namespace Paramdic.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<City> cities { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<SocialStatus> socialStatuses { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cases> cases { get; set; }
    }
}
