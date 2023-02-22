using System.ComponentModel;

namespace DirectoryStructureToMarkdownLinks
{
    public partial class AppForm : Form
    {
        

        public AppForm()
        {
            InitializeComponent();

            //directoryTreeView.AfterCheck += DirectoryTreeView_AfterCheck;

            //OpenNewDirectory();

            buttonSelectDir.ForeColor = Color.Blue;

            buttonGoUp.Enabled = false;
            buttonGoDown.Enabled = false;

        }

        //void TreeGeneratorBackgroundWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;

        //    //(string fullpath, TreeNode _tree) = e.Argument as Tuple<string, TreeNode>;

        //    var directoryTree = (DirectoryTree)e.Argument;

        //    //directoryTree.Append();
            
        //    //TreeNode _tree = new TreeNode(fullpath);

        //    //GenerateTree(fullpath, _tree, worker, e);

        //    //e.Result = directoryTree.node;

        //    //TreeNode _tree = (TreeNode)e.Result;

        //    //directoryTreeView.Nodes.Add(_tree); // this also takes time

        //    //_tree.Expand();

        //    //// Check whether root directory has README.md
        //    //var hasReadme = HasReadme(_tree);
        //}

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

        async private void MoveToDirectory(string fullpath)
        {

            // Initialize directoryTreeView
            directoryTreeView.Nodes.Clear();

            //labelLoading.Visible = true;
            //progressBarLoad.Value = 0;
            //progressBarLoad.Visible = true;

            var directoryTree = new DirectoryTree(fullpath);

            directoryTree.Append(2);

            //backgroundDirectoryTreeGenerator.RunWorkerAsync(directoryTree);
            
        }

        

        //private void DirectoryTreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        //{
        //    if (e.Action == TreeViewAction.Unknown) return;

        //    TreeNode node = e.Node;
        //    TreeNode _tree = node.TreeView.Nodes[0];
        //    TreeNode rootNode = _tree;

        //    if (e.Node.Checked)
        //    {
        //        // if root node is checked, check all node
        //        // and unckeck self
        //        if (node.Equals(rootNode))
        //        {
        //            // Check all children
        //            //CheckAllChildren(rootNode.Nodes, true);
        //            CheckAllChildrenNonRecursive(rootNode, true);

        //            //rootNode.Checked = false;
        //        }
        //        else
        //        {
        //            // If directory, check all children
        //            if (node.Nodes.Count > 0)
        //            {
        //                CheckAllChildren(node.Nodes, false);
        //                CheckAllAncestors(node);

        //                node.Expand();
        //            }
        //            else
        //            {
        //                // if parent node (directory) is not checked,
        //                // check all ancestors
        //                CheckAllAncestors(node);
        //            }
        //        }
                
        //    }
        //    else
        //    {
        //        if (node.Equals(rootNode))
        //        {
        //            // Unheck all children
        //            UncheckAllChildren(rootNode.Nodes, true);

        //        }
        //        else
        //        {
        //            if (node.Nodes.Count > 0)
        //            {
        //                //
        //                UncheckAllChildren(node.Nodes, true);

        //                //node.Collapse();
        //            }
        //        }
        //    }

        //    // update markdown links
        //    UpdateMarkdownList(_tree);

        //    buttonCopy.ForeColor = Color.Blue;

        //}

        //private void DirectoryTreeView_NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    buttonGoDown.Enabled = false;

        //    var lastSelectedNode = directoryTreeView.SelectedNode; // This is not clicked node
        //    //if (lastSelectedNode != null) lastSelectedNode.BackColor = DefaultBackColor;

        //    //// Left mouse button is clicked & directory with children nodes is selected 
        //    if (e.Button == MouseButtons.Left & e.Node.Nodes.Count > 0)
        //    {
        //        buttonGoDown.Enabled = true;
        //        //    e.Node.BackColor = Color.LightGoldenrodYellow;
        //        //    if (lastSelectedNode != null) lastSelectedNode.BackColor = Color.Green;
        //    }
        //}

        //async private Task StoreDirectoryTree(string dirname, TreeNode _tree)
        //{
        //    //ShowActionMessageForWhile("Busy", 100);

        //    var dirs = Directory.EnumerateDirectories(dirname).ToList();

        //    foreach (var dir in dirs)
        //    {
        //        var name = Path.GetFileName(dir);

        //        var treeChild = _tree.Nodes.Add(name);

        //        await StoreDirectoryTree(dir, treeChild);
        //    }

        //    var files = Directory.EnumerateFiles(dirname);

        //    foreach (var file in files)
        //    {
        //        var name = Path.GetFileName(file);

        //        _tree.Nodes.Add(name);
        //    }

        //}

        

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


        // UI 
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
            var currentRootdir = directoryTreeView.TopNode.FullPath;

            var newRootdir = Path.GetDirectoryName(currentRootdir);

            MoveToDirectory(newRootdir);
        }
        private void buttonGoDown_Click(object sender, EventArgs e)
        {
            var currentRootdir = directoryTreeView.TopNode.FullPath;

            var selectedRootdir = directoryTreeView.SelectedNode.FullPath;

            MoveToDirectory(selectedRootdir);
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