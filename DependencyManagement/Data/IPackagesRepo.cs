using DependencyManagement.Models;

namespace DependencyManagement.Data
{
  public interface IPackagesRepo
  {
    bool SaveChanges();
    IEnumerable<Package> GetAllPackages();
    Package? GetPackageById(long id);
    void CreatePackage(Package package);
  }
}