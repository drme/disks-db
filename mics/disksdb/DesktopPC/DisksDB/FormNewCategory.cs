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
using System.ComponentModel;
using System.Windows.Forms;
using DisksDB.Utils;
using System;

namespace DisksDB.UserInterface
{
	class FormNewCategory : FormWizardBase
	{
		private TabPage tabPage1;
		private TextBox textBoxName;
		private Label label1;
		private TextBox textBoxDescription;
		private Label label2;
		private IContainer components = null;

		public FormNewCategory()
		{
			InitializeComponent();

			try
			{
				this.Icon = FileIcons.GetFolderIcon(null, true);
				this.pictureBox1.Image = new System.Drawing.Bitmap(MyResources.GetStream("wellcomeImage.png"));
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
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

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.pagesPanel.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Name = "pictureBox1";
			// 
			// pagesPanel
			// 
			this.pagesPanel.Controls.Add(this.tabPage1);
			this.pagesPanel.Name = "pagesPanel";
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.textBoxDescription);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBoxName);
			this.tabPage1.Location = new System.Drawing.Point(4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(332, 303);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(312, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Description";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(8, 72);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(312, 224);
			this.textBoxDescription.TabIndex = 1;
			this.textBoxDescription.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Category name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(8, 24);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(312, 20);
			this.textBoxName.TabIndex = 0;
			this.textBoxName.Text = "";
			// 
			// FormNewCategory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(494, 350);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormNewCategory";
			this.Text = "New Category";
			this.pagesPanel.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public string CategoryName
		{
			get
			{
				return this.textBoxName.Text;
			}
			set
			{
				System.Diagnostics.Debug.Assert(null != value);
				this.textBoxName.Text = value;
			}
		}

		public string CategoryDescription
		{
			get
			{
				return this.textBoxDescription.Text;
			}
			set
			{
				System.Diagnostics.Debug.Assert(null != value);
				this.textBoxDescription.Text = value;
			}
		}
	}
}