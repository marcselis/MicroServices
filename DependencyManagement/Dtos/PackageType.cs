using System.Text.Json.Serialization;

namespace DependencyManagement.Dtos
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum PackageType
  {
    Unknwon=0,
    NuGet,
    NPM
  }
}
