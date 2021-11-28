using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeployService
{
  public class DeployCreateDto
  {
    [Required]
    public string? Id { get; set; }
    public string? ArtifactName { get; set; }
    [Required]
    public string? Server { get; set; }
    public long? ComponentId { get; set; }
    public long? ApplicationId { get; set; }
    public string? Path { get; set; }
    public string? Name { get; set; }
    public Collection<PackageReferenceCreateDto> PackageReferences { get; set; } = new Collection<PackageReferenceCreateDto>();
    public Collection<RuntimeReferenceCreateDto> Runtimes { get; set; } = new Collection<RuntimeReferenceCreateDto>();
    public Collection<AssemblyReferenceCreateDto> AssemblyReferences { get; set; } = new Collection<AssemblyReferenceCreateDto>();
  }

  public class PackageReferenceCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
    [Required]
    public PackageType Type { get; set; }
  }
  public class RuntimeReferenceCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
  }

  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum PackageType
  {
    Unknwon = 0,
    NuGet,
    NPM
  }
  public class AssemblyReferenceCreateDto
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Version { get; set; } = string.Empty;
  }
}
