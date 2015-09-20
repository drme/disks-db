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
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	class TreeViewImages : TreeViewBase
	{
		private FormImagePreview prv = null;
        private TreeNodeImagesFolder tnFront = null;
        private TreeNodeImagesFolder tnBack = null;
        private TreeNodeImagesFolder tnInlay = null;
        private TreeNodeImagesFolder tnDisk = null;
        private TreeNodeImagesFolder tnDVD = null;

		public TreeViewImages(DisksDB.DataBase.DataBase db, FormImagePreview prv)
		{
			this.DataBase = db;
			this.prv = prv;
			LoadTree();
			this.ContextMenu.Popup += new EventHandler(ContextMenuPopup);

            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(TreeViewImages_DragDrop);
		}

        private void TreeViewImages_DragDrop(object sender, DragEventArgs e)
        {
            ImageFactory f = null;

            if (this.SelectedNode is TreeNodeImagesFolder)
            {
                f = ((TreeNodeImagesFolder)this.SelectedNode).ImagesFactory;
            }

            if (null != f)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string s in files)
                {
                    try
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(s);

                        f.AddImage(Utils.CleanUpName(fi.Name), s, null);

                        fi.Delete();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

		public override void LoadTree()
		{
			this.SuspendLayout();

			this.Nodes.Clear();

            this.tnFront = new TreeNodeImagesFolder("Front Covers", this.DataBase.FrontImages);
            this.tnBack = new TreeNodeImagesFolder("Back Covers", this.DataBase.BackImages);
            this.tnInlay = new TreeNodeImagesFolder("Inlay Covers", this.DataBase.InlayImages);
            this.tnDisk = new TreeNodeImagesFolder("Disk Images", this.DataBase.DiskImages);
            this.tnDVD = new TreeNodeImagesFolder("DVD Box Images", this.DataBase.DvdImages);

			this.Nodes.Add(this.tnFront);
			this.Nodes.Add(this.tnBack);
			this.Nodes.Add(this.tnInlay);
            this.Nodes.Add(this.tnDisk);
            this.Nodes.Add(this.tnDVD);

			this.ResumeLayout();
		}

		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			base.OnAfterSelect(e);

			if (null != this.SelectedNode)
			{
				if (this.SelectedNode is TreeNodeImage)
				{
					TreeNodeImage tnImage = (TreeNodeImage)this.SelectedNode;

					if (null != this.prv)
					{
						this.prv.ShowImage(tnImage.InternalImage);
					}
				}
			} 
		}

		private void ContextMenuPopup(object sender, EventArgs e)
		{
			if (null != this.SelectedNode)
			{
				this.mnuEdit.UpdateMenu((IListItem)this.SelectedNode);
			} 
			else
			{
				this.mnuEdit.UpdateMenu(null);
			}
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

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

        }
	}
}
