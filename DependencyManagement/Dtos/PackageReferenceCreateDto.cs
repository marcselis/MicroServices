using System.ComponentModel.DataAnnotations;

namespace DependencyManagement.Dtos
{
  public class PackageReferenceCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
    [Required]
    public PackageType Type { get; set; }
  }


}
