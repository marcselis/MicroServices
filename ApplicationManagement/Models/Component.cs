using System.ComponentModel.DataAnnotations;

namespace ApplicationsService.Models
{
  public class Component
  {
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    [Required]
    public Application? Application { get; set; }
  }
}