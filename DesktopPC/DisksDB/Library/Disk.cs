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
using System.Collections;

namespace DisksDB.DataBase
{
	/// <summary>
	/// CD disk
	/// </summary>
	public class Disk : BaseObject
	{
		public Disk(IDBLayer idb, long id, string name, Image image, DiskType type, Box box) : base(idb, id)
		{
			this.name = name;
			this.image = image;
			this.type = type;
			this.box = box;
		}

		/// <summary>
		/// Disk Name
		/// </summary>
		public string Name
		{
			get
			{
				CheckDeleted();
				return this.name;
			}
			set
			{
				CheckDeleted();
				this.name = value;
				Update();

				OnNameChanged();
			}
		}

		/// <summary>
		/// Disk Type
		/// </summary>
		public DiskType Type
		{
			get
			{
				CheckDeleted();
				return this.type;
			}
			set
			{
				CheckDeleted();
				this.type = value;
				Update();
			}
		}

		/// <summary>
		/// CD Box where this disk belongs
		/// </summary>
		public Box Box
		{
			get
			{
				CheckDeleted();
				return this.box;
			}
			set
			{
				CheckDeleted();

				if (null != box)
				{
					this.box.OnChildRemoved(this);
				}

				this.box = value;
				Update();

				if (null != box)
				{
					this.box.OnChildAdded(this);
				}
			}
		}

		/// <summary>
		/// Disk image
		/// </summary>
		public Image Image
		{
			get
			{
				CheckDeleted();
				return this.image;
			}
			set
			{
				CheckDeleted();
				this.image = value;
				Update();
			}
		}

		/// <summary>
		/// Updates disk info in database
		/// </summary>
		private void Update()
		{
			CheckDeleted();

			idb.UpdateDisk(this, this.name, this.type, this.image, this.box);
		}

		/// <summary>
		/// Deletes disk
		/// </summary>
		public override void Delete()
		{
			this.idb.DeleteDisk(this);
			base.Delete();

			if (null != this.box)
			{
				this.box.Remove(this);
			}
		}

		/// <summary>
		/// Gets files in root folder of this CD.
		/// Objects of type File are packed in ArrayList
		/// </summary>
		public ArrayList Files
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

		private ArrayList files = null;
		private string name = null;
		private Image image = null;
		private DiskType type = null;
		private Box box = null;
	}
}