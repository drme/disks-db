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
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FileIcons.
	/// </summary>
	public class FileIcons
	{
		public FileIcons(ImageList imageList)
		{
			this.imageList = imageList;

			this.imageList.Images.Add(GetFolderIcon(null, true));
			this.imageList.Images.Add(GetFolderIcon(null, false));
			this.imageList.Images.Add(new Icon(MyResources.GetStream("dvdbox.ico")));

			LoadDVDIcon();
			LoadNoIcon();

			this.imageList.Images.Add(GetFileIcon(".bmp"));
		}

		public int GetFileIconId(string extension)
		{
			object id = this.hashTable[extension];

			if (null != id)
			{
				return (int)id;
			}

			return AddFileIconId(extension);
		}

		private int AddFileIconId(string extension)
		{
			System.Drawing.Icon icon = GetFileIcon(extension);

			this.imageList.Images.Add(icon);

			int id = this.imageList.Images.Count - 1;

			this.hashTable.Add(extension, id);

			return id;
		}

		private void LoadDVDIcon()
		{
			try
			{
			int indx = 113; // Windows XP, 2003 and so on DVD small icon index
			IntPtr[] iconPtrs = new IntPtr[1];

			int cnt = ExtractIconEx("shell32.dll", indx, null, iconPtrs, 1);

			if (cnt > 0)
			{
				Icon icon = (Icon)Icon.FromHandle(iconPtrs[0]).Clone();
				DestroyIcon(iconPtrs[0]);

				this.imageList.Images.Add(icon);
			} 
			else
			{
				this.imageList.Images.Add(new Icon(MyResources.GetStream("dvd.ico")));
			}
			}
			catch (Exception ex)
			{
				this.imageList.Images.Add(new Icon(MyResources.GetStream("dvd.ico")));
			}
		}

		private void LoadNoIcon()
		{
			try
			{
				int indx = 0; // Windows XP, 2003 and so on no icon index
				IntPtr[] iconPtrs = new IntPtr[1];

				int cnt = ExtractIconEx("shell32.dll", indx, null, iconPtrs, 1);

				if (cnt > 0)
				{
					Icon icon = (Icon)Icon.FromHandle(iconPtrs[0]).Clone();

					DestroyIcon(iconPtrs[0]);

					this.imageList.Images.Add(icon);
				} 
				else
				{
					this.imageList.Images.Add(new Icon(MyResources.GetStream("dvd.ico")));
				}
			}
			catch (Exception ex)
			{
				this.imageList.Images.Add(new Icon(MyResources.GetStream("dvd.ico")));
			}
		}

        public static Icon GetSystemIcon(int indx)
        {
            try
            {
                IntPtr[] iconPtrs = new IntPtr[1];

                int cnt = ExtractIconEx("shell32.dll", indx, null, iconPtrs, 1);

                if (cnt > 0)
                {
                    Icon icon = (Icon)Icon.FromHandle(iconPtrs[0]).Clone();

                    DestroyIcon(iconPtrs[0]);

                    return icon;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new Icon(MyResources.GetStream("dvdbox.ico"));
            }
        }

        public static Icon GetSystemIcon(int indx, bool large)
        {
            try
            {
                IntPtr[] iconPtrs = new IntPtr[1];

                int cnt = 0;

                if (large == true)
                {
                    cnt = ExtractIconEx("shell32.dll", indx, iconPtrs, null, 1);
                }
                else
                {
                    cnt = ExtractIconEx("shell32.dll", indx, null, iconPtrs, 1);
                }

                if (cnt > 0)
                {
                    Icon icon = (Icon)Icon.FromHandle(iconPtrs[0]).Clone();

                    DestroyIcon(iconPtrs[0]);

                    return icon;
                }
                else
                {
                    return new Icon(MyResources.GetStream("dvdbox.ico"));
                }
            }
            catch (Exception ex)
            {
                return new Icon(MyResources.GetStream("dvdbox.ico"));
            }
        }

		public static Icon GetFileIcon(string fileName)
		{
			try
			{
			SHFILEINFO psfi = new SHFILEINFO();

			IntPtr hImg = SHGetFileInfo(fileName, 0, ref psfi, (uint)Marshal.SizeOf(psfi), SHGFI_ICON | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES);

			Icon icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();

			DestroyIcon(psfi.hIcon);

			return icon;
			}
			catch (Exception ex)
			{
				return new Icon(MyResources.GetStream("dvdbox.ico"));
			}
		}

		public static Icon GetFolderIcon(string path, bool open, bool large)
		{
			try
			{
			SHFILEINFO psfi = new SHFILEINFO();

			uint flag = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;

			if (false == large)
			{
				flag |= SHGFI_SMALLICON;
			} 
			else
			{
				flag |= SHGFI_LARGEICON;
			}

			if (true == open)
			{
				flag |= SHGFI_OPENICON;
			}

			IntPtr hImg = SHGetFileInfo(path, FILE_ATTRIBUTE_DIRECTORY, ref psfi, (uint)Marshal.SizeOf(psfi), flag);

			Icon icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();

			DestroyIcon(psfi.hIcon);
			
			return icon;
			}
			catch (Exception ex)
			{
				return new Icon(MyResources.GetStream("dvdbox.ico"));
			}
		}

		public static Icon GetFolderIcon(string path, bool open)
		{
			try
			{
				SHFILEINFO psfi = new SHFILEINFO();

				uint flag = SHGFI_ICON | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES;

				if (true == open)
				{
					flag |= SHGFI_OPENICON;
				}

				IntPtr hImg = SHGetFileInfo(path, FILE_ATTRIBUTE_DIRECTORY, ref psfi, (uint)Marshal.SizeOf(psfi), flag);

				Icon icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();

				DestroyIcon(psfi.hIcon);
			
				return icon;
			}
			catch (Exception ex)
			{
				return new Icon(MyResources.GetStream("dvdbox.ico"));
			}
		}  

		[DllImport("Shell32", CharSet=CharSet.Auto)]
		private extern static int ExtractIconEx([MarshalAs(UnmanagedType.LPTStr)] string fileName, int inedx, IntPtr[] iconLarge, IntPtr[] iconSmall, int numIcons);

		[DllImport("Shell32")]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

		[DllImport("user32", CharSet=CharSet.Auto)]
		private extern static bool DestroyIcon(IntPtr icon);

		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO 
		{
			public IntPtr hIcon;
			public int iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		private const uint SHGFI_ICON = 0x100;
		private const uint SHGFI_SMALLICON = 0x1;
		private const uint SHGFI_LARGEICON = 0x0;
		private const uint SHGFI_USEFILEATTRIBUTES = 0x10;
		private const uint SHGFI_OPENICON = 0x2;
		private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
		private ImageList imageList = null;
		private Hashtable hashTable = new Hashtable();
	}
}
