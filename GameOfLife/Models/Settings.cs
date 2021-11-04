using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GameOfLife.Models
{
    public class Settings : Observable
    {
        public static readonly Settings Default = new Settings(true, true, true, true, Color.White, Color.Blue, Color.Black, Color.Black, new Options(20, 30, 30));

        private bool isHudVisible;
        private bool isGridVisible;
        private bool isNeighborCountVisible;
        private bool isWrappingUniverse;

        private Color backColor;
        private Color cellColor;
        private Color gridColor;
        private Color grid10xColor;
        private Options options;

        public event PropertyChangingEventHandler? PropertyChanging;
        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsHudVisible
        {
            get => isHudVisible;
            set
            {
                if (isHudVisible != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(IsHudVisible)));
                    isHudVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsHudVisible)));
                }
            }
        }

        public bool IsGridVisible
        {
            get => isGridVisible;
            set
            {
                if (isGridVisible != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(IsGridVisible)));
                    isGridVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsGridVisible)));
                }
            }
        }

        public bool IsNeighborCountVisible
        {
            get => isNeighborCountVisible;
            set
            {
                if (isNeighborCountVisible != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(IsNeighborCountVisible)));
                    isNeighborCountVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNeighborCountVisible)));
                }
            }
        }

        public bool IsWrappingUniverse
        {
            get => isWrappingUniverse;
            set
            {
                if (isWrappingUniverse != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(IsWrappingUniverse)));
                    isWrappingUniverse = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsWrappingUniverse)));
                }
            }
        }

        public Color BackColor
        {
            get => backColor;
            set
            {
                if (backColor != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(BackColor)));
                    backColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackColor)));
                }
            }
        }

        public Color CellColor
        {
            get => cellColor;
            set
            {
                if (cellColor != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(CellColor)));
                    cellColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CellColor)));
                }
            }
        }

        public Color GridColor
        {
            get => gridColor;
            set
            {
                if (gridColor != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(GridColor)));
                    gridColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridColor)));
                }
            }
        }

        public Color Grid10xColor
        {
            get => grid10xColor;
            set
            {
                if (grid10xColor != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Grid10xColor)));
                    grid10xColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Grid10xColor)));
                }
            }
        }
        public Options Options
        {
            get => options;
            set
            {
                if (options != value)
                {
                    PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Options)));
                    options = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Options)));
                }
            }
        }

        [JsonConstructor]
        public Settings(bool isHudVisible, bool isGridVisible, bool isNeighborCountVisible, bool isWrappingUniverse, 
            Color backColor, Color cellColor, Color gridColor, Color grid10xColor, Options options)
        {
            this.isHudVisible = isHudVisible;
            this.isGridVisible = isGridVisible;
            this.isNeighborCountVisible = isNeighborCountVisible;
            this.isWrappingUniverse = isWrappingUniverse;

            this.backColor = backColor;
            this.cellColor = cellColor;
            this.gridColor = gridColor;
            this.grid10xColor = grid10xColor;
            this.options = options;
        }
    }
}
