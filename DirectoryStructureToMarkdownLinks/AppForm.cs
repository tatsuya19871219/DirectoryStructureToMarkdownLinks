namespace DirectoryStructureToMarkdownLinks
{
    public partial class AppForn : Form
    {
        int _tabwidth = 4;

        public AppForn()
        {
            InitializeComponent();
        }

        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
            // initialize
            var dirname = "";
            directoryTreeView.Nodes.Clear();

            // Open a directory.
            // Get the name and search the sub directories and files
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                dirname = folderBrowserDialog.SelectedPath;

                // Make tree of directory structure
                TreeNode tree = new TreeNode(dirname);
                
                StoreDirectoryTree(dirname, tree);
                
                directoryTreeView.Nodes.Add(tree);
                //directoryTreeView.ExpandAll();

                tree.Expand();
                //tree.Checked = true;
                directoryTreeView.AfterCheck += DirectoryTreeView_AfterCheck;

                // Make markdown list
                UpdateMarkdownList(tree);

                
            }

        }

        private void DirectoryTreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            TreeNode node = e.Node;
            TreeNode tree = node.TreeView.TopNode;
            TreeNode rootNode = tree;

            if (e.Node.Checked)
            {
                // if root node is checked, check all node
                // and unckeck self
                if (node.Equals(rootNode))
                {
                    // Check all children
                    CheckAllChildren(rootNode.Nodes, true);

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

        }

        void StoreDirectoryTree(string dirname, TreeNode tree)
        {
            var dirs = Directory.EnumerateDirectories(dirname).ToList();

            foreach (var dir in dirs)
            {
                var name = Path.GetFileName(dir);

                var treeChild = tree.Nodes.Add(name);

                

                StoreDirectoryTree(dir, treeChild);
            }

            var files = Directory.EnumerateFiles(dirname);

            foreach (var file in files)
            {
                var name = Path.GetFileName(file);

                tree.Nodes.Add(name);
            }

        }

        void StoreMarkdownLinks(TreeNode tree, List<string> list)
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

        string GetRelativeLink(TreeNode node)
        {
            var fullpath = node.FullPath;
            var rootpath = node.TreeView.Nodes[0].FullPath;

            return fullpath.Replace(rootpath, ".").Replace("\\", "/");
        }

        void CheckAllChildren(TreeNodeCollection nodes, bool deep)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;

                if (deep) CheckAllChildren(node.Nodes, deep);
            }
        }

        void UncheckAllChildren(TreeNodeCollection nodes, bool deep)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;

                if (deep) UncheckAllChildren(node.Nodes, deep);
            }
        }

        void CheckAllAncestors(TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Parent.Checked = true;

                CheckAllAncestors(node.Parent);
            }
        }

        void UpdateMarkdownList(TreeNode tree)
        {
            List<string> list = new();

            StoreMarkdownLinks(tree, list);

            textBox1.Lines = list.ToArray();
        }

    }
}