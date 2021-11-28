using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tools
{
  public class NullableDateOnlyConverter : JsonConverter<DateOnly?>
  {
    private const string _nullString = null;

    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var value = reader.GetString();
      if (string.IsNullOrEmpty(value))
        return null;
      return DateOnly.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        writer.WriteStringValue(_nullString);
      }
      else
      {
        writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
      }
    }
  }
}
