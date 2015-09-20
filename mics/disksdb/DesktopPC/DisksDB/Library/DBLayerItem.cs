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
using System.IO;

namespace DisksDB.DataBase
{
	class DBLayerItem
	{
		public DBLayerItem(String path, String className, IDBLayer layer)
		{
			this.FullPath = Path.GetFileName(path);
			this.ClassName = className;
			this.Layer = layer;
		}

		public override String ToString()
		{
			return this.Layer.Name;
		}

		public string ClassName
		{
			get;
			private set;
		}

		public string FullPath
		{
			get;
			private set;
		}

		public IDBLayer Layer
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes database: creates database files, populates with initial data, deletes old database.
		/// In case of error throws ApplicationException with message.
		/// </summary>
		public void InitDataBase(bool silent)
		{
			if (false == this.Layer.IsNewDataBase())
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

			this.Layer.ResetDataBase();
		}
	}
}
