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
	public class ListItem : ListViewItem
	{
		public ListItem(IListItem i) : base(i.GetName())
		{
			this.iListItem = i;
			this.type = i.GetTypeName();
			this.size = i.GetSize();
			this.date = i.GetDate();
			this.SetInfo();
			this.ImageIndex = (int) i.GetIconId();
			
			i.GetBaseObject().NameChanged += new EventHandler(NameChanged);
		}

		private void NameChanged(object sender, EventArgs e)
		{
			this.Text = this.iListItem.GetName();
		}

		public ListItem(string name, string type) : base(name)
		{
			this.type = type;
			this.SetInfo();
		}

		public ListItem(string name, string type, long size, DateTime date) : base(name)
		{
			this.type = type;
			this.date = date;
			this.size = size;
			this.SetInfo();
		}

		private void SetInfo()
		{
			if (this.size < 0)
			{
				this.SubItems.Add("");
			}
			else
			{
				this.SubItems.Add(Convert.ToString(this.size));
			}
			this.SubItems.Add(this.type);
			this.SubItems.Add(this.date.ToString());
		}

		public IListItem IListItem
		{
			get
			{
				return this.iListItem;
			}
		}

		private string type = "";
		private long size = -1;
		private DateTime date = DateTime.Now;
		private IListItem iListItem;
	}
}