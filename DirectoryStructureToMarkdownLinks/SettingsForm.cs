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

        public SettingsForm()
        {
            InitializeComponent();

            _manager = SettingsManager.Current;

            LoadSettings();
        }

        void LoadSettings()
        {
            _checkedListOrderedKey.Clear();

            autoChechMaxDepth.Value = (int)_manager[SettingKeys.AutoCheckMaxDepth];
            
            checkedListBoxSettings.Items.Clear();

            AddCheckedListItem(SettingKeys.DotDirAllowed);
            AddCheckedListItem(SettingKeys.ReadmeEnabled);
            AddCheckedListItem(SettingKeys.AutoCheckEnabled);

            listIgnoreDirs.Items.Clear();
            var ignoreDirs = (StringCollection)_manager[SettingKeys.IgnoreDirs];
            foreach ( var ignoreDir in ignoreDirs ) listIgnoreDirs.Items.Add(ignoreDir);

            listIgnoreFiles.Items.Clear();
            var ignoreFiles = (StringCollection)_manager[SettingKeys.IgnoreFiles];
            foreach (var ignoreFile in ignoreFiles) listIgnoreFiles.Items.Add(ignoreFile);


        }

        void AddCheckedListItem(string key)
        {
            var itemChecked = (bool)_manager[key];

            checkedListBoxSettings.Items.Add(key, itemChecked);

            _checkedListOrderedKey.Add(key);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Overwrite setting properties

            _manager[SettingKeys.AutoCheckMaxDepth] = (int)autoChechMaxDepth.Value;

            for (int i = 0; i < _checkedListOrderedKey.Count; i++)
            {
                _manager[_checkedListOrderedKey[i]] = checkedListBoxSettings.GetItemChecked(i);
            }

            var ignoreDirs = new StringCollection();
            foreach ( ListViewItem ignoreDirItem in listIgnoreDirs.Items)
            {
                ignoreDirs.Add(ignoreDirItem.Text);
            }

            // Save
            _manager.Save();

            // Close form
            this.Close();
        }

        //private void listIgnoreDirs_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    listIgnoreDirs.
        //}

        // Callbacks
        private void listIgnoreDirs_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = (sender as ListView).FocusedItem;

            item.BeginEdit();
        }

        private void listIgnoreDire_KeyDown(object sender, EventArgs e)
        {
            
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _manager.Reset();
            LoadSettings();
        }
    }
}
