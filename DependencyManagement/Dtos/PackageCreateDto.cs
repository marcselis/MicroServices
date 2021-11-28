using System.ComponentModel.DataAnnotations;

namespace DependencyManagement.Dtos
{
  public class PackageCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
    public PackageType Type { get; set; }
    public long? ProductVersionId { get; set; }
  }
}
