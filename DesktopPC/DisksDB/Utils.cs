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
using System.IO;
using System.Drawing;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		public static string CleanUpName(string name)
		{
			return name.Replace(".jpg", "").Replace("_", " ").Replace("-front", "").Replace("-back", "").Replace("-cd", "").Replace("-", " ");
		}

        public static string GetExtension(string fileName)
        {
            for (int i = fileName.Length - 1; i >= 0; i--)
            {
                if ('.' == fileName[i])
                {
                    return fileName.Substring(i);
                }
            }

            return null;
        }

        public static void ExportImage(DataBase.Image img, System.Windows.Forms.IWin32Window parentWindow)
        {
            SaveFileDialog sf = new SaveFileDialog();

            if (DialogResult.OK == sf.ShowDialog(parentWindow))
            {
                string ext = ".jpg";  //GetExtension(img.FileName);

                if (null == ext)
                {
                    ext = ".png";
                }

                string fileName = sf.FileName + ext;

                img.Picture.Save(fileName);
            }
        }
	}
}
