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

namespace DisksDB.DataBase
{
	/// <summary>
	/// Empty implementation
	/// </summary>
	internal class EmptyLayer : IDBLayer
	{
		public Category GetRootCategory()
		{
			return null;
		}

        public void Start()
        {
        }

		public void UpdateCategory(Category category, string newName, string newDescription, Category newParent)
		{
		}

		public void DeleteCategory(Category category)
		{
		}

		public ArrayList GetChildCategories(Category parentCat)
		{
			return null;
		}

		public ArrayList GetChildCDBoxes(Category parentCat)
		{
			return null;
		}

		public Category AddCategory(string name, string description, Category cat)
		{
			return null;
		}

		public Box AddCDBox(string name, string description, BoxType type, Image frontImage, Image backImage, Image inlayImage, Category cat)
		{
			return null;
		}

		public Disk AddDisk(string name, DiskType type, Image image, Box box, string driveLetter, IAddDiskProgress prog, bool addFiles)
		{
			return null;
		}

		public void UpdateDisk(Disk disk, string name, DiskType type, Image image, Box box)
		{
		}

		public void DeleteDisk(Disk d)
		{
		}

		public void DeleteCDBox(Box box)
		{
		}

		public void UpdateCDBox(Box box, string newName, string newDescription, Image newBack, Image newFront, Image newInlay, BoxType newType, Category newParent)
		{
		}

		public ArrayList GetCDBoxTypes()
		{
			return null;
		}

		public ArrayList GetDiskTypes()
		{
			return null;
		}

		public byte[] LoadImage(Image img)
		{
			return null;
		}

		public void DeleteFrontImage(Image img)
		{
		}

		public void DeleteBackImage(Image img)
		{
		}

		public void DeleteInlayImage(Image img)
		{
		}

        public void DeleteDiskImage(Image img)
        {
        }

        public void DeleteDvdImage(Image img)
        {
        }

		public void UpdateFrontImage(Image img, string name, string fileName, byte[] data)
		{
		}

		public void UpdateBackImage(Image ing, string name, string fileName, byte[] data)
		{
		}

		public void UpdateInlayImage(Image img, string name, string fileName, byte[] data)
		{
		}

        public void UpdateDiskImage(Image img, string name, string fileName, byte[] data)
        {
        }

        public void UpdateDvdImage(Image img, string name, string fileName, byte[] data)
        {
        }

		public ArrayList GetFrontImages()
		{
			return null;
		}

		public ArrayList GetBackImages()
		{
			return null;
		}

		public ArrayList GetInlayImages()
		{
			return null;
		}

        public ArrayList GetDiskImages()
        {
            return null;
        }

        public ArrayList GetDvdImages()
        {
            return null;
        }

		public ArrayList GetDisks(Box box)
		{
			return null;
		}

		public ArrayList GetFiles(Disk disk)
		{
			return null;
		}

		public ArrayList GetFiles(File file)
		{
			return null;
		}

		public Image AddFrontImage(string name, string fileName, byte[] data)
		{
			return null;
		}

		public Image AddBackImage(string name, string fileName, byte[] data)
		{
			return null;
		}

		public Image AddInlayImage(string name, string fileName, byte[] data)
		{
			return null;
		}

        public Image AddDiskImage(string name, string fileName, byte[] data)
        {
            return null;
        }

        public Image AddDvdImage(string name, string fileName, byte[] data)
        {
            return null;
        }

		public DataSetSearch FindFile(string fileName, bool useMinSize, bool userMaxSize, bool useEquals, long minSize, long maxSize, long size)
		{
			return null;
		}

		public DataBase DataBase
		{
			set
			{
			}
		}

		public string Name
		{
			get
			{
				return "No Implementation";
			}
		}

		public object ConfigObject
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		public DataSetSync GetCategoriesChanges(DateTime timeStamp, long[] pdaCategories)
		{
			return null;
		}

		public DataSetSync GetBoxesChanges(DateTime timeStamp, long[] pdaBoxes)
		{
			return null;
		}

		public DataSetSync GetDisksChanges(DateTime timeStamp, long[] pdaDisks)
		{
			return null;
		}
	
		public DataSetSync GetFilesChanges(DateTime timeStamp, long[] pdaFiles, long fromId, long toId)
		{
			return null;
		}

		public long GetMaxCategories()
		{
			return 0;
		}

		public long GetMaxBoxes()		
		{
			return 0;
		}

		public long GetMaxDisks()		
		{
			return 0;
		}

		public long GetMaxFiles()		
		{
			return 0;
		}

		public DataSetSync GetCategories()
		{
			return null;
		}

		public DataSetSync GetFiles(long diskId)
		{
			return null;
		}

		public bool IsNewDataBase()
		{
			return true;
		}

		public void ResetDataBase()
		{
		}

		public long AddFile(string name, DateTime date, long size, long diskId, long parentId, long attributes, object transaction)
		{
			return -1;
		}

		public long GetFilesCount(long diskId)
		{
			return 0;
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
			return 0;
		}

		public string GetDataBaseId()
		{
			return string.Empty;
		}

        public void SaveConfig(DisksDB.Config.Config cfg)
        {
        }

        public void LoadConfig(DisksDB.Config.Config cfg)
        {
        }
    }
}
