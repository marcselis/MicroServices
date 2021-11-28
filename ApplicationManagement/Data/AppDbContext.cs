using Microsoft.EntityFrameworkCore;
using ApplicationsService.Models;

namespace ApplicationsService.Data
{
  public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Application> Applications { get; set; } = null!;
    }
}
