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

namespace DisksDB.Utils
{
	public class Logger
	{
		public static void LogException(Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex.Message);
			System.Diagnostics.Debug.WriteLine(ex.StackTrace);

			LogToFile(ex.Message);
			LogToFile(ex.StackTrace);
		}

		private static void LogToFile(string text)
		{
//			System.IO.FileStream fs = new System.IO.FileStream("C:/condump.txt", System.IO.FileMode.Append);
//
//			System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
//
//			bw.Write(text + "\n");
//
//			fs.Close();
		}
	}
}
