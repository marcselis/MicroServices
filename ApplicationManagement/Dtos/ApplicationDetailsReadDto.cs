using System.Collections.ObjectModel;

namespace ApplicationsService.Dtos
{
  public class ApplicationDetailsReadDto
  {
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public Collection<ComponentReadDto> Components { get; } = new Collection<ComponentReadDto>();

  }
}
