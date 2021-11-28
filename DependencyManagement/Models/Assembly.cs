using System.ComponentModel.DataAnnotations;

namespace DependencyManagement.Models
{
  public class Assembly
  {
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
    public string? Description { get; set; }
    public long? ProducVersionId { get; set; }
  }
}
