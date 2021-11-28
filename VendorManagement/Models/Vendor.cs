using System.ComponentModel.DataAnnotations;

namespace VendorManagement.Models
{

  public class Vendor
  {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
  }

}
