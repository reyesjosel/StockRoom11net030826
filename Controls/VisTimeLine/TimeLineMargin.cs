using System.Text.Json;
using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    /// <summary>
    /// Represents configuration options for specifying margins in a timeline visualization.
    /// </summary>
    /// <remarks>Use this class to define custom margin values for timeline items and axes. All properties are
    /// optional; if a property is not set, the default margin behavior is applied.</remarks>
    public class TimeLineMargin
    {
        [JsonPropertyName("item")]
        [JsonConverter(typeof(ItemMarginConverter))]
        public ItemMargin Item { get; set; } = new(10); // Default vis.js value

        /// <summary>
        /// Gets or sets the axis margin value.
        /// </summary>
        [JsonPropertyName("axis")]
        public int? Axis { get; set; } = 20;
    }

    /// <summary>
    /// Represents the margin configuration for timeline items,
    /// allowing for separate horizontal and vertical margin values.
    /// It can be serialized as either a single integer (for uniform margins)
    /// or as an object with distinct horizontal and vertical values.
    /// </summary>
    public class ItemMargin
    {
        public int Horizontal { get; set; }
        public int Vertical { get; set; }

        // Default constructor
        public ItemMargin() { }

        // Shorthand helper constructor
        public ItemMargin(int uniformMargin)
        {
            Horizontal = uniformMargin;
            Vertical = uniformMargin;
        }

        public ItemMargin(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }
    }

    /// <summary>
    /// The Custom Polymorphic Converter (System.Text.Json)
    /// Add this converter class to ensure C# knows exactly how to read a
    /// bare int or a full JSON object when talking to your front-end code.
    /// </summary>
    public class ItemMarginConverter : JsonConverter<ItemMargin>
    {
        public override ItemMargin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                int uniformValue = reader.GetInt32();
                return new ItemMargin(uniformValue);
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using var jsonDoc = JsonDocument.ParseValue(ref reader);
                var root = jsonDoc.RootElement;

                int horizontal = root.TryGetProperty("horizontal", out var hProp) ? hProp.GetInt32() : 10;
                int vertical = root.TryGetProperty("vertical", out var vProp) ? vProp.GetInt32() : 10;

                return new ItemMargin(horizontal, vertical);
            }

            throw new JsonException("Unexpected token style for margin.item layout mapping.");
        }

        public override void Write(Utf8JsonWriter writer, ItemMargin value, JsonSerializerOptions options)
        {
            // If horizontal and vertical match, serialize cleanly as a simple shorthand number
            if (value.Horizontal == value.Vertical)
            {
                writer.WriteNumberValue(value.Horizontal);
            }
            else // Otherwise output structural config options
            {
                writer.WriteStartObject();
                writer.WriteNumber("horizontal", value.Horizontal);
                writer.WriteNumber("vertical", value.Vertical);
                writer.WriteEndObject();
            }
        }
    }

}
