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

using DisksDB.Utils;
using System;
using System.Data;

namespace DisksDB.Config
{
	class Config
	{
		private Config()
		{
			String path = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

			this.configFileName = path + "\\" + appId + "\\config.xml";

			DisksDB.Utils.Utils.CreateFolders(this.configFileName);

			try
			{
				dataSet.ReadXml(this.configFileName);
			}
			catch (Exception)
			{
				dataSet = new DataSetConfig();

				this.configFileExists = false;
			}
		}

		public static Config Instance
		{
			get
			{
				if (null == instance)
				{
					instance = new Config();
				}

				return instance;
			}
		}

		public string GetValue(String key)
		{
			DataRow[] rows = this.dataSet.Config.Select("key = '" + key + "'");

			if (rows.Length > 0)
			{
				if (false == rows[0].IsNull(1))
				{
					return (string) rows[0][1];
				}
			}

			return null;
		}

		public int GetValue(String key, int defaultValue)
		{
			String s = GetValue(key);

			if (null != s)
			{
				return int.Parse(s);
			}

			return defaultValue;
		}

        public bool GetValue(String key, bool defaultValue)
        {
            String s = GetValue(key);

            if (null != s)
            {
                return (s == "true");
            }
            else
            {
                return defaultValue;
            }
        }

		public string GetValue(String key, String defaultValue)
		{
			String s = GetValue(key);

			if (null != s)
			{
				return s;
			}

			return defaultValue;
		}

        public void SetValue(String key, bool value)
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

        public void SetValue(String key, int value)
        {
            SetValue(key, value.ToString());
        }

        public void SetValue(String key, String value)
        {
			DataRow[] rows = this.dataSet.Config.Select("key = '" + key + "'");

			if (rows.Length > 0)
			{
				rows[0][1] = value;
			}
			else
			{
				DataSetConfig.ConfigRow dr = dataSet.Config.NewConfigRow();
				dr.Key = key;
				dr.Value = value;
				dataSet.Config.AddConfigRow(dr);
			}
		}

		public void Save()
		{
			try
			{
				this.dataSet.WriteXml(configFileName);
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

		public String AppID
		{
			get
			{
				return appId;
			}
		}

		private DataSetConfig dataSet = new DataSetConfig();
		private static Config instance = null;
		private String configFileName = null;
		private bool configFileExists = true;
		private const String appId = "DisksDB\\{9FE0FD34-BD2E-4c50-A057-FE550CD25472}";
	}
}
