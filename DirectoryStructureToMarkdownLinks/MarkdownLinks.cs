using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace DirectoryStructureToMarkdownLinks
{
    internal class MarkdownLinks
    {
        readonly int _tabwidth = 4;

        readonly DirectoryTree _tree;

        public MarkdownLinks(DirectoryTree tree) 
        { 
            _tree = tree;
        }


        public List<string> Generate()
        {
            List<string> list = new();

            StoreMarkdownLinks(_tree.RootNode, list);

            return list;
        }


        private void StoreMarkdownLinks(TreeNode tree, List<string> list)
        {

            foreach (TreeNode node in tree.Nodes)
            {
                int depth = node.Level;
                //var tabs = string.Concat(Enumerable.Repeat("\t", depth - 1));
                var tabs = string.Concat(Enumerable.Repeat(" ", _tabwidth * (depth - 1)));

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

                if (node.Checked) list.Add(line);

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
    }
}
