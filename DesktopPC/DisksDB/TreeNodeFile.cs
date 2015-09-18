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
using System.Collections;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Represents file/folder in cd tree.
	/// </summary>
	public class TreeNodeFile : TreeNodeBase
	{
		private bool isNodesLoaded = false;
		private DataBase.File file = null;
		private ArrayList childFiles = null;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="f">database file object</param>
		public TreeNodeFile(DataBase.File f, TreeViewCatalog tvc) : base(f.Name, f, false, false, "GenericFile", f.Size, f.Date, true, false, false, false, false)
		{
			this.file = f;

			if (f.Attributes == 1)
			{
				this.ImageIndex = TreeImages.Folder;
				this.SelectedImageIndex = TreeImages.FolderOpen;
				this.typeName = "Folder";
				this.size = -1;
			}
			else
			{
				int pos = f.Name.LastIndexOf(".");

				string ext = "";

				if (pos >= 0)
				{
					ext = f.Name.Substring(pos);
				}

				this.ImageIndex = tvc.FileIcons.GetFileIconId(ext);
				this.SelectedImageIndex = this.ImageIndex;
				this.typeName = "File";
			}
		}

		/// <summary>
		/// Shows properties dialog.
		/// </summary>
		public override void ShowProperties()
		{
			new FormPropertiesFile(this).ShowDialog();
		}

		/// <summary>
		/// Causes tree node to get its child nodes
		/// </summary>
		public override void LoadTreeNodeChilds()
		{
			if (true == this.isNodesLoaded)
			{
				return;
			}

			ArrayList files = this.file.Files;
			
			this.childFiles = new ArrayList();

			if (null != files)
			{
				foreach (DataBase.File f in files)
				{
					TreeNodeFile nf = new TreeNodeFile(f, (TreeViewCatalog)this.TreeView);

					if (f.Attributes == 1)
					{
						this.Nodes.Add(nf);
					}
					this.childFiles.Add(nf);
				}
			}

			this.isNodesLoaded = true;
		}

		/// <summary>
		/// Returns list of child files for displaying in a list.
		/// </summary>
		public override IEnumerable ChildNodes
		{
			get
			{
				LoadTreeNodeChilds();
				return this.childFiles;
			}
		}

		public DataBase.File InternalFile
		{
			get
			{
				return this.file;
			}
		}
	}
}
