namespace ProductsService.Dtos
{

  public class ProductVersionCreateDto
  {
    public string Version { get; set; } = "";
    public LifeCycleInfoDto LifeCycle { get; set; } = new LifeCycleInfoDto();
  }

}
