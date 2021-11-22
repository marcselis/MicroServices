using System.Text.Json.Serialization;

namespace ProductsService.Dtos
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum LifeCycle
  {
    Undefined = 0,
    Plan,
    PhaseIn,
    Active,
    PhaseOut,
    EndOfLife
  }

}
