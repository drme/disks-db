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
using System.Collections;
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Represents disk in cd catalog tree
	/// </summary>
	class TreeNodeDisk : TreeNodeBase
	{
		private bool isNodesLoaded = false;
		private DataBase.Disk disk = null;
		private ArrayList files = null;
		private DisksDB.DataBase.DataBase db = null;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="d">this disk object</param>
		public TreeNodeDisk(DataBase.Disk d, DisksDB.DataBase.DataBase db) : base(d.Name, d, true, true, "CD/DVD Disk", -1, DateTime.Now, true, false, false, false, false)
		{
			this.disk = d;
			this.db = db;
			this.ImageIndex = TreeImages.CD;
			this.SelectedImageIndex = TreeImages.CDOpen;
			this.disk.NameChanged += new EventHandler(NameChanged);
		}

		/// <summary>
		/// Deletes disk from database, also removes from tree.
		/// </summary>
		public override void Delete()
		{
			if (ErrorMessenger.QuestionMessage(null, "Delete CD Disk", "Are you sure want to delete CD Disk?") == DialogResult.Yes)
			{
				try
				{
					this.disk.Delete();
				}
				catch (Exception ex)
				{
					ErrorMessenger.ErrorMessage(null, "Error occured while deleting disk", ex);
				}
			}
		}

		public override void Rename(string name)
		{
			this.disk.Name = name;
		}

		public override string GetName()
		{
			return this.disk.Name;
		}

		public override void ShowProperties()
		{
			new FormPropertiesDisk(this.disk, this.db).ShowDialog();
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

			var files = disk.Files;

			if (null != files)
			{
				this.files = new ArrayList();

				foreach (DataBase.File f in files)
				{
					TreeNodeFile nf = new TreeNodeFile(f, (TreeViewCatalog)this.TreeView);
					this.files.Add(nf);
					if (f.Attributes == 1)
					{
						this.Nodes.Add(nf);
					}
				}
			}

			isNodesLoaded = true;
		}

		public override IEnumerable ChildNodes
		{
			get
			{
				return this.files;
			}
		}

		public DisksDB.DataBase.Disk InternalDisk
		{
			get
			{
				return this.disk;
			}
		}

		private void NameChanged(object sender, EventArgs e)
		{
			this.Text = this.disk.Name;
		}

		public override void Refresh()
		{
			this.isNodesLoaded = false;
			LoadTreeNodeChilds();
		}
	}
}
