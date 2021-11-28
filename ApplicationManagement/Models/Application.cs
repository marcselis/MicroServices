using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationsService.Models
{

  public class Application
  {
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = "";
    public string? Description { get; set; }

    public ICollection<Component> Components { get; set; } = new Collection<Component>();
  }

}