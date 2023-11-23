using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velosaurus.Api.Utils;

// TODO: NOT WORKING?!
public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    public CustomDateTimeConverter()
    {
        Console.WriteLine("CustomDateTimeConverter instantiated");
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Console.WriteLine("sdf");
        var dateStr = reader.GetString();
        // Try parsing the date string using different formats
        if (DateTime.TryParse(dateStr, out var date) ||
            DateTime.TryParseExact(dateStr, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out date))
            return date;
        throw new JsonException($"Unable to parse \"{dateStr}\" as a date.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        Console.WriteLine("CustomDateTimeConverter.Write called");

        writer.WriteStringValue(value.ToString("O"));
    }
}


public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeConverter() : base(
        v => v.ToUniversalTime(),
        v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
    {
    }
}