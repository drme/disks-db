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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DisksDB.DataBase;
using Image = DisksDB.DataBase.Image;

namespace DisksDB.UserInterface
{
	class FormPropertiesImage : FormPropertiesBase
	{
		private TabPage tabPage2;
		private Button button1;
		private CheckBox checkBox1;
		private Panel panel1;
		private PictureBox pictureBox1;
		private IContainer components = null;
		private ImageFactory fact = null;
		private Image SelectedImage = null;
		private string fileName = null;
		private System.Windows.Forms.Button buttonCleanUp;
		private bool updated = false;

		public FormPropertiesImage(ImageFactory fact, Image selectedImage)
		{
			this.fact = fact;
			this.SelectedImage = selectedImage;
			InitializeComponent();

			if (null != selectedImage)
			{
				this.textBoxTitle.Text = selectedImage.Name;
				this.textBoxDescription.Text = "";
				this.pictureBox1.Image = selectedImage.Picture;
				this.Text = selectedImage.Name + " Properties";
				ResizeImage();
			}
			else
			{
				this.textBoxTitle.Text = "";
				this.textBoxDescription.Text = "";
				this.Text = "New Image";
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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonCleanUp = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
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
			this.tabPage1.Controls.Add(this.buttonCleanUp);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Controls.SetChildIndex(this.buttonCleanUp, 0);
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
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Name = "textBoxTitle";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel1);
			this.tabPage2.Controls.Add(this.checkBox1);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(296, 318);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Image";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 272);
			this.panel1.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(264, 256);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(8, 288);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(200, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Stretch";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(216, 288);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Browse...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonCleanUp
			// 
			this.buttonCleanUp.Location = new System.Drawing.Point(216, 288);
			this.buttonCleanUp.Name = "buttonCleanUp";
			this.buttonCleanUp.TabIndex = 6;
			this.buttonCleanUp.Text = "Clean Up";
			this.buttonCleanUp.Click += new System.EventHandler(this.buttonCleanUp_Click);
			// 
			// FormPropertiesImage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 389);
			this.Name = "FormPropertiesImage";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				this.fileName = openFileDialog1.FileName;

				Bitmap bmp = new Bitmap(openFileDialog1.FileName);

				this.pictureBox1.Image = null;
				this.pictureBox1.Image = bmp;
				this.pictureBox1.Update();

				ResizeImage();

				this.SetUpdated();
			}
		}

		private void ResizeImage()
		{
			System.Drawing.Image img = this.pictureBox1.Image;

			if (null != img)
			{
				if (true == this.checkBox1.Checked)
				{
					this.pictureBox1.Width = this.panel1.Width;
					this.pictureBox1.Height = this.panel1.Height;
					this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				}
				else
				{
					this.pictureBox1.Width = img.Width;
					this.pictureBox1.Height = img.Height;
					this.pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
				}
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			ResizeImage();
		}

		protected override void SaveChanges()
		{
			if (null != this.SelectedImage)
			{
				this.SelectedImage.Name = this.textBoxTitle.Text;

				if (null != this.fileName)
				{
					this.SelectedImage.FileName = this.fileName;
				}

				this.updated = true;
			}
			else
			{
				try
				{
					this.SelectedImage = this.fact.AddImage(this.textBoxTitle.Text, this.fileName, null);
					this.updated = true;
				}
				catch (Exception)
				{
					MessageBox.Show(this, "Please specify image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonCleanUp_Click(object sender, System.EventArgs e)
		{
			this.textBoxTitle.Text = Utils.CleanUpName(this.textBoxTitle.Text);
			this.SetUpdated();
		}

		public bool Updated
		{
			get
			{
				return this.updated;
			}
		}
	}
}