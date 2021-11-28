using DependencyManagement.Models;

namespace DependencyManagement.Data
{
  public class PackagesRepo : IPackagesRepo
  {
    private readonly AppDbContext _context;

    public PackagesRepo(AppDbContext context)
    {
      _context = context;
    }

    public void CreatePackage(Package Package)
    {
      _context.Packages.Add(Package ?? throw new ArgumentNullException(nameof(Package)));
    }

    public IEnumerable<Package> GetAllPackages()
    {
      return _context.Packages;
    }

    public Package? GetPackageById(long id)
    {
      return _context.Packages.FirstOrDefault(v => v.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }
  }
}