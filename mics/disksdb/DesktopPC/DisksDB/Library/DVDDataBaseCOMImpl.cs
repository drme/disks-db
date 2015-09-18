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
/*
using System;
using System.Runtime.InteropServices;

namespace DisksDB.DataBase
{
	//[System.Runtime.InteropServices.LayoutKind.Sequential]
	public struct DBItem
	{
		public long Id;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;
		//[MarshalAs(UnmanagedType.
		//	 System.Runtime.InteropServices.UnmanagedType.ByValTStr,
		//	 SizeConst=conMAX_PATH)]
		public DateTime time;
	}


	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDVDDataBaseCOM
	{
		void TestME(long id);
	
		DBItem FindFirst();
		DBItem FindNext();
		void FindClose();
		DBItem GetItem(long id);
	}


	[ClassInterface(ClassInterfaceType.None)]
	public class DVDDataBaseCOM : IDVDDataBaseCOM
	{
		public DVDDataBaseCOM()
		{
			System.Windows.Forms.MessageBox.Show("INIT DVDDB");
		}

		public void TestME(long id)
		{
			System.Windows.Forms.MessageBox.Show("hwehwe " + id);
		}

		public DBItem FindFirst()
		{
			return null;

//			System.Diagnostics.Debug.WriteLine("FindFirst");
//
//			try
//			{
//				DataBase db = new DataBase();
//				this.ds = db.LowAccessLayer.GetCategories();
//			}
//			catch (Exception ex)
//			{
//				System.Diagnostics.Debug.WriteLine(ex.Message);
//			}
//
//			if (null == ds)
//			{
//				System.Windows.Forms.MessageBox.Show("NULL " + Environment.CurrentDirectory);
//			}
//
//			DBItem item;
//
//			this.pointer = 0;
//
//			item.Id = this.ds.Categories[this.pointer].id;
//			item.Name = this.ds.Categories[this.pointer].Name;
//			item.time = this.ds.Categories[this.pointer].LastUpdate;
//
//			System.Diagnostics.Debug.WriteLine("Name : " + item.Name);
//
//			this.pointer++;
//
//			return  item;
		}

		public DBItem GetItem(long id)
		{
			DBItem item;

			System.Data.DataRow r = this.ds.Categories.Rows.Find(id);

			DataSetSync.CategoriesRow dr = (DataSetSync.CategoriesRow)r;


			if (null != dr)
			{
				item.Id = dr.id;
				item.Name = dr.Name;
				item.time = dr.LastUpdate;
			} 
			else
			{
				item.Id = -1;
				item.Name = null;
				item.time = DateTime.Now;
			}

			return item;
		}

		public DBItem FindNext()
		{
			System.Windows.Forms.MessageBox.Show("FindNext");

			DBItem item = new DBItem();
			item.Id = -1;

			if (this.pointer >= this.ds.Categories.Rows.Count)
			{
				item.Id = -1;

				return item;
			} 
			else
			{
				item.Id = this.ds.Categories[this.pointer].id;
				item.Name = this.ds.Categories[this.pointer].Name;
				item.time = this.ds.Categories[this.pointer].LastUpdate;

				this.pointer++;

				return item;

			}


		}

		public void FindClose()
		{
			this.pointer = 0;
		}

		private DataSetSync ds = null;
		private int pointer = 0;
	}

//	public class DVDDataBaseItemCOMImpl : IDVDDataBaseItemCOM
//	{
//		public string GetName()
//		{
//			System.Windows.Forms.MessageBox.Show("ASDA");
//
//			return "aza";
//		}
//
//		public long GetId()
//		{
//			return 0;
//		}
//	}
}

*/