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
    public partial class SimulateToDialogForm : Form
    {
        private int generation;

        public int Generation 
        { 
            get => generation;
            set => generation = value;
        }

        public SimulateToDialogForm()
        {
            InitializeComponent();
        }

        private void SimulateToDialogForm_Load(object sender, EventArgs e)
        {
            generationUpDown.Value = generation;
        }

        private void generationUpDown_ValueChanged(object sender, EventArgs e)
        {
            Generation = (int)generationUpDown.Value;
        }
    }
}
