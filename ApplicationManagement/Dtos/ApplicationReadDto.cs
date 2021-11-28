namespace ApplicationsService.Dtos
{
  public class ApplicationReadDto
  {
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
  }

}
