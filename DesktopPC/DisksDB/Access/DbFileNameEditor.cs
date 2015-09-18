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

namespace DisksDB.Access
{
	/// <summary>
	/// Summary description for DbFileNameEditor.
	/// </summary>
	public class DbFileNameEditor : System.Windows.Forms.Design.FileNameEditor
	{
		protected override void InitializeDialog(System.Windows.Forms.OpenFileDialog openFileDialog)
		{
			base.InitializeDialog(openFileDialog);

			openFileDialog.CheckFileExists = false;
			openFileDialog.Filter = "Microsoft Office Access (*.mdb)|*.mdb";
		}
	}
}
