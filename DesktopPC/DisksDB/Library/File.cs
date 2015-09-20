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
using System.Collections.Generic;

namespace DisksDB.DataBase
{
	/// <summary>
	/// 
	/// </summary>
	class File : BaseObject
	{
		public File(IDBLayer idb, long id, string name, long size, DateTime date, long attr) : base(idb, id)
		{
			this.name = name;
			this.fa = attr;
			this.size = size;
			this.date = date;
		}

		public string Name
		{
			get
			{
				CheckDeleted();

				return this.name;
			}
		}

		public long Attributes
		{
			get
			{
				CheckDeleted();

				return this.fa;
			}
		}

		/// <summary>
		/// Gets files in root folder of this CD.
		/// Objects of type File are packed in ArrayList
		/// </summary>
		public List<File> Files
		{
			get
			{
				CheckDeleted();

				if (null == this.files)
				{
					this.files = idb.GetFiles(this);
				}

				return this.files;
			}
		}

		public bool IsFolder
		{
			get
			{
				CheckDeleted();

				return false;
			}
		}

		public long Size
		{
			get
			{
				return this.size;
			}
		}

		public DateTime Date
		{
			get
			{
				return this.date;
			}
		}

		private string name = "";
		private long fa;
		private List<File> files = null;
		private long size = 0;
		private DateTime date = DateTime.Now;
	}
}