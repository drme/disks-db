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
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Interface for item in list view
	/// </summary>
	public interface IListItem
	{
		/// <summary>
		/// Gets icon id then lsit item is not selected
		/// </summary>
		/// <returns></returns>
		long GetIconId();

		/// <summary>
		/// Gets icon id then list item is selected
		/// </summary>
		/// <returns>icon id</returns>
		long GetSelectedIconId();

		/// <summary>
		/// Gets name of list item
		/// </summary>
		/// <returns>name</returns>
		string GetName();

		/// <summary>
		/// Gets size of list item
		/// </summary>
		/// <returns>size</returns>
		long GetSize();

		/// <summary>
		/// Gets date of creation of list item
		/// </summary>
		/// <returns>date of creation</returns>
		DateTime GetDate();

		/// <summary>
		/// Gets list item type
		/// </summary>
		/// <returns>type name</returns>
		string GetTypeName();

		/// <summary>
		/// Gets child nodes to display
		/// object impelenting IListItem interface in ArrayList
		/// </summary>
		IEnumerable ChildNodes
		{
			get;
		}

		bool IsDeleted();
		bool CanBeDeleted();
		bool CanBeRenamed();
		bool HasProperties();
		bool CanContainCategory();
		bool CanContainDisk();
		bool CanContainBox();
		bool CanContainImage();

		void CreateNewCategory();
		void CreateNewBox();
		void CreateNewDisk();
		void CreateNewImage();


	//	void Refresh();


		/// <summary>
		/// Invokes properties dialog window for specified item.
		/// </summary>
		void ShowProperties();

		/// <summary>
		/// Deletes specified item.
		/// </summary>
		void Delete();

		/// <summary>
		/// Renames specified item.
		/// </summary>
		/// <param name="name">new name</param>
		void Rename(string name);

		BaseObject GetBaseObject();

		void Refresh();

		void Open();
	}
}
