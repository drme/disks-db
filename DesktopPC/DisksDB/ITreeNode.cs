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
namespace DisksDB.UserInterface
{
	/// <summary>
	/// Tree Node interface in DiskView tree.
	/// Defines basic functionality for components in tree.
	/// </summary>
	interface ITreeNode : IListItem
	{
		/// <summary>
		/// Causes tree node to get its child nodes
		/// </summary>
		void LoadTreeNodeChilds();
	}
}
