using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameOfLife.Converters
{
    public class MultiDimensionalArrayJsonConverter<T> : JsonConverter<T[,]>
    {
        public override T[,]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = JsonSerializer.Deserialize<T[][]>(ref reader, options);
            if (data == null ||
                data.Length == 0)
            {
                return new T[0, 0];
            }
            var array = new T[data.Length, data[0].Length];
            for (var x = 0; x < array.GetLength(0); x++)
            {
                for (var y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = data[x][y];
                }
            }
            return array;
        }

        public override void Write(Utf8JsonWriter writer, T[,] value, JsonSerializerOptions options)
        {
            var xFirstIndex = value.GetLowerBound(0);
            var xLastIndex = value.GetUpperBound(0);
            var yFirstIndex = value.GetLowerBound(1);
            var yLastIndex = value.GetUpperBound(1);

            writer.WriteStartArray();
            for(var x = xFirstIndex; x <= xLastIndex; x++)
            {
                writer.WriteStartArray();
                for(var y = yFirstIndex; y <= yLastIndex; y++)
                {
                    writer.WriteRawValue(JsonSerializer.Serialize(value[x, y], options));
                }
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
    }
}
