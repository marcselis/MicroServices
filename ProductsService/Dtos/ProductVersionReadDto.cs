namespace ProductsService.Dtos
{
  public class ProductVersionReadDto
  {
    public int Id { get; set; }
    public string Version { get; set; } = "";
    public LifeCycle LifeCycle { get; set; }
  }
}
