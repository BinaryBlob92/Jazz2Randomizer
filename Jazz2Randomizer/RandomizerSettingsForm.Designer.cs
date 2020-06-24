namespace Jazz2Randomizer
{
    partial class RandomizerSettingsForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLevelSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxLevels = new System.Windows.Forms.GroupBox();
            this.dataGridViewLevels = new System.Windows.Forms.DataGridView();
            this.ColumnLevelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripLevels = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxLevels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLevels)).BeginInit();
            this.toolStripLevels.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.Controls.Add(this.groupBoxLevelSettings, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBoxLevels, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 425F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 425);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // groupBoxLevelSettings
            // 
            this.groupBoxLevelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLevelSettings.Location = new System.Drawing.Point(243, 3);
            this.groupBoxLevelSettings.Name = "groupBoxLevelSettings";
            this.groupBoxLevelSettings.Size = new System.Drawing.Size(554, 419);
            this.groupBoxLevelSettings.TabIndex = 1;
            this.groupBoxLevelSettings.TabStop = false;
            this.groupBoxLevelSettings.Text = "Level settings";
            // 
            // groupBoxLevels
            // 
            this.groupBoxLevels.Controls.Add(this.dataGridViewLevels);
            this.groupBoxLevels.Controls.Add(this.toolStripLevels);
            this.groupBoxLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLevels.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLevels.Name = "groupBoxLevels";
            this.groupBoxLevels.Size = new System.Drawing.Size(234, 419);
            this.groupBoxLevels.TabIndex = 0;
            this.groupBoxLevels.TabStop = false;
            this.groupBoxLevels.Text = "Levels";
            // 
            // dataGridViewLevels
            // 
            this.dataGridViewLevels.AllowUserToAddRows = false;
            this.dataGridViewLevels.AllowUserToDeleteRows = false;
            this.dataGridViewLevels.AllowUserToResizeColumns = false;
            this.dataGridViewLevels.AllowUserToResizeRows = false;
            this.dataGridViewLevels.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLevels.ColumnHeadersVisible = false;
            this.dataGridViewLevels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLevelName});
            this.dataGridViewLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLevels.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewLevels.Location = new System.Drawing.Point(3, 41);
            this.dataGridViewLevels.MultiSelect = false;
            this.dataGridViewLevels.Name = "dataGridViewLevels";
            this.dataGridViewLevels.RowHeadersVisible = false;
            this.dataGridViewLevels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLevels.Size = new System.Drawing.Size(228, 375);
            this.dataGridViewLevels.TabIndex = 0;
            this.dataGridViewLevels.SelectionChanged += new System.EventHandler(this.DataGridViewLevels_SelectionChanged);
            // 
            // ColumnLevelName
            // 
            this.ColumnLevelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnLevelName.DataPropertyName = "LevelFilename";
            this.ColumnLevelName.HeaderText = "Level name";
            this.ColumnLevelName.Name = "ColumnLevelName";
            // 
            // toolStripLevels
            // 
            this.toolStripLevels.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLevels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddLevel,
            this.toolStripButtonDeleteLevel});
            this.toolStripLevels.Location = new System.Drawing.Point(3, 16);
            this.toolStripLevels.Name = "toolStripLevels";
            this.toolStripLevels.Size = new System.Drawing.Size(228, 25);
            this.toolStripLevels.TabIndex = 1;
            this.toolStripLevels.Text = "toolStrip1";
            // 
            // toolStripButtonAddLevel
            // 
            this.toolStripButtonAddLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLevel.Image = global::Jazz2Randomizer.Properties.Resources.add;
            this.toolStripButtonAddLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLevel.Name = "toolStripButtonAddLevel";
            this.toolStripButtonAddLevel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddLevel.Click += new System.EventHandler(this.ToolStripButtonAddLevel_Click);
            // 
            // toolStripButtonDeleteLevel
            // 
            this.toolStripButtonDeleteLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteLevel.Image = global::Jazz2Randomizer.Properties.Resources.delete;
            this.toolStripButtonDeleteLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteLevel.Name = "toolStripButtonDeleteLevel";
            this.toolStripButtonDeleteLevel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteLevel.Click += new System.EventHandler(this.ToolStripButtonDeleteLevel_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::Jazz2Randomizer.Properties.Resources._new;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNew.Click += new System.EventHandler(this.ToolStripButtonNew_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::Jazz2Randomizer.Properties.Resources.open;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Click += new System.EventHandler(this.ToolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::Jazz2Randomizer.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // RandomizerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Name = "RandomizerSettingsForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxLevels.ResumeLayout(false);
            this.groupBoxLevels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLevels)).EndInit();
            this.toolStripLevels.ResumeLayout(false);
            this.toolStripLevels.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxLevelSettings;
        private System.Windows.Forms.GroupBox groupBoxLevels;
        private System.Windows.Forms.DataGridView dataGridViewLevels;
        private System.Windows.Forms.ToolStrip toolStripLevels;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLevel;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLevelName;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
    }
}