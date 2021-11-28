using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProductsService.Models
{

  public class Product
  {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public int? VendorId { get; set; }
    public LifeCycleInfo Lifecycle { get; set; } = new LifeCycleInfo();
    public ICollection<ProductVersion> Versions { get; set; } = new Collection<ProductVersion>();
  }

}