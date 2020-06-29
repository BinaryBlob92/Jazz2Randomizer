using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Jazz2Randomizer
{
    public partial class LevelSettingsControl : UserControl
    {
        private BindingList<EventGroup> eventGroups => (BindingList<EventGroup>)dataGridViewEventGroups.DataSource;
        private BindingList<EventInfo> eventsFrom => (BindingList<EventInfo>)dataGridViewEventsFrom.DataSource;
        private BindingList<EventInfo> eventsTo => (BindingList<EventInfo>)dataGridViewEventsTo.DataSource;

        public LevelSettingsControl(RandomizerSettings randomizerSettings, LevelSettings levelSettings)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            textBoxLevelFilename.DataBindings.Add("Text", levelSettings, "LevelFilename");
            checkBoxJazz.DataBindings.Add("Checked", levelSettings, "Jazz");
            checkBoxSpaz.DataBindings.Add("Checked", levelSettings, "Spaz");
            checkBoxLori.DataBindings.Add("Checked", levelSettings, "Lori");
            checkBoxFrog.DataBindings.Add("Checked", levelSettings, "Frog");
            checkBoxBird.DataBindings.Add("Checked", levelSettings, "Bird");
            checkBoxRandomzieColors.DataBindings.Add("Checked", levelSettings, "RandomizeColors");
            dataGridViewEventGroups.AutoGenerateColumns = false;
            dataGridViewEventGroups.DataSource = new BindingList<EventGroup>(levelSettings.EventGroups);
            ColumnFromDifficulty.DataSource = Enum.GetValues(typeof(Difficulty));
            ColumnToDifficulty.DataSource = Enum.GetValues(typeof(Difficulty));

            var eventTypes = EventInfo.EventNames
                .Select((name, i) => new { Name = name, Id = i, Type = EventInfo.EventTypes[i] })
                .Where(x => !string.IsNullOrEmpty(x.Type))
                .GroupBy(x => x.Type)
                .ToList();

            foreach (var eventGroup in eventTypes)
            {
                var eventInfos = eventGroup
                    .ToList();

                var menuItemFrom = new ToolStripMenuItem(eventGroup.Key);
                menuItemFrom.DropDownItems.Add("-= ADD ALL =-").Click += delegate
                {
                    foreach (var eventInfo in eventInfos)
                        eventsFrom?.Add(new EventInfo() { EventId = eventInfo.Id });
                };

                var menuItemTo = new ToolStripMenuItem(eventGroup.Key);
                menuItemTo.DropDownItems.Add("-= ADD ALL =-").Click += delegate
                {
                    foreach (var eventInfo in eventInfos)
                        eventsTo?.Add(new EventInfo() { EventId = eventInfo.Id });
                };

                foreach (var eventInfo in eventInfos)
                {
                    menuItemFrom.DropDownItems.Add(eventInfo.Name).Click += delegate
                    {
                        eventsFrom?.Add(new EventInfo() { EventId = eventInfo.Id });
                    };
                    menuItemTo.DropDownItems.Add(eventInfo.Name).Click += delegate
                    {
                        eventsTo?.Add(new EventInfo() { EventId = eventInfo.Id });
                    };
                }

                toolStripDropDownButtonAddFromEvent.DropDownItems.Add(menuItemFrom);
                toolStripDropDownButtonAddToEvent.DropDownItems.Add(menuItemTo);
            }

            var existingEventGroups = randomizerSettings.LevelSettings
                .SelectMany(x => x.EventGroups)
                .Distinct();

            foreach (var eventGroup in existingEventGroups)
            {
                toolStripSplitButtonAddEventGroup.DropDownItems.Add(eventGroup.Name).Click += delegate
                {
                    eventGroups.Add(eventGroup);
                };
            }
        }

        private void ToolStripSplitButtonAddEventGroup_ButtonClick(object sender, EventArgs e)
        {
            eventGroups.Add(new EventGroup());
        }

        private void ToolStripButtonDeleteEventGroup_Click(object sender, EventArgs e)
        {
            var selectedEventGroups = dataGridViewEventGroups.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(x => (EventGroup)x.DataBoundItem)
                .ToList();

            foreach (var eventGroup in selectedEventGroups)
                eventGroups.Remove(eventGroup);
        }

        private void DataGridViewEventGroups_SelectionChanged(object sender, EventArgs e)
        {
            var selectedEventGroup = dataGridViewEventGroups.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(x => (EventGroup)x.DataBoundItem)
                .FirstOrDefault();

            if (selectedEventGroup == null)
            {
                groupBoxEventsFrom.Enabled = false;
                groupBoxEventsTo.Enabled = false;
                dataGridViewEventsFrom.DataSource = null;
                dataGridViewEventsTo.DataSource = null;
            }
            else if (selectedEventGroup != null)
            {
                dataGridViewEventsFrom.AutoGenerateColumns = false;
                dataGridViewEventsFrom.DataSource = new BindingList<EventInfo>(selectedEventGroup.EventsFrom);
                dataGridViewEventsTo.AutoGenerateColumns = false;
                dataGridViewEventsTo.DataSource = new BindingList<EventInfo>(selectedEventGroup.EventsTo);
                groupBoxEventsFrom.Enabled = true;
                groupBoxEventsTo.Enabled = true;
            }
        }

        private void ToolStripButtonDeleteFromEvent_Click(object sender, EventArgs e)
        {
            if (eventsFrom != null)
            {
                var selectedEvents = dataGridViewEventsFrom.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(x => (EventInfo)x.DataBoundItem)
                    .ToList();

                foreach (var eventInfo in selectedEvents)
                    eventsFrom.Remove(eventInfo);
            }
        }

        private void ToolStripButtonDeleteToEvent_Click(object sender, EventArgs e)
        {
            if (eventsTo != null)
            {
                var selectedEvents = dataGridViewEventsTo.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(x => (EventInfo)x.DataBoundItem)
                    .ToList();

                foreach (var eventInfo in selectedEvents)
                    eventsTo.Remove(eventInfo);
            }
        }
    }
}
