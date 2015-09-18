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
using System.Data.OleDb;

namespace DisksDB.Access
{
	/// <summary>
	/// Utilities for acessing Access DAtaBase
	/// </summary>
	internal class DBUtils
	{
		private static void BuildParameters(OleDbCommand cmd, object[] parameters)
		{
			if ( (null != parameters) && (parameters.Length > 0) )
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					if (parameters[i] is DateTime)
					{
						OleDbParameter p = new OleDbParameter("p" + i, OleDbType.DBDate);
						p.Value = parameters[i];
						cmd.Parameters.Add(p);
					} 
					else
					{
						cmd.Parameters.AddWithValue("p" + i, parameters[i]);
					}
				}
			}
		}

		public static OleDbDataReader ExecSQL(string conStr, string sql, object[] parameters)
		{
			OleDbConnection oleCon = new OleDbConnection(conStr);
			OleDbCommand oleCmd = new OleDbCommand(sql, oleCon);

			BuildParameters(oleCmd, parameters);

			oleCon.Open();

			return oleCmd.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public static int InsertSQL(string conStr, string sql, object[] parameters)
		{
			OleDbConnection oleCon = new OleDbConnection(conStr);
			OleDbCommand oleCmd = new OleDbCommand(sql, oleCon);

			BuildParameters(oleCmd, parameters);

			oleCon.Open();

			oleCmd.ExecuteNonQuery();

			OleDbCommand oleCmdIdentity = new OleDbCommand("SELECT @@IDENTITY", oleCon);

			int rez = (int)oleCmdIdentity.ExecuteScalar();

			oleCon.Close();

			return rez;
		}

		public static void UpdateSQL(string conStr, string sql, object[] parameters)
		{
			OleDbConnection oleCon = new OleDbConnection(conStr);
			OleDbCommand oleCmd = new OleDbCommand(sql, oleCon);

			BuildParameters(oleCmd, parameters);

			oleCon.Open();

			oleCmd.ExecuteNonQuery();

			oleCon.Close();
		}

		public static void DeleteSQL(string conStr, string sql, object[] parameters)
		{
			OleDbConnection oleCon = new OleDbConnection(conStr);
			OleDbCommand oleCmd = new OleDbCommand(sql, oleCon);

			BuildParameters(oleCmd, parameters);

			oleCon.Open();

			oleCmd.ExecuteNonQuery();

			oleCon.Close();
		}

		public static object ExecScalar(string conStr, string sql, object[] parameters)
		{
			OleDbConnection oleCon = new OleDbConnection(conStr);
			OleDbCommand oleCmd = new OleDbCommand(sql, oleCon);

			BuildParameters(oleCmd, parameters);

			oleCon.Open();

			object rez = oleCmd.ExecuteScalar();

			oleCon.Close();

			return rez;
		}

		public static void FillDataTable(DataTable dt, string conStr, string sql, object[] parameters)
		{
			OleDbConnection oleCon = new OleDbConnection(conStr);

			OleDbCommand oleCmd = new OleDbCommand(sql, oleCon);

			BuildParameters(oleCmd, parameters);

			OleDbDataAdapter da = new OleDbDataAdapter(oleCmd);

			da.Fill(dt);
		}
	}
}
