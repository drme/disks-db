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

namespace DisksDB.DataBase
{
	class SearchResultRow : System.Windows.Forms.ListViewItem
	{
		public SearchResultRow(string fileName, int fileSize, int fileType, DateTime fileDate, Disk disk, Box box, Category category, string diskName, string boxName, string categoryName) : base(fileName)
		{
			this.fileName = fileName;
			this.fileSize = fileSize;
			this.fileType = fileType;
			this.fileDate = fileDate;
			this.disk = disk;
			this.box = box;
			this.category = category;
			this.diskName = diskName;
			this.boxName = boxName;
			this.categoryName = categoryName;
		}

		private string fileName;
		private int fileSize;
		private int fileType;
		private DateTime fileDate;
		private Disk disk;
		private Box box;
		private Category category;
		private string diskName;
		private string boxName;
		private string categoryName;

		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName = value;
			}
		}

		public int FileSize
		{
			get
			{
				return fileSize;
			}
			set
			{
				fileSize = value;
			}
		}

		public int FileType
		{
			get
			{
				return fileType;
			}
			set
			{
				fileType = value;
			}
		}

		public DateTime FileDate
		{
			get
			{
				return fileDate;
			}
			set
			{
				fileDate = value;
			}
		}

		public Disk Disk
		{
			get
			{
				return disk;
			}
			set
			{
				disk = value;
			}
		}

		public Box Box
		{
			get
			{
				return box;
			}
			set
			{
				box = value;
			}
		}

		public Category Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
			}
		}

		public string DiskName
		{
			get
			{
				return diskName;
			}
			set
			{
				diskName = value;
			}
		}

		public string BoxName
		{
			get
			{
				return boxName;
			}
			set
			{
				boxName = value;
			}
		}

		public string CategoryName
		{
			get
			{
				return categoryName;
			}
			set
			{
				categoryName = value;
			}
		}
	}
}