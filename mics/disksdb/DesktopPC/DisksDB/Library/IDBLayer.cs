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
using DisksDB.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DisksDB.DataBase
{
	/// <summary>
	/// Interface of database layer.
	/// Implement this interface to use different database management systems.
	/// </summary>
	interface IDBLayer
	{
        /// <summary>
        /// Starts data base engine. Time to perform some initialization steps if required.
        /// </summary>
        void Start();

		/// <summary>
		/// Deletes and initializes a new empty database.
		/// Responsible for creating database files or databases according configuration object,
		/// populating database with initial data.
		/// </summary>
		void ResetDataBase();

		/// <summary>
		/// Is the database specified in configuration object is new?
		/// </summary>
		/// <returns>Is the database specified in configuration object is new?</returns>
		bool IsNewDataBase();

		/// <summary>
		/// Gets root category.
		/// Database must have one root category, which has all other categories as chills.
		/// This category is not visible.
		/// </summary>
		/// <returns></returns>
		Category GetRootCategory();

		/// <summary>
		/// Updates cateroy info with new data
		/// </summary>
		/// <param name="category">Category which to update. Function should only use category id</param>
		/// <param name="newName">New category name</param>
		/// <param name="newDescription">New category description</param>
		/// <param name="newParent">New parent category id</param>
		void UpdateCategory(Category category, String newName, String newDescription, Category newParent);

		/// <summary>
		/// Deletes category.
		/// This method should delete all child categories, child cdboxes, their disks and files.
		/// </summary>
		/// <param name="category">Category which to delete. Function should only use category id</param>
		void DeleteCategory(Category category);

		/// <summary>
		/// Gets child categories.
		/// </summary>
		/// <param name="parentCat">parent category. Function should only use category id</param>
		/// <returns>Objects of class Category packed in ArrayList</returns>
		List<Category> GetChildCategories(Category parentCat);

		/// <summary>
		/// Gets child CD Boxes.
		/// </summary>
		/// <param name="parentCat">Parent category. Function should only use category id.</param>
		/// <returns>Objects of class CBBox packed in ArrayList</returns>
		List<Box> GetChildCDBoxes(Category parentCat);

		/// <summary>
		/// Creates new category in database. Returns new category object.
		/// </summary>
		/// <param name="name">Category name</param>
		/// <param name="description">Category description</param>
		/// <param name="cat">parent category. Function should only use category id</param>
		/// <returns>Newly created category.</returns>
		Category AddCategory(String name, String description, Category cat);

		/// <summary>
		/// Adds CD Box to database
		/// </summary>
		/// <param name="name">CD Box name</param>
		/// <param name="description">CD Box description</param>
		/// <param name="type">box type</param>
		/// <param name="frontImage">front cover image</param>
		/// <param name="backImage">back cover image</param>
		/// <param name="inlayImage">inlay cover image</param>
		/// <param name="cat">CD Box category it resides</param>
		/// <returns>created cd box</returns>
		Box AddCDBox(String name, String description, BoxType type, Image frontImage, Image backImage, Image inlayImage, Category cat);

		/// <summary>
		/// Adds CD disk
		/// </summary>
		/// <param name="name">disks name</param>
		/// <param name="type">disks type</param>
		/// <param name="image">disk image</param>
		/// <param name="box">this disk resides in this CD Box</param>
		/// <param name="driveLetter">drive letter to scan for files</param>
		/// <param name="prog">files scanning status notifier</param>
		/// <returns>created disk</returns>
		Disk AddDisk(String name, DiskType type, Image image, Box box, String driveLetter, IAddDiskProgress prog, bool addFiles);

		/// <summary>
		/// updates existing disk
		/// </summary>
		/// <param name="disk">disk</param>
		/// <param name="name">disks new name</param>
		/// <param name="type">disks new type</param>
		/// <param name="image">disks new image</param>
		/// <param name="box">disks new box</param>
		void UpdateDisk(Disk disk, String name, DiskType type, Image image, Box box);

		/// <summary>
		/// Deletes disk
		/// </summary>
		/// <param name="d">disk to delete</param>
		void DeleteDisk(Disk d);

		/// <summary>
		/// Deletes cd box
		/// </summary>
		/// <param name="box">cd box to delete</param>
		void DeleteCDBox(Box box);

		/// <summary>
		/// Updates CD Box
		/// </summary>
		/// <param name="box">cd box</param>
		/// <param name="newName">cd box new name</param>
		/// <param name="newDescription">cd box new description</param>
		/// <param name="newBack">cd box new back cover image</param>
		/// <param name="newFront">cd box new front cover image</param>
		/// <param name="newInlay">cd box new inlay cover image</param>
		/// <param name="newType">cd box new type</param>
		/// <param name="newParent">cd box new parent category</param>
		void UpdateCDBox(Box box, String newName, String newDescription, Image newBack, Image newFront, Image newInlay, BoxType newType, Category newParent);

		/// <summary>
		/// Returs list of CDBox types
		/// </summary>
		/// <returns>array with CDBoxType objects</returns>
		List<BoxType> GetCDBoxTypes();

		/// <summary>
		/// Returns list of Disk types
		/// </summary>
		/// <returns>array with DiskType objects</returns>
		List<DiskType> GetDiskTypes();

		/// <summary>
		/// Loads Image from database, or file
		/// </summary>
		/// <param name="img">image</param>
		/// <returns>image in array of bytes</returns>
		byte[] LoadImage(Image img);

		/// <summary>
		/// Deletes front image from database
		/// </summary>
		/// <param name="img">image</param>
		void DeleteFrontImage(Image img);

		/// <summary>
		/// Deletes back image from database
		/// </summary>
		/// <param name="img">image</param>
		void DeleteBackImage(Image img);

		/// <summary>
		/// Deletes inlay image from database
		/// </summary>
		/// <param name="img">image</param>
		void DeleteInlayImage(Image img);

		/// <summary>
		/// Deletes disk image from database
		/// </summary>
		/// <param name="img">image</param>
        void DeleteDiskImage(Image img);

        void DeleteDvdImage(Image img);

		/// <summary>
		/// Updates front image
		/// </summary>
		/// <param name="img">image to update</param>
		/// <param name="name">new name</param>
		/// <param name="fileName">new file name</param>
		/// <param name="data">new image data</param>
		void UpdateFrontImage(Image img, String name, String fileName, byte[] data);

		/// <summary>
		/// Updates back image
		/// </summary>
		/// <param name="ing">image to update</param>
		/// <param name="name">new name</param>
		/// <param name="fileName">new file name</param>
		/// <param name="data">new image data</param>
		void UpdateBackImage(Image img, String name, String fileName, byte[] data);

		/// <summary>
		/// Updates inlay image
		/// </summary>
		/// <param name="img">image to update</param>
		/// <param name="name">new name</param>
		/// <param name="fileName">new file name</param>
		/// <param name="data">new image data</param>
		void UpdateInlayImage(Image img, String name, String fileName, byte[] data);

		/// <summary>
		/// Updates disk image
		/// </summary>
		/// <param name="img">image to update</param>
		/// <param name="name">new name</param>
		/// <param name="fileName">new file name</param>
		/// <param name="data">new image data</param>
        void UpdateDiskImage(Image img, String name, String fileName, byte[] data);

        void UpdateDvdImage(Image img, String name, String fileName, byte[] data);

		/// <summary>
		/// Returns list of front Images.
		/// </summary>
        /// <returns>class Image objects packed in ArrayList</returns>
		List<Image> GetFrontImages();

		/// <summary>
		/// Returns list of back Images.
		/// </summary>
        /// <returns>class Image objects packed in ArrayList</returns>
		List<Image> GetBackImages();

		/// <summary>
		/// Returns list of inlay Images.
		/// </summary>
		/// <returns>class Image objects packed in ArrayList</returns>
		List<Image> GetInlayImages();

		/// <summary>
		/// Returns list of disk Images.
		/// </summary>
        /// <returns>class Image objects packed in ArrayList</returns>
		List<Image> GetDiskImages();

        List<Image> GetDvdImages();

		/// <summary>
		/// Get`s list of disk, who resides in this cd box
		/// </summary>
		/// <param name="box">box</param>
		/// <returns>ArrayList filled with Disk class objects</returns>
		List<Disk> GetDisks(Box box);

		/// <summary>
		/// Get`s list of files, who resides on specified disk
		/// </summary>
		/// <param name="disk">disk</param>
		/// <returns>ArrayList filled with File class objects</returns>
		List<File> GetFiles(Disk disk);

		/// <summary>
		/// Get`s list of files, who resides in specified folder
		/// </summary>
		/// <param name="file">folder</param>
		/// <returns>ArrayList filled with File class objects</returns>
		List<File> GetFiles(File file);

		/// <summary>
		/// Adds front image to database
		/// </summary>
		/// <param name="name">name of image</param>
		/// <param name="fileName">file name of image to load from</param>
		/// <param name="data"> or (and) data of loaded file in memory</param>
		/// <returns>Added Image</returns>
		Image AddFrontImage(String name, String fileName, byte[] data);

		/// <summary>
		/// Adds back image to database
		/// </summary>
		/// <param name="name">name of image</param>
		/// <param name="fileName">file name of image to load from</param>
		/// <param name="data"> or (and) data of loaded file in memory</param>
		/// <returns>Added Image</returns>
		Image AddBackImage(String name, String fileName, byte[] data);

		/// <summary>
		/// Adds inlay image to database
		/// </summary>
		/// <param name="name">name of image</param>
		/// <param name="fileName">file name of image to load from</param>
		/// <param name="data"> or (and) data of loaded file in memory</param>
		/// <returns>Added Image</returns>
		Image AddInlayImage(String name, String fileName, byte[] data);

		/// <summary>
		/// Adds disk image to database
		/// </summary>
		/// <param name="name">name of image</param>
		/// <param name="fileName">file name of image to load from</param>
		/// <param name="data"> or (and) data of loaded file in memory</param>
		/// <returns>Added Image</returns>
        Image AddDiskImage(String name, String fileName, byte[] data);

        Image AddDvdImage(String name, String fileName, byte[] data);

		/// <summary>
		/// Searches database for file using specified pattern
		/// </summary>
		/// <param name="fileName">filename (can use wild chars)</param>
		/// <param name="useMinSize">use min size parameter</param>
		/// <param name="userMaxSize">use max size parameter</param>
		/// <param name="useEquals">use equals parameter (overrides min and max sizes)</param>
		/// <param name="minSize">minimum size of file</param>
		/// <param name="maxSize">maximum size of file</param>
		/// <param name="size">exact size of file</param>
		DataSetSearch FindFile(String fileName, bool useMinSize, bool userMaxSize, bool useEquals, long minSize, long maxSize, long size);

		/// <summary>
		/// Reference of database system object, usually used for images managing.
		/// </summary>
		DataBase DataBase
		{
			set;
		}
		/// <summary>
		/// Data Access Layer Name
		/// </summary>
		String Name
		{
			get;
		}
        /// <summary>
        /// Configuration object
        /// </summary>
        object ConfigObject
        {
            get;
        }

		/// <summary>
		/// Adds file To database. (used only in Database transfer process).
		/// </summary>
		/// <param name="name">file name</param>
		/// <param name="date">file creation date</param>
		/// <param name="size">file size</param>
		/// <param name="diskId">files disk Id</param>
		/// <param name="parentId">files parent(folder) (if on root then -1)</param>
		/// <param name="attributes">files attributes (1 - folder, 0 - file)</param>
		/// <param name="transaction">transaction object created by BeginFilesAdd method.</param>
		/// <returns>created file id or -1 on error</returns>
		long AddFile(String name, DateTime date, long size, long diskId, long parentId, long attributes, Object transaction);
		
		/// <summary>
		/// Gets files count on specified disk. (used only in Database transfer process).
		/// </summary>
		/// <param name="diskId">disk id</param>
		/// <returns>files count</returns>
		long GetFilesCount(long diskId);

		/// <summary>
		/// Begins files adding. (used only in Database transfer process).
		/// Shoud create transaction object which later will be passed to AddFile method.
		/// </summary>
		/// <returns>transaction object. (for example SqlTransaction). Using this object all disk files will be added in single transaction</returns>
		Object BeginFilesAdd();

		/// <summary>
		/// Finishes files adding. (used only in Database transfer process).
		/// Closes transaction and commits or rollback changes.
		/// </summary>
		/// <param name="transaction">transaction object created in BeginFilesAdd</param>
		/// <param name="commit">true == commit transaction, false == rollback</param>
		void EndFilesAdd(Object transaction, bool commit);
		
		/// <summary>
		/// Gets Disks count in database. (used only in Database transfer process).
		/// Used for progress bar during database transfer.
		/// </summary>
		/// <returns>disks count in database</returns>
		long GetDisksCount();

		DataSetSync GetCategoriesChanges(DateTime timeStamp, long[] pdaCategories);
		DataSetSync GetBoxesChanges(DateTime timeStamp, long[] pdaBoxes);
		DataSetSync GetDisksChanges(DateTime timeStamp, long[] pdaDisks);
		DataSetSync GetFilesChanges(DateTime timeStamp, long[] pdaFiles, long fromId, long toId); // toId == -1 means  to the end. suggested 100 records steps
		DataSetSync GetFiles(long diskId);

		long GetMaxCategories();
		long GetMaxBoxes();
		long GetMaxDisks();
		long GetMaxFiles();

		DataSetSync GetCategories();

		/// <summary>
		/// Gates database ID. Used in synchronization, in order to determine if synchronization is being performed with correct database.
		/// '|' should not be contained in ID string.
		/// </summary>
		/// <returns>database Id (could be any string, GUID is recommend)</returns>
		String GetDataBaseId();

        /// <summary>
        /// Saves configuration to configuration object.
        /// </summary>
        /// <param name="cfg">configuration object to which to save settings</param>

        void SaveConfig(DisksDB.Config.Config cfg);
        /// <summary>
        /// Loads configuration from configuration object.
        /// </summary>
        /// <param name="cfg">configuration object to load parameters from.</param>
        void LoadConfig(DisksDB.Config.Config cfg);
	}
}
