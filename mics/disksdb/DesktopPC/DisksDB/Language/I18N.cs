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
using System.Windows.Forms;
using DisksDB.Config;
using DisksDB.Utils;

namespace DisksDB.Language
{
	public class I18N : System.ComponentModel.Component
	{
		private I18N()
		{
			InitializeComponent();

//			if (false == SetFile(DisksDB.Utils.Utils.ApplicationFolder + "/language.mdb"))
//			{
//				/**
//				 * While in development
//				 */
//				SetFile(DisksDB.Utils.Utils.ApplicationFolder + "/../../../Language/DataBase/language.mdb");
//			}
//
//			UpdateLanguage();
		}

		private bool SetFile(string fileName)
		{
			if (System.IO.File.Exists(fileName))
			{
				SetDbFile(fileName);

				this.hasLanguages = true;
				this.readOnly = false;

				return true;
			} 
			else
			{
				this.hasLanguages = false;
				this.readOnly = true;

				return false;
			}
		}

		private void SetDbFile(string fileName)
		{
			this.oleDbConnection1.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=\"" + fileName + "\";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=\"Microsoft.Jet.OLEDB.4.0\";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
		}

		public string GetText(string key, string altText)
		{
//			if (false == this.hasLanguages)
//			{
				return altText;
//			}
//
//			DataSetTranslation ds = new DataSetTranslation();
//
//			try
//			{
//				this.oleDbDataAdapterGetText.SelectCommand.Parameters[0].Value = (int)language.Id;
//				this.oleDbDataAdapterGetText.SelectCommand.Parameters[1].Value = key;
//				this.oleDbDataAdapterGetText.Fill(ds.Texts);
//			}
//			catch (Exception ex)
//			{
//				Logger.LogException(ex);
//				
//				this.hasLanguages = false;
//
//				return altText;
//			}
//
//			if (ds.Texts.Rows.Count > 0)
//			{
//				return ds.Texts[0].Vertimas;
//			}
//			else
//			{
//				if (false == this.readOnly)
//				{
//					try
//					{
//						DataSetTranslation.TextsRow tr = ds.Texts.NewTextsRow();
//						tr.Kalba = (int)language.Id;
//						tr.Vertimas = altText;
//						tr.SrcTekstas = key;
//						ds.Texts.AddTextsRow(tr);
//						this.oleDbDataAdapterGetText.Update(ds);
//					}
//					catch (Exception ex)
//					{
//						Logger.LogException(ex);
//						this.readOnly = true;
//					}
//				}
//
//				return altText;
//			}
		}

		#region "Windows Designer Generated Code"
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterLanguages;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterTexts;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterGetText;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterConfig;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;

