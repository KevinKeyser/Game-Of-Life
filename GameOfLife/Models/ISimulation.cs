namespace GameOfLife.Models
{
    public interface ISimulation
    {
        int UniverseWidth { get; set; }
        int UniverseHeight { get; set; }
        int AliveCount { get; set; }

        void Set(int x, int y, bool value);

        void Randomize(int? seed = null);

        void Update(Settings settings);

        void Draw(Graphics graphics, Settings settings);
    }
}
