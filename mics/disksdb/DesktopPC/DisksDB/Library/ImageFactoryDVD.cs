using System;
using System.Collections.Generic;
using System.Text;

namespace DisksDB.DataBase
{
    public class ImageFactoryDVD : ImageFactory
	{
        public ImageFactoryDVD(IDBLayer idb) : base(idb)
		{
            this.AddImageEvent = new AddImageHandler(idb.AddDvdImage);
            this.GetImagesEvent = new GetImagesHandler(idb.GetDvdImages);
            this.DeleteImageEvent = new DeleteImageHandler(idb.DeleteDvdImage);
            this.UpdateImageEvent = new UpdateImageHandler(idb.UpdateDvdImage);
		}
	}
}
