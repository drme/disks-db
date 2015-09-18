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
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	public class FormPropertiesDisk : FormPropertiesBase
	{
		private IContainer components = null;
		private TabPage tabPage2;
		private Label label2;
		private ComboBox comboBox1;
		private ControlImagePanel imagePanel1;
		private DisksDB.DataBase.Disk disk = null;

		public FormPropertiesDisk(DisksDB.DataBase.Disk disk, DisksDB.DataBase.DataBase db)
		{
			InitializeComponent();
			this.disk = disk;
			this.textBoxTitle.Text = disk.Name;
			this.textBoxDescription.Text = "";
			this.textBoxDescription.Enabled = false;
			this.imagePanel1.ImgFact = db.DiskImages;

			foreach (DiskType o in db.DiskTypes)
			{
				this.comboBox1.Items.Add(o);
				if (o.Id == disk.Type.Id)
				{
					this.comboBox1.SelectedItem = o;
				}
			}

			this.imagePanel1.ShowImage(disk.Image);
			this.Text = disk.Name + " - Properties";
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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.imagePanel1 = new DisksDB.UserInterface.ControlImagePanel();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
			this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Controls.SetChildIndex(this.label2, 0);
			this.tabPage1.Controls.SetChildIndex(this.comboBox1, 0);
			this.tabPage1.Controls.SetChildIndex(this.label1, 0);
			this.tabPage1.Controls.SetChildIndex(this.textBoxTitle, 0);
			this.tabPage1.Controls.SetChildIndex(this.label3, 0);
			this.tabPage1.Controls.SetChildIndex(this.textBoxDescription, 0);
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
			this.textBoxDescription.Size = new System.Drawing.Size(280, 216);
			this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.imagePanel1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(296, 318);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Image";
			// 
			// imagePanel1
			// 
			this.imagePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePanel1.Location = new System.Drawing.Point(0, 0);
			this.imagePanel1.Name = "imagePanel1";
			this.imagePanel1.ReadOnly = false;
			this.imagePanel1.Size = new System.Drawing.Size(296, 318);
			this.imagePanel1.TabIndex = 0;
			this.imagePanel1.Changed += new DisksDB.UserInterface.ControlImagePanel.ChangeHandler(this.imagePanel1_Changed);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 292);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Type";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(64, 288);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(224, 21);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// FormPropertiesDisk
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 389);
			this.Name = "FormPropertiesDisk";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetUpdated();
		}

		private void imagePanel1_Changed(object sender, EventArgs e)
		{
			SetUpdated();
		}

		protected override void SaveChanges()
		{
			this.disk.Name = this.textBoxTitle.Text;
			this.disk.Type = (DiskType) this.comboBox1.SelectedItem;
			this.disk.Image = this.imagePanel1.SelectedImage;
		}

		private void textBoxTitle_TextChanged(object sender, System.EventArgs e)
		{
			SetUpdated();
		}

		private void textBoxDescription_TextChanged(object sender, System.EventArgs e)
		{
			SetUpdated();
		}
	}
}