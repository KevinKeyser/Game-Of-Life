using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class SeedDialogForm : Form
    {
        private Random random = new Random();

        private int seed;
        public int Seed
        {
            get => seed;
            set => seed = value;
        }

        public SeedDialogForm()
        {
            InitializeComponent();
        }

        private void SeedDialogForm_Load(object sender, EventArgs e)
        {
            seedUpDown.Value = seed;
        }

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            seedUpDown.Value = random.Next(int.MinValue, int.MaxValue);
        }

        private void seedUpDown_ValueChanged(object sender, EventArgs e)
        {
            seed = (int)seedUpDown.Value;
        }
    }
}