		private void InitializeComponent()
		{
			this.oleDbDataAdapterLanguages = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterTexts = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterGetText = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapterConfig = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			// 
			// oleDbDataAdapterLanguages
			// 
			this.oleDbDataAdapterLanguages.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapterLanguages.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapterLanguages.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapterLanguages.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "Languages", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("id", "id"),
																																																							 new System.Data.Common.DataColumnMapping("Name", "Name")})});
			this.oleDbDataAdapterLanguages.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM Languages WHERE (id = ?) AND (Name = ? OR ? IS NULL AND Name IS NULL)" +
				"";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""E:\Projects\DVDDB\database\language.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO Languages(Name) VALUES (?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT id, Name FROM Languages";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE Languages SET Name = ? WHERE (id = ?) AND (Name = ? OR ? IS NULL AND Name " +
				"IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterTexts
			// 
			this.oleDbDataAdapterTexts.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterTexts.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterTexts.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterTexts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "Texts", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("id", "id"),
																																																					 new System.Data.Common.DataColumnMapping("Kalba", "Language"),
																																																					 new System.Data.Common.DataColumnMapping("SrcTekstas", "SrcText"),
																																																					 new System.Data.Common.DataColumnMapping("Vertimas", "Translation")})});
			this.oleDbDataAdapterTexts.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM Texts WHERE (id = ?) AND (Kalba = ? OR ? IS NULL AND Kalba IS NULL) A" +
				"ND (SrcTekstas = ? OR ? IS NULL AND SrcTekstas IS NULL) AND (Vertimas = ? OR ? I" +
				"S NULL AND Vertimas IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO Texts(Kalba, SrcTekstas, Vertimas) VALUES (?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Kalba", System.Data.OleDb.OleDbType.Integer, 0, "Kalba"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, "SrcTekstas"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, "Vertimas"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT id, Kalba, SrcTekstas, Vertimas FROM Texts";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE Texts SET Kalba = ?, SrcTekstas = ?, Vertimas = ? WHERE (id = ?) AND (Kalb" +
				"a = ? OR ? IS NULL AND Kalba IS NULL) AND (SrcTekstas = ? OR ? IS NULL AND SrcTe" +
				"kstas IS NULL) AND (Vertimas = ? OR ? IS NULL AND Vertimas IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Kalba", System.Data.OleDb.OleDbType.Integer, 0, "Kalba"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, "SrcTekstas"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, "Vertimas"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterGetText
			// 
			this.oleDbDataAdapterGetText.DeleteCommand = this.oleDbDeleteCommand3;
			this.oleDbDataAdapterGetText.InsertCommand = this.oleDbInsertCommand3;
			this.oleDbDataAdapterGetText.SelectCommand = this.oleDbSelectCommand3;
			this.oleDbDataAdapterGetText.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "Texts", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("Vertimas", "Vertimas"),
																																																					   new System.Data.Common.DataColumnMapping("id", "id"),
																																																					   new System.Data.Common.DataColumnMapping("Kalba", "Kalba"),
																																																					   new System.Data.Common.DataColumnMapping("SrcTekstas", "SrcTekstas")})});
			this.oleDbDataAdapterGetText.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM Texts WHERE (id = ?) AND (Kalba = ? OR ? IS NULL AND Kalba IS NULL) A" +
				"ND (SrcTekstas = ? OR ? IS NULL AND SrcTekstas IS NULL) AND (Vertimas = ? OR ? I" +
				"S NULL AND Vertimas IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO Texts(Vertimas, Kalba, SrcTekstas) VALUES (?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, "Vertimas"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Kalba", System.Data.OleDb.OleDbType.Integer, 0, "Kalba"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, "SrcTekstas"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT Vertimas, id, Kalba, SrcTekstas FROM Texts WHERE (Kalba = ?) AND (SrcTekst" +
				"as = ?)";
			this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Kalba", System.Data.OleDb.OleDbType.Integer, 0, "Kalba"));
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, "SrcTekstas"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE Texts SET Vertimas = ?, Kalba = ?, SrcTekstas = ? WHERE (id = ?) AND (Kalb" +
				"a = ? OR ? IS NULL AND Kalba IS NULL) AND (SrcTekstas = ? OR ? IS NULL AND SrcTe" +
				"kstas IS NULL) AND (Vertimas = ? OR ? IS NULL AND Vertimas IS NULL)";
			this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, "Vertimas"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Kalba", System.Data.OleDb.OleDbType.Integer, 0, "Kalba"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, "SrcTekstas"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Kalba1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Kalba", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SrcTekstas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SrcTekstas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Vertimas1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Vertimas", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapterConfig
			// 
			this.oleDbDataAdapterConfig.DeleteCommand = this.oleDbDeleteCommand4;
			this.oleDbDataAdapterConfig.InsertCommand = this.oleDbInsertCommand4;
			this.oleDbDataAdapterConfig.SelectCommand = this.oleDbSelectCommand4;
			this.oleDbDataAdapterConfig.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "ActiveLanguage", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("ActiveLanguage", "ActiveLanguage"),
																																																							   new System.Data.Common.DataColumnMapping("id", "id")})});
			this.oleDbDataAdapterConfig.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT ActiveLanguage, id FROM ActiveLanguage";
			this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO ActiveLanguage(ActiveLanguage) VALUES (?)";
			this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActiveLanguage", System.Data.OleDb.OleDbType.Integer, 0, "ActiveLanguage"));
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE ActiveLanguage SET ActiveLanguage = ? WHERE (id = ?) AND (ActiveLanguage =" +
				" ? OR ? IS NULL AND ActiveLanguage IS NULL)";
			this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ActiveLanguage", System.Data.OleDb.OleDbType.Integer, 0, "ActiveLanguage"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActiveLanguage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActiveLanguage", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActiveLanguage1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActiveLanguage", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM ActiveLanguage WHERE (id = ?) AND (ActiveLanguage = ? OR ? IS NULL AN" +
				"D ActiveLanguage IS NULL)";
			this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActiveLanguage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActiveLanguage", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ActiveLanguage1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ActiveLanguage", System.Data.DataRowVersion.Original, null));

		}

		private System.Data.OleDb.OleDbConnection oleDbConnection1;

		#endregion

		internal void OnLanguageChanged(EventArgs e)
		{
			if (null != LanguageChanged)
			{
				LanguageChanged(null, e);
			}
		}

		public Language[] Languages
		{
			get
			{
//				try
//				{
//					DataSetLanguage ds = new DataSetLanguage();
//					this.oleDbDataAdapterLanguages.Fill(ds.Languages);
//
//					Language[] lngs = new Language[ds.Languages.Rows.Count];
//					int i = 0;
//				
//					foreach (DataSetLanguage.LanguagesRow dr in ds.Languages.Rows)
//					{
//						lngs[i] = new Language(dr.id, dr.Name);
//						i++;
//					}
//
//					return lngs;
//				}
//				catch (Exception ex)
//				{
//					Logger.LogException(ex);
					this.hasLanguages = false;
					this.readOnly = true;
					return new Language[] { new Language(9, "English") };
//				}
			}
		}

		public Language Language
		{
			get
			{
				return this.language;
			}
			set
			{
				this.language = value;

				if (null != this.language)
				{
					DisksDB.Config.Config.Instance.SetValue(languageConfigTag, "" + this.language.Id);
				}

				OnLanguageChanged(EventArgs.Empty);
			}
		}

		internal DataSetLanguage GetData()
		{
			DataSetLanguage ds = new DataSetLanguage();

			try
			{
				this.oleDbDataAdapterLanguages.Fill(ds.Languages);
				this.oleDbDataAdapterTexts.Fill(ds.Texts);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				this.hasLanguages = false;
			}

			return ds;
		}

		internal void UpdateData(DataSetLanguage ds)
		{
			if (true == this.readOnly)
			{
				return;
			}

			try
			{
				this.oleDbDataAdapterTexts.Update(ds.Texts);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				this.readOnly = true;
			}
		}

		public static I18N Instance
		{
			get
			{
				if (null == i18n)
				{
					i18n = new I18N();
				}

				return i18n;
			}
		}

		public DialogResult MessageShow(IWin32Window parent, string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icons)
		{
			return MessageBox.Show(parent, message, caption, buttons, icons);
		}

		private int GetActiveLanguage()
		{
			try
			{
				return DisksDB.Config.Config.Instance.GetValue(languageConfigTag, -1);
			}
			catch (Exception)
			{
				return -1;
			}
		}

		private void UpdateLanguage()
		{
			Language[] lngs = this.Languages;

			if (lngs.Length == 0)
			{
				throw new ApplicationException("No Languages found at all");
			}

			int languageId = GetActiveLanguage();

			if (languageId >= 0)
			{
				foreach (Language l in lngs)
				{
					if (l.Id == languageId)
					{
						Language = l;
						return;
					}
				}

				Language = lngs[0];
			}
			else
			{
				Language = lngs[0];
			}
		}

		public event EventHandler LanguageChanged;
		private Language language = null;
		private bool hasLanguages = false;
		private bool readOnly = true;
		private static I18N i18n = null;
		private static string languageConfigTag = "Language.{125FCD7C-E4C4-4ec5-A043-88D148050DEF}";
	}
}
