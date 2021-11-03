using System.Text;
using System.Text.Json;

using GameOfLife.Models;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        private ISimulation simulation = new GameOfLifeSimulation(Settings.Default.Options.UniverseWidth, Settings.Default.Options.UniverseHeight);
        private SimulateToDialogForm simulateToDialogForm = new SimulateToDialogForm();
        private SeedDialogForm seedDialog = new SeedDialogForm();
        private OptionsDialogForm optionsDialog = new OptionsDialogForm();

        private readonly ObservableContainer<Settings> observableSettings = new ObservableContainer<Settings>();

        public Settings CurrentSettings => observableSettings.TrackedObject ?? Settings.Default;

        private int currentSeed = 0;
        public int CurrentSeed
        {
            get => currentSeed;
            set
            {
                if(currentSeed != value)
                {
                    currentSeed = value;
                    seedStatusLabel.Text = $"Seed: {currentSeed}";
                }
            }
        }

        private int? simulateToGeneration = null;
        private int currentGeneration = 0;
        public int CurrentGeneration
        {
            get => currentGeneration;
            set
            {
                if(currentGeneration != value)
                {
                    currentGeneration = value;
                    generationsStatusLabel.Text = $"Generation: {currentGeneration}";
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            observableSettings.PropertyChanging += (sender, e) => DisposeSettings();
            observableSettings.PropertyChanged += (sender, e) => InitializeSettings();
            observableSettings.TrackedObject = GetSavedSettings();
        }

        private Settings GetSavedSettings()
        {
            var userAppDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var appDataLocation = Path.Combine(userAppDataLocation, "VigilantGames", "GameOfLife");
            var settingsFileLocation = Path.Combine(appDataLocation, "Settings.json");

            var settings = Settings.Default;
            if(!File.Exists(settingsFileLocation))
            {
                var settingsData = JsonSerializer.Serialize(settings);
                //File.WriteAllText(settingsFileLocation, settingsData);
            }
            else
            {
                var settingsData = File.ReadAllText(settingsFileLocation);
                settings = JsonSerializer.Deserialize<Settings>(settingsData)
                    ?? Settings.Default;
            }

            return settings;
        }

        private void InitializeSettings()
        {
            CurrentSettings.PropertyChanged += CurrentSettings_PropertyChanged;
            timer.Interval = CurrentSettings.Options.TimerInterval;
            intervalStatusLabel.Text = $"Interval: {timer.Interval}";
            graphicsPanel.BackColor = CurrentSettings.BackColor;
            hudMenuItemToggle.Checked = CurrentSettings.IsHudVisible;
            gridMenuItemToggle.Checked = CurrentSettings.IsGridVisible;
            neighborCountMenuItemToggle.Checked = CurrentSettings.IsNeighborCountVisible;
            wrapUniverseMenuItem.Checked = CurrentSettings.IsWrappingUniverse;
            graphicsPanel.Invalidate();
        }

        private void DisposeSettings()
        {
            if (CurrentSettings != null)
            {
                CurrentSettings.PropertyChanged += CurrentSettings_PropertyChanged;
            }
        }

        private void CurrentSettings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Settings.Options))
            {
                timer.Interval = CurrentSettings.Options.TimerInterval;
                intervalStatusLabel.Text = $"Interval: {timer.Interval}";
                simulation.UniverseWidth = CurrentSettings.Options.UniverseWidth;
                simulation.UniverseHeight = CurrentSettings.Options.UniverseHeight;
            }
            else if (e.PropertyName == nameof(Settings.BackColor))
            {
                graphicsPanel.BackColor = CurrentSettings.BackColor;
            }
            else if (e.PropertyName == nameof(Settings.IsHudVisible))
            {
                hudMenuItemToggle.Checked = CurrentSettings.IsHudVisible;
            }
            else if (e.PropertyName == nameof(Settings.IsGridVisible))
            {
                gridMenuItemToggle.Checked = CurrentSettings.IsGridVisible;
            }
            else if (e.PropertyName == nameof(Settings.IsNeighborCountVisible))
            {
                neighborCountMenuItemToggle.Checked = CurrentSettings.IsNeighborCountVisible;
            }
            else if (e.PropertyName == nameof(Settings.IsWrappingUniverse))
            {
                wrapUniverseMenuItem.Checked = CurrentSettings.IsWrappingUniverse;
            }

            //Invalidate graphicsPanel   
            graphicsPanel.Invalidate();
        }

        private void RunSimulation()
        {
            playButton.Enabled = false;
            startMenuItem.Enabled = false;
            stepButton.Enabled = false;
            nextMenuItem.Enabled = false;
            pauseButton.Enabled = true;
            pauseMenuItem.Enabled = true;
            timer.Start();
        }

        private void StopSimulation()
        {
            playButton.Enabled = true;
            startMenuItem.Enabled = true;
            stepButton.Enabled = true;
            nextMenuItem.Enabled = true;
            pauseButton.Enabled = false;
            pauseMenuItem.Enabled = false;
            simulateToGeneration = null;
            timer.Stop();
        }

        private void StepSimulation()
        {
            if(simulateToGeneration is not null
                && simulateToGeneration <= currentGeneration)
            {
                StopSimulation();
                return;
            }
            CurrentGeneration++;
            simulation.Update(CurrentSettings);
            graphicsPanel.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            StepSimulation();
        }

        private Color Lerp(Color color1, Color color2, float lerp)
        {
            var inverseLerp = 1 - lerp;
            var red = color1.R * lerp + color2.R * inverseLerp;
            var green = color1.G * lerp + color2.G * inverseLerp;
            var blue = color1.B * lerp + color2.B * inverseLerp;
            var alpha = color1.A * lerp + color2.A * inverseLerp;

            return Color.FromArgb((int)alpha, (int)red, (int)green, (int)blue);
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            var cellXCount = CurrentSettings.Options.UniverseWidth;
            var cellYCount = CurrentSettings.Options.UniverseHeight;

            var cellWidth = graphics.ClipBounds.Width / cellXCount;
            var cellHeight = graphics.ClipBounds.Height / cellYCount;

            var penCell = new Pen(CurrentSettings.CellColor, 2);
            var penGrid = new Pen(Lerp(CurrentSettings.GridColor, Color.Transparent, .5f), 2);
            var penGrid10x = new Pen(CurrentSettings.Grid10xColor, 2);

            simulation.Draw(graphics, CurrentSettings);

            #region Draw Grid
            if (CurrentSettings.IsGridVisible)
            {
                for (var x = 0; x <= cellXCount; x++)
                {
                    var point1 = new PointF(graphics.ClipBounds.X + x * cellWidth, graphics.ClipBounds.Y);
                    var point2 = new PointF(graphics.ClipBounds.X + x * cellWidth, graphics.ClipBounds.Height);

                    var pen = penGrid;
                    if(x % 10 == 0)
                    {
                        pen = penGrid10x;
                    }
                    graphics.DrawLine(pen, point1, point2);
                }

                for (var y = 0; y <= cellYCount; y++)
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
            if(CurrentSettings.IsHudVisible)
            {
                var size = new SizeF(150, 75);
                var brushColor = Lerp(Color.White, Color.Transparent, 0.50f);
                graphics.FillPolygon(new SolidBrush(brushColor),
                    new[]{
                        new PointF(0, graphics.ClipBounds.Height - size.Height),
                        new PointF(size.Width, graphics.ClipBounds.Height - size.Height),
                        new PointF(size.Width, graphics.ClipBounds.Height),
                        new PointF(0, graphics.ClipBounds.Height)
                        });
                string infinite = "Infinite";
                string finite = "Finite";
                graphics.DrawString($"Generation: {CurrentGeneration}\nAlive: {simulation.AliveCount}\nBoundaryType: {(CurrentSettings.IsWrappingUniverse ? infinite : finite)}\nUniverse Size: {simulation.UniverseWidth} x {simulation.UniverseHeight}", Font, Brushes.Black, new PointF(0, graphics.ClipBounds.Height - size.Height));
            }
            aliveStatusLabel.Text = $"Alive: {simulation.AliveCount}";
            #endregion
        }

        public void NewFile()
        {
            simulation = new GameOfLifeSimulation(CurrentSettings.Options.UniverseWidth, CurrentSettings.Options.UniverseHeight);
            graphicsPanel.Invalidate();
        }

        public void OpenFileDialog()
        {
            var result = openFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {

            }
        }

        public void ImportFileDialog()
        {

        }

        public void SaveFileDialog()
        {
            var result = saveFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {

            }
        }

        public void ExitDialog()
        {

        }

        #region Toolbar
        private void newFileButton_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            RunSimulation();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            StepSimulation();
        }
        #endregion

        #region File Menu
        private void newFileMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void importFileMenuItem_Click(object sender, EventArgs e)
        {
            ImportFileDialog();
        }

        private void saveFileMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            ExitDialog();
        }
        #endregion

        #region View Menu
        private void hudMenuItemToggle_Click(object sender, EventArgs e)
        {
            CurrentSettings.IsHudVisible = !CurrentSettings.IsHudVisible;
        }

        private void neighborCountMenuItemToggle_Click(object sender, EventArgs e)
        {
            CurrentSettings.IsNeighborCountVisible = !CurrentSettings.IsNeighborCountVisible;
        }

        private void gridMenuItemToggle_Click(object sender, EventArgs e)
        {
            CurrentSettings.IsGridVisible = !CurrentSettings.IsGridVisible;
        }

        private void wrapUniverseMenuItem_Click(object sender, EventArgs e)
        {
            CurrentSettings.IsWrappingUniverse = !CurrentSettings.IsWrappingUniverse;
        }
        #endregion

        #region Run Menu
        private void startMenuItem_Click(object sender, EventArgs e)
        {
            RunSimulation();
        }

        private void pauseMenuItem_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void nextMenuItem_Click(object sender, EventArgs e)
        {
            StepSimulation();
        }

        private void toMenuItem_Click(object sender, EventArgs e)
        {
            simulateToDialogForm.Generation = currentGeneration + 1;
            var result = simulateToDialogForm.ShowDialog(this);

            if(result == DialogResult.OK)
            {
                simulateToGeneration = simulateToDialogForm.Generation;
                RunSimulation();
            }
        }
        #endregion

        #region Randomize Menu
        private void fromSeedMenuItem_Click(object sender, EventArgs e)
        {
            seedDialog.Seed = CurrentSeed;
            
            DialogResult result = seedDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                CurrentSeed = seedDialog.Seed;
                simulation.Randomize(CurrentSeed);
                graphicsPanel.Invalidate();
            }
        }

        private void fromCurrentSeedMenuItem_Click(object sender, EventArgs e)
        {
            simulation.Randomize(CurrentSeed);
            graphicsPanel.Invalidate();
        }

        private void fromTimeMenuItem_Click(object sender, EventArgs e)
        {
            simulation.Randomize();
            graphicsPanel.Invalidate();
        }
        #endregion

        #region Settings Menu
        private void backColorMenuItem_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                CurrentSettings.BackColor = colorDialog.Color;
            }
        }

        private void cellColorMenuItem_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                CurrentSettings.CellColor = colorDialog.Color;
            }
        }

        private void gridColorMenuItem_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                CurrentSettings.GridColor = colorDialog.Color;
            }
        }

        private void gridX10ColorMenuItem_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                CurrentSettings.Grid10xColor = colorDialog.Color;
            }
        }

        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            optionsDialog.Options = CurrentSettings.Options;
            var result = optionsDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                CurrentSettings.Options = optionsDialog.Options;
            }
        }

        private void resetMenuItem_Click(object sender, EventArgs e)
        {
            observableSettings.TrackedObject = Settings.Default;
        }

        private void reloadMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void UpdateMouseInputs(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
            {
                return;
            }

            var cellWidth = (float)graphicsPanel.Width / simulation.UniverseWidth;
            var cellHeight = (float)graphicsPanel.Height / simulation.UniverseHeight;

            var xCellLocation = (e.X - graphicsPanel.Location.X) / cellWidth;
            var yCellLocation = (e.Y - graphicsPanel.Location.Y) / cellHeight;

            if (e.Button == MouseButtons.Left)
            {
                simulation.Set((int)xCellLocation, (int)yCellLocation, true);
            }
            else if (e.Button == MouseButtons.Right)
            {
                simulation.Set((int)xCellLocation, (int)yCellLocation, false);
            }

            graphicsPanel.Invalidate();
        }

        private void graphicsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateMouseInputs(e);
        }

        private void graphicsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Change what mouseEventArgs are sent to update inputs since
            // the one sent from the event is only the current button pressed and not all button states
            var mouseEventArgs = new MouseEventArgs(Control.MouseButtons, e.Clicks, e.X, e.Y, e.Delta);
            UpdateMouseInputs(mouseEventArgs);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            graphicsPanel.Invalidate();
        }
    }
}