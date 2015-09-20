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
using System.Drawing;
using System.IO;
using System;

namespace DisksDB.DataBase
{
	/// <summary>
	/// Base class of images
	/// </summary>
	class Image : BaseObject
	{
		public Image(IDBLayer idb, long id, string name, long picId, EnumImageCategories imageType, bool deleteable) : base(idb, id)
		{
			this.name = name;
			this.picId = picId;
            this.imgFact = null;
			this.type = imageType;
			this.deleteable = deleteable;
		}

		public Image(IDBLayer idb, long id, string name, long picId, byte[] data, EnumImageCategories imageType, bool deleteable) : this(idb, id, name, picId, imageType, deleteable)
		{
			this.image = BuildImage(data);
		}

		public System.Drawing.Image Picture
		{
			get
			{
				if (null == this.image)
				{
					this.image = LoadImage();
				}

				return this.image;
			}
		}

		public string FileName
		{
			set
			{
				this.imgFact.UpdateImage(this, this.name, value, null);
				this.image = null;
			}
		}

		protected System.Drawing.Image BuildImage(byte[] b)
		{
			this.bytes = b;

			if (null == b)
			{
				return new Bitmap(1, 1);
			}

			if (0 == b.Length)
			{
				return null;
			}

			MemoryStream stream = new MemoryStream(b, true);
			stream.Write(b, 0, b.Length);
			Bitmap bmp = new Bitmap(stream);
			//stream.Close();

			return bmp;
		}

		protected System.Drawing.Image LoadImage()
		{
			return BuildImage(this.idb.LoadImage(this));
		}

		public override string ToString()
		{
			return this.name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				imgFact.UpdateImage(this, this.name, null, null);
                OnNameChanged();
			}
		}

		internal ImageFactory ImageFactory
		{
			set
			{
				this.imgFact = value;
			}
		}

		public override void Delete()
		{
			if (false == this.deleteable)
			{
				throw new ApplicationException("Can not be deleted");
			}

			this.imgFact.DeleteImage(this);
			base.Delete();
		}

		public EnumImageCategories ImageType
		{
			get
			{
				return this.type;
			}
		}

		public byte[] Bytes
		{
			get
			{
				if (null == this.image)
				{
					this.image = LoadImage();
				}

				return this.bytes;
			}
		}

		internal bool IsNullImage
		{
			get
			{
				return !this.deleteable;
			}
		}

		protected string name = string.Empty;
		protected System.Drawing.Image image = null;
		protected long picId = -1;
		protected ImageFactory imgFact = null;
		protected EnumImageCategories type = EnumImageCategories.FrontImage;
		protected bool deleteable = true;
		protected byte[] bytes = null;
	}
}
