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
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace DisksDB.Utils
{
	/// <summary>
	/// Summary description for SharedMemory.
	/// </summary>
	public class SharedMemory : IDisposable
	{
		public SharedMemory(bool create, string name, uint size)
		{
			if (true == create)
			{
				this.file = CreateFileMapping((IntPtr) (-1), IntPtr.Zero, PageProtection.ReadWrite, 0, size, name);
			}
			else
			{
				this.file = OpenFileMapping(983071, true, name);
			}

			this.pointer = MapViewOfFile(this.file, 983071, 0, 0, (UIntPtr) 0);
		}

		~SharedMemory()
		{
			Dispose();
		}

		public object Data
		{
			get
			{
				MemoryStream ms = new MemoryStream();

				long[] buf = new long[1];

				Marshal.Copy(this.pointer, buf, 0, 1);

				long len = buf[0];

				byte[] data = new byte[len];

				IntPtr p = new IntPtr(this.pointer.ToInt64() + 8);

				Marshal.Copy(p, data, 0, (int) len);

				BinaryWriter bw = new BinaryWriter(ms);

				bw.Write(data);

				ms.Seek(0, SeekOrigin.Begin);

				BinaryFormatter f = new BinaryFormatter();

				return f.Deserialize(ms);
			}
			set
			{
				BinaryFormatter f = new BinaryFormatter();

				MemoryStream ms1 = new MemoryStream();
				f.Serialize(ms1, value);

				MemoryStream ms = new MemoryStream();
				BinaryWriter bs = new BinaryWriter(ms);

				bs.Write(ms1.Length);

				f.Serialize(ms, value); //? bs.Write(ms1.GetBuffer());

				ms.Seek(0, SeekOrigin.Begin);

				BinaryReader reader = new BinaryReader(ms);

				byte[] data = reader.ReadBytes((int) ms.Length);

				Marshal.Copy(data, 0, this.pointer, data.Length);
			}
		}

		public void Dispose()
		{
			if (IntPtr.Zero != this.pointer)
			{
				CloseHandle(this.pointer);

				this.pointer = IntPtr.Zero;
			}

			if (IntPtr.Zero != this.file)
			{
				UnmapViewOfFile(this.file);

				this.file = IntPtr.Zero;
			}
		}

		[Flags]
		private enum PageProtection : uint
		{
			NoAccess = 0x01,
			Readonly = 0x02,
			ReadWrite = 0x04,
			WriteCopy = 0x08,
			Execute = 0x10,
			ExecuteRead = 0x20,
			ExecuteReadWrite = 0x40,
			ExecuteWriteCopy = 0x80,
			Guard = 0x100,
			NoCache = 0x200,
			WriteCombine = 0x400,
		}

		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpFileMappingAttributes, PageProtection flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, string lpName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenFileMapping(uint dwDesiredAccess, bool bInheritHandle, string lpName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, UIntPtr dwNumberOfBytesToMap);

		[DllImport("kernel32.dll")]
		internal static extern bool CloseHandle(IntPtr handle);

		[DllImport("kernel32.dll")]
		internal static extern bool UnmapViewOfFile(IntPtr map);

		private IntPtr file = IntPtr.Zero;
		private IntPtr pointer = IntPtr.Zero;
	}
}