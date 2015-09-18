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
using System.IO;
using System.Reflection;

namespace DisksDB.Utils
{
	public class Utils
	{
		public static void CreateFolders(string name)
		{
			if (name.Length < 2)
			{
				return;
			}

			string path = "";
			string sep = "\\";

			if ( (name[0] == '\\') && (name[1] == '\\') )
			{
				path = "\\\\";
				name = name.Substring(2);
			}
			else
			{
				sep = "/";
			}

			string[] folders = name.Split('\\', '/');

			for (int i = 0; i < folders.Length - 1; i++)
			{
				path += folders[i] + sep;

				if (false == Directory.Exists(path))
				{
					try
					{
						Directory.CreateDirectory(path);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		public static string UserApplicationFolder
		{
			get
			{
				return Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
			}
		}

		public static string ApplicationFolder
		{
			get
			{
				return Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
			}
		}

		public static string DataBaseLayersFolder
		{
			get
			{
				return ApplicationFolder;
			}
		}
	}
}
