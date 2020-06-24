namespace Jazz2Randomizer
{
    partial class LevelSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelLevelFilename = new System.Windows.Forms.Label();
            this.textBoxLevelFilename = new System.Windows.Forms.TextBox();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.panelCharacters = new System.Windows.Forms.Panel();
            this.checkBoxBird = new System.Windows.Forms.CheckBox();
            this.checkBoxFrog = new System.Windows.Forms.CheckBox();
            this.checkBoxLori = new System.Windows.Forms.CheckBox();
            this.checkBoxSpaz = new System.Windows.Forms.CheckBox();
            this.checkBoxJazz = new System.Windows.Forms.CheckBox();
            this.groupBoxEventGroups = new System.Windows.Forms.GroupBox();
            this.dataGridViewEventGroups = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRandomizeIndividually = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStripEventGroups = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButtonAddEventGroup = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButtonDeleteEventGroup = new System.Windows.Forms.ToolStripButton();
            this.groupBoxEventsFrom = new System.Windows.Forms.GroupBox();
            this.dataGridViewEventsFrom = new System.Windows.Forms.DataGridView();
            this.ColumnFromEventId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFromDifficulty = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStripEventsFrom = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonAddFromEvent = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonDeleteFromEvent = new System.Windows.Forms.ToolStripButton();
            this.groupBoxEventsTo = new System.Windows.Forms.GroupBox();
            this.dataGridViewEventsTo = new System.Windows.Forms.DataGridView();
            this.ColumnToEventId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnToDifficulty = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStripEventsTo = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonAddToEvent = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonDeleteToEvent = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel.SuspendLayout();
            this.panelCharacters.SuspendLayout();
            this.groupBoxEventGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventGroups)).BeginInit();
            this.toolStripEventGroups.SuspendLayout();
            this.groupBoxEventsFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventsFrom)).BeginInit();
            this.toolStripEventsFrom.SuspendLayout();
            this.groupBoxEventsTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventsTo)).BeginInit();
            this.toolStripEventsTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.labelLevelFilename, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxLevelFilename, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelCharacters, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panelCharacters, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.groupBoxEventGroups, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.groupBoxEventsFrom, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.groupBoxEventsTo, 2, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(798, 548);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelLevelFilename
            // 
            this.labelLevelFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLevelFilename.AutoSize = true;
            this.labelLevelFilename.Location = new System.Drawing.Point(3, 6);
            this.labelLevelFilename.Name = "labelLevelFilename";
            this.labelLevelFilename.Size = new System.Drawing.Size(78, 13);
            this.labelLevelFilename.TabIndex = 0;
            this.labelLevelFilename.Text = "Level filename:";
            // 
            // textBoxLevelFilename
            // 
            this.textBoxLevelFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.textBoxLevelFilename, 2);
            this.textBoxLevelFilename.Location = new System.Drawing.Point(87, 3);
            this.textBoxLevelFilename.Name = "textBoxLevelFilename";
            this.textBoxLevelFilename.Size = new System.Drawing.Size(708, 20);
            this.textBoxLevelFilename.TabIndex = 1;
            // 
            // labelCharacters
            // 
            this.labelCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCharacters.AutoSize = true;
            this.labelCharacters.Location = new System.Drawing.Point(3, 32);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(78, 13);
            this.labelCharacters.TabIndex = 2;
            this.labelCharacters.Text = "Characters:";
            // 
            // panelCharacters
            // 
            this.tableLayoutPanel.SetColumnSpan(this.panelCharacters, 2);
            this.panelCharacters.Controls.Add(this.checkBoxBird);
            this.panelCharacters.Controls.Add(this.checkBoxFrog);
            this.panelCharacters.Controls.Add(this.checkBoxLori);
            this.panelCharacters.Controls.Add(this.checkBoxSpaz);
            this.panelCharacters.Controls.Add(this.checkBoxJazz);
            this.panelCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCharacters.Location = new System.Drawing.Point(87, 29);
            this.panelCharacters.Name = "panelCharacters";
            this.panelCharacters.Size = new System.Drawing.Size(708, 20);
            this.panelCharacters.TabIndex = 4;
            // 
            // checkBoxBird
            // 
            this.checkBoxBird.AutoSize = true;
            this.checkBoxBird.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxBird.Location = new System.Drawing.Point(187, 0);
            this.checkBoxBird.Name = "checkBoxBird";
            this.checkBoxBird.Size = new System.Drawing.Size(44, 20);
            this.checkBoxBird.TabIndex = 7;
            this.checkBoxBird.Text = "Bird";
            this.checkBoxBird.UseVisualStyleBackColor = true;
            // 
            // checkBoxFrog
            // 
            this.checkBoxFrog.AutoSize = true;
            this.checkBoxFrog.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxFrog.Location = new System.Drawing.Point(140, 0);
            this.checkBoxFrog.Name = "checkBoxFrog";
            this.checkBoxFrog.Size = new System.Drawing.Size(47, 20);
            this.checkBoxFrog.TabIndex = 6;
            this.checkBoxFrog.Text = "Frog";
            this.checkBoxFrog.UseVisualStyleBackColor = true;
            // 
            // checkBoxLori
            // 
            this.checkBoxLori.AutoSize = true;
            this.checkBoxLori.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxLori.Location = new System.Drawing.Point(97, 0);
            this.checkBoxLori.Name = "checkBoxLori";
            this.checkBoxLori.Size = new System.Drawing.Size(43, 20);
            this.checkBoxLori.TabIndex = 5;
            this.checkBoxLori.Text = "Lori";
            this.checkBoxLori.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpaz
            // 
            this.checkBoxSpaz.AutoSize = true;
            this.checkBoxSpaz.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxSpaz.Location = new System.Drawing.Point(47, 0);
            this.checkBoxSpaz.Name = "checkBoxSpaz";
            this.checkBoxSpaz.Size = new System.Drawing.Size(50, 20);
            this.checkBoxSpaz.TabIndex = 4;
            this.checkBoxSpaz.Text = "Spaz";
            this.checkBoxSpaz.UseVisualStyleBackColor = true;
            // 
            // checkBoxJazz
            // 
            this.checkBoxJazz.AutoSize = true;
            this.checkBoxJazz.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxJazz.Location = new System.Drawing.Point(0, 0);
            this.checkBoxJazz.Name = "checkBoxJazz";
            this.checkBoxJazz.Size = new System.Drawing.Size(47, 20);
            this.checkBoxJazz.TabIndex = 3;
            this.checkBoxJazz.Text = "Jazz";
            this.checkBoxJazz.UseVisualStyleBackColor = true;
            // 
            // groupBoxEventGroups
            // 
            this.tableLayoutPanel.SetColumnSpan(this.groupBoxEventGroups, 2);
            this.groupBoxEventGroups.Controls.Add(this.dataGridViewEventGroups);
            this.groupBoxEventGroups.Controls.Add(this.toolStripEventGroups);
            this.groupBoxEventGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEventGroups.Location = new System.Drawing.Point(3, 55);
            this.groupBoxEventGroups.Name = "groupBoxEventGroups";
            this.tableLayoutPanel.SetRowSpan(this.groupBoxEventGroups, 2);
            this.groupBoxEventGroups.Size = new System.Drawing.Size(250, 490);
            this.groupBoxEventGroups.TabIndex = 5;
            this.groupBoxEventGroups.TabStop = false;
            this.groupBoxEventGroups.Text = "Event groups";
            // 
            // dataGridViewEventGroups
            // 
            this.dataGridViewEventGroups.AllowUserToAddRows = false;
            this.dataGridViewEventGroups.AllowUserToDeleteRows = false;
            this.dataGridViewEventGroups.AllowUserToResizeRows = false;
            this.dataGridViewEventGroups.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewEventGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnRandomizeIndividually});
            this.dataGridViewEventGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEventGroups.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewEventGroups.Location = new System.Drawing.Point(3, 41);
            this.dataGridViewEventGroups.MultiSelect = false;
            this.dataGridViewEventGroups.Name = "dataGridViewEventGroups";
            this.dataGridViewEventGroups.RowHeadersVisible = false;
            this.dataGridViewEventGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEventGroups.Size = new System.Drawing.Size(244, 446);
            this.dataGridViewEventGroups.TabIndex = 1;
            this.dataGridViewEventGroups.SelectionChanged += new System.EventHandler(this.DataGridViewEventGroups_SelectionChanged);
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnRandomizeIndividually
            // 
            this.ColumnRandomizeIndividually.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRandomizeIndividually.DataPropertyName = "RandomizeIndividually";
            this.ColumnRandomizeIndividually.HeaderText = "Randomize individually";
            this.ColumnRandomizeIndividually.Name = "ColumnRandomizeIndividually";
            // 
            // toolStripEventGroups
            // 
            this.toolStripEventGroups.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEventGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButtonAddEventGroup,
            this.toolStripButtonDeleteEventGroup});
            this.toolStripEventGroups.Location = new System.Drawing.Point(3, 16);
            this.toolStripEventGroups.Name = "toolStripEventGroups";
            this.toolStripEventGroups.Size = new System.Drawing.Size(244, 25);
            this.toolStripEventGroups.TabIndex = 0;
            this.toolStripEventGroups.Text = "toolStrip1";
            // 
            // toolStripSplitButtonAddEventGroup
            // 
            this.toolStripSplitButtonAddEventGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButtonAddEventGroup.Image = global::Jazz2Randomizer.Properties.Resources.add;
            this.toolStripSplitButtonAddEventGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonAddEventGroup.Name = "toolStripSplitButtonAddEventGroup";
            this.toolStripSplitButtonAddEventGroup.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButtonAddEventGroup.ButtonClick += new System.EventHandler(this.ToolStripSplitButtonAddEventGroup_ButtonClick);
            // 
            // toolStripButtonDeleteEventGroup
            // 
            this.toolStripButtonDeleteEventGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteEventGroup.Image = global::Jazz2Randomizer.Properties.Resources.delete;
            this.toolStripButtonDeleteEventGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteEventGroup.Name = "toolStripButtonDeleteEventGroup";
            this.toolStripButtonDeleteEventGroup.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteEventGroup.Click += new System.EventHandler(this.ToolStripButtonDeleteEventGroup_Click);
            // 
            // groupBoxEventsFrom
            // 
            this.groupBoxEventsFrom.Controls.Add(this.dataGridViewEventsFrom);
            this.groupBoxEventsFrom.Controls.Add(this.toolStripEventsFrom);
            this.groupBoxEventsFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEventsFrom.Enabled = false;
            this.groupBoxEventsFrom.Location = new System.Drawing.Point(259, 55);
            this.groupBoxEventsFrom.Name = "groupBoxEventsFrom";
            this.groupBoxEventsFrom.Size = new System.Drawing.Size(536, 242);
            this.groupBoxEventsFrom.TabIndex = 6;
            this.groupBoxEventsFrom.TabStop = false;
            this.groupBoxEventsFrom.Text = "Turn these events...";
            // 
            // dataGridViewEventsFrom
            // 
            this.dataGridViewEventsFrom.AllowUserToAddRows = false;
            this.dataGridViewEventsFrom.AllowUserToDeleteRows = false;
            this.dataGridViewEventsFrom.AllowUserToResizeRows = false;
            this.dataGridViewEventsFrom.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewEventsFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventsFrom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFromEventId,
            this.ColumnFromDifficulty});
            this.dataGridViewEventsFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEventsFrom.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewEventsFrom.Location = new System.Drawing.Point(3, 41);
            this.dataGridViewEventsFrom.Name = "dataGridViewEventsFrom";
            this.dataGridViewEventsFrom.RowHeadersVisible = false;
            this.dataGridViewEventsFrom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEventsFrom.Size = new System.Drawing.Size(530, 198);
            this.dataGridViewEventsFrom.TabIndex = 2;
            // 
            // ColumnFromEventId
            // 
            this.ColumnFromEventId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFromEventId.DataPropertyName = "EventId";
            this.ColumnFromEventId.HeaderText = "Event ID";
            this.ColumnFromEventId.Name = "ColumnFromEventId";
            // 
            // ColumnFromDifficulty
            // 
            this.ColumnFromDifficulty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFromDifficulty.DataPropertyName = "Difficulty";
            this.ColumnFromDifficulty.HeaderText = "Difficulty";
            this.ColumnFromDifficulty.Name = "ColumnFromDifficulty";
            // 
            // toolStripEventsFrom
            // 
            this.toolStripEventsFrom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEventsFrom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonAddFromEvent,
            this.toolStripButtonDeleteFromEvent});
            this.toolStripEventsFrom.Location = new System.Drawing.Point(3, 16);
            this.toolStripEventsFrom.Name = "toolStripEventsFrom";
            this.toolStripEventsFrom.Size = new System.Drawing.Size(530, 25);
            this.toolStripEventsFrom.TabIndex = 1;
            this.toolStripEventsFrom.Text = "toolStrip2";
            // 
            // toolStripDropDownButtonAddFromEvent
            // 
            this.toolStripDropDownButtonAddFromEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonAddFromEvent.Image = global::Jazz2Randomizer.Properties.Resources.add;
            this.toolStripDropDownButtonAddFromEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAddFromEvent.Name = "toolStripDropDownButtonAddFromEvent";
            this.toolStripDropDownButtonAddFromEvent.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonAddFromEvent.Text = "toolStripDropDownButton1";
            // 
            // toolStripButtonDeleteFromEvent
            // 
            this.toolStripButtonDeleteFromEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteFromEvent.Image = global::Jazz2Randomizer.Properties.Resources.delete;
            this.toolStripButtonDeleteFromEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteFromEvent.Name = "toolStripButtonDeleteFromEvent";
            this.toolStripButtonDeleteFromEvent.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteFromEvent.Click += new System.EventHandler(this.ToolStripButtonDeleteFromEvent_Click);
            // 
            // groupBoxEventsTo
            // 
            this.groupBoxEventsTo.Controls.Add(this.dataGridViewEventsTo);
            this.groupBoxEventsTo.Controls.Add(this.toolStripEventsTo);
            this.groupBoxEventsTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEventsTo.Enabled = false;
            this.groupBoxEventsTo.Location = new System.Drawing.Point(259, 303);
            this.groupBoxEventsTo.Name = "groupBoxEventsTo";
            this.groupBoxEventsTo.Size = new System.Drawing.Size(536, 242);
            this.groupBoxEventsTo.TabIndex = 7;
            this.groupBoxEventsTo.TabStop = false;
            this.groupBoxEventsTo.Text = "...into any of these events:";
            // 
            // dataGridViewEventsTo
            // 
            this.dataGridViewEventsTo.AllowUserToAddRows = false;
            this.dataGridViewEventsTo.AllowUserToDeleteRows = false;
            this.dataGridViewEventsTo.AllowUserToResizeRows = false;
            this.dataGridViewEventsTo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewEventsTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventsTo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnToEventId,
            this.ColumnToDifficulty});
            this.dataGridViewEventsTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEventsTo.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewEventsTo.Location = new System.Drawing.Point(3, 41);
            this.dataGridViewEventsTo.Name = "dataGridViewEventsTo";
            this.dataGridViewEventsTo.RowHeadersVisible = false;
            this.dataGridViewEventsTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEventsTo.Size = new System.Drawing.Size(530, 198);
            this.dataGridViewEventsTo.TabIndex = 3;
            // 
            // ColumnToEventId
            // 
            this.ColumnToEventId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnToEventId.DataPropertyName = "EventId";
            this.ColumnToEventId.HeaderText = "Event ID";
            this.ColumnToEventId.Name = "ColumnToEventId";
            // 
            // ColumnToDifficulty
            // 
            this.ColumnToDifficulty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnToDifficulty.DataPropertyName = "Difficulty";
            this.ColumnToDifficulty.HeaderText = "Difficulty";
            this.ColumnToDifficulty.Name = "ColumnToDifficulty";
            // 
            // toolStripEventsTo
            // 
            this.toolStripEventsTo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEventsTo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonAddToEvent,
            this.toolStripButtonDeleteToEvent});
            this.toolStripEventsTo.Location = new System.Drawing.Point(3, 16);
            this.toolStripEventsTo.Name = "toolStripEventsTo";
            this.toolStripEventsTo.Size = new System.Drawing.Size(530, 25);
            this.toolStripEventsTo.TabIndex = 2;
            this.toolStripEventsTo.Text = "toolStrip3";
            // 
            // toolStripDropDownButtonAddToEvent
            // 
            this.toolStripDropDownButtonAddToEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonAddToEvent.Image = global::Jazz2Randomizer.Properties.Resources.add;
            this.toolStripDropDownButtonAddToEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAddToEvent.Name = "toolStripDropDownButtonAddToEvent";
            this.toolStripDropDownButtonAddToEvent.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonAddToEvent.Text = "toolStripDropDownButton1";
            // 
            // toolStripButtonDeleteToEvent
            // 
            this.toolStripButtonDeleteToEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteToEvent.Image = global::Jazz2Randomizer.Properties.Resources.delete;
            this.toolStripButtonDeleteToEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteToEvent.Name = "toolStripButtonDeleteToEvent";
            this.toolStripButtonDeleteToEvent.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteToEvent.Click += new System.EventHandler(this.ToolStripButtonDeleteToEvent_Click);
            // 
            // LevelSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "LevelSettingsControl";
            this.Size = new System.Drawing.Size(798, 548);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelCharacters.ResumeLayout(false);
            this.panelCharacters.PerformLayout();
            this.groupBoxEventGroups.ResumeLayout(false);
            this.groupBoxEventGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventGroups)).EndInit();
            this.toolStripEventGroups.ResumeLayout(false);
            this.toolStripEventGroups.PerformLayout();
            this.groupBoxEventsFrom.ResumeLayout(false);
            this.groupBoxEventsFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventsFrom)).EndInit();
            this.toolStripEventsFrom.ResumeLayout(false);
            this.toolStripEventsFrom.PerformLayout();
            this.groupBoxEventsTo.ResumeLayout(false);
            this.groupBoxEventsTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventsTo)).EndInit();
            this.toolStripEventsTo.ResumeLayout(false);
            this.toolStripEventsTo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelLevelFilename;
        private System.Windows.Forms.TextBox textBoxLevelFilename;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.Panel panelCharacters;
        private System.Windows.Forms.CheckBox checkBoxBird;
        private System.Windows.Forms.CheckBox checkBoxFrog;
        private System.Windows.Forms.CheckBox checkBoxLori;
        private System.Windows.Forms.CheckBox checkBoxSpaz;
        private System.Windows.Forms.CheckBox checkBoxJazz;
        private System.Windows.Forms.GroupBox groupBoxEventGroups;
        private System.Windows.Forms.DataGridView dataGridViewEventGroups;
        private System.Windows.Forms.ToolStrip toolStripEventGroups;
        private System.Windows.Forms.GroupBox groupBoxEventsFrom;
        private System.Windows.Forms.GroupBox groupBoxEventsTo;
        private System.Windows.Forms.DataGridView dataGridViewEventsFrom;
        private System.Windows.Forms.ToolStrip toolStripEventsFrom;
        private System.Windows.Forms.ToolStrip toolStripEventsTo;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteEventGroup;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteFromEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRandomizeIndividually;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAddFromEvent;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonAddEventGroup;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAddToEvent;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteToEvent;
        private System.Windows.Forms.DataGridView dataGridViewEventsTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFromEventId;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFromDifficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnToEventId;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnToDifficulty;
    }
}
