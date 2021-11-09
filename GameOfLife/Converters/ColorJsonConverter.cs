using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameOfLife.Converters
{
    public class ColorJsonConverter : JsonConverter<Color>
    {
        private static Color defaultColor = default;

        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            if(stringValue == null)
            {
                return defaultColor;
            }
            
            var stringValues = stringValue.Split(',').Select(value => value.Trim());
            if(stringValues.Count() != 4)
            {
                return defaultColor;
            }

            try
            {
                var values = stringValues.Select(value => Int32.Parse(value))
                    .Select(value => Clamp(value, 0, 255))
                    .ToArray();
                
                return Color.FromArgb(values[0], values[1], values[2], values[3]);
            }
            catch(Exception exception)
            {
                return defaultColor;
            }
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            var stringValue = $"{value.A},{value.R},{value.G},{value.B}";
            writer.WriteStringValue(stringValue);
        }

        private int Clamp(int value, int min, int max)
        {
#if NET5_0_OR_GREATER
            return Math.Clamp(value, min, max);
#else
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
#endif
        }
    }
}
