using System.ComponentModel.DataAnnotations;

namespace ProductsService.Models
{
  public class ProductVersion
  {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public Product? Product { get; set; }
    [Required]
    public string Version { get; set; } = "";

  }
}