using GameOfLife.Converters;
using System.Text.Json.Serialization;

namespace GameOfLife.Models
{

    //[JsonConverter(typeof(SimulationJsonConverter))]
    public interface ISimulation
    {
        int Generation { get; }
        int UniverseWidth { get; set; }
        int UniverseHeight { get; set; }
        int AliveCount { get; }

        void Set(int x, int y, bool value);

        void Randomize(int? seed = null);

        void Update(Settings settings);

        void Draw(Graphics graphics, Settings settings);
    }
}
