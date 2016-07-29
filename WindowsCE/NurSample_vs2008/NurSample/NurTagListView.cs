using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet; //NurApi wrapper

namespace NurSample
{
    public partial class NurTagListView : UserControl
    {
        /// <summary>
        //     TagItem contains additional information about the tag
        //     like ListViewItem.
        /// </summary>
        public class TagItem
        {
            public NurApi.Tag Tag;
            public ListViewItem TagViewItem;
            public TagItem(NurApi.Tag tag)
            {
                this.Tag = tag;
                this.TagViewItem = new ListViewItem(new string[] {
                        tag.rssi.ToString(),
                        tag.GetEpcString() });
                this.TagViewItem.Tag = this;
            }
            override public string ToString() { return Tag.GetEpcString(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NurTagListView"/> class.
        /// </summary>
        public NurTagListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when selected Tag changed.
        /// </summary>
        public event EventHandler SelectedTagChanged;

        /// <summary>
        /// Gets the selected tag.
        /// </summary>
        /// <value>
        /// The selected tag.
        /// </value>
        public NurApi.Tag SelectedTag
        {
            get
            {
                if (tagListView.SelectedIndices.Count > 0)
                {
                    TagItem tagItem = tagListView.Items[tagListView.SelectedIndices[0]].Tag as TagItem;
                    return tagItem.Tag;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the focused item.
        /// </summary>
        /// <value>
        //  A System.Windows.Forms.ListViewItem that represents the item that has focus,
        //  or null if no item has the focus in the System.Windows.Forms.ListView.
        /// </value>
        public ListViewItem FocusedItem { get { return tagListView.FocusedItem; } }

        /// <summary>
        /// Clears the tag list.
        /// </summary>
        public void ClearTagList()
        {
            tagListView.Items.Clear();
        }

        /// <summary>
        /// Updates the tag list.
        /// </summary>
        /// <param name="inventoriedTags">The inventoried tags.</param>
        /// <returns>The number of new tags</returns>
        public int UpdateTagList(NurApi.TagStorage inventoriedTags)
        {
            int numberOfNewTags = inventoriedTags.Count - tagListView.Items.Count;
            if (inventoriedTags.Count > tagListView.Items.Count)
            {
                // Update ListBox
                tagListView.BeginUpdate();
                for (int i = tagListView.Items.Count; i < inventoriedTags.Count; i++)
                {
                    TagItem tagItem = new TagItem(inventoriedTags[i]);
                    tagListView.Items.Add(tagItem.TagViewItem);
                }
                tagListView.EndUpdate();
            }
            return numberOfNewTags;
        }

        private void tagListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedTagChanged != null)
            {
                SelectedTagChanged(this, e);
            }
        }
    }
}
