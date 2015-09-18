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
using System.ComponentModel;

namespace DisksDB.UserInterface
{
	public class FormPopertiesCategory : FormPropertiesBase
	{
		private IContainer components = null;
		private DisksDB.DataBase.Category cat = null;

		public FormPopertiesCategory(DisksDB.DataBase.Category cat) : base()
		{
			this.cat = cat;
			InitializeComponent();
			SetData();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override void SaveChanges()
		{
			if (null != this.cat)
			{
				this.cat.Name = this.textBoxTitle.Text;
				this.cat.Description = this.textBoxDescription.Text;
			}
		}

		private void SetData()
		{
			if (null == this.cat)
			{
				return;
			}

			this.textBoxDescription.Text = this.cat.Description;
			this.textBoxTitle.Text = this.cat.Name;
			this.Text = this.cat.Name + " - Properties";
		}

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// tabControl1
			// 
			this.tabControl1.Name = "tabControl1";
			// 
			// label1
			// 
			this.label1.Name = "label1";
			// 
			// label3
			// 
			this.label3.Name = "label3";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
			// 
			// FormPopertiesCategory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 389);
			this.Name = "FormPopertiesCategory";

		}

		#endregion

		private void textBoxTitle_TextChanged(object sender, EventArgs e)
		{
			SetUpdated();
		}

		private void textBoxDescription_TextChanged(object sender, EventArgs e)
		{
			SetUpdated();
		}
	}
}