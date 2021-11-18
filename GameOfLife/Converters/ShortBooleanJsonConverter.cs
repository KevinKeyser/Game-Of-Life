using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameOfLife.Converters
{
    public class ShortBooleanJsonConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            bool value = false;
            try
            {
                var numberValue = reader.GetInt16();
                value = numberValue > 0;
            }
            catch (Exception exception)
            {
                value = reader.GetBoolean();
            }
            return value;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value ? 1 : 0);
        }
    }
}
