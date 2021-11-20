using System.Collections.ObjectModel;

namespace ProductsService.Dtos
{
  public class ProductDetailsReadDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? VendorId { get; set; }
    public Collection<ProductVersionReadDto> Versions { get; } = new Collection<ProductVersionReadDto>();
  }
}
