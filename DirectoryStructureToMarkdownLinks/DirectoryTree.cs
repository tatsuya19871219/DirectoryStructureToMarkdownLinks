using System.Collections.Specialized;

namespace DirectoryStructureToMarkdownLinks
{
    internal class DirectoryTree
    {
        readonly string _rootpath;
        readonly TreeNode _tree;

        readonly string _dummy = "This Is Dummy Item";
        readonly string _securityDummy = "Access Denied";

        TreeNode? _clickedDirNode = null; // for go up operation

        //bool _isTreeViewBound = false;

        readonly SettingsManager _manager;

        //StringCollection _ignoreDirs //=> _manager[SettingKeys.IgnoreDirs] as StringCollection ?? new StringCollection();

        //StringCollection _ignoreFiles //=> _manager[SettingKeys.IgnoreFiles] as StringCollection ?? new StringCollection();

        ListRegex _ignoreDirsRegex
            => new ListRegex(_manager.Get<StringCollection>(SettingKeys.IgnoreDirs));
        ListRegex _ignoreFilesRegex
            => new ListRegex(_manager.Get<StringCollection>(SettingKeys.IgnoreFiles));

        public DirectoryTree(string rootpath, TreeView treeView)
        {
            _manager = SettingsManager.Current;

            _rootpath = rootpath;
            _tree = new TreeNode(rootpath);
            _tree.Nodes.Add(_dummy); // To Expand function works fine

            BindTreeView(treeView);
        }

        public TreeNode RootNode => _tree;


        //public void Append(int depth = 1) => Append(_tree, depth);

        public void Append(TreeNode node, int depth = 1)
        {
            // Is a valid node?
            if (!IsValidNode(node)) throw new ArgumentException("Unexpected node is given.");

            // Is a File?
            if (IsFileItem(node)) return;

            // Is already appended?
            if (IsAlreadyAppend(node)) return;

            node.Nodes.Clear();

            string dirname = GetPath(node);

            try
            {
                var tmp = Directory.EnumerateDirectories(dirname);
            }
            catch (Exception ex)
            {
                node.Nodes.Add(_securityDummy).ForeColor = Color.Red;
                return;
                //throw new SystemException("Accessibility exception");
            }

            var dirs = Directory.EnumerateDirectories(dirname).ToList();

            foreach (var dir in dirs)
            {
                var name = Path.GetFileName(dir);

                var treeChild = node.Nodes.Add(name);

                if (depth > 1)
                    Append(treeChild, depth - 1);
                else
                    treeChild.Nodes.Add(_dummy);
            }

            var files = Directory.EnumerateFiles(dirname);

            foreach (var file in files)
            {
                var name = Path.GetFileName(file);

                DateTime creationTime = File.GetCreationTime(file);
                DateTime lastAccessTime = File.GetLastAccessTime(file);
                DateTime lastWriteTime = File.GetLastWriteTime(file);

                node.Nodes.Add(name);
            }

        }

        private bool IsAlreadyAppend(TreeNode node)
        {
            if (IsFileItem(node)) return false;

            if (node.Nodes[0].Text == _dummy) return false;

            return true;
        }

        public bool IsFileItem(TreeNode node)
            => (node.Nodes.Count == 0) ? true : false;

        private bool IsValidNode(TreeNode node)
        {
            if (node.Level == 0)
                return node.Equals(_tree);
            else
                return IsValidNode(node.Parent);
        }

        private string GetPath(TreeNode node)
        {
            if (node.Level == 0)
                return node.Text;
            else
                return Path.Combine(GetPath(node.Parent), node.Text);
        }

        private void BindTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add(_tree);
        }

        public void Expand(int depth = 1) => Expand(_tree, depth);

        public void Expand(TreeNode parentNode, int depth = 1)
        {
            if (depth == 0) return;
            if (IsFileItem(parentNode)) return;
            if (!IsValidNode(parentNode)) throw new ArgumentException("Unexpected node is given.");

            //if (!allowDotDirExpand & IsDotDir(parentNode)) return;
            //else 
            // Check ignore directory list
            if (_ignoreDirsRegex.Contains(parentNode.Text)) return;

            parentNode.Expand();

            foreach (TreeNode node in parentNode.Nodes)
            {
                if (!IsFileItem(node)) Expand(node, depth - 1);
            }
        }

        //private bool IsDotDir(TreeNode node)
        //{
        //    if (node.Text.StartsWith(".")) return true;
        //    else return false;
        //}

        public void Collaspe(TreeNode node)
        {
            if (!IsValidNode(node)) throw new ArgumentException("Unexpected node is given.");

            node.Collapse();
        }

        public void Click(TreeNode node)
        {
            if (!IsValidNode(node)) throw new ArgumentException("Unexpected node is given.");

            if (_clickedDirNode != null) _clickedDirNode.BackColor = Color.White;

            if (IsFileItem(node))
            {
                _clickedDirNode = null;
                return;
            }
            else
            {
                node.BackColor = Color.LightBlue;
                _clickedDirNode = node;
            }

        }

        public bool TryGetParentDir(out string dir)
        {
            dir = Path.GetDirectoryName(_tree.FullPath);

            if (dir == null) return false;
            else return true;
        }

        public bool TryGetSelectedDir(out string dir)
        {
            dir = _clickedDirNode?.FullPath;

            if (dir == null) return false;
            else return true;
        }

        public void Check(TreeNode node)
        {
            if (!IsFileItem(node))
            {
                CheckAllChildren(node);
                //CheckAllChildrenNonRecursive(node);
            }

            CheckAllAncestors(node);
        }

        public void Uncheck(TreeNode node)
        {
            if (IsFileItem(node)) return;
            else
            {
                UncheckAllChildren(node);
            }
        }

        private void CheckAllChildren(TreeNode parentNode)
        {
            // Check ignore directory list
            if (_ignoreDirsRegex.Contains(parentNode.Text)) return;

            parentNode.Checked = true;

            if (!IsFileItem(parentNode))
            {
                Append(parentNode);
                //Expand(parentNode);
            }

            foreach (TreeNode node in parentNode.Nodes)
            {
                //node.Checked = true;

                if (!IsFileItem(node)) CheckAllChildren(node);
                else
                {
                    if (!_ignoreFilesRegex.Contains(node.Text))
                        node.Checked = true;
                }
            }
        }

        // NonRecursive version of CheckAllChildren
        private void CheckAllChildrenNonRecursive(TreeNode parentNode)
        {
            if (parentNode.Nodes.Count == 0) return;

            Queue<TreeNode> staging = new Queue<TreeNode>();

            TreeNode scanNode;

            staging.Enqueue(parentNode);

            do
            {
                scanNode = staging.Dequeue();

                Append(scanNode);

                if (scanNode != parentNode) scanNode.Checked = true;

                foreach (TreeNode childNode in scanNode.Nodes)
                {
                    staging.Enqueue(childNode);
                }


            } while (staging.Count > 0);

        }

        private void UncheckAllChildren(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                node.Checked = false;

                UncheckAllChildren(node);
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

        public bool HasReadme() => HasReadme(_tree);
        private bool HasReadme(TreeNode tree)
        {
            foreach (TreeNode node in tree.Nodes)
            {
                if (node.Text == "README.md")
                {
                    node.ForeColor = Color.Green;
                    return true;
                }
            }

            return false;
        }


    }
}
