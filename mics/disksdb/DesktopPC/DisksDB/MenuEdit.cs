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

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for MenuEdit.
	/// </summary>
	public class MenuEdit
	{
		private MenuItem mnuRename = new MenuItem("Rename");
		private MenuItem mnuProperties = new MenuItem("Properties");
		private MenuItem mnuSep = new MenuItem("-");
		private MenuItem mnuSep2 = new MenuItem("-");
		private MenuItem mnuNew = new MenuItem("New");
		private MenuItem mnuDel = new MenuItem("Delete");
		private MenuItem mnuNewCat = new MenuItem("Category");
		private MenuItem mnuNewBox = new MenuItem("CD/DVD Box");
		private MenuItem mnuNewDisk = new MenuItem("CD/DVD Disk");
		private MenuItem mnuNewImage = new MenuItem("Image");
		private MenuItem mnuSep3 = new MenuItem("-");
		private MenuItem mnuRefresh = new MenuItem("Refresh");
		private MenuItem[] mnuItems = new MenuItem[8];
		private IListItem item = null;
		private INativeRename editor = null;

		public MenuEdit()
		{
			mnuProperties.Click += new EventHandler(PropertiesClick);
			mnuNewDisk.Click += new EventHandler(NewDiskClick);
			mnuNewBox.Click += new EventHandler(NewBoxClick);
			mnuNewCat.Click += new EventHandler(NewCategoryClick);
			mnuRename.Click += new EventHandler(RenameClick);
			mnuDel.Click += new EventHandler(DeleteClick);
			mnuRefresh.Click += new EventHandler(RefreshClick);
			mnuNewImage.Click += new EventHandler(NewImageClick);

			mnuItems[0] = mnuNew;
			mnuItems[1] = mnuSep;
			mnuItems[2] = mnuDel;
			mnuItems[3] = mnuRename;
			mnuItems[4] = mnuSep2;
			mnuItems[5] = mnuRefresh;
			mnuItems[6] = mnuSep3;
			mnuItems[7] = mnuProperties;

			mnuNew.MenuItems.Add(mnuNewCat);
			mnuNew.MenuItems.Add(mnuNewBox);
			mnuNew.MenuItems.Add(mnuNewDisk);
			mnuNew.MenuItems.Add(mnuNewImage);
		}

		public void UpdateMenu(IListItem item)
		{
			this.item = item;

			if (null == this.item)
			{
				mnuProperties.Enabled = false;
				mnuDel.Enabled = false;
				mnuRename.Enabled = false;
				mnuNewCat.Enabled = false;
				mnuNewBox.Enabled = false;
				mnuNewDisk.Enabled = false;
				mnuNewImage.Enabled = false;
			} 
			else
			{
				mnuProperties.Enabled = this.item.HasProperties();
				mnuDel.Enabled = this.item.CanBeDeleted();
				mnuRename.Enabled = this.item.CanBeRenamed();
				mnuNewCat.Enabled = this.item.CanContainCategory();
				mnuNewBox.Enabled = this.item.CanContainBox();
				mnuNewDisk.Enabled = this.item.CanContainDisk();
				mnuNewImage.Enabled = this.item.CanContainImage();
			}
		}

		public void SetEditor(INativeRename editor)
		{
			this.editor = editor;
		}

		public MenuItem[] MenuItems
		{
			get
			{
				return this.mnuItems;
			}
		}

		public void PropertiesClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.ShowProperties();
			}
		}

		private void NewDiskClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.CreateNewDisk();
			}	
		}

		private void NewBoxClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.CreateNewBox();
			}		
		}

		private void NewCategoryClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.CreateNewCategory();
			}		
		}

		private void RenameClick(object sender, EventArgs e)
		{
			if (null != this.editor)
			{
				this.editor.BeginEdit();
			}
		}

		public void DeleteClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.Delete();
			}
		}

		private void RefreshClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.Refresh();
			}		
		}

		private void NewImageClick(object sender, EventArgs e)
		{
			if (null != this.item)
			{
				this.item.CreateNewImage();
			}		
		}
	}
}
