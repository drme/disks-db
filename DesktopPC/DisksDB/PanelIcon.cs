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
using System.Drawing;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Panel which displays icon
	/// </summary>
	public class PanelIcon : System.Windows.Forms.Panel
	{
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			if (null != this.icon)
			{
				e.Graphics.DrawIcon(this.icon, 0, 0);
			}
			else
			{
				base.OnPaint(e);
			}
		}

		public Icon BackIcon
		{
			get
			{
				return this.icon;
			}
			set
			{
				this.icon = value;
			}
		}

		private Icon icon = null;
	}
}
