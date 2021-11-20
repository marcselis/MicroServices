using System.Collections.ObjectModel;

namespace ProductsService.Dtos
{
  public class ProductCreateDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? VendorId { get; set; }
    public Collection<ProductVersionCreateDto> Versions { get; } = new Collection<ProductVersionCreateDto>();
  }

}
