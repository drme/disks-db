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
using System.IO;
using System.Reflection;
using DisksDB.Utils;

namespace DisksDB.DataBase
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class DBLayersScanner
	{
		public DBLayersScanner()
		{
		}

		public ArrayList LoadModules()
		{
			ArrayList lst = new ArrayList();

			Type repType = typeof(IDBLayer);

			string[] strDLLs = Directory.GetFileSystemEntries(DisksDB.Utils.Utils.DataBaseLayersFolder, "*.dll");

			if (strDLLs.Length == 0)
			{
				return lst;
			}

			foreach (string fileName in strDLLs)
			{
				try
				{
					Assembly a = Assembly.LoadFrom(fileName);

					foreach (Type t in a.GetTypes())
					{
						try
						{
							if ( (t.IsPublic) && (!t.IsAbstract) && (t.GetInterface(repType.FullName) != null))
							{
								DBLayerItem item = new DBLayerItem(fileName, t.FullName, (IDBLayer)a.CreateInstance(t.FullName));
								lst.Add(item);

                                item.Layer.LoadConfig(DisksDB.Config.Config.Instance);

                                //try
                                //{
                                //    string xml = DisksDB.Config.Config.Instance.GetValue("Layer " + t.FullName);
                                //    item.Layer.ConfigObject = Serializer.StringToObject(xml, item.Layer.ConfigObject.GetType());
                                //}
                                //catch (Exception ex)
                                //{
                                //    Logger.LogException(ex);
                                //}

								break;
							}
						}
						catch (Exception ex)
						{
							Logger.LogException(ex);
						}
					}
				}
				catch (Exception ex)
				{
					Logger.LogException(ex);
				}
			}

			return lst;
		}
	}
}
