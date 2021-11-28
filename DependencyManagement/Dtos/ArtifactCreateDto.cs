using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DependencyManagement.Dtos
{
  public class ArtifactCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    [Required]
    public string ComponentId { get; set; } = string.Empty;
    [Required]
    public string ApplicationId { get; set; } = string.Empty;
    public Collection<PackageReferenceCreateDto> PackageReferences { get; set; } = new Collection<PackageReferenceCreateDto>();
    public Collection<RuntimeReferenceCreateDto> Runtimes { get; set; } = new Collection<RuntimeReferenceCreateDto>();
    public Collection<AssemblyReferenceCreateDto> AssemblyReferences { get; set; } = new Collection<AssemblyReferenceCreateDto>();
  }


}
