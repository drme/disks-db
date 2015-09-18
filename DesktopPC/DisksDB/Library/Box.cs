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
	/// Summary description for CDBox.
	/// </summary>
	public class Box : BaseObject
	{
		public Box(string name, string comment, long id, Image back, Image inlay, BoxType type, Image front, IDBLayer idb, Category parent) : base(idb, id)
		{
			this.parent = parent;
			this.name = name;
			this.desc = comment;
			this.type = type;
			this.front = front;
			this.back = back;
			this.inlay = inlay;
		}

		public override void Delete()
		{
			idb.DeleteCDBox(this);
			base.Delete();

			if (null != this.parent)
			{
				this.parent.Remove(this);
			}
		}

		public Category Parent
		{
			get
			{
				CheckDeleted();

				return this.parent;
			}
			set
			{
				CheckDeleted();
				
				if (null != parent)
				{
					this.parent.OnChildRemoved(this);
				}

				this.parent = value;
				Update();

				if (null != parent)
				{
					this.parent.OnChildAdded(this);
				}
			}
		}

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

		public string Description
		{
			get
			{
				CheckDeleted();

				return this.desc;
			}
			set
			{
				CheckDeleted();

				this.desc = value;
				Update();
			}
		}

		public Image FrontCover
		{
			get
			{
				CheckDeleted();

				return this.front;
			}
			set
			{
				CheckDeleted();

				this.front = value;
				Update();
			}
		}

		public Image BackCover
		{
			get
			{
				CheckDeleted();

				return this.back;
			}
			set
			{
				CheckDeleted();

				this.back = value;
				Update();
			}
		}

		public Image InlayCover
		{
			get
			{
				CheckDeleted();

				return this.inlay;
			}
			set
			{
				CheckDeleted();

				this.inlay = value;
				Update();
			}
		}

		public BoxType Type
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

		public ArrayList Disks
		{
			get
			{
				CheckDeleted();

				//if (null == this.disks)
				{
					this.disks = idb.GetDisks(this);
				}

				return this.disks;
			}
		}

		private void Update()
		{
			CheckDeleted();

			this.idb.UpdateCDBox(this, this.name, this.desc, this.back, this.front, this.inlay, this.type, this.parent);
		}

		public Disk AddDisk(string name, DiskType type, Image image, string driveLetter, IAddDiskProgress prog, bool addFiles)
		{
			CheckDeleted();

			Disk d = this.idb.AddDisk(name, type, image, this, driveLetter, prog, addFiles);

			if (d != null)
			{
				OnChildAdded(d);
			}

			return d;
		}

		private ArrayList disks = null;
		private string name = null;
		private string desc = null;
		private Category parent = null;
		private Image front = null;
		private Image back = null;
		private Image inlay = null;
		private BoxType type = null;
	}
}