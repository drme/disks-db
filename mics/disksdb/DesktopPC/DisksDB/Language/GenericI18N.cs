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

namespace DisksDB.Language
{
	/// <summary>
	/// Summary description for GenericI18N.
	/// </summary>
	internal class GenericI18N
	{
		internal static void InternationalizeControl(MenuItem mi)
		{
//			foreach (MenuItem m in mi.MenuItems)
//			{
//				InternationalizeControl(m);
//			}
//
//			if (mi.Text != "-")
//			{
//				mi.Text = I18N.Instance.GetText(mi.Text, mi.Text);
//			}
		}

		internal static void InternationalizeControl(Control c)
		{
//			if (c is Form)
//			{
//				c.Text = I18N.Instance.GetText(c.Name, c.Text);
//
//				Form f = (Form)c;
//
//				if (null != f.Menu)
//				{
//					foreach (MenuItem mi in f.Menu.MenuItems)
//					{
//						InternationalizeControl(mi);
//					}
//				}
//			}
//			else if (c is Label)
//			{
//				c.Text = I18N.Instance.GetText(c.Parent.Name + "/" + c.Name, c.Text);
//			} 
//			else
//			{
//			}
//
//			foreach (Control c1 in c.Controls)
//			{
//				InternationalizeControl(c1);
//			}
		}
	}
}
