using ApplicationsService.Models;

namespace ApplicationsService.Data
{
  public interface IApplicationsRepo
  {
    Task<bool> SaveChangesAsync();
    IEnumerable<Application> GetAllApplications();
    Task<Application?> GetApplicationByIdAsync(long id);
    Task CreateApplicationAsync(Application vendor);
    Task<bool> CheckApplicationExistsAsync(long id);
  }
}