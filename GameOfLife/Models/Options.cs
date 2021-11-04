using System.Text.Json.Serialization;

namespace GameOfLife.Models
{
    public struct Options : IEquatable<Options>
    {
        private readonly int timerInterval;
        private readonly int universeWidth;
        private readonly int universeHeight;

        public int TimerInterval => timerInterval;
        public int UniverseWidth => universeWidth;
        public int UniverseHeight => universeHeight;

        [JsonConstructor]
        public Options(int timerInterval, int universeWidth, int universeHeight)
        {
            this.timerInterval = timerInterval;
            this.universeWidth = universeWidth;
            this.universeHeight = universeHeight;
        }

        public bool Equals(Options other)
        {
            return this == other;
        }

        public static bool operator ==(Options options, Options otherOptions)
        {
            return options.TimerInterval == otherOptions.TimerInterval &&
                    options.UniverseWidth == otherOptions.UniverseWidth &&
                    options.UniverseHeight == otherOptions.UniverseHeight;
        }

        public static bool operator !=(Options options, Options otherOptions)
        {
            return  options.TimerInterval != otherOptions.TimerInterval ||
                    options.UniverseWidth != otherOptions.UniverseWidth ||
                    options.UniverseHeight != otherOptions.UniverseHeight;
        }

        public override bool Equals(object obj)
        {
            return obj is Options && Equals((Options)obj);
        }
    }
}
