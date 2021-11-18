using System.Text;
using System.Text.Json;
using GameOfLife.Converters;
using GameOfLife.Models;

namespace GameOfLife
{
    public partial class MainForm : Form
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters =
            {
                new MultiDimensionalArrayJsonConverter<bool>(),
                new ShortBooleanJsonConverter(),
                new ColorJsonConverter()
            }
        };

        private ISimulation simulation = new GameOfLifeSimulation(Settings.Default.Options.UniverseWidth, Settings.Default.Options.UniverseHeight);
        private NewSimulationDialogForm newSimulationDialogForm = new NewSimulationDialogForm();
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

        public MainForm()
        {
            InitializeComponent();
            // Get compiled .Net version and use it as the title
            Text = $"Game of Life (.NET {Environment.Version})";

            // Setup observable functionality
            observableSettings.PropertyChanging += (sender, e) => DisposeSettings();
            observableSettings.PropertyChanged += (sender, e) => InitializeSettings();
            observableSettings.TrackedObject = GetSavedSettings();
        }

        #region Core Functionality
        /// <summary>
        /// Save and serialize current settings into ../AppData/Roaming/VigilantGames/GameOfLife/Settings.json.
        /// </summary>
        /// <returns>True if the settings saved properly.</returns>
        private bool TrySaveSettings()
        {
            var userAppDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var appDataLocation = Path.Combine(userAppDataLocation, "VigilantGames", "GameOfLife");
            var settingsFileLocation = Path.Combine(appDataLocation, "Settings.json");

            if (!Directory.Exists(settingsFileLocation))
            {
                Directory.CreateDirectory(appDataLocation);
            }

            FileStream fileStream;
            if (!File.Exists(settingsFileLocation))
            {
                fileStream = File.Create(settingsFileLocation);
            }
            else
            {
                fileStream = File.Open(settingsFileLocation, FileMode.Truncate, FileAccess.Write);
            }
            var streamWriter = new StreamWriter(fileStream);

            try
            {
                var json = JsonSerializer.Serialize(CurrentSettings, jsonSerializerOptions);
                streamWriter.Write(json);
                return true;
            }
            catch (Exception exception)
            {
            }
            finally
            {
                streamWriter.Close();
            }
            return false;
        }

        /// <summary>
        /// Get and deserialize settings from ../AppData/Roaming/VigilantGames/GameOfLife/Settings.json.
        /// If the settings doesn't exist, returns the default settings.
        /// </summary>
        /// <returns>Saved <see cref="Settings"/></returns>
        private Settings GetSavedSettings()
        {
            var userAppDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var appDataLocation = Path.Combine(userAppDataLocation, "VigilantGames", "GameOfLife");
            var settingsFileLocation = Path.Combine(appDataLocation, "Settings.json");

            var settings = Settings.Default;
            if (File.Exists(settingsFileLocation))
            {
                var fileStream = File.OpenRead(settingsFileLocation);
                var streamReader = new StreamReader(fileStream);
                try 
                {
                    settings = JsonSerializer.Deserialize<Settings>(streamReader.ReadToEnd(), jsonSerializerOptions)
                        ?? Settings.Default;
                }
                catch (Exception exception)
                {

                }
                finally
                {
                    streamReader.Close();
                }
            }

            return settings;
        }
        
        /// <summary>
        /// Serialize and save <see cref="ISimulation"/> at given file path.
        /// </summary>
        /// <param name="path">File save path.</param>
        /// <param name="simulation"><see cref="ISimulation"/> to save.</param>
        /// <returns>True if <see cref="ISimulation"/> saved properly.</returns>
        private bool TrySaveSimulation(string path, ISimulation simulation)
        {
            FileStream fileStream;
            if (!File.Exists(path))
            {
                fileStream = File.Create(path);
            }
            else
            {
                fileStream = File.Open(path, FileMode.Truncate, FileAccess.Write);
            }
            var streamWriter = new StreamWriter(fileStream);

            try
            {
                var json = JsonSerializer.Serialize(simulation, jsonSerializerOptions);
                streamWriter.Write(json);
                return true;
            }
            catch (Exception exception)
            {
            }
            finally
            {
                streamWriter.Close();
            }
            return false;
        }

        /// <summary>
        /// Deserialize <see cref="ISimulation"/> from given path.
        /// </summary>
        /// <param name="path">Saved file path.</param>
        /// <param name="simulation">Deserialized <see cref="ISimulation"/>.</param>
        /// <returns>True if deserialization into <paramref name="simulation"/> worked properly.</returns>
        private bool TryGetSavedSimulation(string path, out ISimulation? simulation)
        {
            simulation = null;
            if (File.Exists(path))
            {
                var fileStream = File.OpenRead(path);
                var streamReader = new StreamReader(fileStream);

                try
                {
                    var tempSimulation = JsonSerializer.Deserialize<ISimulation?>(streamReader.ReadToEnd(), jsonSerializerOptions);
                    if (tempSimulation != null)
                    {
                        simulation = tempSimulation;
                        return true;
                    }

                }
                catch (Exception exception)
                {
                }
                finally 
                { 
                    streamReader.Close(); 
                }
            }
            return false;
        }

        /// <summary>
        /// Initialize current settings when settings reference has changed due to loading a save file.
        /// </summary>
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
            TrySaveSettings();
            graphicsPanel.Invalidate();
        }

        /// <summary>
        /// Clean up old settings before reference is lost.
        /// </summary>
        private void DisposeSettings()
        {
            if (CurrentSettings != null)
            {
                CurrentSettings.PropertyChanged += CurrentSettings_PropertyChanged;
            }
        }

        /// <summary>
        /// Start running simulation.
        /// </summary>
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

        /// <summary>
        /// Stop running simulation.
        /// </summary>
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

        /// <summary>
        /// Step one generation in simulation.
        /// </summary>
        private void StepSimulation()
        {
            if(simulateToGeneration is not null
                && simulateToGeneration <= simulation.Generation)
            {
                StopSimulation();
                return;
            }
            simulation.Update(CurrentSettings);
            graphicsPanel.Invalidate();
        }

        /// <summary>
        /// Set new clean slated simulation environment.
        /// </summary>
        public void NewFile()
        {
            var result = newSimulationDialogForm.ShowDialog(this);
            if(result != DialogResult.OK)
            {
                return;
            }

            simulation = (ISimulation)Activator.CreateInstance(newSimulationDialogForm.SimulationType);
            simulation.Initialize(CurrentSettings);
            //simulation = new GameOfLifeSimulation(CurrentSettings.Options.UniverseWidth, CurrentSettings.Options.UniverseHeight);
            graphicsPanel.Invalidate();
        }

        /// <summary>
        /// Open file dialog and set current simulation.
        /// </summary>
        public void OpenFileDialog()
        {
            var result = openFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            if (TryGetSavedSimulation(openFileDialog.FileName, out var simulation)
                && simulation is not null)
            {
                this.simulation = simulation;
                graphicsPanel.Invalidate();
                CurrentSettings.Options =
                    new Options(CurrentSettings.Options.TimerInterval,
                        simulation.UniverseWidth,
                        simulation.UniverseHeight);
            }
            else
            {
                MessageBox.Show(this, "Could not load file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Open Save Dialog for current simulation.
        /// </summary>
        public void SaveFileDialog()
        {
            var result = saveFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }

            if (!TrySaveSimulation(saveFileDialog.FileName, simulation))
            {
                MessageBox.Show(this, "Could not save file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exit Application.
        /// </summary>
        public void ExitApplication()
        {
            Close();
        }
        #endregion

        #region Core Events
        /// <summary>
        /// Listener for when properties in observabled settings has changed.
        /// </summary>
        /// <param name="sender">Object that is sending the event.</param>
        /// <param name="e">Property information for observed changed.</param>
        private void CurrentSettings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Settings.Options))
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

            // Save changed settings
            TrySaveSettings();

            // Force redraw of graphicsPanel   
            graphicsPanel.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            StepSimulation();
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            simulation.Draw(graphics, CurrentSettings);

            generationsStatusLabel.Text = $"Generation: {simulation.Generation}";
            aliveStatusLabel.Text = $"Alive: {simulation.AliveCount}";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            graphicsPanel.Invalidate();
        }
        #endregion

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

        private void saveFileMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
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
            simulateToDialogForm.Generation = simulation.Generation + 1;
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

        #region Handle Inputs
        private void HandleMouseInputs(MouseEventArgs e)
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
            HandleMouseInputs(e);
        }

        private void graphicsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // Change what mouseEventArgs are sent to update inputs since
            // the one sent from the event is only the current button pressed and not all button states
            var mouseEventArgs = new MouseEventArgs(Control.MouseButtons, e.Clicks, e.X, e.Y, e.Delta);
            HandleMouseInputs(mouseEventArgs);
        }
        #endregion
    }
}