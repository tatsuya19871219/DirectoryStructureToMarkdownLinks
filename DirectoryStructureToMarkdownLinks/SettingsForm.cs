using System;
using System.Collections.Generic;
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
            autoChechMaxDepth.Value = (int)_manager[SettingKeys.AutoCheckMaxDepth];
            
            checkedListBoxSettings.Items.Clear();

            AddCheckedListItem(SettingKeys.DotDirAllowed);
            AddCheckedListItem(SettingKeys.ReadmeEnabled);
            AddCheckedListItem(SettingKeys.AutoCheckEnabled);
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

            // Save
            _manager.Save();

            // Close form
            this.Close();
        }
    }
}
