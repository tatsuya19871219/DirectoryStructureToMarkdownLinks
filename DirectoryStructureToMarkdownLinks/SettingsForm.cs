using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        ListViewEditor _ignoreDirsEditor;
        ListViewEditor _ignoreFilesEditor;

        public SettingsForm()
        {
            InitializeComponent();

            _manager = SettingsManager.Current;

            _ignoreDirsEditor = new ListViewEditor(listIgnoreDirs, buttonAddIgnoreDir, buttonRemoveIgnoreDir);
            _ignoreFilesEditor = new ListViewEditor(listIgnoreFiles, buttonAddIgnoreFile, buttonRemoveIgnoreFile);

            LoadSettings();
        }

        void LoadSettings()
        {
            _checkedListOrderedKey.Clear();

            autoCheckMaxDepth.Value = _manager.Get<int>(SettingKeys.AutoCheckMaxDepth);
            
            checkedListBoxSettings.Items.Clear();

            AddCheckedListItem(SettingKeys.DotDirAllowed);
            AddCheckedListItem(SettingKeys.ReadmeEnabled);
            AddCheckedListItem(SettingKeys.AutoCheckEnabled);

            _ignoreDirsEditor.Set(_manager.Get<StringCollection>(SettingKeys.IgnoreDirs));
            _ignoreFilesEditor.Set(_manager.Get<StringCollection>(SettingKeys.IgnoreFiles));

        }

        void SaveSettings()
        {
            // Overwrite setting properties

            _manager.Set<int>(SettingKeys.AutoCheckMaxDepth, (int)autoCheckMaxDepth.Value);

            for (int i = 0; i < _checkedListOrderedKey.Count; i++)
            {
                _manager.Set<bool>(_checkedListOrderedKey[i], checkedListBoxSettings.GetItemChecked(i));
            }

            var ignoreDirs = new StringCollection();
            foreach (ListViewItem ignoreDirItem in listIgnoreDirs.Items)
            {
                ignoreDirs.Add(ignoreDirItem.Text);
            }

            // Save
            _manager.Save();
        }

        void AddCheckedListItem(string key)
        {
            bool itemChecked = _manager.Get<bool>(key);

            checkedListBoxSettings.Items.Add(key, itemChecked);

            _checkedListOrderedKey.Add(key);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveSettings();

            // Close form
            this.Close();
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            _manager.Reset();
            LoadSettings();
        }

        //private void listIgnoreDirs_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    listIgnoreDirs.
        //}

        //// Callbacks
        //private void listIgnoreDirs_DoubleClick(object sender, EventArgs e)
        //{
        //    ListViewItem item = (sender as ListView).FocusedItem;

        //    item.BeginEdit();
        //}

        //private void listIgnoreDire_KeyDown(object sender, EventArgs e)
        //{
            
        //}

        
    }
}
