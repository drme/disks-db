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
using System.Collections;

namespace DisksDB.DataBase
{
	/// <summary>
	/// Factory for loading images
	/// </summary>
	public abstract class ImageFactory : BaseObject
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="idb">abstract database layer</param>
		public ImageFactory(IDBLayer idb) : base(idb, -1)
		{
		}

		public virtual Image AddImage(string name, string fileName, byte[] data)
		{
			if (null != AddImageEvent)
			{
				Image img = AddImageEvent(name, fileName, data);
				img.ImageFactory = this;

				if (null != img)
				{
					this.images.Add(img);
					OnChildAdded(img);
				}

				return img;
			}

			return null;
		}

		public virtual void UpdateImage(Image img, string name, string fileName, byte[] data)
		{
			if (null != UpdateImageEvent)
			{
				UpdateImageEvent(img, name, fileName, data);
			}
		}

		public virtual void DeleteImage(Image img)
		{
			if (null != DeleteImageEvent)
			{
				DeleteImageEvent(img);
			}

			OnChildRemoved(img);
		}

		/// <summary>
		/// Gets image by ID
		/// </summary>
		/// <param name="id">images ID</param>
		/// <returns>if image found object of class Image othervise nulll</returns>
		public virtual Image GetImage(long id)
		{
			foreach (Image img in GetImages())
			{
				if (img.Id == id)
				{
					return img;
				}
			}

			return null;
		}

		public virtual ArrayList GetImages()
		{
			if (null == this.images)
			{
				if (null != this.GetImagesEvent)
				{
					this.images = this.GetImagesEvent();
				}

				if (null != this.images)
				{
					foreach (Image img in this.images)
					{
						img.ImageFactory = this;
					}
				}
			}

			return this.images;
		}

		protected ArrayList images = null;
		protected AddImageHandler AddImageEvent = null;
		protected GetImagesHandler GetImagesEvent = null;
		protected DeleteImageHandler DeleteImageEvent = null;
		protected UpdateImageHandler UpdateImageEvent = null;
		protected delegate Image AddImageHandler(string name, string fileName, byte[] data);
		protected delegate void UpdateImageHandler(Image img, string name, string fileName, byte[] data);
		protected delegate ArrayList GetImagesHandler();
		protected delegate void DeleteImageHandler(Image img);
	}
}