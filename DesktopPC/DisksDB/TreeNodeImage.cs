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
	/// Summary description for TreeNodeImage.
	/// </summary>
	public class TreeNodeImage : TreeNodeBase
	{
		private Image img;
		private ImageFactory imgFact;

		public TreeNodeImage(Image img, ImageFactory imgFact) : base(img.Name, img, true, true, "Image", -1, DateTime.Now, true, false, false, false, false)
		{
			this.ImageIndex = TreeImages.Picture;
			this.SelectedImageIndex = TreeImages.Picture;
			this.img = img;
			this.imgFact = imgFact;
			this.img.NameChanged += new EventHandler(NameChanged);
		}

		public override void LoadTreeNodeChilds()
		{
		}

		public override void ShowProperties()
		{
			new FormPropertiesImage(this.imgFact, this.img).ShowDialog();
		}

		public Image InternalImage
		{
			get
			{
				return this.img;
			}
		}

		private void NameChanged(object sender, EventArgs e)
		{
			this.Text = this.img.Name;
		}

		public override void Delete()
		{
			if (ErrorMessenger.QuestionMessage(null, "Delete Image", "Are you sure want to delete image?") == DialogResult.Yes)
			{
				try
				{
					this.img.Delete();
				}
				catch (Exception ex)
				{
					ErrorMessenger.ErrorMessage(null, "This image cannot be deleted at this time.", ex);
				}
			}
		}

		public override void Rename(string name)
		{
			this.img.Name = name;
		}

		public override string GetName()
		{
			return this.img.Name;
		}
	}
}
