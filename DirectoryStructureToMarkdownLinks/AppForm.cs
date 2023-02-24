using System.ComponentModel;

namespace DirectoryStructureToMarkdownLinks
{
    public partial class AppForm : Form
    {

        DirectoryTree _directoryTree;
        MarkdownLinks _markdownLinks;
        readonly SettingsManager _manager;

        bool _readmeNotificationEnable
                => _manager.Get<bool>(SettingKeys.ReadmeEnabled);

        int _autoExpandDepth
                => _manager.Get<int>(SettingKeys.AutoCheckMaxDepth);

        public AppForm()
        {
            InitializeComponent();

            //OpenNewDirectory();

            _manager = SettingsManager.Current;

            buttonSelectDir.ForeColor = Color.Blue;

            buttonGoUp.Enabled = false;
            buttonGoDown.Enabled = false;

        }

        private void OpenNewDirectory()
        {

            // Open a directory.
            // Get the name and search the sub directories and files
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var dirname = folderBrowserDialog.SelectedPath;

                MoveToDirectory(dirname);
            }
        }

        private void MoveToDirectory(string fullpath)
        {
            _directoryTree = new DirectoryTree(fullpath, directoryTreeView);

            _markdownLinks = new MarkdownLinks(_directoryTree);

            _directoryTree.Expand(_autoExpandDepth);
            //_directoryTree.Expand();

            // Tree Go Up enable?
            if (_directoryTree.TryGetParentDir(out var _)) buttonGoUp.Enabled = true;
            else buttonGoUp.Enabled = false;

            buttonGoDown.Enabled = false;

            bool hasReamdmeAtRoot = _directoryTree.HasReadme();

            if (_readmeNotificationEnable) WarningReadmeIsLacked(hasReamdmeAtRoot);

        }


        void WarningReadmeIsLacked(bool hasReamdme)
        {
            if (!hasReamdme)
            {
                var result = MessageBox.Show("README.md is not found at first level.", 
                                                "Notification", MessageBoxButtons.OKCancel);

                if (result == DialogResult.Cancel)
                {
                    OpenNewDirectory(); 
                }
            }
        }


        /// <summary>
        /// Append directory tree before expanding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectoryTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;

            _directoryTree.Append(node);
        }


        private void DirectoryTreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            TreeNode node = e.Node;

            if (node.Checked)
            {
                _directoryTree.Check(node);
                _directoryTree.Expand(node);
            }
            else
            {
                _directoryTree.Uncheck(node);
                _directoryTree.Collaspe(node);
            }

            // Update markdown links
            previewMarkdownLinks.Lines = _markdownLinks.Generate().ToArray();
             
            if (previewMarkdownLinks.Text != "")
            {
                buttonCopy.Enabled = true;
                buttonRefresh.Enabled = true;
            }
            else
            {
                buttonCopy.Enabled = false;
                buttonRefresh.Enabled = false;
            }

            buttonCopy.ForeColor = Color.Blue;

        }

        private void DirectoryTreeView_NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;

            // Left mouse button is clicked 
            if (e.Button == MouseButtons.Left) _directoryTree.Click(node);

            if (!_directoryTree.IsFileItem(node)) buttonGoDown.Enabled = true;
            else buttonGoDown.Enabled = false;
        }




        // UI callbacks 
        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
            OpenNewDirectory();
        }
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(previewMarkdownLinks.Text);

            buttonCopy.ForeColor = Color.Black;

            ShowActionMessageForWhile("Copied!");
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //UpdateMarkdownList(directoryTreeView.Nodes[0]);

            ShowActionMessageForWhile("Refreshed!");
        }   
        private void buttonGoUp_Click(object sender, EventArgs e)
        {
            if (_directoryTree.TryGetParentDir(out string newRootdir))
                MoveToDirectory(newRootdir);
        }
        private void buttonGoDown_Click(object sender, EventArgs e)
        {
            if (_directoryTree.TryGetSelectedDir(out string newRootdir))
                MoveToDirectory(newRootdir);
        }

        // 
        async private void ShowActionMessageForWhile(string message, int delay = 1000)
        {
            labelMessage.Text = message;
            labelMessage.Visible = true;

            await Task.Delay(delay);

            labelMessage.Visible = false;
            labelMessage.Text = "";
        }

        async private void buttonSetting_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            await Task.Run(() => Application.Run(new SettingsForm()));

            this.Enabled = true;
            this.Activate();
        }
    }
}