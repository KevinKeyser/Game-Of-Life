using System.Text.Json;
using System.Text.Json.Serialization;

using GameOfLife.Models;

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
            return interfaceType.IsAssignableFrom(typeToConvert);
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

            if (// Check that the next part is a property name of "Type"
                !reader.Read()
                || reader.TokenType != JsonTokenType.PropertyName
                || reader.GetString() != typePropertyName
                // Check that the next part is a string
                || !reader.Read() 
                || reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            // Get string value and find corresponding type.
            var typeName = reader.GetString();
            var type = simulationTypes
                .FirstOrDefault(type => type.FullName == typeName);

            if(// Check that the next part is a property name of "Simulation"
                !reader.Read() 
                || reader.TokenType != JsonTokenType.PropertyName
                || reader.GetString() != simulationPropertyName
                // Check that the following after the property name is an object
                || !reader.Read()
                || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            // Deserialize json token starting at current object as a ISimulation of {type}
            var simulation = (ISimulation?)JsonSerializer.Deserialize(ref reader, type, options);

            if (// Check that the next part ends the object
                !reader.Read() 
                || reader.TokenType != JsonTokenType.EndObject)
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
                    // Create property to hold the Type name
                    var type = value.GetType();
                    writer.WriteString(typePropertyName, type.FullName);
                    // Create property to hold the simulation value
                    writer.WritePropertyName(simulationPropertyName);
                    JsonSerializer.Serialize(writer, value, type, options);
                    writer.WriteEndObject();
                    break;
            }
        }
    }
}
