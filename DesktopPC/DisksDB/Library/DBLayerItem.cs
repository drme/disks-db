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
using System.IO;

namespace DisksDB.DataBase
{
	/// <summary>
	/// Summary description for DBLayerItem.
	/// </summary>
	public class DBLayerItem
	{
		public DBLayerItem(string path, string className, IDBLayer layer)
		{
			this.path = Path.GetFileName(path);
			this.className = className;
			this.layer = layer;
		}

		public override string ToString()
		{
			return this.layer.Name;
		}

		public string ClassName
		{
			get
			{
				return this.className;
			}
		}

		public string FullPath
		{
			get
			{
				return this.path;
			}
		}

		public IDBLayer Layer
		{
			get
			{
				return this.layer;
			}
		}

		/// <summary>
		/// Initializes database: creates database files, populates with initial data, deletes old database.
		/// In case of error throws ApplicationException with message.
		/// </summary>
		public void InitDataBase(bool silent)
		{
			if (false == this.layer.IsNewDataBase())
			{
				if (true == silent)
				{
					return;
				}

				if (System.Windows.Forms.DialogResult.Yes != System.Windows.Forms.MessageBox.Show(null, "DataBase is populated with data. All Disks data will be lost.Do you want to reset datbase?", "Reset database", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning))
				{
					return;
				}
			}

			this.layer.ResetDataBase();
		}

		private string path;
		private string className;
		private IDBLayer layer;
	}
}
