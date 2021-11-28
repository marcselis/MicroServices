using System.Collections.ObjectModel;

namespace DependencyManagement.Models
{
  public class Artifact
  {
    public Collection<Package> PackageReferences { get; set; } = new Collection<Package>();
    public Collection<Assembly> AssemblyReferences { get; set; } = new Collection<Assembly>();
    public Collection<Runtime> Runtimes { get; set; } = new Collection<Runtime>();
  }
}
