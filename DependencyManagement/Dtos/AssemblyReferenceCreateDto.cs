using System.ComponentModel.DataAnnotations;

namespace DependencyManagement.Dtos
{
  public class AssemblyReferenceCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
  }


}
