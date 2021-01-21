using System.Collections.Generic;

namespace RecursiveConsoleApp.Model
{
    public class TreeViewItemModel
	{
		public string Text
		{
			get;
			set;
		}
		public int Id
		{
			get;
			set;
		}
		public bool HasChildren
		{
			get;
			set;
		}

		public List<TreeViewItemModel> Items
		{
			get;
			set;
		}

		public TreeViewItemModel()
		{
			this.Items = new List<TreeViewItemModel>();
		}

        public int depth { get; set; }
    }

}
