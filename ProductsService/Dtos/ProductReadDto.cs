namespace ProductsService.Dtos
{
  public class ProductReadDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? VendorId { get; set; }
    public LifeCycle LifeCycle { get; set; }
  }

}
