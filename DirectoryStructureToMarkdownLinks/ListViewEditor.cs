using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryStructureToMarkdownLinks
{
    internal class ListViewEditor
    {
        readonly Button _addButton;
        readonly Button _removeButton;
        readonly ListView _listView;

        public ListViewEditor(ListView listView, Button addButton, Button removeButton)
        {
            _addButton = addButton;
            _removeButton = removeButton;
            _listView = listView;

            // Set callback functions
        }

        public void Set(StringCollection? collection)
        {
            if (collection == null) return;

            foreach (string item in collection)
            {
                _listView.Items.Add(item);
            }
        }

        public StringCollection Get()
        {
            var collection = new StringCollection();

            foreach (string item in _listView.Items)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
