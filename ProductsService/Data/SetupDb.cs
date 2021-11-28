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
          },
          new Product
          {
            Name = "NServiceBus",
            VendorId = 3,
            Lifecycle = new LifeCycleInfo { Active = new DateOnly(2011, 7, 18) },
            Versions = {
              new ProductVersion
              {
                Version="6.5",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2018,8,30), PhaseOut=new DateOnly(2020,5,29), EndOfLife=new DateOnly(2022,5,29)}
              },
              new ProductVersion
              {
                Version="7.0",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2018,5,29), EndOfLife=new DateOnly(2019,2,28)}
              },
              new ProductVersion
              {
                Version="7.1",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2018,8,30), EndOfLife=new DateOnly(2020,4,23)}
              },
              new ProductVersion
              {
                Version="7.2",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2019,10,23), EndOfLife=new DateOnly(2020,11,8)}
              },
              new ProductVersion
              {
                Version="7.3",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2020,5,8), EndOfLife=new DateOnly(2021,2,14)}
              },
              new ProductVersion
              {
                Version="7.4",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2020,8,14), EndOfLife=new DateOnly(2022,1,14)}
              },
              new ProductVersion
              {
                Version="7.5",
                Lifecycle=new LifeCycleInfo{Active=new DateOnly(2021,7,15) }
              },
              }
          }
        );
      context.SaveChanges();
    }
  }
}