namespace DirectoryStructureToMarkdownLinks
{
    public partial class AppForn : Form
    {
        int _tabwidth = 4;

        public AppForn()
        {
            InitializeComponent();

            directoryTreeView.AfterCheck += DirectoryTreeView_AfterCheck;

            //OpenNewDirectory();

            buttonSelectDir.ForeColor = Color.Blue;

            buttonGoUp.Enabled = false;
            buttonGoDown.Enabled = false;
        }

        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
            OpenNewDirectory();
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

        async private void MoveToDirectory(string fullpath)
        {
            // Initialize directoryTreeView
            directoryTreeView.Nodes.Clear();

            // Make tree of directory structure
            TreeNode tree = new TreeNode(fullpath);
            
            await StoreDirectoryTree(fullpath, tree);

            directoryTreeView.Nodes.Add(tree);
            //directoryTreeView.ExpandAll();

            tree.Expand();
            //tree.Checked = true;

            // Make markdown list
            //UpdateMarkdownList(tree);

            buttonSelectDir.ForeColor = Color.Black;

            // Check whether root directory has README.md
            var hasReadme = HasReadme(tree);

            buttonGoUp.Enabled = true;
        }

        private bool HasReadme(TreeNode tree)
        {
            foreach(TreeNode node in tree.Nodes)
            {
                if (node.Text == "README.md")
                {
                    node.ForeColor = Color.Green;
                    return true;
                }
            }

            return false;
        }

        private void DirectoryTreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            TreeNode node = e.Node;
            TreeNode tree = node.TreeView.Nodes[0];
            TreeNode rootNode = tree;

            if (e.Node.Checked)
            {
                // if root node is checked, check all node
                // and unckeck self
                if (node.Equals(rootNode))
                {
                    // Check all children
                    //CheckAllChildren(rootNode.Nodes, true);
                    CheckAllChildrenNonRecursive(rootNode, true);

                    //rootNode.Checked = false;
                }
                else
                {
                    // If directory, check all children
                    if (node.Nodes.Count > 0)
                    {
                        CheckAllChildren(node.Nodes, false);
                        CheckAllAncestors(node);

                        node.Expand();
                    }
                    else
                    {
                        // if parent node (directory) is not checked,
                        // check all ancestors
                        CheckAllAncestors(node);
                    }
                }
                
            }
            else
            {
                if (node.Equals(rootNode))
                {
                    // Unheck all children
                    UncheckAllChildren(rootNode.Nodes, true);

                }
                else
                {
                    if (node.Nodes.Count > 0)
                    {
                        //
                        UncheckAllChildren(node.Nodes, true);

                        //node.Collapse();
                    }
                }
            }

            // update markdown links
            UpdateMarkdownList(tree);

            buttonCopy.ForeColor = Color.Blue;

        }

        async private Task StoreDirectoryTree(string dirname, TreeNode tree)
        {
            //ShowActionMessageForWhile("Busy", 100);

            var dirs = Directory.EnumerateDirectories(dirname).ToList();

            foreach (var dir in dirs)
            {
                var name = Path.GetFileName(dir);

                var treeChild = tree.Nodes.Add(name);

                await StoreDirectoryTree(dir, treeChild);
            }

            var files = Directory.EnumerateFiles(dirname);

            foreach (var file in files)
            {
                var name = Path.GetFileName(file);

                tree.Nodes.Add(name);
            }

        }

        private void StoreMarkdownLinks(TreeNode tree, List<string> list)
        {

            foreach(TreeNode node in tree.Nodes)
            {
                int depth = node.Level;
                //var tabs = string.Concat(Enumerable.Repeat("\t", depth - 1));
                var tabs = string.Concat(Enumerable.Repeat(" ", _tabwidth*(depth - 1)));

                var line = tabs;

                if (node.Nodes.Count == 0)
                {
                    // file
                    var relativeLink = GetRelativeLink(node);

                    line = tabs + " - " + $"[{node.Text}]" + $"({relativeLink})";
                }
                else
                {
                    // directory
                    line = tabs + " - " + node.Text + "/";
                }

                if(node.Checked) list.Add(line);

                if (node.Nodes.Count > 0)
                    StoreMarkdownLinks(node, list);
            }

        }

        private string GetRelativeLink(TreeNode node)
        {
            var fullpath = node.FullPath;
            var rootpath = node.TreeView.Nodes[0].FullPath;
            var rootdir = Path.GetFileName(rootpath); 

            return fullpath.Replace(rootpath, $".").Replace("\\", "/");
        }

        private void CheckAllChildren(TreeNodeCollection nodes, bool deep)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;

                if (deep) CheckAllChildren(node.Nodes, deep);
            }
        }

        // NonRecursive version of CheckAllChildren
        private void CheckAllChildrenNonRecursive(TreeNode parentNode, bool deep)
        {
            if (parentNode.Nodes.Count == 0) return;

            Queue<TreeNode> staging = new Queue<TreeNode>();

            TreeNode scanNode;

            staging.Enqueue(parentNode);

            do 
            {
                scanNode = staging.Dequeue();

                if (scanNode != parentNode) scanNode.Checked = true;

                foreach (TreeNode childNode in scanNode.Nodes)
                {
                    staging.Enqueue(childNode);
                }


            } while (staging.Count > 0);
            
        }

        private void UncheckAllChildren(TreeNodeCollection nodes, bool deep)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;

                if (deep) UncheckAllChildren(node.Nodes, deep);
            }
        }

        private void CheckAllAncestors(TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Parent.Checked = true;

                CheckAllAncestors(node.Parent);
            }
        }

        private void UpdateMarkdownList(TreeNode tree)
        {
            List<string> list = new();

            StoreMarkdownLinks(tree, list);

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


        async private void ShowActionMessageForWhile(string message, int delay = 1000)
        {
            labelMessage.Text = message;
            labelMessage.Visible = true;

            await Task.Delay(delay);

            labelMessage.Visible = false;
            labelMessage.Text = "";
        }

        private void buttonGoUp_Click(object sender, EventArgs e)
        {
            var currentRootdir = directoryTreeView.TopNode.FullPath;

            var newRootdir = Path.GetDirectoryName(currentRootdir);

            MoveToDirectory(newRootdir);
        }

        private void directoryTreeView_NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            buttonGoDown.Enabled = false;

            var lastSelectedNode = directoryTreeView.SelectedNode; // This is not clicked node
            //if (lastSelectedNode != null) lastSelectedNode.BackColor = DefaultBackColor;

            //// Left mouse button is clicked & directory with children nodes is selected 
            if (e.Button == MouseButtons.Left & e.Node.Nodes.Count > 0)
            {
                buttonGoDown.Enabled = true;
            //    e.Node.BackColor = Color.LightGoldenrodYellow;
            //    if (lastSelectedNode != null) lastSelectedNode.BackColor = Color.Green;
            }
        }

        private void buttonGoDown_Click(object sender, EventArgs e)
        {
            var currentRootdir = directoryTreeView.TopNode.FullPath;

            var selectedRootdir = directoryTreeView.SelectedNode.FullPath;

            MoveToDirectory(selectedRootdir);
        }
    }
}