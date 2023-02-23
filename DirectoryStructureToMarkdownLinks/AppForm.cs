using System.ComponentModel;

namespace DirectoryStructureToMarkdownLinks
{
    public partial class AppForm : Form
    {

        DirectoryTree _directoryTree;
        MarkdownLinks _markdownLinks;
        readonly SettingsManager _manager;

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

            _directoryTree.Expand((int)_manager[SettingKeys.AutoCheckMaxDepth], false);

            // Tree Go Up enable?
            if (_directoryTree.TryGetParentDir(out var dir)) buttonGoUp.Enabled = true;
            else buttonGoUp.Enabled = false;

            buttonGoDown.Enabled = false;


            bool hasReamdmeAtRoot = _directoryTree.HasReadme();

            if (!hasReamdmeAtRoot)
            {
                var result = MessageBox.Show("README.md is not found at first level.", 
                                                "Notification", MessageBoxButtons.OKCancel);

                if (result == DialogResult.Cancel)
                {
                    OpenNewDirectory(); return;
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


            // update markdown links
            previewMarkdownLinks.Lines = _markdownLinks.Generate().ToArray();
             
                //_markdownLinks

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

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            Task.Run(() => Application.Run(new SettingsForm()));
        }
    }
}