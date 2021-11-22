using System.Text.Json.Serialization;
using Tools;

namespace ProductsService.Dtos
{
  public class LifeCycleInfoDto
  {
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? Plan { get; set; }
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? PhaseIn { get; set; }
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? Active { get; set; }
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? PhaseOut { get; set; }
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? EndOfLife { get; set; }
  }
}
