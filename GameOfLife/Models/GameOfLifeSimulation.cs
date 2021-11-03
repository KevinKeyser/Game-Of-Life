﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    public class GameOfLifeSimulation : ISimulation
    {
        private bool[,] universe;
        private static FontFamily fontFamily = new FontFamily("Arial");
        private static Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

        public int UniverseWidth
        {
            get => universe.GetLength(0);
            set => ResizeUniverse(value, UniverseHeight);
        }

        public int UniverseHeight
        {
            get => universe.GetLength(1);
            set => ResizeUniverse(UniverseWidth, value);
        }

        private int aliveCount = 0;
        public int AliveCount
        {
            get => aliveCount;
            set
            {
                aliveCount = value;
            }
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
            AliveCount = tempAliveCount;
        }

        public void Draw(Graphics graphics, Settings settings)
        {
            var graphicsWidth = graphics.ClipBounds.Width;
            var graphicsHeight = graphics.ClipBounds.Height;

            var cellWidth = graphicsWidth / UniverseWidth;
            var cellHeight = graphicsHeight / UniverseHeight;

            var brush = Brushes.Black;

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
