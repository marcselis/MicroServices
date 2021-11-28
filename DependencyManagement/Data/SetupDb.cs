using DependencyManagement.Models;

namespace DependencyManagement.Data
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
      if (context.Packages == null)
      {
        throw new ArgumentException("Products DbSet is null", nameof(context));
      }
      if (context.Packages.Any())
      {
        Console.WriteLine("Context has data");
        return;
      }
      Console.WriteLine("Seeding data");
      context.Packages.AddRange(
          new Package
          {
            Name = "NServiceBus.Core",
            Version="6.5",
            Type=PackageType.NuGet,
            ProductVersionId=5,
          },
          new Package
          {
            Name = "NServiceBus.Core",
            Version = "7.0",
            Type = PackageType.NuGet,
            ProductVersionId = 6
          }
        );
      context.SaveChanges();
    }
  }
}