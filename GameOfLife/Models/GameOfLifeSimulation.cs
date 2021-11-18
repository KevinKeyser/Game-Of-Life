using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GameOfLifeSimulation : ISimulation
    {
        private static FontFamily fontFamily = new FontFamily("Arial");
        private static Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

        private int aliveCount = 0;
        private int generation = 0;
        private bool[,] universe;

        [JsonIgnore]
        public int AliveCount => aliveCount;
        public int Generation => generation;

        public bool[,] Universe => universe;

        [JsonIgnore]
        public int UniverseWidth
        {
            get => universe.GetLength(0);
            set => ResizeUniverse(value, UniverseHeight);
        }

        [JsonIgnore]
        public int UniverseHeight
        {
            get => universe.GetLength(1);
            set => ResizeUniverse(UniverseWidth, value);
        }

        public GameOfLifeSimulation()
        {
            generation = 0;
            universe = new bool[0, 0];
        }

        [JsonConstructor]
        public GameOfLifeSimulation(int generation, bool[,] universe)
        {
            this.generation = generation;
            this.universe = universe;

            for(var x = 0; x < UniverseWidth; x++)
            {
                for(var y = 0; y < UniverseHeight; y++)
                {
                    aliveCount += universe[x, y] ? 1 : 0;
                }
            }
        }

        public void Initialize(Settings settings)
        {
            generation = 0;
            universe = new bool[settings.Options.UniverseWidth, settings.Options.UniverseHeight];
        }

        public GameOfLifeSimulation(int width, int height)
        {
            universe = new bool[width, height];
        }

        public void Randomize(int? seed = null)
        {
            Random random;
            if (seed is null)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed.Value);
            }
            for(var x = 0; x < universe.GetLength(0); x++)
            {
                for(var y = 0; y < universe.GetLength(1); y++)
                {
                    Set(x, y, random.Next() % 2 == 0);
                }
            }
        }

        public void Set(int x, int y, bool value)
        {
            if(x < 0 || x >= UniverseWidth || y < 0 || y >= UniverseHeight)
            {
                return;
            }
            generation = 0;
            aliveCount -= universe[x, y] ? 1 : 0;
            universe[x, y] = value;
            aliveCount += universe[x, y] ? 1 : 0;
        }

        public void Update(Settings settings)
        {
            var tempUniverse = new bool[UniverseWidth, UniverseHeight];
            var tempAliveCount = 0;
            for (int x = 0; x < UniverseWidth; x++)
            {
                for(int y = 0; y < UniverseHeight; y++)
                {
                    var shouldLive = ShouldLive(x, y, settings);
                    tempUniverse[x, y] = shouldLive;
                    tempAliveCount += shouldLive ? 1 : 0;
                }
            }
            universe = tempUniverse;
            aliveCount = tempAliveCount;
            generation++;
        }

        public void Draw(Graphics graphics, Settings settings)
        {
            var graphicsWidth = graphics.ClipBounds.Width;
            var graphicsHeight = graphics.ClipBounds.Height;

            var cellWidth = graphicsWidth / UniverseWidth;
            var cellHeight = graphicsHeight / UniverseHeight;

            var brush = new SolidBrush(settings.CellColor);
            var penGrid = new Pen(ColorExtensions.Lerp(settings.GridColor, Color.Transparent, .5f), 2);
            var penGrid10x = new Pen(settings.Grid10xColor, 2);

            for (int x = 0; x < UniverseWidth; x++)
            {
                for (int y = 0; y < UniverseHeight; y++)
                {
                    if (universe[x, y])
                    {
                        graphics.FillRectangle(brush, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
                    }
                    if (settings.IsNeighborCountVisible)
                    {
                        DrawNeighborCount(graphics, x, y, cellWidth, cellHeight, settings);
                    }
                }
            }

            #region Draw Grid
            if (settings.IsGridVisible)
            {
                // Render columns
                for (var x = 0; x <= UniverseWidth; x++)
                {
                    var point1 = new PointF(graphics.ClipBounds.X + x * cellWidth, graphics.ClipBounds.Y);
                    var point2 = new PointF(graphics.ClipBounds.X + x * cellWidth, graphics.ClipBounds.Height);

                    var pen = penGrid;
                    if (x % 10 == 0)
                    {
                        pen = penGrid10x;
                    }
                    graphics.DrawLine(pen, point1, point2);
                }

                // Render rows
                for (var y = 0; y <= UniverseHeight; y++)
                {
                    var point1 = new PointF(graphics.ClipBounds.X, graphics.ClipBounds.Y + y * cellHeight);
                    var point2 = new PointF(graphics.ClipBounds.Width, graphics.ClipBounds.Y + y * cellHeight);

                    var pen = penGrid;
                    if (y % 10 == 0)
                    {
                        pen = penGrid10x;
                    }
                    graphics.DrawLine(pen, point1, point2);
                }
            }
            #endregion

            #region Draw HUD
            if (settings.IsHudVisible)
            {
                var size = new SizeF(150, 50);
                var brushColor = ColorExtensions.Lerp(Color.White, Color.Transparent, 0.50f);
                graphics.FillPolygon(new SolidBrush(brushColor),
                    new[]{
                        new PointF(0, graphics.ClipBounds.Height - size.Height),
                        new PointF(size.Width, graphics.ClipBounds.Height - size.Height),
                        new PointF(size.Width, graphics.ClipBounds.Height),
                        new PointF(0, graphics.ClipBounds.Height)
                        });
                string infinite = "Infinite";
                string finite = "Finite";
                graphics.DrawString($"Generation: {Generation}" +
                                    $"\nAlive: {AliveCount}" +
                                    $"\nBoundaryType: {(settings.IsWrappingUniverse ? infinite : finite)}" +
                                    $"\nUniverse Size: {UniverseWidth} x {UniverseHeight}",
                    font, Brushes.Black, new PointF(0, graphics.ClipBounds.Height - size.Height));
            }
            #endregion
        }

        private void DrawNeighborCount(Graphics graphics, int x, int y, float width, float height, Settings settings)
        {
            var neighborCount = GetNeighborCount(x, y, settings);
            if (neighborCount > 0)
            {
                var size = graphics.MeasureString($"{neighborCount}", font);
                var brush = Brushes.Red;
                if(ShouldLive(x, y, settings))
                {
                    brush = Brushes.Green;
                }
                graphics.DrawString($"{neighborCount}", font, brush, x * width + (width - size.Width) / 2, y * height + (height - size.Height) / 2);
            }
        }

        private void ResizeUniverse(int width, int height)
        {
            generation = 0;
            var tempUniverse = new bool[width, height];
            var minWidth = Math.Min(width, UniverseWidth);
            var minHeight = Math.Min(height, UniverseHeight);

            for (var x = 0; x < minWidth; x++)
            {
                for (var y = 0; y < minHeight; y++)
                {
                    tempUniverse[x, y] = universe[x, y];
                }
            }

            universe = tempUniverse;
        }

        private bool ShouldLive(int x, int y, Settings settings)
        {
            var neighborCount = GetNeighborCount(x, y, settings);
            var isLiving = universe[x, y];
            if (isLiving)
            {
                if (neighborCount >= 2 && neighborCount <= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (neighborCount == 3)
                {
                    return true;
                }
            }
            return universe[x, y];
        }

        private int GetNeighborCount(int x, int y, Settings settings)
        {
            var leftLocation = x - 1;
            var rightLocation = x + 1;
            var topLocation = y - 1;
            var bottomLocation = y + 1;
            if (settings.IsWrappingUniverse)
            {
                leftLocation = ((x - 1) % UniverseWidth + UniverseWidth) % UniverseWidth;
                rightLocation = (x + 1) % UniverseWidth;
                topLocation = ((y - 1) % UniverseHeight + UniverseHeight) % UniverseHeight;
                bottomLocation = (y + 1) % UniverseHeight;
            }

            int topLeft = 0, topMiddle = 0, topRight = 0;
            int middleLeft = 0, middleRight = 0;
            int bottomLeft = 0, bottomMiddle = 0, bottomRight = 0;

            if (leftLocation > -1 && topLocation > -1)
            {
                topLeft = universe[leftLocation, topLocation] ? 1 : 0;
            }
            if (topLocation > -1)
            {
                topMiddle = universe[x, topLocation] ? 1 : 0;
            }
            if (rightLocation < UniverseWidth && topLocation > -1)
            {
                topRight = universe[rightLocation, topLocation] ? 1 : 0;
            }
            if (leftLocation > -1)
            {
                middleLeft = universe[leftLocation, y] ? 1 : 0;
            }
            if (rightLocation < UniverseWidth)
            {
                middleRight = universe[rightLocation, y] ? 1 : 0;
            }
            if (leftLocation > -1 && bottomLocation < UniverseHeight)
            {
                bottomLeft = universe[leftLocation, bottomLocation] ? 1 : 0;
            }
            if (bottomLocation < UniverseHeight)
            {
                bottomMiddle = universe[x, bottomLocation] ? 1 : 0;
            }
            if (rightLocation < UniverseWidth && bottomLocation < UniverseHeight)
            {
                bottomRight = universe[rightLocation, bottomLocation] ? 1 : 0;
            }

            return topLeft + topMiddle + topRight
                + middleLeft + middleRight
                + bottomLeft + bottomMiddle + bottomRight;
        }
    }
}
