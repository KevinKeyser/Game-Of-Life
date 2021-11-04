using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameOfLife.Converters
{
    public class SimulationJsonConverter : JsonConverter<ISimulation>
    {
        private const string typePropertyName = "Type";
        private const string simulationPropertyName = "Simulation";

        public override ISimulation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Type? type = null;
            string? simulation = null;
            while(reader.Read())
            {
                if(reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    if (propertyName == typePropertyName)
                    {
                        reader.Read();
                        var typeName = reader.GetString();
                        type = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(assembly => assembly.GetTypes())
                            .FirstOrDefault(type => type.FullName == typeName);
                    }
                    else if(propertyName == simulationPropertyName)
                    {
                        reader.Read();
                        //JsonDocument.Parse(reader, options);
                        //simulation = JsonSerializer.Deserialize(reader, type, options);
                    }
                }
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, ISimulation value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case null:
                    JsonSerializer.Serialize(writer, null as ISimulation, options);
                    break;
                default:
                    writer.WriteStartObject();
                    var type = value.GetType();
                    writer.WriteString(typePropertyName, type.FullName);
                    writer.WritePropertyName(simulationPropertyName);
                    JsonSerializer.Serialize(writer, value, type, options);
                    writer.WriteEndObject();
                    break;
            }
        }
    }
}
