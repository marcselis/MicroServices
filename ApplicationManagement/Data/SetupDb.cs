using ApplicationsService.Models;

namespace ApplicationsService.Data
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
      if (context.Applications == null)
      {
        throw new ArgumentException("Applications DbSet is null", nameof(context));
      }
      if (context.Applications.Any())
      {
        Console.WriteLine("Context has data");
        return;
      }
      Console.WriteLine("Seeding data");
      context.Applications.AddRange(
          new Application
          {
            Name = "PAS",
            Description="Central service to manags application & functionality authorizations",
            Components = {
              new Component {
                Name = "PAS Runtime",
                Description="PAS Component to get authorization data",
              },
              new Component {
                Name = "PAS Management",
                Description= "PAS Component to manage authorization data"
              }
            }
          },
          new Application
          {
            Name = "e-Communication",
            Description="Central service to send declarations to 3rd parties and to process their responses",
            Components = {
              new Component {
                Name = "RSZ Receiver",
                Description="Receives response files from the Belgian RSZ"
              },
              new Component {
                Name="RSZ Transmitter",
                Description="Transmit declarations to the Belgian RSZ"
              }
            },
          }
        );
      context.SaveChanges();
    }
  }
}