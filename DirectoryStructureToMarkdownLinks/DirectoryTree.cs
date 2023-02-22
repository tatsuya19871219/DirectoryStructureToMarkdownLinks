using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryStructureToMarkdownLinks
{
    internal class DirectoryTree
    {
        readonly string _rootpath;
        readonly TreeNode _tree;

        public DirectoryTree(string rootpath) 
        { 
            _rootpath = rootpath;
            _tree = new TreeNode(rootpath);
        }

        public void Append(int depth = 1)
        {
            Append(_tree, depth);
        }

        public void Append(TreeNode node, int depth)
        {
            // Is valid node?
            if (!IsValidNode(node)) throw new ArgumentException("Unexpected node is given.");

            string dirname = GetPath(node);

            var dirs = Directory.EnumerateDirectories(dirname).ToList();

            //int N = dirs.Count;
            //int i = 0;

            foreach (var dir in dirs)
            {
                var name = Path.GetFileName(dir);

                var treeChild = _tree.Nodes.Add(name);

                //GenerateTree(dir, treeChild, worker, e);
                if (depth > 1) Append(treeChild, depth - 1);
            }
            //i++;

            //    if (_tree.Parent == null)
            //    {
            //        // update progress
            //        worker.ReportProgress((int)((float)i / N * 100));
            //    }
            //}

            var files = Directory.EnumerateFiles(dirname);

            foreach (var file in files)
            {
                var name = Path.GetFileName(file);

                _tree.Nodes.Add(name);
            }
            
        }

        private bool IsValidNode(TreeNode node)
        {
            if (node.Level == 0)
            {
                return node.Equals(_tree);
            }
            else
            {
                return IsValidNode(node.Parent);
            }
        }

        private string GetPath(TreeNode node)
        {
            if (node.Level == 0)
            {
                return node.Text;
            }
            else
            {
                return GetPath(node.Parent) + "/" + node.Text;
            }
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

        
        void GenerateTree(string dirname, TreeNode tree, BackgroundWorker worker, DoWorkEventArgs e)
        {

            var dirs = Directory.EnumerateDirectories(dirname).ToList();

            int N = dirs.Count;
            int i = 0;

            foreach (var dir in dirs)
            {
                var name = Path.GetFileName(dir);

                var treeChild = tree.Nodes.Add(name);

                GenerateTree(dir, treeChild, worker, e);

                i++;

                if (tree.Parent == null)
                {
                    // update progress
                    worker.ReportProgress((int)((float)i / N * 100));
                }
            }

            var files = Directory.EnumerateFiles(dirname);

            foreach (var file in files)
            {
                var name = Path.GetFileName(file);

                tree.Nodes.Add(name);
            }

            //return _tree;
        }

    }
}
