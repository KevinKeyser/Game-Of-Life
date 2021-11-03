namespace GameOfLife
{
    partial class OptionsDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timerIntervalLabel = new System.Windows.Forms.Label();
            this.universeWidthLabel = new System.Windows.Forms.Label();
            this.universeHeightLabel = new System.Windows.Forms.Label();
            this.timerIntervalUpDown = new System.Windows.Forms.NumericUpDown();
            this.universeWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.universeHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.confirmButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.universeWidthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.universeHeightUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerIntervalLabel
            // 
            this.timerIntervalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerIntervalLabel.AutoSize = true;
            this.timerIntervalLabel.Location = new System.Drawing.Point(5, 9);
            this.timerIntervalLabel.Margin = new System.Windows.Forms.Padding(5);
            this.timerIntervalLabel.Name = "timerIntervalLabel";
            this.timerIntervalLabel.Size = new System.Drawing.Size(161, 15);
            this.timerIntervalLabel.TabIndex = 0;
            this.timerIntervalLabel.Text = "Timer Interval in Milliseconds";
            this.timerIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // universeWidthLabel
            // 
            this.universeWidthLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.universeWidthLabel.AutoSize = true;
            this.universeWidthLabel.Location = new System.Drawing.Point(24, 42);
            this.universeWidthLabel.Margin = new System.Windows.Forms.Padding(5);
            this.universeWidthLabel.Name = "universeWidthLabel";
            this.universeWidthLabel.Size = new System.Drawing.Size(142, 15);
            this.universeWidthLabel.TabIndex = 1;
            this.universeWidthLabel.Text = "Width of Universe in Cells";
            this.universeWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // universeHeightLabel
            // 
            this.universeHeightLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.universeHeightLabel.AutoSize = true;
            this.universeHeightLabel.Location = new System.Drawing.Point(20, 76);
            this.universeHeightLabel.Margin = new System.Windows.Forms.Padding(5);
            this.universeHeightLabel.Name = "universeHeightLabel";
            this.universeHeightLabel.Size = new System.Drawing.Size(146, 15);
            this.universeHeightLabel.TabIndex = 2;
            this.universeHeightLabel.Text = "Height of Universe in Cells";
            this.universeHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerIntervalUpDown
            // 
            this.timerIntervalUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timerIntervalUpDown.Location = new System.Drawing.Point(176, 5);
            this.timerIntervalUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.timerIntervalUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timerIntervalUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timerIntervalUpDown.Name = "timerIntervalUpDown";
            this.timerIntervalUpDown.Size = new System.Drawing.Size(60, 23);
            this.timerIntervalUpDown.TabIndex = 0;
            this.timerIntervalUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timerIntervalUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // universeWidthUpDown
            // 
            this.universeWidthUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.universeWidthUpDown.Location = new System.Drawing.Point(176, 38);
            this.universeWidthUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.universeWidthUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.universeWidthUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.universeWidthUpDown.Name = "universeWidthUpDown";
            this.universeWidthUpDown.Size = new System.Drawing.Size(60, 23);
            this.universeWidthUpDown.TabIndex = 1;
            this.universeWidthUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.universeWidthUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // universeHeightUpDown
            // 
            this.universeHeightUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.universeHeightUpDown.Location = new System.Drawing.Point(176, 72);
            this.universeHeightUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.universeHeightUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.universeHeightUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.universeHeightUpDown.Name = "universeHeightUpDown";
            this.universeHeightUpDown.Size = new System.Drawing.Size(60, 23);
            this.universeHeightUpDown.TabIndex = 2;
            this.universeHeightUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.universeHeightUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Location = new System.Drawing.Point(37, 11);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(10);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.universeHeightUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.universeHeightLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.universeWidthUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.universeWidthLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.timerIntervalUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.timerIntervalLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(245, 102);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.confirmButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cancelButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(25, 126);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(245, 46);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(132, 11);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OptionsDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 197);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsDialogForm";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options Dialog";
            this.Load += new System.EventHandler(this.OptionsDialogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.universeWidthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.universeHeightUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label timerIntervalLabel;
        private Label universeWidthLabel;
        private Label universeHeightLabel;
        private NumericUpDown timerIntervalUpDown;
        private NumericUpDown universeWidthUpDown;
        private NumericUpDown universeHeightUpDown;
        private Button confirmButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button cancelButton;
    }
}