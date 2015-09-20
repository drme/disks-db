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
using DisksDB.Access;
using DisksDB.Library;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace DisksDB.DataBase
{
	/// <summary>
	/// DisksDB database access
	/// </summary>
	class DataBase
	{
		private DataBase()
		{
			string assembly = DisksDB.Config.Config.Instance.GetValue("DefaultLayerFile");
			string className = DisksDB.Config.Config.Instance.GetValue("DefaultLayerClass");

			SetDataBase(assembly, className);
		}

		/// <summary>
		/// Changes Access Layer on runtime
		/// </summary>
		/// <param name="assemblyName">assembly</param>
		/// <param name="className">class</param>
		public void SetDataBase(string assemblyName, string className)
		{
			this.dbLayer = new MsAccessDBLayer();

			this.dbLayer.DataBase = this;
			this.frontImages = new ImageFactoryFront(this.dbLayer);
			this.backImages = new ImageFactoryBack(this.dbLayer);
			this.inlayImages = new ImageFactoryInlay(this.dbLayer);
			this.diskImages = new ImageFactoryDisk(this.dbLayer);
            this.dvdImages = new ImageFactoryDVD(this.dbLayer);

            this.dbLayer.LoadConfig(DisksDB.Config.Config.Instance);

            this.dbLayer.Start();

			OnLayerChanged();
		}

		public void OnLayerChanged()
		{
			if (null != this.LayerChanged)
			{
				this.LayerChanged(this, EventArgs.Empty);
			}
		}

		public Category RootCategory
		{
			get
			{
				return this.dbLayer.GetRootCategory();
			}
		}

		public List<BoxType> BoxTypes
		{
			get
			{
				return this.dbLayer.GetCDBoxTypes();
			}
		}

		public List<DiskType> DiskTypes
		{
			get
			{
				return this.dbLayer.GetDiskTypes();
			}
		}

		public ImageFactory FrontImages
		{
			get
			{
				return frontImages;
			}
		}

		public ImageFactory BackImages
		{
			get
			{
				return backImages;
			}
		}

		public ImageFactory InlayImages
		{
			get
			{
				return inlayImages;
			}
		}

		public ImageFactory DiskImages
		{
			get
			{
				return diskImages;
			}
		}

        public ImageFactoryDVD DvdImages
        {
            get
            {
                return this.dvdImages;
            }
        }

		public DataSetSearch FindFile(string fileName, bool useMinSize, bool userMaxSize, bool useEquals, long minSize, long maxSize, long size)
		{
			return dbLayer.FindFile(fileName, useMinSize, userMaxSize, useEquals, minSize, maxSize, size);
		}

		public IDBLayer LowAccessLayer
		{
			get
			{
				return this.dbLayer;
			}
		}

		public static DataBase Instance
		{
			get
			{
				if (null == dataBase)
				{
					dataBase = new DataBase();
				}

				return dataBase;
			}
		}

		private void CopyFiles(File srcFile, long dstParent, long diskId, object transaction, IProgress progress, ref long doneFiles, IDBLayer dstDataBase)
		{
			long newFile = dstDataBase.AddFile(srcFile.Name, srcFile.Date, srcFile.Size, diskId, dstParent, srcFile.Attributes, transaction);

			doneFiles++;

			if ((null != progress) && (doneFiles % 100 == 0))
			{
				progress.ProgressSmall(doneFiles);
			}

			foreach (File f in srcFile.Files)
			{
				CopyFiles(f, newFile, diskId, transaction, progress, ref doneFiles, dstDataBase);
			}
		}

		private void CopyFiles(File srcFile, Disk dstParent, object transaction, IProgress progress, ref long doneFiles)
		{
			long newFile = dstParent.DataBase.AddFile(srcFile.Name, srcFile.Date, srcFile.Size, dstParent.Id, -1, srcFile.Attributes, transaction);

			doneFiles++;

			if (null != progress)
			{
				progress.ProgressSmall(doneFiles);
			}

			foreach (File f in srcFile.Files)
			{
				CopyFiles(f, newFile, dstParent.Id, transaction, progress, ref doneFiles, dstParent.DataBase);
			}
		}

		private void CopyDisk(Disk srcDisk, Box dstBox, IProgress progress)
		{
			Image imgDisk = null;

			if (true == srcDisk.Image.IsNullImage)
			{
				if (null == this.dstDiskNoImage)
				{
					foreach (Image img in dstBox.DataBase.GetDiskImages())
					{
						if (true == img.IsNullImage)
						{
							this.dstDiskNoImage = img;
							break;
						}
					}
				}

				imgDisk = this.dstDiskNoImage;
			} 
			else
			{
				imgDisk = dstBox.DataBase.AddDiskImage(srcDisk.Image.Name, "", srcDisk.Image.Bytes);
			}

			Disk newDisk = dstBox.AddDisk(srcDisk.Name, srcDisk.Type, imgDisk, "d:", null, false);

			object transaction = dstBox.DataBase.BeginFilesAdd();

			long doneFiles = 0;

			if (null != progress)
			{
				progress.Progress(++this.disksDone);
				progress.TotallSmall(srcDisk.DataBase.GetFilesCount(srcDisk.Id));
				progress.ProgressSmall(doneFiles);
				progress.Message(newDisk.Name);
			}

			foreach (File f in srcDisk.Files)
			{
				//long newFile = newDisk.DataBase.AddFile(f.Name, f.Date, f.Size, newDisk.Id, -1, f.Attributes, transaction);

				doneFiles++;

				if ((null != progress) && (doneFiles % 100 == 0))
				{
					progress.ProgressSmall(doneFiles);
				}
				
				CopyFiles(f, newDisk, transaction, progress, ref doneFiles);
			}

			dstBox.DataBase.EndFilesAdd(transaction, true);
		}

		private void CopyBox(Box srcBox, Category dstParent, IProgress progress)
		{
			Image imgFront = null;
			Image imgBack = null;
			Image imgInlay = null;

			if (true == srcBox.FrontCover.IsNullImage)
			{
				if (null == this.dstFrontNoImage)
				{
					foreach (Image img in dstParent.DataBase.GetFrontImages())
					{
						if (true == img.IsNullImage)
						{
							this.dstFrontNoImage = img;
							break;
						}
					}
				}

				imgFront = this.dstFrontNoImage;
			} 
			else
			{
				imgFront = dstParent.DataBase.AddFrontImage(srcBox.FrontCover.Name, "", srcBox.FrontCover.Bytes);
			}

			if (true == srcBox.BackCover.IsNullImage)
			{
				if (null == this.dstBackNoImage)
				{
					foreach (Image img in dstParent.DataBase.GetBackImages())
					{
						if (true == img.IsNullImage)
						{
							this.dstBackNoImage = img;
							break;
						}
					}
				}

				imgBack = this.dstBackNoImage;
			} 
			else
			{
				imgBack  = dstParent.DataBase.AddBackImage(srcBox.BackCover.Name, "", srcBox.BackCover.Bytes);
			}

			if (true == srcBox.InlayCover.IsNullImage)
			{
				if (null == this.dstInlayNoImage)
				{
					foreach (Image img in dstParent.DataBase.GetInlayImages())
					{
						if (true == img.IsNullImage)
						{
							this.dstInlayNoImage = img;
							break;
						}
					}
				}

				imgInlay = this.dstInlayNoImage;
			} 
			else
			{
				imgInlay = dstParent.DataBase.AddInlayImage(srcBox.InlayCover.Name, "", srcBox.InlayCover.Bytes);
			}

			Box newBox = dstParent.AddCDBox(srcBox.Name, srcBox.Description, srcBox.Type, imgFront, imgBack, imgInlay);

			foreach (Disk d in srcBox.Disks)
			{
				CopyDisk(d, newBox, progress);
			}
		}

		private void CopyCategory(Category srcCategory, Category dstParent, IProgress progress)
		{
			Category newCategory = dstParent.AddCategory(srcCategory.Name, srcCategory.Description);

			foreach (Category c in srcCategory.ChildCategories)
			{
				CopyCategory(c, newCategory, progress);
			}

			foreach (Box b in srcCategory.ChildCDBoxes)
			{
				CopyBox(b, newCategory, progress);
			}
		}

		public void TransferDataBase(IDBLayer dstLayer, IProgress progress)
		{
			IDBLayer srcLayer = this.dbLayer;

			this.dstFrontNoImage = null;
			this.dstBackNoImage = null;
			this.dstInlayNoImage = null;
			this.dstDiskNoImage = null;
			this.disksDone = 0;

			dstLayer.ResetDataBase();
			
			Category srcRoot = srcLayer.GetRootCategory();
			Category dstRoot = dstLayer.GetRootCategory();

			if (null != progress)
			{
				progress.Total(srcLayer.GetDisksCount());
			}

			foreach (Category srcCategory in srcRoot.ChildCategories)
			{
				CopyCategory(srcCategory, dstRoot, progress);
			}

			foreach (Box b in srcRoot.ChildCDBoxes)
			{
				CopyBox(b, dstRoot, progress);
			}
		}

		public void WriteRegistryKeys()
		{
			string exePath = Config.Config.Instance.GetValue("SyncFile", "E:\\Projects\\DisksDB\\SyncActiveSync\\bin\\Debug\\SyncActiveSync.exe");

			RegistryKey k1 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows CE Services\\AutoStartOnConnect");
			k1.SetValue("DisksDB.AS.{0E405CBF-705E-4596-89DB-32D5366069F1}", exePath);

			RegistryKey k2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows CE Services\\AutoStartOnDisconnect");
			k2.SetValue("DisksDB.AS.{0E405CBF-705E-4596-89DB-32D5366069F1}", exePath);
		}

		public bool IsActiveSync
		{
			get
			{
				RegistryKey k1 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows CE Services\\AutoStartOnConnect");
				
				if (null != k1.GetValue("DisksDB.AS.{0E405CBF-705E-4596-89DB-32D5366069F1}"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public void RemoveRegistryKeys()
		{
			RegistryKey k1 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows CE Services\\AutoStartOnConnect");
			k1.DeleteValue("DisksDB.AS.{0E405CBF-705E-4596-89DB-32D5366069F1}");

			RegistryKey k2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows CE Services\\AutoStartOnDisconnect");
			k2.DeleteValue("DisksDB.AS.{0E405CBF-705E-4596-89DB-32D5366069F1}");
		}

		public event EventHandler LayerChanged = null;
		private ImageFactoryFront frontImages = null;
		private ImageFactoryBack backImages = null;
		private ImageFactoryInlay inlayImages = null;
		private ImageFactoryDisk diskImages = null;
        private ImageFactoryDVD dvdImages = null;
		private IDBLayer dbLayer = null;
		private Image dstFrontNoImage = null;
		private Image dstBackNoImage = null;
		private Image dstInlayNoImage = null;
        private Image dstDiskNoImage = null;
        private Image dstDvdNoImage = null;
		private long disksDone = 0;
		private static DataBase dataBase = null;
	}
}
