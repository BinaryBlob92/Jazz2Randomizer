namespace Jazz2Randomizer
{
    partial class MainForm
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
            this.labelSeed = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.buttonRandomizeSeed = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.labelSeed, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxSeed, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonRandomizeSeed, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonSettings, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(295, 93);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelSeed
            // 
            this.labelSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSeed.AutoSize = true;
            this.labelSeed.Location = new System.Drawing.Point(3, 16);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(35, 13);
            this.labelSeed.TabIndex = 0;
            this.labelSeed.Text = "Seed:";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSeed.Location = new System.Drawing.Point(44, 13);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(121, 20);
            this.textBoxSeed.TabIndex = 1;
            this.textBoxSeed.TextChanged += new System.EventHandler(this.TextBoxSeed_TextChanged);
            // 
            // buttonRandomizeSeed
            // 
            this.buttonRandomizeSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomizeSeed.Location = new System.Drawing.Point(171, 11);
            this.buttonRandomizeSeed.Name = "buttonRandomizeSeed";
            this.buttonRandomizeSeed.Size = new System.Drawing.Size(121, 23);
            this.buttonRandomizeSeed.TabIndex = 2;
            this.buttonRandomizeSeed.Text = "Randomize";
            this.buttonRandomizeSeed.UseVisualStyleBackColor = true;
            this.buttonRandomizeSeed.Click += new System.EventHandler(this.ButtonRandomizeSeed_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.buttonSettings, 3);
            this.buttonSettings.Location = new System.Drawing.Point(3, 58);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(289, 23);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "Settings...";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 93);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MainForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelSeed;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Button buttonRandomizeSeed;
        private System.Windows.Forms.Button buttonSettings;
    }
}