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
using System.Xml.Serialization;

namespace DisksDB.DataBase
{
	[Serializable()]
	public class BaseObject
	{
		public BaseObject(IDBLayer idb, long id)
		{
			this.idb = idb;
			this.id = id;
		}

		protected void CheckDeleted()
		{
			if (true == isDeleted)
			{
				throw new ObjectDeletedException();
			}
		}

		public long Id
		{
			get
			{
				return this.id;
			}
		}

		[XmlIgnore]
		public IDBLayer DataBase
		{
			get
			{
				return this.idb;
			}
		}

		public virtual void Delete()
		{
			this.isDeleted = true;
		}

		public bool IsDeleted
		{
			get
			{
				return this.isDeleted;
			}
		}

		protected void OnNameChanged()
		{
			if (null != this.NameChanged)
			{
				this.NameChanged(this, EventArgs.Empty);
			}
		}

		protected void OnChildsChanged()
		{
			if (null != this.ChildsChanged)
			{
				this.ChildsChanged(this, EventArgs.Empty);
			}
		}

		protected internal void OnChildAdded(BaseObject newItem)
		{
			if (null != this.ChildItemAdded)
			{
				this.ChildItemAdded(newItem);
			}

			OnChildsChanged();
		}

		protected internal void OnChildRemoved(BaseObject removedItem)
		{
			if (null != this.ChildItemRemoved)
			{
				this.ChildItemRemoved(removedItem);
			}

			OnChildsChanged();
		}

		internal virtual void Remove(BaseObject child)
		{
			OnChildRemoved(child);
		}

		public string GetXml()
		{
			//System.Runtime.Serialization.Formatters.Soap.SoapFormatter sf = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

			//System.IO.MemoryStream ms = new System.IO.MemoryStream();

			//sf.Serialize(ms, this);

			//return ms.ToString();

			return "<category name=\"" + "name" +  "\" id=\"" + this.id + "\" />";
		}
		
		[XmlIgnore]
		protected IDBLayer idb = null;
		protected bool isDeleted = false;
		protected long id = -1;
		public event EventHandler NameChanged;
		public event EventHandler ChildsChanged;
		public event EventHandlerItemAdded ChildItemAdded;
		public event EventHandlerItemRemoved ChildItemRemoved;
	}
}
