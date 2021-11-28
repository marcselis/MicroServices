using Microsoft.EntityFrameworkCore;
using DependencyManagement.Models;

namespace DependencyManagement.Data
{
  public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Package> Packages { get; set; } = null!;
    }
}
