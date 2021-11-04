namespace GameOfLife
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.generationsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.intervalStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.aliveStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.seedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.newFileButton = new System.Windows.Forms.ToolStripButton();
            this.openFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolbarSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.playButton = new System.Windows.Forms.ToolStripButton();
            this.pauseButton = new System.Windows.Forms.ToolStripButton();
            this.stepButton = new System.Windows.Forms.ToolStripButton();
            this.menubar = new System.Windows.Forms.MenuStrip();
            this.fileMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.hudMenuItemToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.neighborCountMenuItemToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMenuItemToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.wrapUniverseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSeedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromCurrentSeedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.backColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridX10ColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbarContainer = new System.Windows.Forms.ToolStripContainer();
            this.graphicsPanel = new GameOfLife.DoubleBufferPanel();
            this.menubarContainer = new System.Windows.Forms.ToolStripContainer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusbar.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.menubar.SuspendLayout();
            this.toolbarContainer.ContentPanel.SuspendLayout();
            this.toolbarContainer.TopToolStripPanel.SuspendLayout();
            this.toolbarContainer.SuspendLayout();
            this.menubarContainer.ContentPanel.SuspendLayout();
            this.menubarContainer.TopToolStripPanel.SuspendLayout();
            this.menubarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generationsStatusLabel,
            this.intervalStatusLabel,
            this.aliveStatusLabel,
            this.seedStatusLabel});
            this.statusbar.Location = new System.Drawing.Point(0, 589);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(634, 22);
            this.statusbar.TabIndex = 0;
            // 
            // generationsStatusLabel
            // 
            this.generationsStatusLabel.Name = "generationsStatusLabel";
            this.generationsStatusLabel.Size = new System.Drawing.Size(82, 17);
            this.generationsStatusLabel.Text = "Generations: 0";
            // 
            // intervalStatusLabel
            // 
            this.intervalStatusLabel.Name = "intervalStatusLabel";
            this.intervalStatusLabel.Size = new System.Drawing.Size(64, 17);
            this.intervalStatusLabel.Text = "Interval: 20";
            // 
            // aliveStatusLabel
            // 
            this.aliveStatusLabel.Name = "aliveStatusLabel";
            this.aliveStatusLabel.Size = new System.Drawing.Size(45, 17);
            this.aliveStatusLabel.Text = "Alive: 0";
            // 
            // seedStatusLabel
            // 
            this.seedStatusLabel.Name = "seedStatusLabel";
            this.seedStatusLabel.Size = new System.Drawing.Size(44, 17);
            this.seedStatusLabel.Text = "Seed: 0";
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openFileButton,
            this.saveFileButton,
            this.toolbarSeparator1,
            this.playButton,
            this.pauseButton,
            this.stepButton});
            this.toolbar.Location = new System.Drawing.Point(3, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(156, 25);
            this.toolbar.TabIndex = 2;
            // 
            // newFileButton
            // 
            this.newFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileButton.Image = ((System.Drawing.Image)(resources.GetObject("newFileButton.Image")));
            this.newFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(23, 22);
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileButton.Image = ((System.Drawing.Image)(resources.GetObject("openFileButton.Image")));
            this.openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(23, 22);
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveFileButton.Image")));
            this.saveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(23, 22);
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // toolbarSeparator1
            // 
            this.toolbarSeparator1.Name = "toolbarSeparator1";
            this.toolbarSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // playButton
            // 
            this.playButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(23, 22);
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseButton.Enabled = false;
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(23, 22);
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stepButton.Image = ((System.Drawing.Image)(resources.GetObject("stepButton.Image")));
            this.stepButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(23, 22);
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // menubar
            // 
            this.menubar.Dock = System.Windows.Forms.DockStyle.None;
            this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItemOptions,
            this.viewMenuItemOptions,
            this.runMenuItemOptions,
            this.randomizeMenuItemOptions,
            this.settingsMenuItemOptions,
            this.helpMenuItem});
            this.menubar.Location = new System.Drawing.Point(0, 0);
            this.menubar.Name = "menubar";
            this.menubar.Size = new System.Drawing.Size(634, 24);
            this.menubar.TabIndex = 3;
            // 
            // fileMenuItemOptions
            // 
            this.fileMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileMenuItem,
            this.openFileMenuItem,
            this.fileSeparator1,
            this.saveFileMenuItem,
            this.fileSeparator2,
            this.exitMenuItem});
            this.fileMenuItemOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileMenuItemOptions.Name = "fileMenuItemOptions";
            this.fileMenuItemOptions.ShortcutKeyDisplayString = "Ctrl+N";
            this.fileMenuItemOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.fileMenuItemOptions.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItemOptions.Text = "File";
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newFileMenuItem.Text = "New";
            this.newFileMenuItem.Click += new System.EventHandler(this.newFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openFileMenuItem.Text = "Open";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // fileSeparator1
            // 
            this.fileSeparator1.Name = "fileSeparator1";
            this.fileSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveFileMenuItem.Text = "Save";
            this.saveFileMenuItem.Click += new System.EventHandler(this.saveFileMenuItem_Click);
            // 
            // fileSeparator2
            // 
            this.fileSeparator2.Name = "fileSeparator2";
            this.fileSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // viewMenuItemOptions
            // 
            this.viewMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hudMenuItemToggle,
            this.neighborCountMenuItemToggle,
            this.gridMenuItemToggle,
            this.wrapUniverseMenuItem});
            this.viewMenuItemOptions.Name = "viewMenuItemOptions";
            this.viewMenuItemOptions.Size = new System.Drawing.Size(44, 20);
            this.viewMenuItemOptions.Text = "View";
            // 
            // hudMenuItemToggle
            // 
            this.hudMenuItemToggle.Checked = true;
            this.hudMenuItemToggle.CheckOnClick = true;
            this.hudMenuItemToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hudMenuItemToggle.Name = "hudMenuItemToggle";
            this.hudMenuItemToggle.Size = new System.Drawing.Size(160, 22);
            this.hudMenuItemToggle.Text = "HUD";
            this.hudMenuItemToggle.Click += new System.EventHandler(this.hudMenuItemToggle_Click);
            // 
            // neighborCountMenuItemToggle
            // 
            this.neighborCountMenuItemToggle.Checked = true;
            this.neighborCountMenuItemToggle.CheckOnClick = true;
            this.neighborCountMenuItemToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.neighborCountMenuItemToggle.Name = "neighborCountMenuItemToggle";
            this.neighborCountMenuItemToggle.Size = new System.Drawing.Size(160, 22);
            this.neighborCountMenuItemToggle.Text = "Neighbor Count";
            this.neighborCountMenuItemToggle.Click += new System.EventHandler(this.neighborCountMenuItemToggle_Click);
            // 
            // gridMenuItemToggle
            // 
            this.gridMenuItemToggle.Checked = true;
            this.gridMenuItemToggle.CheckOnClick = true;
            this.gridMenuItemToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridMenuItemToggle.Name = "gridMenuItemToggle";
            this.gridMenuItemToggle.Size = new System.Drawing.Size(160, 22);
            this.gridMenuItemToggle.Text = "Grid";
            this.gridMenuItemToggle.Click += new System.EventHandler(this.gridMenuItemToggle_Click);
            // 
            // wrapUniverseMenuItem
            // 
            this.wrapUniverseMenuItem.Checked = true;
            this.wrapUniverseMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wrapUniverseMenuItem.Name = "wrapUniverseMenuItem";
            this.wrapUniverseMenuItem.Size = new System.Drawing.Size(160, 22);
            this.wrapUniverseMenuItem.Text = "Wrap Universe";
            this.wrapUniverseMenuItem.Click += new System.EventHandler(this.wrapUniverseMenuItem_Click);
            // 
            // runMenuItemOptions
            // 
            this.runMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenuItem,
            this.pauseMenuItem,
            this.nextMenuItem,
            this.toMenuItem});
            this.runMenuItemOptions.Name = "runMenuItemOptions";
            this.runMenuItemOptions.Size = new System.Drawing.Size(40, 20);
            this.runMenuItemOptions.Text = "Run";
            // 
            // startMenuItem
            // 
            this.startMenuItem.Name = "startMenuItem";
            this.startMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startMenuItem.Size = new System.Drawing.Size(124, 22);
            this.startMenuItem.Text = "Start";
            this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Enabled = false;
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.pauseMenuItem.Size = new System.Drawing.Size(124, 22);
            this.pauseMenuItem.Text = "Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.pauseMenuItem_Click);
            // 
            // nextMenuItem
            // 
            this.nextMenuItem.Name = "nextMenuItem";
            this.nextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.nextMenuItem.Size = new System.Drawing.Size(124, 22);
            this.nextMenuItem.Text = "Next";
            this.nextMenuItem.Click += new System.EventHandler(this.nextMenuItem_Click);
            // 
            // toMenuItem
            // 
            this.toMenuItem.Name = "toMenuItem";
            this.toMenuItem.Size = new System.Drawing.Size(124, 22);
            this.toMenuItem.Text = "To";
            this.toMenuItem.Click += new System.EventHandler(this.toMenuItem_Click);
            // 
            // randomizeMenuItemOptions
            // 
            this.randomizeMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromSeedMenuItem,
            this.fromCurrentSeedMenuItem,
            this.fromTimeMenuItem});
            this.randomizeMenuItemOptions.Name = "randomizeMenuItemOptions";
            this.randomizeMenuItemOptions.Size = new System.Drawing.Size(78, 20);
            this.randomizeMenuItemOptions.Text = "Randomize";
            // 
            // fromSeedMenuItem
            // 
            this.fromSeedMenuItem.Name = "fromSeedMenuItem";
            this.fromSeedMenuItem.Size = new System.Drawing.Size(173, 22);
            this.fromSeedMenuItem.Text = "From Seed";
            this.fromSeedMenuItem.Click += new System.EventHandler(this.fromSeedMenuItem_Click);
            // 
            // fromCurrentSeedMenuItem
            // 
            this.fromCurrentSeedMenuItem.Name = "fromCurrentSeedMenuItem";
            this.fromCurrentSeedMenuItem.Size = new System.Drawing.Size(173, 22);
            this.fromCurrentSeedMenuItem.Text = "From Current Seed";
            this.fromCurrentSeedMenuItem.Click += new System.EventHandler(this.fromCurrentSeedMenuItem_Click);
            // 
            // fromTimeMenuItem
            // 
            this.fromTimeMenuItem.Name = "fromTimeMenuItem";
            this.fromTimeMenuItem.Size = new System.Drawing.Size(173, 22);
            this.fromTimeMenuItem.Text = "From Time";
            this.fromTimeMenuItem.Click += new System.EventHandler(this.fromTimeMenuItem_Click);
            // 
            // settingsMenuItemOptions
            // 
            this.settingsMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backColorMenuItem,
            this.cellColorMenuItem,
            this.gridColorMenuItem,
            this.gridX10ColorMenuItem,
            this.settingsSeparator1,
            this.optionsMenuItem,
            this.settingsSeparator2,
            this.resetMenuItem,
            this.reloadMenuItem});
            this.settingsMenuItemOptions.Name = "settingsMenuItemOptions";
            this.settingsMenuItemOptions.Size = new System.Drawing.Size(61, 20);
            this.settingsMenuItemOptions.Text = "Settings";
            // 
            // backColorMenuItem
            // 
            this.backColorMenuItem.Name = "backColorMenuItem";
            this.backColorMenuItem.Size = new System.Drawing.Size(149, 22);
            this.backColorMenuItem.Text = "Back Color";
            this.backColorMenuItem.Click += new System.EventHandler(this.backColorMenuItem_Click);
            // 
            // cellColorMenuItem
            // 
            this.cellColorMenuItem.Name = "cellColorMenuItem";
            this.cellColorMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cellColorMenuItem.Text = "Cell Color";
            this.cellColorMenuItem.Click += new System.EventHandler(this.cellColorMenuItem_Click);
            // 
            // gridColorMenuItem
            // 
            this.gridColorMenuItem.Name = "gridColorMenuItem";
            this.gridColorMenuItem.Size = new System.Drawing.Size(149, 22);
            this.gridColorMenuItem.Text = "Grid Color";
            this.gridColorMenuItem.Click += new System.EventHandler(this.gridColorMenuItem_Click);
            // 
            // gridX10ColorMenuItem
            // 
            this.gridX10ColorMenuItem.Name = "gridX10ColorMenuItem";
            this.gridX10ColorMenuItem.Size = new System.Drawing.Size(149, 22);
            this.gridX10ColorMenuItem.Text = "Grid x10 Color";
            this.gridX10ColorMenuItem.Click += new System.EventHandler(this.gridX10ColorMenuItem_Click);
            // 
            // settingsSeparator1
            // 
            this.settingsSeparator1.Name = "settingsSeparator1";
            this.settingsSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(149, 22);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // settingsSeparator2
            // 
            this.settingsSeparator2.Name = "settingsSeparator2";
            this.settingsSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.Name = "resetMenuItem";
            this.resetMenuItem.Size = new System.Drawing.Size(149, 22);
            this.resetMenuItem.Text = "Reset";
            this.resetMenuItem.Click += new System.EventHandler(this.resetMenuItem_Click);
            // 
            // reloadMenuItem
            // 
            this.reloadMenuItem.Name = "reloadMenuItem";
            this.reloadMenuItem.Size = new System.Drawing.Size(149, 22);
            this.reloadMenuItem.Text = "Reload";
            this.reloadMenuItem.Click += new System.EventHandler(this.reloadMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // toolbarContainer
            // 
            // 
            // toolbarContainer.ContentPanel
            // 
            this.toolbarContainer.ContentPanel.Controls.Add(this.graphicsPanel);
            this.toolbarContainer.ContentPanel.Size = new System.Drawing.Size(634, 540);
            this.toolbarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarContainer.Location = new System.Drawing.Point(0, 0);
            this.toolbarContainer.Name = "toolbarContainer";
            this.toolbarContainer.Size = new System.Drawing.Size(634, 565);
            this.toolbarContainer.TabIndex = 6;
            // 
            // toolbarContainer.TopToolStripPanel
            // 
            this.toolbarContainer.TopToolStripPanel.Controls.Add(this.toolbar);
            // 
            // graphicsPanel
            // 
            this.graphicsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel.Location = new System.Drawing.Point(0, 0);
            this.graphicsPanel.Name = "graphicsPanel";
            this.graphicsPanel.Size = new System.Drawing.Size(634, 540);
            this.graphicsPanel.TabIndex = 0;
            this.graphicsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel_Paint);
            this.graphicsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel_MouseDown);
            this.graphicsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel_MouseMove);
            // 
            // menubarContainer
            // 
            // 
            // menubarContainer.ContentPanel
            // 
            this.menubarContainer.ContentPanel.Controls.Add(this.toolbarContainer);
            this.menubarContainer.ContentPanel.Size = new System.Drawing.Size(634, 565);
            this.menubarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menubarContainer.Location = new System.Drawing.Point(0, 0);
            this.menubarContainer.Name = "menubarContainer";
            this.menubarContainer.Size = new System.Drawing.Size(634, 589);
            this.menubarContainer.TabIndex = 7;
            // 
            // menubarContainer.TopToolStripPanel
            // 
            this.menubarContainer.TopToolStripPanel.Controls.Add(this.menubar);
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "gol";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "gol";
            this.saveFileDialog.FileName = "gameoflife";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 611);
            this.Controls.Add(this.menubarContainer);
            this.Controls.Add(this.statusbar);
            this.MainMenuStrip = this.menubar;
            this.Name = "MainForm";
            this.Text = "Game of Life";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.menubar.ResumeLayout(false);
            this.menubar.PerformLayout();
            this.toolbarContainer.ContentPanel.ResumeLayout(false);
            this.toolbarContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolbarContainer.TopToolStripPanel.PerformLayout();
            this.toolbarContainer.ResumeLayout(false);
            this.toolbarContainer.PerformLayout();
            this.menubarContainer.ContentPanel.ResumeLayout(false);
            this.menubarContainer.TopToolStripPanel.ResumeLayout(false);
            this.menubarContainer.TopToolStripPanel.PerformLayout();
            this.menubarContainer.ResumeLayout(false);
            this.menubarContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusbar;
        private ToolStripStatusLabel generationsStatusLabel;
        private ToolStripStatusLabel intervalStatusLabel;
        private ToolStripStatusLabel aliveStatusLabel;
        private ToolStripStatusLabel seedStatusLabel;
        private ToolStrip toolbar;
        private MenuStrip menubar;
        private ToolStripButton newFileButton;
        private ToolStripButton openFileButton;
        private ToolStripButton saveFileButton;
        private ToolStripSeparator toolbarSeparator1;
        private ToolStripButton playButton;
        private ToolStripButton pauseButton;
        private ToolStripButton stepButton;
        private ToolStripMenuItem fileMenuItemOptions;
        private ToolStripMenuItem newFileMenuItem;
        private ToolStripMenuItem openFileMenuItem;
        private ToolStripSeparator fileSeparator1;
        private ToolStripMenuItem saveFileMenuItem;
        private ToolStripSeparator fileSeparator2;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem viewMenuItemOptions;
        private ToolStripMenuItem hudMenuItemToggle;
        private ToolStripMenuItem neighborCountMenuItemToggle;
        private ToolStripMenuItem gridMenuItemToggle;
        private ToolStripMenuItem runMenuItemOptions;
        private ToolStripMenuItem startMenuItem;
        private ToolStripMenuItem pauseMenuItem;
        private ToolStripMenuItem nextMenuItem;
        private ToolStripMenuItem toMenuItem;
        private ToolStripMenuItem randomizeMenuItemOptions;
        private ToolStripMenuItem fromSeedMenuItem;
        private ToolStripMenuItem fromCurrentSeedMenuItem;
        private ToolStripMenuItem fromTimeMenuItem;
        private ToolStripMenuItem settingsMenuItemOptions;
        private ToolStripMenuItem backColorMenuItem;
        private ToolStripMenuItem cellColorMenuItem;
        private ToolStripMenuItem gridColorMenuItem;
        private ToolStripMenuItem gridX10ColorMenuItem;
        private ToolStripSeparator settingsSeparator1;
        private ToolStripMenuItem optionsMenuItem;
        private ToolStripSeparator settingsSeparator2;
        private ToolStripMenuItem resetMenuItem;
        private ToolStripMenuItem reloadMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripContainer toolbarContainer;
        private ToolStripContainer menubarContainer;
        private System.Windows.Forms.Timer timer;
        private DoubleBufferPanel graphicsPanel;
        private ColorDialog colorDialog;
        private ToolStripMenuItem fromSeedToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ToolStripMenuItem wrapUniverseMenuItem;
        private ErrorProvider errorProvider;
    }
}