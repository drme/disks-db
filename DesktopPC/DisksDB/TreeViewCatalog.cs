/*
===========================================================================
Copyright (C) 2015 Sarunas

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
using System.Drawing;
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Class Represents loaded disks tree from database
	/// Displays categories, cd boxes, disks, folders, files in a tree
	/// </summary>
	class TreeViewCatalog : TreeViewBase
	{
		private DataBase.Category rootCategory = null;
		private TreeNodeCategory rootCat = null;
		private FormInfoView infoView = null;
		private FileIcons fileIcons = null;

		public TreeViewCatalog(ImageList imgList) : base()
		{
			this.AllowDrop = true;
			this.ContextMenu.Popup += new EventHandler(ContextMenuPopup);
			this.ImageList = imgList;
			this.fileIcons = new FileIcons(imgList);
		}

		protected override void OnItemDrag(ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);

			base.OnItemDrag(e);
		}

		protected override void OnDragEnter(DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;

			base.OnDragEnter(e);
		}

		private bool TryDragCategory(DragEventArgs e, TreeNodeCategory c)
		{
			object fromObj = e.Data.GetData(typeof (TreeNodeCategory));

			if (null == fromObj)
			{
				return false;
			}

			if (fromObj == c)
			{
				return false;
			}

			TreeNodeCategory dragedCat = (TreeNodeCategory) fromObj;

			try
			{
				dragedCat.InternalCategory.Parent = c.InternalCategory;
			}
			catch (Exception ex)
			{
				ErrorMessenger.ErrorMessage(null, "Category can not be moved here", ex);

				return false;
			}

			return true;
		}

		private bool TryDragBox(DragEventArgs e, TreeNodeCategory c)
		{
			object fromObj = e.Data.GetData(typeof (TreeNodeBox));

			if (null == fromObj)
			{
				return false;
			}

			if (fromObj == c)
			{
				return false;
			}

			TreeNodeBox dragedBox = (TreeNodeBox) fromObj;
			dragedBox.InternalBox.Parent = c.InternalCategory;

			return true;
		}

		private bool TryDragDisk(DragEventArgs e, TreeNodeBox b)
		{
			object fromObj = e.Data.GetData(typeof (TreeNodeDisk));

			if (null == fromObj)
			{
				return false;
			}

			if (fromObj == b)
			{
				return false;
			}

			TreeNodeDisk dragedDisk = (TreeNodeDisk) fromObj;
			dragedDisk.InternalDisk.Box = b.InternalBox;

			return true;
		}

		private void DragToCategory(DragEventArgs e, TreeNodeCategory c)
		{
			if (true == TryDragCategory(e, c))
			{
				return;
			}

			if (true == TryDragBox(e, c))
			{
				return;
			}
		}

		private void DragToBox(DragEventArgs e, TreeNodeBox b)
		{
			if (true == TryDragDisk(e, b))
			{
				return;
			}
		}

		private bool DragToRoot(DragEventArgs e)
		{
			if (null == this.rootCategory)
			{
				return false;
			}

			object fromObj = e.Data.GetData(typeof (TreeNodeCategory));

			if (null == fromObj)
			{
				return false;
			}

			TreeNodeCategory dragedCat = (TreeNodeCategory) fromObj;
			try
			{
				dragedCat.InternalCategory.Parent = this.rootCat.InternalCategory;
			}
			catch (Exception ex)
			{
				ErrorMessenger.ErrorMessage(null, "Category can not be draged here", ex);

				return false;
			}

			return true;
		}

		protected override void OnDragDrop(DragEventArgs e)
		{
			base.OnDragDrop(e);

			TreeNode destNode = this.GetNodeAt(this.PointToClient(new Point(e.X, e.Y)));

			if (null == destNode)
			{
				DragToRoot(e);
			}
			else if (destNode is TreeNodeCategory)
			{
				DragToCategory(e, (TreeNodeCategory) destNode);
			}
			else if (destNode is TreeNodeBox)
			{
				DragToBox(e, (TreeNodeBox) destNode);
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// Explicitly loads/reloads tree contents
		/// </summary>
		public override void LoadTree()
		{
			try
			{
				this.rootCategory = this.DataBase.RootCategory;

				if (null == this.rootCategory)
				{
					return;
				}

				this.rootCat = new TreeNodeCategory(this.DataBase, rootCategory, this);
				this.rootCat.LoadTreeNodeChilds();

				this.SelectedNode = this.rootCat;
			}
			catch (Exception ex)
			{
				ErrorMessenger.ErrorMessage(this, "Error occured while loading data", ex);
			}

			FillList();
		}

		protected void FillList()
		{
			if (null != this.infoView)
			{
				if (null != this.SelectedNode)
				{
					if (this.SelectedNode is IListItem)
					{
						IListItem li = (IListItem) this.SelectedNode;
						this.infoView.SetRootItem(li);
					}
					else
					{
						this.infoView.SetRootItem(null);
					}
				}
				else
				{
					this.infoView.SetRootItem(this.rootCat);
				}
			}
		}

		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			base.OnAfterSelect(e);
			FillList();
		}

		/// <summary>
		/// Asociates tree control with list control.
		/// Then tree node is selected list asociated list view is updated.
		/// </summary>
		public FormInfoView InfoVew
		{
			set
			{
				this.infoView = value;
			}
		}

		public void MoveUp()
		{
			if (null != this.SelectedNode)
			{
				TreeNode tn = this.SelectedNode.Parent;

				if (null != tn)
				{
					this.SelectedNode = tn;
				}
			}
		}

		private void ContextMenuPopup(object sender, EventArgs e)
		{
			if (null != this.SelectedNode)
			{
				this.mnuEdit.UpdateMenu((IListItem) this.SelectedNode);
			}
			else
			{
				this.mnuEdit.UpdateMenu(this.rootCat);
			}
		}

		public void ReFillList(IListItem changedItem)
		{
			if (null != this.infoView)
			{
				this.infoView.ReFillList(changedItem);
			}
		}

		public FileIcons FileIcons
		{
			get
			{
				return this.fileIcons;
			}
		}
	}
}