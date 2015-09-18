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
using System.Collections;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	public class TreeNodeBox : TreeNodeBase
	{
		private bool isNodesLoaded = false;
		private DisksDB.DataBase.DataBase db = null;
		private DataBase.Box box = null;
		protected TreeViewCatalog trv;

		/// <summary>
		/// Constructs CD Box tree item
		/// </summary>
		/// <param name="db">database</param>
		/// <param name="box">database object of cdbox</param>
		public TreeNodeBox(DisksDB.DataBase.DataBase db, DataBase.Box box, TreeViewCatalog trv) : base(box.Name, box, true, true, "CD/DVD Box", -1, DateTime.Now, true, true, false, false, false)
		{
			this.trv = trv;
			this.db = db;
			this.box = box;
			this.ImageIndex = TreeImages.CDBox;
			this.SelectedImageIndex = TreeImages.CDBoxOpen;
			this.box.ChildItemAdded += new EventHandlerItemAdded(ChildItemAdded);
			this.box.ChildItemRemoved += new EventHandlerItemRemoved(ChildItemRemoved);
			this.box.NameChanged += new EventHandler(NameChanged);
			this.box.ChildsChanged += new EventHandler(ChildsChanged);
		}

		/// <summary>
		/// Causes tree node to get its child nodes
		/// </summary>
		public override void LoadTreeNodeChilds()
		{
			if (true == isNodesLoaded)
			{
				return;
			}

			this.Nodes.Clear();

			ArrayList disks = this.box.Disks;

			if (null != disks)
			{
				foreach (DataBase.Disk d in disks)
				{
					TreeNodeDisk nd = new TreeNodeDisk(d, this.db);
					this.Nodes.Add(nd);
				}
			}

			isNodesLoaded = true;
		}

		public override string GetName()
		{
			return this.box.Name;
		}

		/// <summary>
		/// Deltes CDBox
		/// </summary>
		public override void Delete()
		{
			if (MessageBox.Show("Are you sure want to delete CD Box?", "Delete CD Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.box.Delete();
			}
		}

		public override void Rename(string name)
		{
			this.box.Name = name;
		}

		/// <summary>
		/// Show Properties dialog, of this disk
		/// </summary>
		public override void ShowProperties()
		{
			FormPropertiesBox f = new FormPropertiesBox(db, this.box);
			f.ShowDialog();
		}

		public override IEnumerable ChildNodes
		{
			get
			{
				return this.Nodes;
			}
		}

		public DataBase.Box InternalBox
		{
			get
			{
				return this.box;
			}
		}

		public override void CreateNewDisk()
		{
			FormNewDisk f = new FormNewDisk(this.db, this.box);
			f.ShowDialog();
		}

		private void AddItem(TreeNodeCollection lst, BaseObject obj)
		{
			LoadTreeNodeChilds();

			if (obj is DisksDB.DataBase.Disk)
			{
				DisksDB.DataBase.Disk d = (DisksDB.DataBase.Disk)obj;

				int pos = 0;

				for (pos = 0; (pos < lst.Count) && (lst[pos] is TreeNodeDisk); pos++)
				{
					TreeNodeDisk dd = (TreeNodeDisk)lst[pos];
					
					if (dd.InternalDisk.Name.CompareTo(d.Name) >= 0)
					{
						lst.Insert(pos, new TreeNodeDisk(d, this.db));
						return;
					}
				}

				lst.Insert(pos, new TreeNodeDisk(d, this.db));
			}
		}

		private void RemoveItem(TreeNodeCollection lst, BaseObject obj)
		{
			LoadTreeNodeChilds();

			if (obj is DisksDB.DataBase.Disk)
			{
				DisksDB.DataBase.Disk d = (DisksDB.DataBase.Disk)obj;

				for (int i = 0; i < lst.Count; i++)
				{
					if (lst[i] is TreeNodeDisk)
					{
						TreeNodeDisk dd = (TreeNodeDisk)lst[i];

						if (dd.InternalDisk == d)
						{
							lst.RemoveAt(i);
							return;
						}
					}
				}
			} 
		}

		private void ChildItemAdded(BaseObject item)
		{
			this.TreeView.Invoke(new EventHandlerNodesUpdated(AddItem), new object[] { this.Nodes, item } );
			//AddItem(this.Nodes, item);
		}

		private void ChildItemRemoved(BaseObject item)
		{
			this.TreeView.Invoke(new EventHandlerNodesUpdated(RemoveItem), new object[] { this.Nodes, item } );
			//RemoveItem(this.Nodes, item);
		}

		private void NameChanged(object sender, EventArgs e)
		{
			this.Text = this.box.Name;
		}

		private void ChildsChanged(object sender, EventArgs e)
		{
			this.trv.ReFillList(this);
		}

		public override void Refresh()
		{
			this.isNodesLoaded = false;
			LoadTreeNodeChilds();
		}
	}
}
