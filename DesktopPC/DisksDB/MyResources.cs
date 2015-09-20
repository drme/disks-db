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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace DisksDB.UserInterface
{
	public class MyResources
	{
		public static Stream GetStream(String fileName)
		{
			return Assembly.GetExecutingAssembly().GetManifestResourceStream(nameSpaceName + fileName);
		}

        public static Bitmap GetBitmap(String fileName)
        {
			using (Stream stream = GetStream(fileName))
			{
				if (null != stream)
				{
					return new Bitmap(stream);
				}
				else
				{
					return new Bitmap(16, 16);
				}
			}
        }

        public static Icon GetIcon(String fileName)
        {
			using (Stream stream = GetStream(fileName))
			{
				if (null != stream)
				{
					return new Icon(stream);
				}
				else
				{
					return FileIcons.GetSystemIcon(0);
				}
			}
        }

		public static String GetText(String fileName)
		{
			using (Stream stream = GetStream(fileName))
			{
				using (StreamReader streamReader = new StreamReader(stream))
				{
					char[] buffer = new char[1024];

					int size = streamReader.Read(buffer, 0, 1024);

					StringBuilder stringBuilder = new StringBuilder();

					while (size > 0)
					{
						stringBuilder.Append(buffer, 0, size);

						size = streamReader.Read(buffer, 0, 1024);
					}

					return stringBuilder.ToString();
				}
			}
		}

		private const string nameSpaceName = "DisksDB.Resources.";
	}
}
