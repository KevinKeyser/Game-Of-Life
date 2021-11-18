using System.Text.Json.Serialization;

namespace GameOfLife.Models
{
    public class TestSimulation : ISimulation
    {
        private static FontFamily fontFamily = new FontFamily("Arial");
        private static Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

        private int generation;
        private int universeWidth;
        private int universeHeight;

        public int Generation => generation;

        public int UniverseWidth { get => universeWidth; set => universeWidth = value; }
        public int UniverseHeight { get => universeHeight; set => universeHeight = value; }

        [JsonIgnore]
        public int AliveCount => 0;

        public TestSimulation()
        {
            generation = 0;
            universeWidth = 30;
            universeHeight = 30;
        }

        [JsonConstructor]
        public TestSimulation(int generation, int universeWidth, int universeHeight)
        {
            this.generation = generation;
            this.universeWidth = universeWidth;
            this.universeHeight = universeHeight;
        }

        public void Initialize(Settings settings)
        {
            generation = 0;
            universeWidth = settings.Options.UniverseWidth;
            universeHeight = settings.Options.UniverseHeight;
        }

        public void Draw(Graphics graphics, Settings settings)
        {
            graphics.DrawString("Test Simulation", font, Brushes.Black, PointF.Empty);
        }

        public void Randomize(int? seed = null)
        {
        }

        public void Set(int x, int y, bool value)
        {
        }

        public void Update(Settings settings)
        {
            generation++;
        }
    }
}
