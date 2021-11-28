namespace DependencyManagement.Models
{
  public class Package
  {
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public PackageType Type { get; set; }
    public long? ProductVersionId { get; set; } 
  }
}
