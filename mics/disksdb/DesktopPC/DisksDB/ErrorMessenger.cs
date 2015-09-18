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
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for ErrorMessenger.
	/// </summary>
	public class ErrorMessenger
	{
		public static void ErrorMessage(IWin32Window parent, string message, Exception ex)
		{
			MessageBox.Show(parent, message + ((null != ex) ? ("\n" + ex.Message+"\n" + ex.StackTrace) : ""), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static DialogResult QuestionMessage(IWin32Window parent, string title, string message)
		{
			return MessageBox.Show(parent, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}
	}
}
