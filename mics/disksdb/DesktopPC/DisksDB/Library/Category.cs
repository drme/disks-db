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
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DisksDB.DataBase
{
	[Serializable()]
	class Category : BaseObject
	{
		public Category() : base(null, -1)
		{
		}

		public Category(string name, string description, long id, IDBLayer idb, Category parent) : base(idb, id)
		{
			this.name = name.Trim();
			this.description = description.Trim();
			this.parent = parent;
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

				this.idb.UpdateCategory(this, value, this.description, this.parent);
				this.name = value;

				OnNameChanged();
			}
		}

		public string Description
		{
			get
			{
				CheckDeleted();

				return this.description;
			}
			set
			{
				CheckDeleted();

				this.idb.UpdateCategory(this, this.name, value, parent);
				this.description = value;
			}
		}

		public bool IsRoot
		{
			get
			{
				CheckDeleted();

				return (null == this.parent);
			}
		}

		[XmlIgnore]
		public List<Category> ChildCategories
		{
			get
			{
				CheckDeleted();

				//if (null == this.childCategories)
				{
					this.childCategories = idb.GetChildCategories(this);
				}

				return this.childCategories;
			}
		}

		[XmlIgnore]
		public List<Box> ChildCDBoxes
		{
			get
			{
				CheckDeleted();

				//if (null == this.childCDBoxes)
				{
					this.childCDBoxes = idb.GetChildCDBoxes(this);
				}

				return this.childCDBoxes;
			}
		}

		public override void Delete()
		{
			this.idb.DeleteCategory(this);
			base.Delete();

			if (null != parent)
			{
				this.parent.Remove(this);
			}
		}

		public Category AddCategory(String name, String description)
		{
			CheckDeleted();

			Category c = this.idb.AddCategory(name, description, this);

			if (null != c)
			{
				this.ChildCategories.Add(c);
				OnChildAdded(c);
			}

			return c;
		}

		[XmlIgnore]
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

				if (false == IsValidMove(value))
				{
					throw new ApplicationException("Can't move here");
				}

				if (null != parent)
				{
					this.parent.OnChildRemoved(this);
				}

				this.idb.UpdateCategory(this, this.name, this.description, value);
				this.parent = value;

				if (null != parent)
				{
					this.parent.OnChildAdded(this);
				}
			}
		}

		bool IsValidMove(Category newParent)
		{
			if (null == newParent)
			{
				return true;
			}

			if (newParent == this)
			{
				return false;
			} 
			else
			{
				return IsValidMove(newParent.Parent);
			}
		}

		public Box AddCDBox(string name, string description, BoxType type, Image front, Image back, Image inlay)
		{
			CheckDeleted();

			Box box = this.idb.AddCDBox(name, description, type, front, back, inlay, this);

			if (box != null)
			{
				OnChildAdded(box);
			}

			return box;
		}

		private string name = null;
		private string description = null;
		[XmlIgnore]
		private List<Category> childCategories = null;
		[XmlIgnore]
		private List<Box> childCDBoxes = null;
		[XmlIgnore]
		private Category parent = null;
	}
}