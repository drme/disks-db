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

namespace DisksDB.DataBase
{
	/// <summary>
	/// Class For cheking files existance in database.
	/// </summary>
	public class DiskChecker
	{
		private DiskChecker()
		{
		}

		internal DiskChecker(IDBLayer idb)
		{
		}


//		/// <summary>
//		/// Cheks if all files in dataset exists in database
//		/// </summary>
//		/// <param name="dt">data table with filled files info</param>
//		/// <returns>does all files exists in database</returns>
//		public bool FindFiles(DataSetCDCatalog.DiskFilesDataTable dt)
//		{
//			if (null == dt)
//			{
//				return true;
//			}
//
//			bool ret = true;
//
//			foreach (DataSetCDCatalog.DiskFilesRow dr in dt.Rows)
//			{
//				if (true == FindFile(dr))
//				{
//					dr.FoundFile = "true";
//				}
//				else
//				{
//					ret = false;
//				}
//			}
//
//			return ret;
//		}
//
//		private bool FindFile(DataSetCDCatalog.DiskFilesRow dr)
//		{
//			try
//			{
//				SqlDataAdapter sqlDa = new SqlDataAdapter("FileExists", this.sqlCon);
//				sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
//				SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar, 1024);
//				SqlParameter p2 = new SqlParameter("@size", SqlDbType.BigInt);
//				p1.Value = dr.FileName;
//				p2.Value = dr.FileSize;
//				sqlDa.SelectCommand.Parameters.Add(p1);
//				sqlDa.SelectCommand.Parameters.Add(p2);
//
//				DataTable dt = new DataTable();
//				
//				sqlDa.Fill(dt);
//
//				if (dt.Rows.Count > 0)
//				{
//					return true;
//				}
//				else
//				{
//					return false;
//				}
//			}
//			catch (Exception ex)
//			{
//				System.Diagnostics.Debug.WriteLine(ex.Message);
//			}
//
//			return false;
//		}
//
//
//		public void FillFilesDataSet(DataSetCDCatalog.DiskFilesDataTable dt, string root)
//		{
//			try
//			{
//				ScanFiles(root, dt);
//			}
//			catch (Exception ex)
//			{
//				System.Diagnostics.Debug.WriteLine(ex.Message);
//			}
//		}
//
//		private void AddFile(FileInfo fi, DataSetCDCatalog.DiskFilesDataTable dt)
//		{
//			DataSetCDCatalog.DiskFilesRow dr = dt.NewDiskFilesRow();
//			dr.FileName = fi.Name;
//			dr.FileSize = (ulong)fi.Length;
//			dr.FileDate = fi.CreationTime;
//			dr.FoundFile = "false";
//			dr.FullPath = fi.FullName;
//			dt.Rows.Add(dr);
//		}
//
//		private void ScanFiles(string root, DataSetCDCatalog.DiskFilesDataTable dt)
//		{
//			ScanFiles(new DirectoryInfo(root), dt);
//		}
//
//		private void ScanFiles(DirectoryInfo di, DataSetCDCatalog.DiskFilesDataTable dt)
//		{
//			FileInfo[] fiArr = di.GetFiles();
//
//			foreach (FileInfo fi in fiArr)
//			{
//				AddFile(fi, dt);
//			}
//
//			DirectoryInfo[] diArr = di.GetDirectories();
//
//			foreach (DirectoryInfo dri in diArr)
//			{
//				ScanFiles(dri, dt);
//			}
//		}

	}
}
