using System.Text.Json.Serialization;

using GameOfLife.Converters;

namespace GameOfLife.Models
{

    [JsonConverter(typeof(SimulationJsonConverter))]
    public interface ISimulation
    {
        int Generation { get; }
        int UniverseWidth { get; set; }
        int UniverseHeight { get; set; }
        int AliveCount { get; }

        void Initialize(Settings settings);

        void Set(int x, int y, bool value);

        void Randomize(int? seed = null);

        void Update(Settings settings);

        void Draw(Graphics graphics, Settings settings);
    }
}
