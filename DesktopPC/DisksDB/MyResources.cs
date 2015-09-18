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

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for MyResources.
	/// </summary>
	public class MyResources
	{
		public static System.IO.Stream GetStream(string fileName)
		{
			return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(nameSpaceName + fileName);
		}

        public static System.Drawing.Bitmap GetBitmap(string fileName)
        {
            System.IO.Stream s = GetStream(fileName);

            if (null != s)
            {
                return new System.Drawing.Bitmap(s);
            }
            else
            {
                return new System.Drawing.Bitmap(16, 16);
            }
        }

        public static System.Drawing.Icon GetIcon(string fileName)
        {
            System.IO.Stream s = GetStream(fileName);

            if (null != s)
            {
                return new System.Drawing.Icon(s);
            }
            else
            {
                return FileIcons.GetSystemIcon(0);
            }
        }

		public static string GetText(string fileName)
		{
			System.IO.Stream s = GetStream(fileName);
			System.IO.StreamReader sr = new System.IO.StreamReader(s);

			char[] buf = new char[1024];

			int size = sr.Read(buf, 0, 1024);

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			while (size > 0)
			{
				sb.Append(buf, 0, size);

				size = sr.Read(buf, 0, 1024);
			}

			return sb.ToString();
		}

		private static string nameSpaceName = "DisksDB.UserInterface.Resources.";
	}
}
