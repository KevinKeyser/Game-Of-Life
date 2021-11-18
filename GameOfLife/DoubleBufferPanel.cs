namespace GameOfLife
{
    public partial class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }
    }
}
