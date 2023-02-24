using System.Collections.Specialized;

namespace DirectoryStructureToMarkdownLinks
{
    internal class ListViewEditor
    {
        readonly Button _addButton;
        readonly Button _removeButton;
        readonly ListView _listView;

        readonly string _placeholder = "=====";

        ListViewItem? _selectedItem = null;

        public ListViewEditor(ListView listView, Button addButton, Button removeButton)
        {
            _addButton = addButton;
            _removeButton = removeButton;
            _listView = listView;

            // Set callback functions
            _addButton.Click += new EventHandler(addClicked);
            _removeButton.Click += new EventHandler(removeClicked);

            _listView.DoubleClick += new EventHandler(listDoubleClicked);
            _listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listSelectionChanged);
        }

        public void Set(StringCollection? collection)
        {
            _listView.Items.Clear();

            if (collection == null) return;

            foreach (string item in collection)
            {
                _listView.Items.Add(item);
            }
        }

        public StringCollection Get()
        {
            var collection = new StringCollection();

            foreach (ListViewItem item in _listView.Items)
            {
                string itemString = item.Text;
                if (!collection.Contains(itemString))
                    collection.Add(itemString);
            }

            return collection;
        }


        // Callbacks
        void addClicked(object sender, EventArgs e)
        {
            _listView.Items.Add(_placeholder);
        }

        void removeClicked(object sender, EventArgs e)
        {
            if (_selectedItem == null) return;

            _listView.Items.Remove(_selectedItem);
        }

        void listDoubleClicked(object sender, EventArgs e)
        {
            ListViewItem item = (sender as ListView).FocusedItem;

            item.BeginEdit();
        }

        void listSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) _selectedItem = e.Item;
            else _selectedItem = null;
        }
    }
}
