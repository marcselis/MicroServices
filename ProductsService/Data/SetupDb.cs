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
          new Product
          {
            Name = "Windows",
            VendorId = 1,
            Lifecycle = new LifeCycleInfo { Active = new DateOnly(1985, 11, 20) },
            Versions = {
              new ProductVersion {
                Version = "10",
                Lifecycle = new LifeCycleInfo { Active = new DateOnly(2015, 7, 29), PhaseOut = new DateOnly(2021, 10, 5) }
              },
              new ProductVersion {
                Version = "11",
                Lifecycle = new LifeCycleInfo{Active=new DateOnly(2021,10,5) }
              }
            }
          },
          new Product
          {
            Name = "Windows Server",
            VendorId = 1,
            Lifecycle = new LifeCycleInfo { Active = new DateOnly(1993, 7, 27) },
            Versions = {
              new ProductVersion {
                Version = "2016",
                Lifecycle = new LifeCycleInfo { Active = new DateOnly(2016, 10, 15), PhaseOut = new DateOnly(2022, 1, 11), EndOfLife=new DateOnly(2027,1,11) }
              },
              new ProductVersion {
                Version = "2019",
                Lifecycle = new LifeCycleInfo { Active = new DateOnly(2018, 10, 2), PhaseOut = new DateOnly(2024, 1, 9), EndOfLife=new DateOnly(2029,1,9) }
              }
            }
          }
        );
      context.SaveChanges();
    }
  }
}