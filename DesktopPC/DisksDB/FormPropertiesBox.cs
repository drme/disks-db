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
using System.ComponentModel;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	public class FormPropertiesBox : FormPropertiesBase
	{
		private Label label2;
		private ComboBox comboBoxType;
		private IContainer components = null;
		private ComboBox comboBox1;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private TabPage tabPage4;
		private DisksDB.DataBase.DataBase db = null;
		private ComboBox comboBox2;
		private ComboBox comboBox3;
		private Label label4;
		private ControlImagePanel imagePanelFront;
		private ControlImagePanel imagePanelBack;
		private ControlImagePanel imagePanelInlay;
		private DataBase.Box box = null;

		public FormPropertiesBox(DisksDB.DataBase.DataBase db, DataBase.Box box)
		{
			this.db = db;
			this.box = box;

			InitializeComponent();

			this.textBoxTitle.Text = this.box.Name;
			this.textBoxDescription.Text = this.box.Description;

			foreach (Object o in db.BoxTypes)
			{
				this.comboBox3.Items.Add(o);
			}

			for (int i = 0; i < this.comboBox3.Items.Count; i++)
			{
				if (((BoxType) this.comboBox3.Items[i]).Id == box.Type.Id)
				{
					this.comboBox3.SelectedIndex = i;
				}
			}

			this.imagePanelFront.ImgFact = db.FrontImages;
			this.imagePanelBack.ImgFact = db.BackImages;
			this.imagePanelInlay.ImgFact = db.InlayImages;
			this.imagePanelBack.ShowImage(box.BackCover);
			this.imagePanelFront.ShowImage(box.FrontCover);
			this.imagePanelInlay.ShowImage(box.InlayCover);

			ArrayList lst = this.db.BoxTypes;
			this.comboBox1.DataSource = lst;
			this.Text = box.Name + " - Properties";
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
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.imagePanelFront = new DisksDB.UserInterface.ControlImagePanel();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.imagePanelBack = new DisksDB.UserInterface.ControlImagePanel();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.imagePanelInlay = new DisksDB.UserInterface.ControlImagePanel();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
			this.tabControl1.Controls.SetChildIndex(this.tabPage4, 0);
			this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
			this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.comboBox3);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Controls.SetChildIndex(this.comboBox3, 0);
			this.tabPage1.Controls.SetChildIndex(this.label4, 0);
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
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Type";
			// 
			// comboBoxType
			// 
			this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxType.Location = new System.Drawing.Point(48, 288);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(240, 21);
			this.comboBoxType.TabIndex = 7;
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(48, 288);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(240, 21);
			this.comboBox1.TabIndex = 6;
			this.comboBox1.Text = "comboBox1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.imagePanelFront);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(296, 318);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Front";
			// 
			// imagePanelFront
			// 
			this.imagePanelFront.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePanelFront.Location = new System.Drawing.Point(0, 0);
			this.imagePanelFront.Name = "imagePanelFront";
			this.imagePanelFront.ReadOnly = false;
			this.imagePanelFront.Size = new System.Drawing.Size(296, 318);
			this.imagePanelFront.TabIndex = 0;
			this.imagePanelFront.Changed += new DisksDB.UserInterface.ControlImagePanel.ChangeHandler(this.imagePanelFront_Changed);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.imagePanelBack);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(296, 318);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Back";
			// 
			// imagePanelBack
			// 
			this.imagePanelBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePanelBack.Location = new System.Drawing.Point(0, 0);
			this.imagePanelBack.Name = "imagePanelBack";
			this.imagePanelBack.ReadOnly = false;
			this.imagePanelBack.Size = new System.Drawing.Size(296, 318);
			this.imagePanelBack.TabIndex = 0;
			this.imagePanelBack.Changed += new DisksDB.UserInterface.ControlImagePanel.ChangeHandler(this.imagePanelBack_Changed);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.imagePanelInlay);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(296, 318);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Inlay";
			// 
			// imagePanelInlay
			// 
			this.imagePanelInlay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePanelInlay.Location = new System.Drawing.Point(0, 0);
			this.imagePanelInlay.Name = "imagePanelInlay";
			this.imagePanelInlay.ReadOnly = false;
			this.imagePanelInlay.Size = new System.Drawing.Size(296, 318);
			this.imagePanelInlay.TabIndex = 0;
			this.imagePanelInlay.Changed += new DisksDB.UserInterface.ControlImagePanel.ChangeHandler(this.imagePanelInlay_Changed);
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(80, 288);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(208, 21);
			this.comboBox2.TabIndex = 6;
			this.comboBox2.Text = "comboBox2";
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Location = new System.Drawing.Point(72, 288);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(216, 21);
			this.comboBox3.TabIndex = 6;
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 292);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Type";
			// 
			// FormPropertiesBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 389);
			this.Name = "FormPropertiesBox";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		protected override void SaveChanges()
		{
			if (null != box)
			{
				box.Name = this.textBoxTitle.Text;
				box.Description = this.textBoxDescription.Text;
				box.Type = (BoxType) this.comboBox3.SelectedItem;
				box.FrontCover = this.imagePanelFront.SelectedImage;
				box.BackCover = this.imagePanelBack.SelectedImage;
				box.InlayCover = this.imagePanelInlay.SelectedImage;
			}
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.loaded)
			{
				this.SetUpdated();
			}
		}

		private void imagePanelFront_Changed(object sender, EventArgs e)
		{
			if (this.loaded)
			{
				this.SetUpdated();
			}
		}

		private void imagePanelBack_Changed(object sender, EventArgs e)
		{
			if (this.loaded)
			{
				this.SetUpdated();
			}
		}

		private void imagePanelInlay_Changed(object sender, EventArgs e)
		{
			if (this.loaded)
			{
				this.SetUpdated();
			}
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