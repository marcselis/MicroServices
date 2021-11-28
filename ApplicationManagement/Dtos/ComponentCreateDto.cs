using System.ComponentModel.DataAnnotations;

namespace ApplicationsService.Dtos
{

  public class ComponentCreateDto
  {
    [Required]
    public string Name { get; set; } = "";
    public string? Description { get; set; }
  }

}
