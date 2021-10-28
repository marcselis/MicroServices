using VendorManagement.Models;

namespace VendorManagement.Data
{
    public static class SetupDb
    {
        public static void Prepare(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetRequiredService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (context.Vendors==null)
            {
                throw new ArgumentException("Vendors DbSet is null", nameof(context));
            }
            if (context.Vendors.Any())
            {
                Console.WriteLine("Context has data");
                return;
            }
            Console.WriteLine("Seeding data");
            context.Vendors.AddRange(
                new Vendor { Name = "Microsoft" }, new Vendor { Name = "IBM" });
            context.SaveChanges();
        }
    }
}
