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
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DisksDB.DataBase;
using DisksDB.Utils;
using File = DisksDB.DataBase.File;

namespace DisksDB.Access
{
	/// <summary>
	/// Summary description for MsAccessDBLAyer.
	/// </summary>
	public class MsAccessDBLayer : IDBLayer
	{
		public MsAccessDBLayer()
		{
		}

        public void Start()
        {
            try
            {
                DBUtils.ExecSQL(this.DBConString, "INSERT INTO [ImageCategories] ([Name], [id], [ParentCategory]) VALUES('DVD Box', 6, 1)", new object[] { });
            }
            catch (Exception)
            {
            }
        }

		public bool IsNewDataBase()
		{
			string fileName = "";

			if (true == "".Equals(Path.GetDirectoryName(this.cfg.DataBaseFile)))
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

				fileName = path + "\\" + DisksDB.Config.Config.Instance.AppID + "\\" + this.cfg.DataBaseFile;
			}
			else
			{
				fileName = this.cfg.DataBaseFile;
			}

			return !System.IO.File.Exists(fileName);
		}

		public void ResetDataBase()
		{
			Stream rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("DisksDB.Access.Resources.initial.mdb");

			string fileName = "";

			if (true == "".Equals(Path.GetDirectoryName(this.cfg.DataBaseFile)))
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

				fileName = path + "\\" + DisksDB.Config.Config.Instance.AppID + "\\" + this.cfg.DataBaseFile;
			}
			else
			{
				fileName = this.cfg.DataBaseFile;
			}

			Utils.Utils.CreateFolders(fileName);

			FileStream fs = new FileStream(fileName, FileMode.Create);

			byte[] buffer = new byte[1024];

			int size = rs.Read(buffer, 0, 1024);

			while (size > 0)
			{
				fs.Write(buffer, 0, size);

				size = rs.Read(buffer, 0, 1024);
			}

