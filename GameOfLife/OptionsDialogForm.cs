using GameOfLife.Models;

namespace GameOfLife
{
    public partial class OptionsDialogForm : Form
    {
        private Options options;
        public Options Options
        {
            get => options;
            set => options = value;
        }

        public OptionsDialogForm()
        {
            InitializeComponent();
        }

        private void OptionsDialogForm_Load(object sender, EventArgs e)
        {
            timerIntervalUpDown.Value = Options.TimerInterval;
            universeWidthUpDown.Value = Options.UniverseWidth;
            universeHeightUpDown.Value = Options.UniverseHeight;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            options = new Options((int)timerIntervalUpDown.Value, (int)universeWidthUpDown.Value, (int)universeHeightUpDown.Value);
        }
    }
}
