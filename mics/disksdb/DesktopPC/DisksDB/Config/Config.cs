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
using System.Data;
using DisksDB.Utils;

namespace DisksDB.Config
{
	public class Config
	{
		private Config()
		{
			string path = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

			this.cfgFileName = path + "\\" + appId + "\\config.xml";

			DisksDB.Utils.Utils.CreateFolders(this.cfgFileName);

			try
			{
				dsCfg.ReadXml(this.cfgFileName);
			}
			catch (Exception)
			{
				dsCfg = new DataSetConfig();

				this.configFileExists = false;
			}
		}

		public static Config Instance
		{
			get
			{
				if (null == _isntace)
				{
					_isntace = new Config();
				}

				return _isntace;
			}
		}

		public string GetValue(string key)
		{
			DataRow[] rows = this.dsCfg.Config.Select("key = '" + key + "'");

			if (rows.Length > 0)
			{
				if (false == rows[0].IsNull(1))
				{
					return (string) rows[0][1];
				}
			}

			return null;
		}

		public int GetValue(string key, int defaultValue)
		{
			string s = GetValue(key);

			if (null != s)
			{
				return int.Parse(s);
			}

			return defaultValue;
		}

        public bool GetValue(string key, bool defaultValue)
        {
            string s = GetValue(key);

            if (null != s)
            {
                return (s == "true");
            }
            else
            {
                return defaultValue;
            }
        }

		public string GetValue(string key, string defaultValue)
		{
			string s = GetValue(key);

			if (null != s)
			{
				return s;
			}

			return defaultValue;
		}

        public void SetValue(string key, bool value)
        {
            if (true == value)
            {
                SetValue(key, "true");
            }
            else
            {
                SetValue(key, "false");
            }
        }

        public void SetValue(string key, int value)
        {
            SetValue(key, value.ToString());
        }

        public void SetValue(string key, string value)
        {
			DataRow[] rows = this.dsCfg.Config.Select("key = '" + key + "'");

			if (rows.Length > 0)
			{
				rows[0][1] = value;
			}
			else
			{
				DataSetConfig.ConfigRow dr = dsCfg.Config.NewConfigRow();
				dr.Key = key;
				dr.Value = value;
				dsCfg.Config.AddConfigRow(dr);
			}
		}

		public void Save()
		{
			try
			{
				this.dsCfg.WriteXml(cfgFileName);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
		}

		public bool ConfigFileExists
		{
			get
			{
				return this.configFileExists;
			}
		}

		public string AppID
		{
			get
			{
				return appId;
			}
		}

		private DataSetConfig dsCfg = new DataSetConfig();
		private static Config _isntace = null;
		private string cfgFileName = null;
		private bool configFileExists = true;
		private static string appId = "DisksDB\\{9FE0FD34-BD2E-4c50-A057-FE550CD25472}";
	}
}
