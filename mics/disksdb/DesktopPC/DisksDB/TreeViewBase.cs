/*
===========================================================================
Copyright (C) 2005 Sarunas

This file is part of DisksDB source code.

DisksDB source code is free software; you can redistribute it
and/or modify it under the terms of the GNU General Public License as
published by the Free Software Foundation; either version 2 of the License,
or (at your option) any later version.

DisksDB source code is distributed in the hope that it will be
useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with DisksDB; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
===========================================================================
*/
using System;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for BaseTreeView.
	/// </summary>
	public abstract class TreeViewBase : TreeView, INativeRename
	{
		public event EventHandlerItemSelected ItemSelected;
		protected MenuEdit mnuEdit = null;
		private TreeNode mySelectedNode = null;
		private DisksDB.DataBase.DataBase dataBase = null;

		public TreeViewBase() : base()
		{
			this.mnuEdit = new MenuEdit();
			this.mnuEdit.SetEditor(this);
			this.ContextMenu = new ContextMenu(this.mnuEdit.MenuItems);
			//this.ContextMenu.Popup += new EventHandler(ContextMenuPopup);
		}

		protected void OnItemSelected(IListItem item)
		{
			if (null != this.ItemSelected)
			{
				this.ItemSelected(item);
			}
		}

		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			base.OnAfterSelect(e);

			if (null != this.SelectedNode)
			{
				if (this.SelectedNode is IListItem)
				{
					OnItemSelected((IListItem)this.SelectedNode);
					mnuEdit.UpdateMenu((IListItem)this.SelectedNode);
				}

				if (this.SelectedNode is ITreeNode)
				{
					ITreeNode tn = (ITreeNode) this.SelectedNode;
					tn.LoadTreeNodeChilds();
				}
			} 
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.mySelectedNode = this.GetNodeAt(e.X, e.Y);
			this.SelectedNode = this.mySelectedNode;
		}

		public virtual void BeginEdit()
		{
			if (this.mySelectedNode != null)
			{
				this.SelectedNode = mySelectedNode;
				this.LabelEdit = true;

				if (false == mySelectedNode.IsEditing)
				{
					mySelectedNode.BeginEdit();
				}
			}		
		}

		protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
		{
			base.OnAfterLabelEdit(e);

			if (e.Label != null)
			{
				if (e.Label.Length > 0)
				{
					if (e.Label.IndexOfAny(new char[] {'@', '.', ',', '!'}) == -1)
					{
						e.Node.EndEdit(false);
						Rename(e.Node, e.Label);
					}
					else
					{
						e.CancelEdit = true;

						MessageBox.Show("Invalid tree node label.\n" +
							"The invalid characters are: '@','.', ',', '!'",
							"Node Label Edit");

						e.Node.BeginEdit();
					}
				}
				else
				{
					e.CancelEdit = true;
					MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
						"Node Label Edit");
					e.Node.BeginEdit();
				}
				this.LabelEdit = false;
			}
		}

		private void Rename(TreeNode n, string newText)
		{
			if (n is IListItem)
			{
				IListItem li = (IListItem)n;

				li.Rename(newText);
			}
		}

		/// <summary>
		/// DataBase object for getting tree contents
		/// </summary>
		public DisksDB.DataBase.DataBase DataBase
		{
			set
			{
				if (null != this.dataBase)
				{
					this.dataBase.LayerChanged -= new EventHandler(LayerChanged);
				}

				this.dataBase = value;

				if (null != this.dataBase)
				{
					this.dataBase.LayerChanged += new EventHandler(LayerChanged);
				}
			}
			get
			{
				return this.dataBase;
			}
		}

		public virtual void LoadTree()
		{
		}

		private void LayerChanged(object sender, EventArgs e)
		{
			this.Nodes.Clear();
			LoadTree();
		}
	}
}
