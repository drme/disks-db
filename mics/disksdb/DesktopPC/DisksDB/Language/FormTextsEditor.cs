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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DisksDB.Language
{
	class FormTextsEditor : WeifenLuo.WinFormsUI.DockContent
	{
		private System.Windows.Forms.Panel panelBack;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button buttonUpdate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataSet dsTexts = new DataSet();
		private System.Data.DataView dataView;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private DataSetLanguage dsLang = null;

		public FormTextsEditor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelBack = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.dataView = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panelBack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelBack
			// 
			this.panelBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelBack.Controls.Add(this.buttonUpdate);
			this.panelBack.Controls.Add(this.dataGrid1);
			this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBack.Location = new System.Drawing.Point(0, 0);
			this.panelBack.Name = "panelBack";
			this.panelBack.Size = new System.Drawing.Size(688, 445);
			this.panelBack.TabIndex = 0;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(672, 400);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpdate.Location = new System.Drawing.Point(605, 415);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.TabIndex = 1;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// dataView
			// 
			this.dataView.AllowDelete = false;
			this.dataView.AllowNew = false;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Source Text";
			this.dataGridTextBoxColumn1.MappingName = "SrcText";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// FormTextsEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 445);
			this.Controls.Add(this.panelBack);
			this.Name = "FormTextsEditor";
			this.Text = "Texts";
			this.Load += new System.EventHandler(this.FormTextsEditor_Load);
			this.panelBack.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void AddText(int lang, string src, string dst)
		{
			if (false == this.dsTexts.Tables[0].Columns.Contains("L" + lang))
			{
				this.dsTexts.Tables[0].Columns.Add("L" + lang, typeof(string));
			}

			DataRow[] drs = this.dsTexts.Tables[0].Select("SrcText = '" + src + "'");

			if (drs.Length > 0)
			{
				drs[0]["L" + lang] = dst;
			}
			else
			{
				DataRow dr = this.dsTexts.Tables[0].NewRow();
				dr["SrcText"] = src;
				dr["L" + lang] = dst;
				this.dsTexts.Tables[0].Rows.Add(dr);
			}
		}

		private void FormTextsEditor_Load(object sender, System.EventArgs e)
		{
			this.dsLang = I18N.Instance.GetData();

			DataTable dt = new DataTable();
			this.dsTexts.Tables.Add(dt);

			dt.Columns.Add("SrcText", typeof(string));

			foreach (DataSetLanguage.LanguagesRow dr1 in this.dsLang.Languages.Rows)
			{
				if (false == this.dsTexts.Tables[0].Columns.Contains("L" + dr1.id))
				{
					this.dsTexts.Tables[0].Columns.Add("L" + dr1.id, typeof(string));
				}
			}

			foreach (DataSetLanguage.TextsRow dr in dsLang.Texts.Rows)
			{
				AddText(dr.Language, dr.SrcText, dr.Translation);
			}

			this.dsTexts.AcceptChanges();

			foreach (DataSetLanguage.LanguagesRow dr1 in this.dsLang.Languages.Rows)
			{
				DataGridTextBoxColumn ds = new DataGridTextBoxColumn();
				ds.MappingName = "L" + dr1.id;
				ds.HeaderText = dr1.Name;

				this.dataGridTableStyle1.GridColumnStyles.Add(ds);
			}

			this.dataGridTableStyle1.MappingName = this.dsTexts.Tables[0].TableName;

			this.dataView.Table = this.dsTexts.Tables[0];
		}

		private void buttonUpdate_Click(object sender, System.EventArgs e)
		{
			foreach (DataRow dr in this.dsTexts.Tables[0].Rows)
			{
				if (dr.RowState == DataRowState.Modified)
				{
					foreach (DataSetLanguage.LanguagesRow drL in this.dsLang.Languages.Rows)
					{
						AddNewText(drL.id, (string)dr["SrcText"], dr.IsNull("L" + drL.id) ? null : (string)dr["L" + drL.id]);
					}
				}
			}

			I18N.Instance.UpdateData(this.dsLang);

			this.Close();

			I18N.Instance.OnLanguageChanged(EventArgs.Empty);
		}

		private void AddNewText(int lng, string src, string s1)
		{
			if (null == s1)
			{
				return;
			}

			DataRow[] drs = this.dsLang.Texts.Select("SrcText = '" + src + "' AND Language = '" + lng + "'");

			if (drs.Length > 0)
			{
				DataSetLanguage.TextsRow dr = (DataSetLanguage.TextsRow)drs[0];

				if (dr.IsTranslationNull())
				{
					dr.Translation = s1;
				}
				else
				{
					if (false == s1.Equals(dr.Translation))
					{
						dr.Translation = s1;
					}
				}
			} 
			else
			{
				DataSetLanguage.TextsRow dr = this.dsLang.Texts.NewTextsRow();
				dr.Language = lng;
				dr.SrcText = src;
				dr.Translation = s1;
				this.dsLang.Texts.AddTextsRow(dr);
			}
		}
	}
}
