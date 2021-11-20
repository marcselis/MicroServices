using ProductsService.Models;

namespace ProductsService.Data
{
  public static class SetupDb
  {
    public static void Prepare(IApplicationBuilder app)
    {
      using (var scope = app.ApplicationServices.CreateScope())
      {
        SeedData(scope.ServiceProvider.GetRequiredService<AppDbContext>());
      }
    }

    private static void SeedData(AppDbContext context)
    {
      if (context.Products == null)
      {
        throw new ArgumentException("Products DbSet is null", nameof(context));
      }
      if (context.Products.Any())
      {
        Console.WriteLine("Context has data");
        return;
      }
      Console.WriteLine("Seeding data");
      context.Products.AddRange(
          new Product { Name = "Windows", VendorId = 1, Versions = { new ProductVersion { Version = "10" }, new ProductVersion { Version = "11" } } },
          new Product { Name = "Windows Server", VendorId = 1, Versions = { new ProductVersion { Version = "2016" }, new ProductVersion { Version = "2019" } } }
            );
      context.SaveChanges();
    }
  }
}
