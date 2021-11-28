using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationsService.Dtos
{

  public class ApplicationCreateDto
  {
    [Required]
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public Collection<ComponentCreateDto> Components { get; } = new Collection<ComponentCreateDto>();
  }

}
