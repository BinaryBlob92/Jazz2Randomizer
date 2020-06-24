using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Jazz2Randomizer
{
    public partial class RandomizerSettingsForm : Form
    {
        private RandomizerSettings randomizerSettings;
        private BindingList<LevelSettings> levels => (BindingList<LevelSettings>)dataGridViewLevels.DataSource;

        public RandomizerSettingsForm(RandomizerSettings randomizerSettings)
        {
            this.randomizerSettings = randomizerSettings;

            InitializeComponent();
            dataGridViewLevels.AutoGenerateColumns = false;
            dataGridViewLevels.DataSource = new BindingList<LevelSettings>(this.randomizerSettings.LevelSettings);
        }

        private void ToolStripButtonAddLevel_Click(object sender, EventArgs e)
        {
            levels.Add(new LevelSettings());
        }

        private void ToolStripButtonDeleteLevel_Click(object sender, EventArgs e)
        {
            var selectedLevels = dataGridViewLevels.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(x => (LevelSettings)x.DataBoundItem)
                .ToList();

            foreach (var level in selectedLevels)
                levels.Remove(level);
        }

        private void DataGridViewLevels_SelectionChanged(object sender, EventArgs e)
        {
            var selectedLevel = dataGridViewLevels.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(x => (LevelSettings)x.DataBoundItem)
                .FirstOrDefault();

            groupBoxLevelSettings.Controls.Clear();

            if (selectedLevel != null)
                groupBoxLevelSettings.Controls.Add(new LevelSettingsControl(this.randomizerSettings, selectedLevel));
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            levels.Clear();
        }

        private void ToolStripButtonOpen_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Jazz 2 Randomizer files|*.j2r|XML-files|*.xml";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.randomizerSettings.LoadFrom(dialog.FileName);
                        dataGridViewLevels.DataSource = new BindingList<LevelSettings>(this.randomizerSettings.LevelSettings);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open settings:\r\n" + ex.Message, "An error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ToolStripButtonSave_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Jazz 2 Randomizer files|*.j2r|XML-files|*.xml";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.randomizerSettings.Save(dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open settings:\r\n" + ex.Message, "An error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
