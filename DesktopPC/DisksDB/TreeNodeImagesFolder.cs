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
using System.Diagnostics;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	class TreeNodeImagesFolder : TreeNodeBase
	{
		private DisksDB.DataBase.ImageFactory imgFact;
		private bool isChildsLoaded = false;

		public TreeNodeImagesFolder(string name, DisksDB.DataBase.ImageFactory imgFact) : base(name, imgFact, false, false, "Images Folder", -1, DateTime.Now, false, false, false, false, true)
		{
			this.ImageIndex = TreeImages.Folder;
			this.SelectedImageIndex = TreeImages.FolderOpen;
			this.imgFact = imgFact;
			this.imgFact.ChildItemAdded += new EventHandlerItemAdded(ChildItemAdded);
			this.imgFact.ChildItemRemoved += new EventHandlerItemRemoved(ChildItemRemoved);
		}

        public DisksDB.DataBase.ImageFactory ImagesFactory
        {
            get
            {
                return this.imgFact;
            }
        }

		public override void LoadTreeNodeChilds()
		{
			if (true == this.isChildsLoaded)
			{
				return;
			}

			if (null != this.imgFact)
			{
				var lst = this.imgFact.GetImages();

				if (null != lst)
				{
					foreach(Image img in lst)
					{
						this.Nodes.Add(new TreeNodeImage(img, this.imgFact));
					}
				}
			}

			this.isChildsLoaded = true;
		}

		private void AddItem(TreeNodeCollection lst, BaseObject obj)
		{
			LoadTreeNodeChilds();

			if (obj is DisksDB.DataBase.Image)
			{
				DisksDB.DataBase.Image img = (DisksDB.DataBase.Image)obj;

				int pos = 0;

				for (pos = 0; (pos < lst.Count) && (lst[pos] is TreeNodeImage); pos++)
				{
					TreeNodeImage ti = (TreeNodeImage)lst[pos];
					
					if (ti.InternalImage.Name.CompareTo(img.Name) >= 0)
					{
						lst.Insert(pos, new TreeNodeImage(img, this.imgFact));
						return;
					}
				}

				lst.Insert(pos, new TreeNodeImage(img, this.imgFact));
			}
		}

		private void RemoveItem(TreeNodeCollection lst, BaseObject obj)
		{
			LoadTreeNodeChilds();

			if (obj is DisksDB.DataBase.Image)
			{
				DisksDB.DataBase.Image img = (DisksDB.DataBase.Image)obj;

				for (int i = 0; i < lst.Count; i++)
				{
					if (lst[i] is TreeNodeImage)
					{
						TreeNodeImage ti = (TreeNodeImage)lst[i];

						if (ti.InternalImage == img)
						{
							lst.RemoveAt(i);
							return;
						}
					}
				}
			} 
		}

		public override void CreateNewImage()
		{
			FormAddImage f = new FormAddImage();
			f.ShowDialog();
			if (f.DialogResult == DialogResult.OK)
			{
				try
				{
					this.imgFact.AddImage(f.ImageTitle, f.ImageFile, null);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					Debug.WriteLine(ex.StackTrace);
				}
			}
			f.Dispose();		
		}

		private void ChildItemAdded(BaseObject item)
		{
			this.TreeView.Invoke(new EventHandlerNodesUpdated(AddItem), new object[] { this.Nodes, item } );
		}

		private void ChildItemRemoved(BaseObject item)
		{
			this.TreeView.Invoke(new EventHandlerNodesUpdated(RemoveItem), new object[] { this.Nodes, item } );
		}

		public override void Refresh()
		{
			this.isChildsLoaded = false;
			LoadTreeNodeChilds();
		}
	}
}