			rs.Close();
			fs.Close();
		}

		public ArrayList GetInlayImages()
		{
			return GetImages(EnumImageCategories.InlayImage);
		}

		public void UpdateInlayImage(Image img, string name, string fileName, byte[] data)
		{
			UpdateImage(img, name, fileName, data);
		}

        public void UpdateDvdImage(Image img, string name, string fileName, byte[] data)
        {
            UpdateImage(img, name, fileName, data);
        }

		public byte[] LoadImage(Image img)
		{
			object o = DBUtils.ExecScalar(this.DBConString, "SELECT [Image] FROM [Images] WHERE [id] = ?", new object[] {img.Id});
			byte[] b = (byte[]) o;
			return b;
		}

		public Box AddCDBox(string name, string description, BoxType type, Image frontImage, Image backImage, Image inlayImage, Category cat)
		{
			int id = DBUtils.InsertSQL(this.DBConString, "INSERT INTO [CDBoxes] ([Description], [Name], [BackImage], [InlayImage], [Type], [FrontImage], [Category]) VALUES(?, ?, ?, ?, ?, ?, ?)", new object[] {description, name, backImage.Id, inlayImage.Id, type.Id, frontImage.Id, cat.Id});

			return new Box(name, description, id, backImage, inlayImage, type, frontImage, this, cat);
		}

		public void UpdateBackImage(Image img, string name, string fileName, byte[] data)
		{
			UpdateImage(img, name, fileName, data);
		}

		public void UpdateDiskImage(Image img, string name, string fileName, byte[] data)
		{
			UpdateImage(img, name, fileName, data);
		}

		public DataSetSearch FindFile(string fileName, bool useMinSize, bool userMaxSize, bool useEquals, long minSize, long maxSize, long size)
		{
			/**
			 * Microsoft Access is unable to store 64-bit integers.
			 * To work around this problem they are stored as strings.
			 * This particularly was applied to file size attribute.
			 */

			try
			{
				string sql = "SELECT [Files].[Date] AS [FileDate], [Files].[Name] AS [FileName], [Files].[Size], [Disks].[Name] AS [Disk], [CDBoxes].[Name] AS [Box], [Categories].[name] AS [Category], [Categories].[id] AS [CategoryId], [CDBoxes].[id] AS [BoxId], [Disks].[id] AS [DiskID], [Files].[Parent] AS [FileParentId] " +
					" FROM [Categories] INNER JOIN ([CDBoxes] INNER JOIN ([Disks] INNER JOIN [Files] ON [Disks].[id] = [Files].[Disk]) ON [CDBoxes].[id] = [Disks].[CDBox]) ON [Categories].[id] = [CDBoxes].[Category] " +
					"WHERE " +
					"([Files].[Name] LIKE '" + fileName.Replace("'", "''").Replace("*", "%") + "') ";

				if (true == useEquals)
				{
					sql += " AND [Files].[Size] = '" + size + "'";
				}

				OleDbDataAdapter da = new OleDbDataAdapter(sql, new OleDbConnection(this.DBConString));

				DataSetSearch ds = new DataSetSearch();

				da.Fill(ds.Files);

				/**
				 * Lame solution. But what to do?
				 */
				if (true == useMinSize)
				{
					foreach (DataSetSearch.FilesRow dr in ds.Files.Rows)
					{
						if (dr.Size < minSize)
						{
							dr.Delete();
						}
					}

					ds.AcceptChanges();
				}

				if (true == userMaxSize)
				{
					foreach (DataSetSearch.FilesRow dr in ds.Files.Rows)
					{
						if (dr.Size > maxSize)
						{
							dr.Delete();
						}
					}

					ds.AcceptChanges();
				}

				return ds;
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
			finally
			{
			}

			return null;
		}

		public ArrayList GetChildCategories(Category parentCat)
		{
			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT Name, id, Description FROM Categories WHERE Parent = ? ORDER BY Name", new object[] {parentCat.Id});

			ArrayList lst = new ArrayList();

			while (true == myReader.Read())
			{
				Category cat = new Category((string) myReader["Name"], (myReader["Description"] is DBNull) ? "" : (string) myReader["Description"], (int) myReader["id"], this, parentCat);

				lst.Add(cat);
			}

			myReader.Close();

			return lst;
		}

		public ArrayList GetBackImages()
		{
			return GetImages(EnumImageCategories.BackImage);
		}

		public void DeleteDisk(Disk d)
		{
			DBUtils.ExecSQL(this.DBConString, "DELETE FROM [Disks] WHERE [id]= ?", new object[] {d.Id});
		}

		public ArrayList GetFiles(File file)
		{
			ArrayList lst = new ArrayList();

			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT [id], [Name], [Size], [Date], [Attributes], [Parent], [Disk] FROM [Files] WHERE ([Parent] = ?) ORDER BY [Attributes] DESC, [Name] ASC", new object[] {file.Id});

			while (true == myReader.Read())
			{
				string attr = myReader[4].ToString();
				File f = new File(this, (int) (myReader[0]), (string) (myReader[1]), long.Parse(myReader[2].ToString()), DateTime.Parse(myReader[3].ToString()), int.Parse(attr));
				lst.Add(f);
			}

			myReader.Close();

			return lst;
		}

		public ArrayList GetFiles(Disk disk)
		{
			ArrayList lst = new ArrayList();

			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT [id], [Name], [Size], [Date], [Attributes], [Parent], [Disk] FROM [Files] WHERE ([Disk] = ?) AND ([Parent] IS NULL) ORDER BY [Attributes] DESC, [Name] ASC", new object[] {disk.Id});

			while (true == myReader.Read())
			{
				string attr = myReader[4].ToString();
				File f = new File(this, (int) (myReader[0]), (string) (myReader[1]), long.Parse(myReader[2].ToString()), DateTime.Parse(myReader[3].ToString()), int.Parse(attr));
				lst.Add(f);
			}

			myReader.Close();

			return lst;
		}

		public Disk AddDisk(string name, DiskType type, Image image, Box box, string driveLetter, IAddDiskProgress prog, bool addFiles)
		{
			try
			{
				long files = 0;

				if (true == addFiles)
				{
					AddFolder(driveLetter, prog, true, ref files, true, null, 0, 0);
				}

				prog.Total(files);

				OleDbConnection sqlCon = new OleDbConnection(this.DBConString);
				sqlCon.Open();
				OleDbTransaction sqlTran = sqlCon.BeginTransaction();

				OleDbCommand sqlCmd = new OleDbCommand("INSERT INTO [Disks] ([DiskImage], [CDBox], [Name], [Type], [Description]) VALUES(?, ?, ?, ?, ?)", sqlCon, sqlTran);

				sqlCmd.Parameters.AddWithValue("@image", image.Id);
                sqlCmd.Parameters.AddWithValue("@box", box.Id);
                sqlCmd.Parameters.AddWithValue("@name", name);
                sqlCmd.Parameters.AddWithValue("@type", type.Id);
                sqlCmd.Parameters.AddWithValue("@desc", "/* TBD */");

				sqlCmd.ExecuteNonQuery();

				OleDbCommand oleCmdIdentity = new OleDbCommand("SELECT @@IDENTITY", sqlCon, sqlTran);

				int rez = (int) oleCmdIdentity.ExecuteScalar();


				if (true == addFiles)
				{
					long diskId = rez;

					files = 0;

					prog.Started();

					AddFolder(driveLetter, prog, true, ref files, false, sqlTran, -1, diskId);
				}

				sqlTran.Commit();
				prog.Finished();

				return new Disk(this, rez, name, image, type, box);
			}
			catch (Exception ex)
			{
				prog.Failed(ex.Message);
			}

			return null;
		}

        public Image AddBackImage(string name, string fileName, byte[] data)
        {
            return AddImage(EnumImageCategories.BackImage, name, fileName, data, EnumImageCategories.BackImage);
        }

        public Image AddDvdImage(string name, string fileName, byte[] data)
        {
            return AddImage(EnumImageCategories.DvdImage, name, fileName, data, EnumImageCategories.BackImage);
        }

		public ArrayList GetDisks(Box box)
		{
			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT [id], [DiskImage], [CDBox], [Name], [Type] FROM [Disks] WHERE [CDBox] = ? ORDER BY [Name]", new object[] {box.Id});

			ArrayList lst = new ArrayList();

			while (true == myReader.Read())
			{
				Disk d = new Disk(this, (int) (myReader[0]), (string) (myReader[3]),
				                  db.DiskImages.GetImage((int) myReader[1]),
				                  GetDiskType((int) myReader[4]), box);
				lst.Add(d);
			}

			myReader.Close();

			return lst;
		}

		public Category AddCategory(string name, string description, Category parent)
		{
			int id = DBUtils.InsertSQL(this.DBConString, "INSERT INTO Categories (Name, Parent, Description) VALUES(?, ?, ?)", new object[] {name, parent.Id, description});

			return new Category(name, description, id, this, parent);
		}

		public void DeleteCategory(Category category)
		{
			foreach (Category c in category.ChildCategories)
			{
				DeleteCategory(c);
			}

			DBUtils.DeleteSQL(this.DBConString, "DELETE FROM Categories WHERE id = ?", new object[] {category.Id});
		}

		public ArrayList GetDiskTypes()
		{
			OleDbDataReader r = DBUtils.ExecSQL(this.DBConString, "SELECT id, Name FROM CDTypes ORDER BY Name", null);

			ArrayList a = new ArrayList();

			while (r.Read())
			{
				a.Add(new DiskType((int) r["id"], (string) r["Name"]));
			}

			r.Close();

			return a;
		}

		public void DeleteBackImage(Image img)
		{
			DeleteImage(img.Id);
		}

        public ArrayList GetFrontImages()
        {
            return GetImages(EnumImageCategories.FrontImage);
        }

        public ArrayList GetDvdImages()
        {
            return GetImages(EnumImageCategories.DvdImage);
        }

        public void DeleteDiskImage(Image img)
        {
            DeleteImage(img.Id);
        }

        public void DeleteDvdImage(Image img)
        {
            DeleteImage(img.Id);
        }

		public void UpdateCategory(Category category, string newName, string newDescription, Category newParent)
		{
			DBUtils.UpdateSQL(this.DBConString, "UPDATE Categories SET Name = ?, Description = ?, Parent = ?, LastUpdate = NOW WHERE id = ?", new object[] {newName, newDescription, newParent.Id, category.Id});
		}

		public void DeleteFrontImage(Image img)
		{
			DeleteImage(img.Id);
		}

		public Image AddInlayImage(string name, string fileName, byte[] data)
		{
			return AddImage(EnumImageCategories.InlayImage, name, fileName, data, EnumImageCategories.InlayImage);
		}

		public Image AddFrontImage(string name, string fileName, byte[] data)
		{
			return AddImage(EnumImageCategories.FrontImage, name, fileName, data, EnumImageCategories.FrontImage);
		}

		public DataBase.DataBase DataBase
		{
			set { this.db = value; }
		}

		public ArrayList GetDiskImages()
		{
			return GetImages(EnumImageCategories.DiskImage);
		}

		public void DeleteCDBox(Box box)
		{
			DBUtils.DeleteSQL(this.DBConString, "DELETE FROM [CDBoxes] WHERE [id] = ?", new object[] {box.Id});
		}

		public ArrayList GetChildCDBoxes(Category parentCat)
		{
			ArrayList lst = new ArrayList();

			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT [id], [Description], [Name], [BackImage], [InlayImage], [Type], [FrontImage] FROM [CDBoxes] WHERE [Category] = ? ORDER BY [Name]", new object[] {parentCat.Id});

			while (true == myReader.Read())
			{
				Box box = new Box((string) (myReader["Name"]), (string) (myReader["Description"]),
				                  (int) (myReader["id"]),
				                  db.BackImages.GetImage((int) myReader["BackImage"]),
				                  db.InlayImages.GetImage((int) myReader["InlayImage"]),
				                  GetCDBoxType((int) myReader["Type"]),
				                  db.FrontImages.GetImage((int) myReader["FrontImage"]),
				                  this, parentCat);
				lst.Add(box);
			}

			myReader.Close();

			return lst;
		}

		public ArrayList GetCDBoxTypes()
		{
			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT [id], [Name] FROM [CDCaseTypes] ORDER BY [Name]", null);

			ArrayList lst = new ArrayList();

			while (true == myReader.Read())
			{
				lst.Add(new BoxType((int) myReader["id"], (string) myReader["Name"]));
			}

			myReader.Close();

			return lst;
		}

		public Category GetRootCategory()
		{
			Category cat = null;

			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT Name, id, Description FROM Categories WHERE Parent IS NULL", null);

			if (true == myReader.Read())
			{
				cat = new Category((string) myReader["Name"], (string) myReader["Description"], (int) myReader["id"], this, null);
			}

			myReader.Close();

			return cat;
		}

		public void UpdateCDBox(Box box, string newName, string newDescription, Image newBack, Image newFront, Image newInlay, BoxType newType, Category newParent)
		{
			DBUtils.UpdateSQL(this.DBConString, "UPDATE [CDBoxes] SET [Description] = ?, [Name] = ?, [BackImage] = ?, [InlayImage] = ?, [Type] = ?,  [FrontImage] = ?, [Category]	= ?, [LastUpdate] = NOW() WHERE [id] = ?", new object[] {newDescription, newName, newBack.Id, newInlay.Id, newType.Id, newFront.Id, newParent.Id, box.Id});
		}

		public void UpdateDisk(Disk disk, string name, DiskType type, Image image, Box box)
		{
			DBUtils.UpdateSQL(this.DBConString, "UPDATE [Disks] SET [DiskImage] = ?, [Name] = ?, [Type] = ?, [CDBox] = ?, [LastUpdate] = NOW() WHERE [id] = ?", new object[] {image.Id, name, type.Id, box.Id, disk.Id});
		}

		public void UpdateFrontImage(Image img, string name, string fileName, byte[] data)
		{
			UpdateImage(img, name, fileName, data);
		}

		public void DeleteInlayImage(Image img)
		{
			DeleteImage(img.Id);
		}

		public Image AddDiskImage(string name, string fileName, byte[] data)
		{
			return AddImage(EnumImageCategories.DiskImage, name, fileName, data, EnumImageCategories.DiskImage);
		}

		public string Name
		{
			get { return "Microsoft Access Data Base"; }
		}

		public object ConfigObject
		{
			get { return this.cfg; }
		}

		private Image AddImage(EnumImageCategories category, string name, string fileName, byte[] data, EnumImageCategories imageType)
		{
			byte[] buffer = data;

			if (null != fileName)
			{
				if (null == buffer)
				{
					FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
					buffer = new byte[stream.Length];
					stream.Read(buffer, 0, (int) stream.Length);
					stream.Close();
				}
			}


			int id = DBUtils.InsertSQL(this.DBConString, "INSERT INTO Images ([FileName], [Image], [Name], [ImageCategory]) VALUES(?, ?, ?, ?)", new object[] {fileName, buffer, name, category});

			return new Image(this, id, name, id, buffer, imageType, true);
		}

		private ArrayList GetImages(EnumImageCategories category)
		{
			ArrayList a = new ArrayList();

			OleDbDataReader myReader = DBUtils.ExecSQL(this.DBConString, "SELECT [id], [FileName], [Name], [Deleteable] FROM [Images] WHERE ([ImageCategory] = ?) ORDER BY [Name]", new object[] {category});

			while (true == myReader.Read())
			{
				Image img = null;

				try
				{
					img = new Image(this, (int) myReader["id"], (string) myReader["Name"], (int) myReader["id"], category, (bool) myReader["Deleteable"]);
				}
				catch (Exception)
				{
					img = new Image(this, (int) myReader["id"], (string) myReader["name"], -1, category, (bool) myReader["Deleteable"]);
				}

				a.Add(img);
			}

			myReader.Close();

			return a;
		}

		private void DeleteImage(long id)
		{
			DBUtils.DeleteSQL(this.DBConString, "DELETE FROM [Images] WHERE [id] = ?", new object[] {id});
		}

		private void UpdateImage(Image img, string name, string fileName, byte[] data)
		{
			byte[] buffer = data;

			if (null != fileName)
			{
				if (null == buffer)
				{
					FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
					buffer = new byte[stream.Length];
					stream.Read(buffer, 0, (int) stream.Length);
					stream.Close();
				}
			}
			else
			{
				buffer = null;
			}

			if (null == fileName)
			{
				fileName = "";
			}

			if (null != buffer)
			{
				DBUtils.UpdateSQL(this.DBConString, "UPDATE [Images] SET [Image] = ? WHERE [id] = ?", new object[] {buffer, img.Id});
			}

			if (null != fileName)
			{
				DBUtils.UpdateSQL(this.DBConString, "UPDATE [Images] SET [FileName] = ? WHERE [id] = ?", new object[] {fileName, img.Id});
			}

			if (null != fileName)
			{
				DBUtils.UpdateSQL(this.DBConString, "UPDATE [Images] SET [Name] = ? WHERE [id] = ?", new object[] {name, img.Id});
			}
		}

		private BoxType GetCDBoxType(long id)
		{
			foreach (BoxType t in GetCDBoxTypes())
			{
				if (t.Id == id)
				{
					return t;
				}
			}

			throw new Exception("CD Box Type not found");
		}

		private void AddFolder(string root, IAddDiskProgress p, bool isRoot, ref long files, bool count, OleDbTransaction sqlTran, long parent, long track)
		{
			DirectoryInfo di = new DirectoryInfo(root);

			if (false == isRoot)
			{
				if (false == count)
				{
					parent = AddFolder(track, parent, di, sqlTran);
				}
			}
			else
			{
				parent = -1;
			}

			FileInfo[] fiArr = di.GetFiles();

			if (true == count)
			{
				files += fiArr.Length;
			}
			else
			{
				foreach (FileInfo fi in fiArr)
				{
					AddFile(track, parent, fi, sqlTran);
					files += 1;
					p.Progress(files);
				}
			}

			DirectoryInfo[] diArr = di.GetDirectories();

			foreach (DirectoryInfo dri in diArr)
			{
				if (true == count)
				{
					files++;
					AddFolder(root + "/" + dri.Name, p, false, ref files, true, null, 0, 0);
				}
				else
				{
					AddFolder(root + "/" + dri.Name, p, false, ref files, false, sqlTran, parent, track);
					files += 1;
					p.Progress(files);
				}
			}
		}

		private long AddFolder(long diskId, long parentId, DirectoryInfo fi, OleDbTransaction sqlTran)
		{
			try
			{
				OleDbCommand cmd = null;

				if (-1 != parentId)
				{
					cmd = new OleDbCommand("INSERT INTO [Files] ([Name], [Size], [Date], [Attributes], [Disk], [Parent]) VALUES(?, 0, ?, ?, ?, ?)", sqlTran.Connection, sqlTran);
				}
				else
				{
					cmd = new OleDbCommand("INSERT INTO [Files] ([Name], [Size], [Date], [Attributes], [Disk]) VALUES(?, 0, ?, ?, ?)", sqlTran.Connection, sqlTran);
				}

                cmd.Parameters.AddWithValue("@name", fi.Name);
                cmd.Parameters.AddWithValue("@dat", OleDbType.Date);
                cmd.Parameters.Add("@attributes", OleDbType.BigInt, 8);
                cmd.Parameters.AddWithValue("@disk", diskId);

				try
				{
					cmd.Parameters[1].Value = fi.CreationTime;
				}
				catch (Exception)
				{
					cmd.Parameters[1].Value = DateTime.Now;
				}

				cmd.Parameters[2].Value = 1;

				if (-1 != parentId)
				{
                    cmd.Parameters.AddWithValue("@parent", parentId);
				}

				cmd.ExecuteNonQuery();

				OleDbCommand oleCmdIdentity = new OleDbCommand("SELECT @@IDENTITY", sqlTran.Connection, sqlTran);

				int rez = (int) oleCmdIdentity.ExecuteScalar();

				return rez;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
		}

		private void AddFile(long diskId, long parentId, FileInfo fi, OleDbTransaction sqlTran)
		{
			try
			{
				OleDbCommand cmd = null;

				if (-1 != parentId)
				{
					cmd = new OleDbCommand("INSERT INTO [Files] ([Name], [Size], [Date], [Attributes], [Disk], [Parent]) VALUES(?, ?, ?, ?, ?, ?)", sqlTran.Connection, sqlTran);
				}
				else
				{
					cmd = new OleDbCommand("INSERT INTO [Files] ([Name], [Size], [Date], [Attributes], [Disk]) VALUES(?, ?, ?, ?, ?)", sqlTran.Connection, sqlTran);
				}

                cmd.Parameters.AddWithValue("@name", fi.Name);
                cmd.Parameters.AddWithValue("@siz", fi.Length);
                cmd.Parameters.AddWithValue("@dat", OleDbType.Date);
				cmd.Parameters.Add("@attributes", OleDbType.BigInt, 8);
                cmd.Parameters.AddWithValue("@disk", diskId);

				try
				{
					cmd.Parameters[2].Value = fi.CreationTime;
				}
				catch (Exception)
				{
					cmd.Parameters[2].Value = DateTime.Now;
				}

				cmd.Parameters[3].Value = 0;

				if (-1 != parentId)
				{
                    cmd.Parameters.AddWithValue("@parent", parentId);
				}

				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				throw;
			}
		}

		private DiskType GetDiskType(long id)
		{
			foreach (DiskType t in GetDiskTypes())
			{
				if (t.Id == id)
				{
					return t;
				}
			}

			throw new Exception("Disk Type not found");
		}

		private string DBConString
		{
			get
			{
				string fileName = "";

				if (true == "".Equals(Path.GetDirectoryName(this.cfg.DataBaseFile)))
				{
					string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

					fileName = path + "\\" + DisksDB.Config.Config.Instance.AppID + "\\" + this.cfg.DataBaseFile;
				}
				else
				{
					fileName = this.cfg.DataBaseFile;
				}

				return "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=\"" + fileName + "\";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=\"Microsoft.Jet.OLEDB.4.0\";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		public DataSetSync GetCategoriesChanges(DateTime timeStamp, long[] pdaCategories)
		{
			/// Flag Values:
			/// 0 - New
			/// 1 - Updated
			/// 2 - Deleted

			try
			{
				string inPart = "";

				if ((null != pdaCategories) && (pdaCategories.Length > 0))
				{
					inPart += "(" + pdaCategories[0];

					for (int i = 1; i < pdaCategories.Length; i++)
					{
						inPart += ", " + pdaCategories[i];
					}

					inPart += ")";
				}

				DataSetSync ds = new DataSetSync();

				string sql = null;

				if (false == string.Empty.Equals(inPart))
				{
					sql = "SELECT [id], [Name], [Description], [Parent], 1 AS [Flag] FROM [Categories] WHERE DATEDIFF(\"s\",  [LastUpdate], '" + timeStamp.ToString("dd/MM/yyyy hh:mm:ss") + "') < 0";

					sql += " AND [id] IN " + inPart;

					DBUtils.FillDataTable(ds.Categories, this.DBConString, sql, new object[] {});
				}

				sql = "SELECT [id], [Name], [Description], [Parent], 0 AS [Flag] FROM [Categories]";

				if (false == string.Empty.Equals(inPart))
				{
					sql += " WHERE [id] NOT IN " + inPart;
				}

				DBUtils.FillDataTable(ds.Categories, this.DBConString, sql, new object[] {});

				sql = "SELECT [id] FROM [Categories]";

				if (false == string.Empty.Equals(inPart))
				{
					sql += " WHERE [id] IN " + inPart;
				}

				if ((null != pdaCategories) && (pdaCategories.Length > 0))
				{
					DataSetTemp dsTemp = new DataSetTemp();

					DBUtils.FillDataTable(dsTemp.Temp, this.DBConString, sql, new object[] {});

					foreach (int id in pdaCategories)
					{
						if (null == dsTemp.Temp.Rows.Find(id))
						{
							DataSetSync.CategoriesRow drDeleted = ds.Categories.NewCategoriesRow();
							drDeleted.Flag = 2;
							drDeleted.id = id;
							ds.Categories.AddCategoriesRow(drDeleted);
						}
					}
				}

				return ds;
			}
			catch (OleDbException ex)
			{
				MessageBox.Show(ex.Message);

				return null;
			}
		}

		public void FillChanges(DateTime timeStamp, long[] existingIds, DataTable dtToFill, string fields, string table, long fromId, long toId)
		{
			/// Flag Values:
			/// 0 - New
			/// 1 - Updated
			/// 2 - Deleted

			try
			{
				string inPart = "";

				if ((null != existingIds) && (existingIds.Length > 0))
				{
					inPart += "(" + existingIds[0];

					for (int i = 1; i < existingIds.Length; i++)
					{
						inPart += ", " + existingIds[i];
					}

					inPart += ")";
				}

				string sql = null;

				string idBetween = "[id] >= " + fromId;

				if (toId != -1)
				{
					idBetween += " AND [id] <= " + toId;
				}

				if (false == string.Empty.Equals(inPart))
				{
					sql = "SELECT " + fields + ", 1 AS [Flag] FROM " + table + " WHERE " + idBetween + " AND DATEDIFF(\"s\",  [LastUpdate], '" + timeStamp.ToString("dd/MM/yyyy hh:mm:ss") + "') < 0";

					sql += " AND [id] IN " + inPart;

					sql += " ORDER BY [id]";

					DBUtils.FillDataTable(dtToFill, this.DBConString, sql, new object[] {});
				}

				sql = "SELECT " + fields + ", 0 AS [Flag] FROM " + table + " WHERE " + idBetween;

				if (false == string.Empty.Equals(inPart))
				{
					sql += " AND [id] NOT IN " + inPart;
				}

				sql += " ORDER BY [id]";

				DBUtils.FillDataTable(dtToFill, this.DBConString, sql, new object[] {});

				sql = "SELECT [id] FROM " + table + " WHERE " + idBetween;

				if (false == string.Empty.Equals(inPart))
				{
					sql += " AND [id] IN " + inPart;
				}

				if ((null != existingIds) && (existingIds.Length > 0))
				{
					DataSetTemp dsTemp = new DataSetTemp();

					DBUtils.FillDataTable(dsTemp.Temp, this.DBConString, sql, new object[] {});

					foreach (int id in existingIds)
					{
						if (null == dsTemp.Temp.Rows.Find(id))
						{
							DataRow drDeleted = dtToFill.NewRow();
							drDeleted["Flag"] = 2;
							drDeleted["id"] = id;
							dtToFill.Rows.Add(drDeleted);
						}
					}
				}
			}
			catch (OleDbException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public DataSetSync GetBoxesChanges(DateTime timeStamp, long[] pdaBoxes)
		{
			DataSetSync ds = new DataSetSync();

			FillChanges(timeStamp, pdaBoxes, ds.Boxes, "[id], [Name], [Description], [Category]", "[CDBoxes]", 0, -1);

			return ds;
		}

		public DataSetSync GetDisksChanges(DateTime timeStamp, long[] pdaDisks)
		{
			DataSetSync ds = new DataSetSync();

			FillChanges(timeStamp, pdaDisks, ds.Disks, "[id], [Name], [Description], [CDBox] AS [Box]", "[Disks]", 0, -1);

			return ds;
		}

		public DataSetSync GetFilesChanges(DateTime timeStamp, long[] pdaFiles, long fromId, long toId)
		{
			DataSetSync ds = new DataSetSync();

			FillChanges(timeStamp, pdaFiles, ds.Files, "[id], [Name], [Size], [Date], [Parent], [Disk], [Attributes]", "[Files]", fromId, toId);

			return ds;
		}

		public long GetMaxCategories()
		{
			try
			{
				return (int) DBUtils.ExecScalar(this.DBConString, "SELECT MAX([id]) FROM [Categories]", null);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public long GetMaxBoxes()
		{
			try
			{
				return (int) DBUtils.ExecScalar(this.DBConString, "SELECT MAX([id]) FROM [CDBoxes]", null);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public long GetMaxDisks()
		{
			try
			{
				return (int) DBUtils.ExecScalar(this.DBConString, "SELECT MAX([id]) FROM [Disks]", null);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public long GetMaxFiles()
		{
			try
			{
				return (int) DBUtils.ExecScalar(this.DBConString, "SELECT MAX([id]) FROM [Files]", null);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public DataSetSync GetCategories()
		{
			Console.WriteLine("GET CAT");


//			System.Windows.Forms.MessageBox.Show("GET CAT");

			DataSetSync ds = new DataSetSync();


			try
			{
				DBUtils.FillDataTable(ds.Categories, this.DBConString, "SELECT [id], [Name], [Parent], [LastUpdate] FROM [Categories]", new object[] {});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return ds;
		}

		public DataSetSync GetFiles(long diskId)
		{
			DataSetSync ds = new DataSetSync();

			DBUtils.FillDataTable(ds.Files, this.DBConString, "SELECT [id], [Name], [Size], [Date], [Parent], [Attributes] FROM [Files] WHERE [Disk] = " + diskId, new object[] {});

			return ds;
		}

		public long AddFile(string name, DateTime date, long size, long diskId, long parentId, long attributes, object transaction)
		{
			int id = 0;

			if (-1 != parentId)
			{
				id = DBUtils.InsertSQL(this.DBConString, "INSERT INTO [Files] ([Name], [Size], [Date], [Attributes], [Disk], [Parent]) VALUES(?, ?, ?, ?, ?, ?)", new object[] {name, size, date, attributes, diskId});
			}
			else
			{
				id = DBUtils.InsertSQL(this.DBConString, "INSERT INTO [Files] ([Name], [Size], [Date], [Attributes], [Disk]) VALUES(?, ?, ?, ?, ?)", new object[] {name, size, date, attributes, diskId, parentId});
			}

			return id;
		}

		public long GetFilesCount(long diskId)
		{
			return (int) DBUtils.ExecScalar(this.DBConString, "SELECT COUNT(id) FROM [Files] WHERE [Disk] = " + diskId, new object[] {});
		}

		public object BeginFilesAdd()
		{
			return null;
		}

		public void EndFilesAdd(object transaction, bool commit)
		{
		}

		public long GetDisksCount()
		{
			return (int) DBUtils.ExecScalar(this.DBConString, "SELECT COUNT(id) FROM [Disks]", new object[] {});
		}

		public string GetDataBaseId()
		{
			object uid = DBUtils.ExecScalar(this.DBConString, "SELECT TOP 1 [DataBaseGUID] FROM [Settings]", new object[] {});


			if (null != uid)
			{
				return (string) uid;
			}
			else
			{
				string id = Guid.NewGuid().ToString();

				DBUtils.UpdateSQL(this.DBConString, "INSERT INTO [Settings] (DataBaseGUID) VALUES(?)", new object[] {id});

				return id;
			}
		}

        public void SaveConfig(DisksDB.Config.Config cfg)
        {
            cfg.SetValue(this.Name + ".DataBaseFile", this.cfg.DataBaseFile);
        }

        public void LoadConfig(DisksDB.Config.Config cfg)
        {
            this.cfg.DataBaseFile = cfg.GetValue(this.Name + ".DataBaseFile");
        }

        private AccessConfig cfg = new AccessConfig();
		private DataBase.DataBase db = null;
	}
}