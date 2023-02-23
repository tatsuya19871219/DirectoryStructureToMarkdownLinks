using System.ComponentModel;

namespace DirectoryStructureToMarkdownLinks
{
    public partial class AppForm : Form
    {

        DirectoryTree _directoryTree;
        MarkdownLinks _markdownLinks;

        public AppForm()
        {
            InitializeComponent();

            //OpenNewDirectory();

            buttonSelectDir.ForeColor = Color.Blue;

            buttonGoUp.Enabled = false;
            buttonGoDown.Enabled = false;

        }


        //void TreeGeneratorCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    TreeNode tree = (TreeNode)e.Result;

        //    directoryTreeView.Nodes.Add(tree); // this also takes time
            
        //    progressBarLoad.Visible = false;
        //    labelLoading.Visible = false;

        //    //directoryTreeView.ExpandAll();

        //    tree.Expand();

        //    //_tree.Checked = true;

        //    // Make markdown list
        //    //UpdateMarkdownList(_tree);

        //    buttonSelectDir.ForeColor = Color.Black;

        //    // Check whether root directory has README.md
        //    //var hasReadme = HasReadme(_tree);

        //    buttonGoUp.Enabled = true;
        //}

        //void TreeGerenatorProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    this.progressBarLoad.Value = e.ProgressPercentage;
        //}

        

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

            //_directoryTree.Append();
            _directoryTree.Expand(2);

            //_directoryTree.BindTreeView(directoryTreeView);

            bool hasReamdmeAtRoot = _directoryTree.HasReadme();

            // Tree Go Up enable?
            if (_directoryTree.TryGetParentDir(out var dir)) buttonGoUp.Enabled = true;
            else buttonGoUp.Enabled = false;

            buttonGoDown.Enabled = false;

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
            //UpdateMarkdownList(_tree);

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



        private void UpdateMarkdownList(TreeNode tree)
        {
            List<string> list = new();

            //StoreMarkdownLinks(_tree, list);

            previewMarkdownLinks.Lines = list.ToArray();

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
            UpdateMarkdownList(directoryTreeView.Nodes[0]);

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