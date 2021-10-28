using Microsoft.EntityFrameworkCore;
using VendorManagement.Models;

namespace VendorManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Vendor> Vendors { get; set; } = null!;
    }
}
