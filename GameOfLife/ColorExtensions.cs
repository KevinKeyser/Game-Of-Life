using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class ColorExtensions
    {
        public static Color Lerp(this Color color1, Color color2, float lerp)
        {
            var inverseLerp = 1 - lerp;
            var red = color1.R * lerp + color2.R * inverseLerp;
            var green = color1.G * lerp + color2.G * inverseLerp;
            var blue = color1.B * lerp + color2.B * inverseLerp;
            var alpha = color1.A * lerp + color2.A * inverseLerp;

            return Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
        }
    }
}
