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
        private static readonly Type interfaceType = typeof(ISimulation);
        private static readonly IEnumerable<Type> simulationTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => Implements(type));

        private const string typePropertyName = "Type";
        private const string simulationPropertyName = "Simulation";

        private static bool Implements(Type typeToConvert)
        {
            return interfaceType.IsAssignableFrom(typeToConvert);// && !typeToConvert.IsInterface;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return Implements(typeToConvert);
        }

        public override ISimulation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!reader.Read()
                    || reader.TokenType != JsonTokenType.PropertyName
                    || reader.GetString() != typePropertyName)
            {
                throw new JsonException();
            }
            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }
            var typeName = reader.GetString();
            var type = simulationTypes
                .FirstOrDefault(type => type.FullName == typeName);

            if(!reader.Read() 
                || reader.TokenType != JsonTokenType.PropertyName
                || reader.GetString() != simulationPropertyName
                || !reader.Read()
                || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            var simulation = (ISimulation?)JsonSerializer.Deserialize(ref reader, type, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }
            return simulation;
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
