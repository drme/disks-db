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
using System;
using System.Data;
using System.Data.OleDb;

namespace DisksDB.Access
{
	/// <summary>
	/// Utilities for acessing Access DataBase
	/// </summary>
	class DBUtils
	{
		private static void BuildParameters(OleDbCommand command, Object[] parameters)
		{
			if ( (null != parameters) && (parameters.Length > 0) )
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					if (parameters[i] is DateTime)
					{
						OleDbParameter parameter = new OleDbParameter("p" + i, OleDbType.DBDate);

						parameter.Value = parameters[i];

						command.Parameters.Add(parameter);
					} 
					else
					{
						command.Parameters.AddWithValue("p" + i, parameters[i]);
					}
				}
			}
		}

		public static OleDbDataReader ExecSQL(String connectionString, String sql, Object[] parameters)
		{
			OleDbConnection connection = new OleDbConnection(connectionString);
			OleDbCommand command = new OleDbCommand(sql, connection);
			BuildParameters(command, parameters);

			connection.Open();

			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public static int InsertSQL(String connectionString, String sql, Object[] parameters)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				using (OleDbCommand command = new OleDbCommand(sql, connection))
				{
					BuildParameters(command, parameters);

					connection.Open();

					command.ExecuteNonQuery();

					using (OleDbCommand identityCommand = new OleDbCommand("SELECT @@IDENTITY", connection))
					{
						int result = (int)identityCommand.ExecuteScalar();

						return result;
					}
				}
			}
		}

		public static void UpdateSQL(String connectionString, String sql, Object[] parameters)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				using (OleDbCommand command = new OleDbCommand(sql, connection))
				{
					BuildParameters(command, parameters);

					connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static void DeleteSQL(String connectionString, String sql, Object[] parameters)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				using (OleDbCommand command = new OleDbCommand(sql, connection))
				{
					BuildParameters(command, parameters);

					connection.Open();

					command.ExecuteNonQuery();
				}
			}
		}

		public static object ExecScalar(String connectionString, String sql, Object[] parameters)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				using (OleDbCommand command = new OleDbCommand(sql, connection))
				{
					BuildParameters(command, parameters);

					connection.Open();

					return command.ExecuteScalar();
				}
			}
		}

		public static void FillDataTable(DataTable dataTable, String connectionString, String sql, Object[] parameters)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				using (OleDbCommand command = new OleDbCommand(sql, connection))
				{
					BuildParameters(command, parameters);

					using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
					{
						dataAdapter.Fill(dataTable);
					}
				}
			}
		}
	}
}
