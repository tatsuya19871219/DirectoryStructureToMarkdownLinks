using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryStructureToMarkdownLinks
{
    public partial class SettingsForm : Form
    {
        readonly SettingsManager _manager;

        List<string> _checkedListOrderedKey = new();

        readonly ListViewEditor _ignoreDirsEditor;
        readonly ListViewEditor _ignoreFilesEditor;

        readonly Dictionary<string, string> _checkedListDescription = new();

        public SettingsForm()
        {
            InitializeComponent();

            _manager = SettingsManager.Current;

            _ignoreDirsEditor = new ListViewEditor(listIgnoreDirs, buttonAddIgnoreDir, buttonRemoveIgnoreDir);
            _ignoreFilesEditor = new ListViewEditor(listIgnoreFiles, buttonAddIgnoreFile, buttonRemoveIgnoreFile);

            _checkedListDescription.Add(SettingKeys.ReadmeEnabled, "Enable warning 'README.md is not found'");
            _checkedListDescription.Add(SettingKeys.AutoCheckEnabled, "[TODO] Enable auto checking when opening new directory");

            LoadSettings();
        }

        void LoadSettings()
        {
            _checkedListOrderedKey.Clear();

            autoCheckMaxDepth.Value = _manager.Get<int>(SettingKeys.AutoCheckMaxDepth);
            
            checkedListBoxSettings.Items.Clear();

            //AddCheckedListItem(SettingKeys.DotDirAllowed);
            AddCheckedListItem(SettingKeys.ReadmeEnabled);
            AddCheckedListItem(SettingKeys.AutoCheckEnabled);

            _ignoreDirsEditor.Set(_manager.Get<StringCollection>(SettingKeys.IgnoreDirs));
            _ignoreFilesEditor.Set(_manager.Get<StringCollection>(SettingKeys.IgnoreFiles));

        }

        bool SaveSettings()
        {
            // check ignore lists is valid regular expression
            var ignoreDirs = _ignoreDirsEditor.Get();
            var ignoreFiles = _ignoreFilesEditor.Get();

            try
            {
                var _ = new ListRegex(ignoreDirs);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check Ignore Directories list\n" + ex.Message, "Notification", MessageBoxButtons.OK);
                return false;
            }

            try
            {
                var _ = new ListRegex(ignoreFiles);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check Ignore Files list\n" + ex.Message , "Notification", MessageBoxButtons.OK);
                return false;
            }


            // Overwrite setting properties
            _manager.Set<int>(SettingKeys.AutoCheckMaxDepth, (int)autoCheckMaxDepth.Value);

            for (int i = 0; i < _checkedListOrderedKey.Count; i++)
            {
                _manager.Set<bool>(_checkedListOrderedKey[i], checkedListBoxSettings.GetItemChecked(i));
            }

            _manager.Set<StringCollection>(SettingKeys.IgnoreDirs, ignoreDirs);
            _manager.Set<StringCollection>(SettingKeys.IgnoreFiles, ignoreFiles);

            // Save
            _manager.Save();

            return true;
        }

        void AddCheckedListItem(string key)
        {
            bool itemChecked = _manager.Get<bool>(key);

            checkedListBoxSettings.Items.Add(_checkedListDescription[key], itemChecked);

            _checkedListOrderedKey.Add(key);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            bool success = SaveSettings();

            if (!success) return;

            // Close form
            this.Close();
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            LoadSettings();            
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Are you sure to restore all the properties to default values?", "Warning", MessageBoxButtons.YesNo);

            if (answer == DialogResult.No) return;

            _manager.Reset();
            LoadSettings();
        }

    }
}
