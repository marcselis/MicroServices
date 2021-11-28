using Microsoft.EntityFrameworkCore;
using ApplicationsService.Models;

namespace ApplicationsService.Data
{
  public class ApplicationsRepo : IApplicationsRepo
  {
    private readonly AppDbContext _context;
    public ApplicationsRepo(AppDbContext context)
    {
      _context = context;
    }

    public Task<bool> CheckApplicationExistsAsync(long id)
    {
      return  _context.Applications.AnyAsync(a => a.Id == id);
      ;
    }

    public async Task CreateApplicationAsync(Application Application)
    {
      await _context.Applications.AddAsync(Application ?? throw new ArgumentNullException(nameof(Application)));
    }

    public IEnumerable<Application> GetAllApplications()
    {
      return _context.Applications;
    }

    public Task<Application?> GetApplicationByIdAsync(long id)
    {
      return _context.Applications.Include(p => p.Components).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
      var result = await _context.SaveChangesAsync().ConfigureAwait(false);
      return  result>= 0;
    }
  }
}