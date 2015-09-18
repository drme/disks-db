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
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Generic item.
	/// </summary>
	public abstract class TreeNodeBase : TreeNode, ITreeNode
	{
		protected BaseObject baseObject;
		protected bool canBeDeleted;
		protected bool canBeRenamed;
		protected string typeName;
		protected long size;
		protected DateTime date;
		protected bool hasProperties;
		protected bool canContainDisk;
		protected bool canContainBox;
		protected bool canContainCategory;
		protected bool canContainImage;

		public TreeNodeBase(string name, BaseObject baseObject, bool canBeDeleted, bool canBeRenamed, string typeName, long size, DateTime date, bool hasProperties, bool canContainDisk, bool canContainBox, bool canContainCategory, bool canContainImage) : base(name)
		{
			Debug.Assert(null != baseObject);

			this.baseObject = baseObject;
			this.canBeDeleted = canBeDeleted;
			this.canBeRenamed = canBeRenamed;
			this.typeName = typeName;
			this.date = date;
			this.size = size;
			this.hasProperties = hasProperties;
			this.canContainBox = canContainBox;
			this.canContainDisk = canContainDisk;
			this.canContainCategory = canContainCategory;
			this.canContainImage = canContainImage;
		}

		public virtual long GetIconId()
		{
			return this.ImageIndex;
		}

		public virtual long GetSelectedIconId()
		{
			return this.SelectedImageIndex;
		}

		public virtual string GetName()
		{
			return base.Text;
		}

		public virtual long GetSize()
		{
			return this.size;
		}

		public virtual DateTime GetDate()
		{
			return this.date;
		}

		public virtual string GetTypeName()
		{
			return this.typeName;
		}

		public virtual IEnumerable ChildNodes
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsDeleted()
		{
			return this.baseObject.IsDeleted;
		}

		public virtual bool CanBeDeleted()
		{
			return this.canBeDeleted;
		}

		public virtual void Delete()
		{
			if (true == this.canBeDeleted)
			{
				throw new NotImplementedException();
			}
		}

		public virtual void Rename(string name)
		{
			throw new NotImplementedException();
		}

		public BaseObject GetBaseObject()
		{
			return this.baseObject;
		}

		public virtual void ShowProperties()
		{
			throw new NotImplementedException();
		}

		public abstract void LoadTreeNodeChilds();

		public virtual bool CanBeRenamed()
		{
			return this.canBeRenamed;
		}

		public virtual bool HasProperties()
		{
			return this.hasProperties;
		}

		public bool CanContainCategory()
		{
			return this.canContainCategory;
		}

		public bool CanContainDisk()
		{
			return this.canContainDisk;
		}

		public bool CanContainBox()
		{
			return this.canContainBox;
		}

		public virtual void CreateNewCategory()
		{
			throw new NotImplementedException();
		}

		public virtual void CreateNewBox()
		{
			throw new NotImplementedException();
		}

		public virtual void CreateNewDisk()
		{
			throw new NotImplementedException();
		}

		public virtual void Refresh()
		{
		}

		public virtual void Open()
		{
			if (null != this.TreeView)
			{
				this.TreeView.SelectedNode = this;
			}
		}

		public virtual void CreateNewImage()
		{
			throw new NotImplementedException();
		}

		public virtual bool CanContainImage()
		{
			return this.canContainImage;
		}
	}
}
